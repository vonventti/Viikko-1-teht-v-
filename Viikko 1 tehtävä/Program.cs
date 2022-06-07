using System;
using System.Collections.Generic;

namespace Viikko_1_tehtävä
{
    class Program
    {


        static void Main(string[] args)
        {
            List<Topic> topicList = new List<Topic>();


            char createAnother = 'N';

            do
            {
                var topic = new Topic();

                Console.WriteLine("Enter an ID");
                topic.ID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter a title");
                topic.title = Console.ReadLine();


                Console.WriteLine("Enter a description");
                topic.description = Console.ReadLine();


                Console.WriteLine("Enter time to complete");
                topic.estimatedTimeToMaster = Console.ReadLine();


                Console.WriteLine("Enter time spent");
                topic.timeSpent = Convert.ToDouble(Console.ReadLine());


                Console.WriteLine("Enter a source");
                topic.source = Console.ReadLine();

                Console.WriteLine("Enter a start date dd/mm/yyyy");
                DateTime date = DateTime.Parse(Console.ReadLine());
                string formatted = date.ToString("dd-MM-yyyy");
                topic.startDate = formatted;

                //Console.WriteLine("Is the topic still ongoing? (y / n)");
                //string InputString = Console.ReadLine();
                //if (Console.ReadLine() == "y")
                //{
                //    return true;
                //}
                //else if (Console.ReadLine() == "n")
                //{
                //    return false;
                //}
                //else
                //{
                //    throw new Exception("only y and n allowed...");
                //}
                //string inProgress10 = Console.ReadLine();

                //bool inProgress = Convert.ToBoolean(Console.ReadLine());


                //Console.WriteLine("Enter a complition date");
                //topic.completionDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter a completion date dd/mm/yyyy");
                DateTime date1 = DateTime.Parse(Console.ReadLine());
                string formatted1 = date1.ToString("dd-MM-yyyy");
                topic.completionDate = formatted1;

                topicList.Add(topic);
                Console.WriteLine("Do you want to add another? [Y/N] : ");
                createAnother = char.ToUpper(Console.ReadKey(false).KeyChar);
            } while (createAnother == 'Y');

            foreach (Topic t in topicList)
            {
                Console.WriteLine("\n" + t.ID + " " + t.title + " " + t.description + " " + t.estimatedTimeToMaster + " " + t.timeSpent + " " + t.source + " " + t.startDate + " " + t.completionDate);
            }

            Console.WriteLine();
        }



        // Testi


        public class Topic
        {
            public int ID { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string estimatedTimeToMaster { get; set; }
            public double timeSpent { get; set; }
            public string source { get; set; }
            public string startDate { get; set; }
            public bool inProgress { get; set; }
            public string completionDate { get; set; }

            public void getTitle() {
                Console.WriteLine(title);
            }

            //public Topic(int ID, string title, string description, string estimatedTimeToMaster, double timeSpent, string source, DateTime startDate, bool inProgress, DateTime completionDate)
            //{
            //    ID = ID;
            //    title = title;
            //    description = description;
            //    estimatedTimeToMaster = estimatedTimeToMaster;
            //    timeSpent = timeSpent;
            //    source = source;
            //    startDate = startDate;
            //    inProgress = inProgress;
            //    completionDate = completionDate;
            //}

            //public void parts(int ID, string title, string description, string estimatedTimeToMaster, double timeSpent, string source, DateTime startDate, bool inProgress, DateTime completionDate)
            //{
            //    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", ID, title, description, estimatedTimeToMaster, timeSpent, source, startDate, inProgress, completionDate);
            //}
        }
    }
}
