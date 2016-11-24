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
using System.Text.RegularExpressions;

namespace ConsoleApplication2
{       

    class ANARTISI
    {
        public string keimeno;
        public DateTime date;



    }
    class  token
    {
        public string AccessToken="";
        public string AccessTokenSec="";
    }
    

    class Program
    {

       
        static void Main(string[] args)
        {
            
            string[] stringSeparator = new string[] { " " };
            string[] result;

            int metritis;
            int choise = 1;
            string date1;
            string message = "stack overflow";
            int Etos;
            int minas;
            int mera;
            int ora;
            int lepto;
            int deuterolepto;
            string AccessToken = "";
            string AccessTokenSec = "";
            Console.WriteLine("1.Nea Anartisi 2.Anagnosi anartiseon 3.<NEO TWEET> 4.exodos");
            
            choise = Convert.ToInt32(Console.ReadLine());
            while (choise != 4)
            {
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
                    deuterolepto = 0;

                    anartisi1.date = new DateTime(Etos, minas, mera, ora, lepto, deuterolepto);

                    //anoigoume ena arxeio ean den yparxei i grafoume kainourgies plirofories se 
                    //ena yparxon gia tis anartiseis kai pote tha ginoun
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


                    //diavazoume oles tis anartiseis mexris stigmis...na prostheso diagrafi...


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
                //Epilogi gia apeuthias tweet.Dinoume credentials tis efarmogis



                else if (choise == 3)
                {

                    string path1 = @"c:\Workplace\MyTest5";  //elenhoume ean exoume xanasindethei gia na min xreiasti
                    if (!File.Exists(path1))                 //na xanaeisxorismoume captcha
                    {
                        using (StreamWriter sw = File.CreateText(path1))
                        {
                            sw.WriteLine("True");
                            metritis = 0;
                        }
                    }
                    else
                    {
                        metritis = 1;
                    }


                    if (metritis == 0)
                    {
                        Console.WriteLine("Parakalo sindethite sto Twiter");

                        var appCredentials = new TwitterCredentials("0rbIj70OY04gB6nbMuXaCArGl", "8sBsmmv6UbLBv3OjnPRDSwiopDlezfcAoxuFKRLyiqDxZ1wrt5");


                        var authenticationContext = AuthFlow.InitAuthentication(appCredentials);

                        Process.Start(authenticationContext.AuthorizationURL);

                        //ean den eixame xanasindethei eisxoroume gia proti fora captchad
                        Console.WriteLine("Θα σας δοθει ενας κωδικος, πληκτρολογηστε εδω");
                        var pinCode = Console.ReadLine();



                        var userCredentials = AuthFlow.CreateCredentialsFromVerifierCode(pinCode, authenticationContext);

                        Console.WriteLine("{0}", userCredentials);
                        string path2 = @"c:\Workplace\MyTest4";
                        if (!File.Exists(path2))
                        {
                            using (StreamWriter sw = File.CreateText(path2))
                            {
                                sw.WriteLine("{0} {1}", userCredentials.AccessToken, userCredentials.AccessTokenSecret);
                            }
                        }
                        else
                        {
                            //apothikeuoyme ta stoixeia se ena arxeio
                            File.WriteAllText(path2, string.Empty);
                            File.AppendAllText(path2, userCredentials.AccessToken);
                            File.AppendAllText(path2, " ");
                            File.AppendAllText(path2, userCredentials.AccessTokenSecret);

                        }
                        Auth.SetCredentials(userCredentials);


                        Console.WriteLine("{0}", userCredentials.AccessToken);
                        Console.WriteLine("{0}", userCredentials.AccessTokenSecret);

                        var firstTweet = Tweet.PublishTweet("Hello World!");

                    }//Ean exoume xanasindethei anevazoume apeutheias to tweet
                    else if (metritis == 1)
                    {
                        try
                        {
                            string path2 = @"c:\Workplace\MyTest4";

                            string ApothikeumenaCredentials;


                            using (StreamReader sr = new StreamReader(path2))
                            {

                                // Read the stream to a string, and write the string to the console.
                                String line = sr.ReadToEnd();
                                Console.WriteLine(line);


                                Char charRange = ' ';
                                Console.WriteLine(line);
                                int startIndex = line.IndexOf(charRange);
                                int endIndex = line.LastIndexOf(charRange);
                                char separatingChars = ' ';
                                string[] words = line.Split(separatingChars);
                                Console.WriteLine("{0} substrings in text:", words.Length);
                                int i;
                                for (i = 0; i < 2; i++)
                                {
                                    if (i == 0)
                                    {
                                        AccessToken = words[i];
                                    }
                                    else if (i == 1)
                                    {
                                        AccessTokenSec = words[i];
                                    }

                                }

                                AccessToken = AccessToken.Replace("\n", "");
                                AccessTokenSec = AccessTokenSec.Replace("\n", "");

                                AccessToken = AccessToken.Replace("\t", "");
                                AccessTokenSec = AccessTokenSec.Replace("\t", "");

                                AccessToken = AccessToken.Replace(" ", "");
                                AccessTokenSec = AccessTokenSec.Replace("\r", "");
                                AccessTokenSec = AccessTokenSec.Replace(" ", "");
                            }

                        }
                        catch (Exception e)
                        {


                            Console.WriteLine("The file could not be read:");
                            Console.WriteLine(e.Message);
                        }

                        Console.WriteLine(AccessToken);
                        Console.WriteLine(AccessTokenSec);



                        // anoigoume to arxeio gia ta credentials ean eixame xanasindethei


                        var creds = new TwitterCredentials("0rbIj70OY04gB6nbMuXaCArGl", "8sBsmmv6UbLBv3OjnPRDSwiopDlezfcAoxuFKRLyiqDxZ1wrt5", AccessToken.Trim(), AccessTokenSec.Trim());
                        Auth.SetCredentials(creds);
                        var first = Tweet.PublishTweet("enadiotriatessera");



                    }

                                   
                        
                }
                     choise = Convert.ToInt32(Console.ReadLine());
            } 
            Console.ReadKey();

                }


            }
        }
    
