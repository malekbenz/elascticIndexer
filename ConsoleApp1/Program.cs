using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConsoleApp1.Model;
using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Persone
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public IEnumerable<Metier> metiers { get; set; }
    }

    static class Extention
    {
        public static void ForEach(this string[] list, Action<string> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }

    }

    class Program
    {

        static ElasticLowLevelClient ElasticClient;


        static void indexerDemandeurs()
        {

            using (var db = new anemContext())
            {
                var demandeurs = db.Demandeurs
                        .ProjectTo<VmDemandeur>()
                        .OrderBy(x => x.Id)
                        .Skip(200000)
                        .Take(1000)
                        .ToList();

                int i = 0;
                foreach (var demandeur in demandeurs)
                {
                    i++;
                    Console.WriteLine($"Id : {demandeur.Id} nom : {demandeur.Nom} ");
                    var IndexResponse = ElasticClient.
                                            Index<string>("demandeurs", "demandeur", demandeur.Id, demandeur);
                    //Stream responseString = IndexResponse.Body;
                    if (i % 20 == 0)
                    {
                        Console.WriteLine($"ordre : {i} Status : {IndexResponse.HttpStatusCode} ");
                    }
                }
            }
        }

        static void indexerPeople()
        {
            var people = new List<Persone>();
            people.Add(new Persone()
            {
                id = 10,
                nom = "Benzemam",
                prenom = "Malek",
                metiers = new List<Metier>() {
                    new Metier() { value = "Conseiller a l'Emploi " },
                    new Metier() { value = "TS en informatique " },
                }
            });

            foreach (var person in people)
            {

                var IndexResponse = ElasticClient.
                                        Index<string>("people", "person", person.id.ToString(), person);
                //Stream responseString = IndexResponse.Body;
                Console.WriteLine($"ordre :  Status : {IndexResponse.HttpStatusCode} ");
            }

        }

        static void show(string x)
        {

            Console.WriteLine(x);
        }
        static Task longRunningTask()
        {
            return Task.Run(() => {
                Thread.Sleep(5000);
            });
        }

        static async Task callProcess()
        {
            await longRunningTask();
            Console.WriteLine("Long running task terminate");
        }

        static void Main(string[] args)
        {

            
            Console.WriteLine("The Main Methode ");
            //Console.Read();

            Mapper.Initialize(cfg =>
                cfg.CreateMap<Demandeurs, VmDemandeur>()
                    .ForMember(dest => dest.Gendre, opt => opt.MapFrom(src => src.Gendre))
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DemandeurId.ToString()))
                    .ForMember(dest => dest.Nom, opt => opt.MapFrom(src => src.NomFr.ToString()))
                    .ForMember(dest => dest.Prenom, opt => opt.MapFrom(src => src.PrenomFr.ToString()))
                    .ForMember(dest => dest.Adresse, opt => opt.MapFrom(src => src.AdresseFr.ToString())));


            //);
            var settings = new ConnectionConfiguration(new Uri("http://localhost:9200"))
                        .RequestTimeout(TimeSpan.FromMinutes(2))
                        .BasicAuthentication("elastic", "changeme");

            ElasticClient = new ElasticLowLevelClient(settings);


            indexerDemandeurs();

            //indexerPeople();

        }
    }

}
