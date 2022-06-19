using System.Collections.Generic;

namespace Viikko_1_tehtävä
{
    class Program
    {
        // Sovellus toteutettu käyttäen luokkaa, listaa sekä metodeja

        static void Main(string[] args)
        {
            List<Topic> Topics = new List<Topic>();

            Topic.kerääTiedot();
            //Topic.kerääTiedot();
            ////Topic.kerääTiedot();
            ////var lista = Topic.Topics;
            //Topic.teksiTiedosto();
            Topic.tulostaTiedot();
            //Topic.EtsiIdtaiTopic();
            //Topic.Delete();
            //Topic.tulostaTiedot();
            ////Topic.tulostaTiedot();
            //Topic.Update(lista);
            //Topic.tulostaTiedot();
            //Topic.readFile();
            //Topic.EtsiIdtaiTopic(lista);

            //foreach (Topic i in lista)
            //{
            //    Console.WriteLine("ID: {0}", i.ID);
            //    Console.WriteLine("Title: {0}", i.Title);
            //    Console.WriteLine("Description: {0}", i.Description);
            //    Console.WriteLine("Estimated time to complete: {0}", i.EstimatedTimeToMaster);
            //    Console.WriteLine("Time spent: {0}", i.TimeSpent);
            //    Console.WriteLine("Source: {0}", i.Source);
            //    Console.WriteLine("Start date: {0}", i.StartDate);
            //    Console.WriteLine("Topic in progress: {0}", i.InProgress);
            //    if (i.InProgress == false)
            //    {
            //        Console.WriteLine("Completion date: {0}", i.CompletionDate);
            //        Console.WriteLine("The topic lasted: " + (i.CompletionDate - i.StartDate).TotalDays + " days");
            //    }
            //}

            //Topic.MuutaId(lista);

            //Console.WriteLine("Enter an ID");
            //var searchId = Topic.Topics.Find(num => num.ID == Convert.ToInt32(Console.ReadLine()));
            //var retrievedId = searchId.ID;
            //var retrievedTitle = searchId.Title;
            //Console.WriteLine(searchId);
            //Console.WriteLine(retrievedTitle);
            //Topic.tulostaTiedot();

            //Topic.teksiTiedosto();
            //Topic.EtsiId();
            //EtsiTitle();

            //int typed = 1;

            //var IDS = lista.Where(c => c.ID == typed);
            //List<Topic> searchById = lista.FindAll(i => i.ID == typed).ToList();





            //foreach (var myStruct in lista)
            //{
            //    Console.WriteLine(myStruct.ID);
            //}
            //Console.ReadLine();

            //foreach (Topic i in searchById)
            //{
            //    Console.WriteLine("ID: {0}", i.ID);
            //    Console.WriteLine("Title: {0}", i.Title);
            //    Console.WriteLine("Description: {0}", i.Description);
            //    Console.WriteLine("Estimated time to complete: {0}", i.EstimatedTimeToMaster);
            //    Console.WriteLine("Time spent: {0}", i.TimeSpent);
            //    Console.WriteLine("Source: {0}", i.Source);
            //    Console.WriteLine("Start date: {0}", i.StartDate);
            //    Console.WriteLine("Topic in progress: {0}", i.InProgress);
            //    if (i.InProgress == false)
            //    {
            //        Console.WriteLine("Completion date: {0}", i.CompletionDate);
            //        Console.WriteLine("The topic lasted: " + (i.CompletionDate - i.StartDate).TotalDays + " days");
            //    }
            //}
        }
    }

}

