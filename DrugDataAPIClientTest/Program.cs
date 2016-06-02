using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;
using DrugLibAPI;
using System.Threading;

[assembly: OwinStartup(typeof(DrugDataAPIClientTest.Program))]


namespace DrugDataAPIClientTest
{
    class Program
    {
        public string SessionId { get; } = Guid.NewGuid().ToString();

        static Program()
        {
            
        }

        static bool finished;
        static void Main(string[] args)
        {
            Run();

            do
            {
                Thread.Sleep(500);
            } while (!finished);

            Console.ReadLine();
        }

        public static async Task Run()
        {/*
            var allConcepts = await DrugApiClient.GetAllRxConcepts();
            foreach (var x in allConcepts)
            {
                Console.WriteLine($"Concept:\t{x.FullName}; RxCUI: {x.RxCUI}; Type: {x.TermType}\n");
            };
            Console.WriteLine($"Found {allConcepts.Length} concepts.");

            */

            var allDrugs = await DrugApiClient.GetAllNDCRecords();

            finished = true;
        }

        void Configure(IAppBuilder app)
        {
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
        
    }
}
