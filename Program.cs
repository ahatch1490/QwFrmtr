using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;

namespace QwFrmtr
{
    class Program
    {
        public static int Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);
        
        [Option(ShortName = "p", Description = "json file name") ]
        public string fileName { get; }

        private void OnExecute()
        {
            var formatter = new PropertyFormatter();
            IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            var fromPath = Configuration["fromPath"];
            var toPath = Configuration["toPath"];

            var json = File.OpenText($"{fromPath}{fileName}").ReadToEnd(); 
            // reformat all caps
            var regCap = new Regex("\"[A-Z]*\":");
            var matches = regCap.Matches(json);
            foreach (var match in matches)
            {
               Console.WriteLine(match.ToString());
               var value = formatter.Format(match.ToString());
               Console.WriteLine(value);
               json = json.Replace(match.ToString(), value);
            }
           
            // reformat underscores
            var reg = new Regex(("\"([A-Za-z]*_[A-Za-z]*)*\":"));
            matches = reg.Matches(json);
          
            foreach (var match in matches)
            {
                Console.WriteLine(match.ToString());
                var value = formatter.Format(match.ToString());
                Console.WriteLine(value);
                json = json.Replace(match.ToString(), value);
            }

            File.WriteAllText($"{toPath}{fileName}", json);

        }
    }
}
