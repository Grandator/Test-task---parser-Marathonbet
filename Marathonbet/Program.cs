using System.Collections.Generic;
using Marathonbet.Models;
using Microsoft.Extensions.DependencyInjection;
using Marathonbet.Services.ParseService;
using Marathonbet.Services.HttpClientFactory;
using System;

namespace Marathonbet
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
               .AddScoped<IHttpClientFactory, HttpClientFactory>()
               .AddTransient<IParseService, ParseService>()
               .BuildServiceProvider();

            List<Match> matches = serviceProvider.GetService<IParseService>().GetMatches().GetAwaiter().GetResult();

            foreach (Match match in matches)
            {
                match.Show();
            }
            while (true)
            {
                Console.WriteLine("Enter Id(int):");
                string input = Console.ReadLine();
                bool boolka = false;
                int inputid;
                bool success = Int32.TryParse(input, out inputid);
                if (success)
                {
                    foreach (Match match in matches)
                    {
                        if (inputid == match.Id)
                        {
                            match.ShowCoefs();
                            boolka = true;
                        }
                        if (boolka == true)
                        {
                            break;
                        }
                    }
                    if (boolka == false)
                    {
                        Console.WriteLine("Match with entered id is not exists");
                    }
                }
                else Console.WriteLine("Invalid data(please enter int data)\n");

            }
        }
    }
}
