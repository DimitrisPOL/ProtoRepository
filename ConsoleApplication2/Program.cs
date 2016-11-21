using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using Tweetinvi.Streaming;
using Stream = Tweetinvi.Stream;
using System.IO;
using System.Diagnostics;
using Tweetinvi.Exceptions; // Handle Exceptions
using Tweetinvi.Core.Extensions; // Extension methods provided by Tweetinvi
using Tweetinvi.Models.DTO; // Data Transfer Objects for Serialization
using Tweetinvi.Json; // JSON static classes to get json from Twitter.
using Tweetinvi.Models.Entities;

namespace ConsoleApplication2
{
   
    class ANARTISI 
    {
      public string keimeno;
      public DateTime date;
         
        

    }
   
    class Program
    {
        
        static void Main(string[] args)
        {
           

            int choise = 1;
            string date1;
            string message="stack overflow";
            int Etos;
            int minas;
            int mera;
            int ora;
            int lepto;
            int deuterolepto;
            
                Console.WriteLine("1.Nea Anartisi 2.Anagnosi anartiseon 3.<NEO TWEET> 4.exodos");
                choise = Convert.ToInt32(Console.ReadLine());
            if (choise == 1)
            {
                ANARTISI anartisi1 = new ANARTISI();

                Console.WriteLine("Keimeno anartisis");

                try
                {
                    anartisi1.keimeno = Console.ReadLine();
                }
                catch (StackOverflowException)
                {
                    Console.WriteLine(message);
                }
                if (anartisi1.keimeno.Length > 140)
                {
                    anartisi1.keimeno = anartisi1.keimeno.Substring(0, 140);
                }
                Console.WriteLine("Etos");
                Etos = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Minas");
                minas = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("mera:");
                mera = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("ora:");
                ora = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("lepto");
                lepto = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("deuterolepto");
                deuterolepto = Convert.ToInt32(Console.ReadLine());

                anartisi1.date = new DateTime(Etos, minas, mera, ora, lepto, deuterolepto);

                string path = @"c:\Workplace\MyTest3";
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("Anartisi: ");
                        sw.WriteLine("{0}", anartisi1.keimeno);
                        sw.WriteLine("Hmerominia: ");
                        sw.WriteLine("{0}", anartisi1.date.ToString());
                    }
                }
                else
                {
                    File.AppendAllText(path, "Anartisi:\n ");
                    File.AppendAllText(path, anartisi1.keimeno);
                    File.AppendAllText(path, "Date:\n ");
                    File.AppendAllText(path, anartisi1.date.ToString());
                }
                date1 = anartisi1.date.ToString();
                Console.WriteLine("Anartisi: {0}", anartisi1.keimeno);
                Console.WriteLine("Hmerominia: {0}", date1);



            }
            else if (choise == 2)
            {




                try
                {
                    string path = @"c:\Workplace\MyTest3";
                    using (StreamReader sr = new StreamReader(path))
                    {

                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
            else if (choise==3)
            {

                Console.WriteLine("Parakalo sindethite sto Twiter");
            
                var appCredentials = new TwitterCredentials("0rbIj70OY04gB6nbMuXaCArGl", "8sBsmmv6UbLBv3OjnPRDSwiopDlezfcAoxuFKRLyiqDxZ1wrt5");

               
                var authenticationContext = AuthFlow.InitAuthentication(appCredentials);
                
                Process.Start(authenticationContext.AuthorizationURL);

               
                Console.WriteLine("Θα σας δοθει ενας κωδικος, πληκτρολογηστε εδω");
                var pinCode = Console.ReadLine();

                
                var userCredentials = AuthFlow.CreateCredentialsFromVerifierCode(pinCode, authenticationContext);

                
                Auth.SetCredentials(userCredentials);

                var firstTweet = Tweet.PublishTweet("Hello World!");
            }
            Console.ReadKey();
        }
        
    }
}
