using AutoMapper;
using AutoMapper.QueryableExtensions;
using Elasticsearch.Net;
using RedIndexer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RedIndexer
{
    class Program
    {

        static void Main(string[] args)
        {

            var indexer = new Indexer();
            indexer.Log += Log;
            indexer.IndexerDemandeurs();


        }

        private static void Log(object Sender , LogEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
