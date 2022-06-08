using System;
using System.Collections.Generic;
using System.IO;

namespace Viikko_1_tehtävä
{
    class Program
    {


        static void Main(string[] args)
        {
            Topic topic = Tiedot();
            näytäLista(topic);
            teksiTiedosto(topic);
        }

        public class Topic
        {
            //public Topic(int id, string title, string description, double estimatedTimeToMaster, double timeSpent, string source, string startDate, bool inProgress, string completionDate)
            //{
            //    ID = id;
            //    Title = title;
            //    Description = description;
            //    EstimatedTimeToMaster = estimatedTimeToMaster;
            //    TimeSpent = timeSpent;
            //    Source = source;
            //    StartDate = startDate;
            //    InProgress = inProgress;
            //    CompletionDate = completionDate;
            //}

            // 
            public List<Topic> Topics { get; set; }
            public int ID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public double EstimatedTimeToMaster { get; set; }
            public double TimeSpent { get; set; }
            public string Source { get; set; }
            public string StartDate { get; set; }
            public bool InProgress { get; set; }
            public string CompletionDate { get; set; }
        }
        static Topic Tiedot()
        {
            Topic topic = new Topic();

            Console.WriteLine("Enter an ID");
            topic.ID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter a title");
            topic.Title = Console.ReadLine();

            Console.WriteLine("Enter a description");
            topic.Description = Console.ReadLine();

            Console.WriteLine("Enter time to complete");
            topic.EstimatedTimeToMaster = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter time spent");
            topic.TimeSpent = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter a source");
            topic.Source = Console.ReadLine();

            Console.WriteLine("Enter a start date (dd/mm/yyyy)");
            DateTime date = DateTime.Parse(Console.ReadLine());
            string formatted = date.ToString("dd-MM-yyyy");
            topic.StartDate = formatted;

            // bool inProgress = true;
            Console.WriteLine("Is the topic still ongoing? (y / n)");
            string inProg = Console.ReadLine();
            if (inProg == "n")
            {
                Console.WriteLine("Enter a completion date (dd/mm/yyyy)");
                DateTime date1 = DateTime.Parse(Console.ReadLine());
                string formatted1 = date1.ToString("dd-MM-yyyy");
                topic.CompletionDate = formatted1;
            } else
            {
                //inProgress = false;
            }

            bool inProgress = true;
            topic.InProgress;
            return topic;
        }
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
            Console.WriteLine("{0}", topic.CompletionDate);
           
        }

        static void teksiTiedosto(Topic topic)
        {
            string Path = @"C:\Users\Anders\textfile.txt";

            using (TextWriter tw = new StreamWriter(Path))
            {
            tw.WriteLine(string.Format("ID: {0}  \nTitle: {1}  \nDecription: {2}  \nTime to Complete: {3}  \nTime spent: {4}  \nSource: {5}  \nStart date: {6}  \nTopic ongoin: {7}  \nCompletion date: {8}  ",
                topic.ID.ToString(),
                topic.Title,
                topic.Description,
                topic.EstimatedTimeToMaster.ToString(),
                topic.TimeSpent.ToString(),
                topic.Source,
                topic.StartDate.ToString(),
                topic.InProgress.ToString(),
                topic.CompletionDate.ToString()));
            }
        }

    }
}
