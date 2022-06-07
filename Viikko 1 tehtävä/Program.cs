using System;
using System.Collections.Generic;

namespace Viikko_1_tehtävä
{
    class Program
    {


        static void Main(string[] args)
        {

            List<Topic> topic = new List<Topic>();    

            int ID = 1;
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

            topic.Add(new Topic(ID, title, description, estimatedTimeToMaster, timeSpent, source, startDate, inProgress, completionDate));
            topic.ForEach(Console.WriteLine);

            foreach (Topic t in topic)
            {
                Console.WriteLine("\n" + t.ID + " " + t.title + " " + t.description + " " + t.estimatedTimeToMaster + " " + t.timeSpent + " " + t.source + " " + t.startDate + " " + t.completionDate);
            }

        }

        public class Topic
        {
            public Topic(int ID, string title, string description, double estimatedTimeToMaster, double timeSpent, string source, string startDate, bool inProgress, string completionDate)
            {
                ID = ID;
                title = title;
                description = description;
                estimatedTimeToMaster = estimatedTimeToMaster;
                timeSpent = timeSpent;
                source = source;
                startDate = startDate;
                inProgress = inProgress;
                completionDate = completionDate;
            }

 
            public List<Topic> topic { get; set; }
            public int ID { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public double estimatedTimeToMaster { get; set; }
            public double timeSpent { get; set; }
            public string source { get; set; }
            public string startDate { get; set; }
            public bool inProgress { get; set; }
            public string completionDate { get; set; }


            //public void parts(int ID, string title, string description, string estimatedTimeToMaster, double timeSpent, string source, DateTime startDate, bool inProgress, DateTime completionDate)
            //{
            //    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", ID, title, description, estimatedTimeToMaster, timeSpent, source, startDate, inProgress, completionDate);
            //}
            

        }
    }
}
