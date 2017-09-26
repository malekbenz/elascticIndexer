using Elasticsearch.Net;
using RedIndexer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedIndexer
{
    public class LogEventArgs : EventArgs
    {
        private readonly string message;
        public LogEventArgs(string Message)
        {
            this.message = Message;
        }
        public string Message
        {
            get { return message; }
        }

    }
    public class Indexer
    {
        private ElasticLowLevelClient ElasticClient;


        public event EventHandler<LogEventArgs> Log;

        protected virtual void OnLog(LogEventArgs e)
        {
            if (Log != null)
                Log(this, e);
        }

        public Indexer()
        {
            var uri = Properties.Settings.Default.elasticAdresse;

            Console.WriteLine("Indexing ..." + uri);
            var settings = new ConnectionConfiguration(new Uri(uri))
                        .RequestTimeout(TimeSpan.FromMinutes(2))
                        .BasicAuthentication("elastic", "changeme");

            ElasticClient = new ElasticLowLevelClient(settings);

        }
        public Indexer(ElasticLowLevelClient ElasticClient)
        {
            this.ElasticClient = ElasticClient;

        }

        public void IndexerDemandeurs()
        {
            var take = 5000;
            var Count = 2000000;
            var Start = Properties.Settings.Default.start;

            using (var context = new FNE())
            {
                //var Count = context.Demandeurs.Count();
                
                int Current = Start;
                while (Start <= Count)
                {
                    var demandeurs = context.Demandeurs
                            .Where(d => d.DateDebutContrat.HasValue)
                            .OrderBy(x => x.id)
                            .Skip(Start)
                            .Take(take)
                            .ToList();


                    foreach (var demandeur in demandeurs)
                    {
                        Current++;

                        var IndexResponse = ElasticClient.
                                                Index<string>("demandeurs", "demandeurs", demandeur.id, demandeur);
                        //Stream responseString = IndexResponse.Body;

                        OnLog(new LogEventArgs($" N° : {Current} Status : {IndexResponse.HttpStatusCode} Id : {demandeur.id} Nom : {demandeur.Nom}  {demandeur.Prenom}"));
                    }

                    Start += take;
                }


            }
        }

    }
}
