using System;
using System.Collections.Generic;
using System.IO;

namespace Viikko_1_tehtävä
{
    class Program
    {


        static void Main(string[] args)
        {

            List<Topic> Topics = new List<Topic>();    

            int id = 1;
            // topic.ID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter a title");
            string title = Console.ReadLine();


            Console.WriteLine("Enter a description");
            string description = Console.ReadLine();


            Console.WriteLine("Enter time to complete");
            double estimatedTimeToMaster = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("Enter time spent");
            double timeSpent = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("Enter a source");
            string source = Console.ReadLine();

            Console.WriteLine("Enter a start date dd/mm/yyyy");
            DateTime date = DateTime.Parse(Console.ReadLine());
            string formatted = date.ToString("dd-MM-yyyy");
            string startDate = formatted;

            Console.WriteLine("Is the topic still ongoing? (y / n)");
            bool inProgress = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Enter a completion date dd/mm/yyyy");
            DateTime date1 = DateTime.Parse(Console.ReadLine());
            string formatted1 = date1.ToString("dd-MM-yyyy");
            string completionDate = formatted1;

            Topic topic = new Topic(id, title, description, estimatedTimeToMaster, timeSpent, source, startDate, inProgress, completionDate);

            // Topic topic = new Topic();

            Topics.Add(topic);

            string Path = @"C:\Users\Anders\textfile.txt";

            using (TextWriter tw = new StreamWriter(Path))
            {
                foreach (Topic t in Topics)
                {
                    // tw.WriteLine(string.Format("Title: {0}, Description: {1}", t.Title, t.Description));
                    tw.WriteLine(string.Format("ID: {0}  \nTitle: {1}  \nDecription: {2}  \nTime to Complete: {3}  \nTime spent: {4}  \nSource: {5}  \nStart date: {6}  \nTopic ongoin: {7}  \nCompletion date: {8}  ", 
                        t.ID.ToString(),
                        t.Title,
                        t.Description, 
                        t.EstimatedTimeToMaster.ToString(), 
                        t.TimeSpent.ToString(), 
                        t.Source, 
                        t.StartDate.ToString(), 
                        t.InProgress.ToString(), 
                        t.CompletionDate.ToString()));
                    Console.WriteLine(t.Title + " " + t.Description);
                }
            }

            // 
            //topic.ForEach(Console.WriteLine);

            foreach (Topic t in Topics)
            {
                Console.WriteLine(t.ID + t.Title + " " + t.Description + " " + t.EstimatedTimeToMaster + " " + t.TimeSpent + " " + t.Source + " " + t.StartDate + " " + t.CompletionDate);
            }
           // 
        }

        public class Topic
        {
            public Topic(int id, string title, string description, double estimatedTimeToMaster, double timeSpent, string source, string startDate, bool inProgress, string completionDate)
            {
                ID = id;
                Title = title;
                Description = description;
                EstimatedTimeToMaster = estimatedTimeToMaster;
                TimeSpent = timeSpent;
                Source = source;
                StartDate = startDate;
                InProgress = inProgress;
                CompletionDate = completionDate;
            }

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


            //public void parts(int ID, string title, string description, string estimatedTimeToMaster, double timeSpent, string source, DateTime startDate, bool inProgress, DateTime completionDate)
            //{
            //    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", ID, title, description, estimatedTimeToMaster, timeSpent, source, startDate, inProgress, completionDate);
            //}
            

        }
    }
}
