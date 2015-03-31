using System;
using System.Text.RegularExpressions;
using DomainModel.Model;
using Infrastructure;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            string txt = "NameDate01052014 999999.txt";

            string re1 = ".*?";	// Non-greedy match on filler
            string re2 = "((?:(?:[0-2]?\\d{1})|(?:[3][01]{1}))(?:[0]?[1-9]|[1][012])(?:(?:[1]{1}\\d{1}\\d{1}\\d{1})|(?:[2]{1}\\d{3})))(?![\\d])";	// DDMMYYYY 1

            Regex r = new Regex(re1 + re2, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                String ddmmyyyy1 = m.Groups[1].ToString();
                Console.Write("(" + ddmmyyyy1.ToString() + ")" + "\n");
            }
            Console.ReadLine();



            //var context = new SampleContext();

            //var client = new Client();

            //var clients = context.Clients;
            //clients.Add(client);
            //context.SaveChanges();

            //var asd2 = 1;

            //var blah = new ConnectDirectSdk.Node();

            //Func<string> config = () => "asd";

            //Action<string> some = (c) => Console.WriteLine(config.Invoke()); 
            //Action<string> some2 = (c) => Console.WriteLine(config.Invoke()); 


            //some2.Invoke(null);
            //some.Invoke(null);

            //var internalId = Guid.NewGuid();

            //Console.WriteLine(internalId.ToString("N"));
            //Console.WriteLine(internalId.ToString());

        }
    }
}
