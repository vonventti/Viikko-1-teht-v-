using System;
using System.Collections.Generic;
using System.IO;

namespace Viikko_1_tehtävä
{
    class Program
    {
        // Sovellus toteutettu käyttäen luokkaa ja oliota sekä kolmea metodia (Tiedot() = kerätään tiedot käyttäjältä, näytäLista() = näytetään tiedot konsolissa, tekstiTiedosto() = syötetään tekstitiedostoon (.txt) käyttäjän syöttämät tiedot

        static void Main(string[] args)
        {
            Topic topic = Tiedot();
            näytäLista(topic);
            teksiTiedosto(topic);
        }

        // Luokka Topic sekä parametrit

        public class Topic
        {
            // Parametrit
            public List<Topic> Topics { get; set; }
            public int ID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public double EstimatedTimeToMaster { get; set; }
            public double TimeSpent { get; set; }
            public string Source { get; set; }
            public DateTime StartDate { get; set; }
            public bool InProgress { get; set; }
            public DateTime CompletionDate { get; set; }
        }

        // Tiedot() => Kerätään käyttäjän tiedot ja tallennetaan olion instanssiin
        public static Topic Tiedot()
        {
            // Olion instanssi topic

            Topic topic = new Topic();

            int ID;

            Console.WriteLine("Enter an ID");
            bool idValid = int.TryParse(Console.ReadLine(), out ID)
                && ID > 0;

            while (!idValid)
            {
                Console.WriteLine("Please enter a valid ID (number)");
                idValid = int.TryParse(Console.ReadLine(), out ID)
                    && ID > 0;
            }
            topic.ID = Convert.ToInt32(idValid);

            Console.WriteLine("Enter a title");
            topic.Title = Console.ReadLine();

            Console.WriteLine("Enter a description");
            topic.Description = Console.ReadLine();

            double EstimatedTimeToMaster;

            Console.WriteLine("Enter time to complete");
            bool valid = double.TryParse(Console.ReadLine(), out EstimatedTimeToMaster)
                && EstimatedTimeToMaster > 0;

            while (!valid)
            {
                Console.WriteLine("Please enter a valid time as a double, i.e. a number or number as xx,xx?");
                valid = double.TryParse(Console.ReadLine(), out EstimatedTimeToMaster)
                    && EstimatedTimeToMaster > 0;
            }
            topic.EstimatedTimeToMaster = Convert.ToDouble(valid);

            double TimeSpent;

            Console.WriteLine("Enter time spent");
            bool validTime = double.TryParse(Console.ReadLine(), out TimeSpent)
                && TimeSpent > 0;

            while (!validTime)
            {
                Console.WriteLine("Please enter a valid time as a double, i.e. a number or number as xx,xx?");
                validTime = double.TryParse(Console.ReadLine(), out TimeSpent)
                    && TimeSpent > 0;
            }
            topic.TimeSpent = Convert.ToDouble(validTime);

            Console.WriteLine("Enter a source");
            topic.Source = Console.ReadLine();

 
            Console.WriteLine("Enter a start date (dd/mm/yyyy)");
            DateTime date = DateTime.Parse(Console.ReadLine());
            string formatted = date.ToString("dd-MM-yyyy");
         
            DateTime StartDate1 = Convert.ToDateTime(formatted);
            topic.StartDate = StartDate1;


            Console.WriteLine("Is the topic still ongoing? (y / n)");
            string inProg = Console.ReadLine();
            bool S = true;
            if (inProg != null && inProg == "n")
            {
                Console.WriteLine("Enter a completion date (dd/mm/yyyy)");
                DateTime date1 = DateTime.Parse(Console.ReadLine());
                string formatted1 = date1.ToString("dd-MM-yyyy");
                DateTime CompletionDate1 = Convert.ToDateTime(formatted1);
                topic.CompletionDate = CompletionDate1;
                S = false;
                
            }

            topic.InProgress = S;
            

            return topic;
        }

        // näytäLista() => printtaa olioon (topic) tallennetut tiedot konsoliin (Completion date sekä the topic lasted-teksti tulee myös loppuun jos InProgress on false)
        static void näytäLista(Topic topic)
        {
            Console.WriteLine("{0}", topic.ID);
            Console.WriteLine("{0}", topic.Title);
            Console.WriteLine("{0}", topic.Description);
            Console.WriteLine("{0}", topic.EstimatedTimeToMaster);
            Console.WriteLine("{0}", topic.TimeSpent);
            Console.WriteLine("{0}", topic.Source);
            Console.WriteLine("{0}", topic.StartDate);
            Console.WriteLine("{0}", topic.InProgress);
            if (topic.InProgress == false)
            {
                Console.WriteLine("{0}", topic.CompletionDate);
                Console.WriteLine("The topic lasted: " + (topic.CompletionDate - topic.StartDate).TotalDays + " days");
            }
            

        }

        // tekstiTiedosto() => tallentaa olion (topic) tiedot tekstidokumenttiin (textfile.txt) (Completion date sekä the topic lasted-teksti tulee myös loppuun jos InProgress on false)
        static void teksiTiedosto(Topic topic)
        {
            string Path = @"C:\Users\Anders\textfile.txt";

            using (TextWriter tw = new StreamWriter(Path))
            {
                tw.WriteLine(string.Format("ID: {0}  \nTitle: {1}  \nDecription: {2}  \nTime to Complete: {3}  \nTime spent: {4}  \nSource: {5}  \nStart date: {6}  \nTopic ongoing: {7}",
                    topic.ID.ToString(),
                    topic.Title,
                    topic.Description,
                    topic.EstimatedTimeToMaster.ToString(),
                    topic.TimeSpent.ToString(),
                    topic.Source,
                    topic.StartDate.ToString(),
                    topic.InProgress.ToString()));
                    if (topic.InProgress == false)
                    {
                    tw.WriteLine("Completion date: " + topic.CompletionDate);
                    tw.WriteLine("The topic lasted: " + (topic.CompletionDate - topic.StartDate).TotalDays + " days");
                }
            }   
        }
        }

    }

