using System;
using System.Data;
using System.Threading;
using System.Xml;

namespace Cms20_Exception
{

    public class Person
    {


        private string _name;

        public void SetName(string name)
        {
            if (name.Length < 2)
            {
                throw new ArgumentException("Name must be at least 2 chars");
            }
            _name = name;
        }

        //ENSURE VALID STATE = Constructorparametrar
        public Person(string name)
        {
           SetName(name);
            _name = name;
        }


        public string Address { get; set; }
        //public string City;
        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                if(value.Length == 0)
                    throw new ArgumentException("ej tom");
                _city = value;
            }
        }
    }

    class Program
    {
        static void Test()
        {
            var p2 = new Person("Stefan");
            p2.City = "SASsa";

            while (true)
            {
                try
                {
                    var p = new Person(Console.ReadLine());
                    p.SetName("d");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static decimal AppleCalculcate(decimal antalApples, decimal antalPersoner)
        {
            if (antalPersoner <= 0)
            {
                throw new ArgumentException("Antal personer måste vara större än 0");
            }
            return antalApples / antalPersoner;
       }


        static void Main(string[] args)
        {
            Test();
            while (true)
            {
                Console.WriteLine("Hur många äpplen har ni");
                decimal antal = Convert.ToDecimal(Console.ReadLine());

                decimal perStyck = 0;
                while (true)
                {
                    Console.WriteLine("Hur många är ni");
                    try
                    {
                        decimal antalPersoner = Convert.ToDecimal(Console.ReadLine());
                        perStyck = AppleCalculcate(antal, antalPersoner);
                        break;
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine($"Dummer inte 0 personer");
                    }
                    catch (OutOfMemoryException ex)
                    {
                        Console.WriteLine($"hmm hold on");
                        //clear cache or something
                        //Then retr
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine( $"{ex.Message}");
                    }


                }
                //if (AppleCalculcate(antal, antalPersoner, out perStyck) == true)
                //{

                //}
                //decimal perStyck = AppleCalculcate(antal, antalPersoner);

                Console.WriteLine($"Ni får {perStyck} äpplen var");
            }
        }
    }
}
