using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            DateTime date1;
            int Etos;
            int minas;
            int mera;
            int ora;
            int lepto;
            int deuterolepto;
            
                Console.WriteLine("1.Nea Anartisi 2.Anagnosi anartiseon 3.Exodos");
                choise = Console.Read();
                ANARTISI anartisi1 = new ANARTISI() ;
                
                    Console.WriteLine("Keimeno anartisis");
                    anartisi1.keimeno = Console.ReadLine();

                    Console.WriteLine("Etos");
                    Etos = Console.Read();

                    Console.WriteLine("Minas");
                    minas = Console.Read();

                    Console.WriteLine("mera:");
                    mera = Console.Read();

                    Console.WriteLine("ora:");
                    ora = Console.Read();

                    Console.WriteLine("lepto");
                    lepto = Console.Read();

                    Console.WriteLine("deuterolepto");
                    deuterolepto = Console.Read();

                    date1 = new DateTime(Etos, minas, mera, ora, lepto, deuterolepto);
                    anartisi1.date = date1;

                    string path = @"c:\Workplace\Mytest";
                    if (!File.Exists(path))
                    {
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("Anartisi: /n");
                            sw.WriteLine("{0}", anartisi1.keimeno);
                            sw.WriteLine("Hmerominia: /n");
                            sw.WriteLine("{0}", anartisi1.date.ToString());
                        }
                    }
               
            
            Console.ReadKey();
        }
        
    }
}
