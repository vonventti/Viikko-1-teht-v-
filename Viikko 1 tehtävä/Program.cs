using System;

namespace Viikko_1_tehtävä
{
    class Program
    {
        // Sovellus toteutettu käyttäen luokkaa, listaa sekä metodeja

        static void Main(string[] args)
        {

            Topic.kerääTiedot();
            Topic.kerääTiedot();
            //Topic.kerääTiedot();
            var lista = Topic.Topics;
            foreach (Topic i in lista)
            {
                Console.WriteLine("{0}", i.ID);
                Console.WriteLine("{0}", i.Title);
                Console.WriteLine("{0}", i.Description);
                Console.WriteLine("{0}", i.EstimatedTimeToMaster);
                Console.WriteLine("{0}", i.TimeSpent);
                Console.WriteLine("{0}", i.Source);
                Console.WriteLine("{0}", i.StartDate);
                Console.WriteLine("{0}", i.InProgress);
                if (i.InProgress == false)
                {
                    Console.WriteLine("{0}", i.CompletionDate);
                    Console.WriteLine("The topic lasted: " + (i.CompletionDate - i.StartDate).TotalDays + " days");
                }
            }

            Console.WriteLine("Enter an ID");
            var searchId = Topic.Topics.Find(num => num.ID == Convert.ToInt32(Console.ReadLine()));
            var retrievedId = searchId.ID;
            var retrievedTitle = searchId.Title;
            Console.WriteLine(searchId);
            Console.WriteLine(retrievedTitle);
            //Topic.tulostaTiedot();

            //Topic.teksiTiedosto();
            //Topic.EtsiId();
            //EtsiTitle();
        }
    }

}

