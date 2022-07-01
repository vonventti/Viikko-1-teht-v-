using System;
using System.Linq;
//using System.Data.Entity;
using System.Threading.Tasks;
using Viikko_1_tehtävä.Models;

namespace Viikko_1_tehtävä
{
    class Metodit
    {

        public static async Task SyötäUusi()
        {
            using (LearningDiaryContext conn = new LearningDiaryContext())
            {
                //Console.WriteLine("Enter an Id");
                //var IdEntered = Console.ReadLine();
                //while (!int.TryParse(IdEntered, out Id))
                //{
                //    Console.WriteLine("This is not a valId Id. Please enter a number as Id");
                //    IdEntered = Console.ReadLine();
                //}
                double TimeToMaster;
                int TimeSpent;
                string Title, Description, Source, inProg;
                DateTime StartLearningDate, CompletionDate;
                bool InProgress;


                Console.WriteLine("Enter a title");
                Title = Console.ReadLine();


                Console.WriteLine("Enter a description");
                Description = Console.ReadLine();


                Console.WriteLine("Enter time to complete");
                var timeToCompleteEntered = Console.ReadLine();

                while (!double.TryParse(timeToCompleteEntered, out TimeToMaster))
                {
                    Console.WriteLine("This is not a valId time. Please enter a number as time to complete");
                    timeToCompleteEntered = Console.ReadLine();
                }

                TimeToMaster = Convert.ToDouble(TimeToMaster);



                // Muuta doubleksi

                Console.WriteLine("Enter time spent");
                var timeSpentEntered = Console.ReadLine();
                while (!int.TryParse(timeSpentEntered, out TimeSpent))
                {
                    Console.WriteLine("This is not a valId time. Please enter a number as time spent");
                    timeSpentEntered = Console.ReadLine();
                }
                TimeSpent = Convert.ToInt32(TimeSpent);

                Console.WriteLine("Enter a source");
                Source = Console.ReadLine();


                Console.WriteLine("Enter a start date (dd/mm/yyyy)");
                var startLearning = Console.ReadLine();
                while (!DateTime.TryParse(startLearning, out StartLearningDate))
                {
                    Console.WriteLine("This is not a valId date. Please enter a valid date in the format dd/mm/yyyy");
                    startLearning = Console.ReadLine();
                }

                StartLearningDate = Convert.ToDateTime(startLearning);


                Console.WriteLine("Is the Topic still ongoing? (y / n)");
                inProg = Console.ReadLine();
                InProgress = true;
                if (inProg != null && inProg == "n")
                {

                    InProgress = false;
                    Console.WriteLine("Enter a completion date (dd/mm/yyyy)");
                    var completion = Console.ReadLine();
                    while (!DateTime.TryParse(completion, out StartLearningDate))
                    {
                        Console.WriteLine("This is not a valId date. Please enter a valid date in the format dd/mm/yyyy");
                        completion = Console.ReadLine();
                    }

                    CompletionDate = Convert.ToDateTime(completion);

                    Topic uusi1 = new Topic()
                    {
                        //Id = Id,
                        Description = Description,
                        Title = Title,
                        TimeToMaster = TimeToMaster,
                        TimeSpent = TimeSpent,
                        Source = Source,
                        StartLearningDate = StartLearningDate,
                        InProgress = InProgress,
                        CompletionDate = CompletionDate
                    };

                    //Console.WriteLine("Id: {0}", Id);
                    Console.WriteLine("Title: {0}", Title);
                    Console.WriteLine("Description: {0}", Description);
                    Console.WriteLine("Estimated time to complete: {0}", TimeToMaster);
                    Console.WriteLine("Time spent: {0}", TimeSpent);
                    Console.WriteLine("Source: {0}", Source);
                    Console.WriteLine("Start date: {0}", StartLearningDate);
                    Console.WriteLine("Topic in progress: {0}", InProgress);
                    Console.WriteLine("Completion date: {0}", CompletionDate);

                    // ClassLibrary joka kertoo josko projekti on ajallaan tai jäänyt jälkeen

                    if (Harjoitus.Class1.OverDueOrNot(StartLearningDate, TimeToMaster) == true)
                    {
                        Console.WriteLine("Projekti on myöhästynyt");
                    }
                    else
                    {

                        Console.WriteLine("Projekti on ajallaan");
                    }

                    conn.Topics.Add(uusi1);


                }
                else if (inProg != null && inProg == "y")
                {
                    InProgress = true;

                    Topic uusi = new Topic()
                    {
                        //Id = Id,
                        Description = Description,
                        Title = Title,
                        TimeToMaster = TimeToMaster,
                        TimeSpent = TimeSpent,
                        Source = Source,
                        StartLearningDate = StartLearningDate,
                        InProgress = InProgress,
                    };


                    //Console.WriteLine("Id: {0}", Id);
                    Console.WriteLine("Title: {0}", Title);
                    Console.WriteLine("Description: {0}", Description);
                    Console.WriteLine("Estimated time to complete: {0}", TimeToMaster);
                    Console.WriteLine("Time spent: {0}", TimeSpent);
                    Console.WriteLine("Source: {0}", Source);
                    Console.WriteLine("Start date: {0}", StartLearningDate);
                    Console.WriteLine("Topic in progress: {0}", InProgress);

                    // ClassLibrary joka kertoo josko projekti on ajallaan tai jäänyt jälkeen

                    if (Harjoitus.Class1.OverDueOrNot(StartLearningDate, TimeToMaster) == true)
                    {
                        Console.WriteLine("Projekti on myöhästynyt");
                    }
                    else
                    {

                        Console.WriteLine("Projekti on ajallaan");
                    }


                    conn.Topics.Add(uusi);



                }
                else
                {
                    Console.WriteLine("Invalid value");
                }


                conn.SaveChanges();
            }
        }

        public static async Task EtsiTopic()
        {
            int Id;
            string Title;


            using (LearningDiaryContext conn = new LearningDiaryContext())
            {
                Console.WriteLine("Syötä '1' jos haluat etsiä Id:n perusteella, tai '2' jos haluat etsiä otsikon perusteella");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Enter Id to search");
                    var IdEntered = Console.ReadLine();
                    while (!int.TryParse(IdEntered, out Id))
                    {
                        Console.WriteLine("This is not a valId Id. Please enter a number as Id");
                        IdEntered = Console.ReadLine();
                    }
                    var tulostus = conn.Topics.Select(t => t);
                    var searchById = tulostus.Where(t => t.Id == Id);

                    foreach (var i in searchById)
                    {
                        Console.WriteLine("Id: {0}", i.Id);
                        Console.WriteLine("Title: {0}", i.Title);
                        Console.WriteLine("Description: {0}", i.Description);
                        Console.WriteLine("Estimated time to complete: {0}", i.TimeToMaster);
                        Console.WriteLine("Time spent: {0}", i.TimeSpent);
                        Console.WriteLine("Source: {0}", i.Source);
                        Console.WriteLine("Start date: {0}", i.StartLearningDate);
                        Console.WriteLine("Topic in progress: {0}", i.InProgress);

                    }


                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter a title");
                    Title = Console.ReadLine();
                    var tulostus = conn.Topics.Select(t => t);
                    var searchByTitle = tulostus.Where(t => t.Title == Title);

                    foreach (var i in searchByTitle)
                    {
                        Console.WriteLine("Id: {0}", i.Id);
                        Console.WriteLine("Title: {0}", i.Title);
                        Console.WriteLine("Description: {0}", i.Description);
                        Console.WriteLine("Estimated time to complete: {0}", i.TimeToMaster);
                        Console.WriteLine("Time spent: {0}", i.TimeSpent);
                        Console.WriteLine("Source: {0}", i.Source);
                        Console.WriteLine("Start date: {0}", i.StartLearningDate);
                        Console.WriteLine("Topic in progress: {0}", i.InProgress);
                    }
                }
                else
                {
                    Console.WriteLine("Jotain meni pieleen");
                }
            }
        }
        public static async Task PoistaTopic()
        {
            int Id;
            string Title;


            using (LearningDiaryContext conn = new LearningDiaryContext())
            {

                Console.WriteLine("Syötä '1' jos haluat poistaa Id:n perusteella, tai '2' jos haluat poistaa otsikon perusteella");
                var input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Enter an Id");
                    var IdEntered = Console.ReadLine();
                    while (!int.TryParse(IdEntered, out Id))
                    {
                        Console.WriteLine("This is not a valId Id. Please enter a number as Id");
                        IdEntered = Console.ReadLine();
                    }
                    conn.Remove(conn.Topics.Single(x => x.Id == Id));

                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter a title");
                    Title = Console.ReadLine();
                    conn.Remove(conn.Topics.Single(x => x.Title == Title));
                }
                else
                {
                    Console.WriteLine("Jotain meni pieleen.");
                }

                conn.SaveChanges();
            }
        }
        public static async Task MuokkaaTopic()
        {
            double TimeToMaster;
            int Id, TimeSpent;
            string Title, inProg;

            bool InProgress;

            using (LearningDiaryContext conn = new LearningDiaryContext())
            {
                Console.WriteLine("Syötä '1' jos haluat päivittää tietoja Id:n perusteella, tai '2' jos haluat päivittää tietoja otsikon perusteella");
                var input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Enter Id to search");
                    var IdEntered = Console.ReadLine();

                    while (!int.TryParse(IdEntered, out Id))
                    {
                        Console.WriteLine("This is not a valId Id. Please enter a number as Id");
                        IdEntered = Console.ReadLine();
                    }
                    var tulostus = conn.Topics.Select(t => t);
                    var query = tulostus.Where(c => c.Id == Id);

                    var updateFields = query.First();



                    //Console.WriteLine("Enter an Id");
                    //IdEntered = Console.ReadLine();

                    //while (!int.TryParse(IdEntered, out Id))
                    //{
                    //    Console.WriteLine("This is not a valId Id. Please enter a number as Id");
                    //    IdEntered = Console.ReadLine();
                    //}
                    //updateFields.Id = Id;


                    Console.WriteLine("Enter a title");
                    updateFields.Title = Console.ReadLine();


                    Console.WriteLine("Enter a description");
                    updateFields.Description = Console.ReadLine();


                    Console.WriteLine("Enter time to complete");
                    var timeToCompleteEntered = Console.ReadLine();

                    while (!double.TryParse(timeToCompleteEntered, out TimeToMaster))
                    {
                        Console.WriteLine("This is not a valId time. Please enter a number as time to complete");
                        timeToCompleteEntered = Console.ReadLine();
                    }
                    updateFields.TimeToMaster = Convert.ToDouble(TimeToMaster);


                    Console.WriteLine("Enter time spent");
                    var timeSpentEntered = Console.ReadLine();
                    while (!int.TryParse(timeSpentEntered, out TimeSpent))
                    {
                        Console.WriteLine("This is not a valId time. Please enter a number as time spent");
                        timeSpentEntered = Console.ReadLine();
                    }
                    updateFields.TimeSpent = Convert.ToInt32(TimeSpent);

                    Console.WriteLine("Enter a source");
                    updateFields.Source = Console.ReadLine();


                    Console.WriteLine("Enter a start date (dd/mm/yyyy)");
                    var date = DateTime.Parse(Console.ReadLine());
                    var formatted = date.ToString("dd-MM-yyyy");

                    var StartLearningDate1 = Convert.ToDateTime(formatted);
                    updateFields.StartLearningDate = StartLearningDate1;

                    Console.WriteLine("Is the Topic still ongoing? (y / n)");
                    inProg = Console.ReadLine();

                    InProgress = true;
                    if (inProg != null && inProg == "n")
                    {
                        InProgress = false;
                    }
                    else if (inProg != null && inProg == "y")
                    {
                        InProgress = true;
                    }
                    else
                    {
                        Console.WriteLine("InvalId value");
                    }

                    updateFields.InProgress = InProgress;







                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter a title");
                    Title = Console.ReadLine();
                    var tulostus = conn.Topics.Select(t => t);
                    var query = tulostus.Where(c => c.Title == Title);

                    var updateFields = query.First();


                    //Console.WriteLine("Enter an Id");
                    //IdEntered = Console.ReadLine();

                    //while (!int.TryParse(IdEntered, out Id))
                    //{
                    //    Console.WriteLine("This is not a valId Id. Please enter a number as Id");
                    //    IdEntered = Console.ReadLine();
                    //}
                    //updateFields.Id = Id;


                    Console.WriteLine("Enter a title");
                    updateFields.Title = Console.ReadLine();


                    Console.WriteLine("Enter a description");
                    updateFields.Description = Console.ReadLine();


                    Console.WriteLine("Enter time to complete");
                    var timeToCompleteEntered = Console.ReadLine();

                    while (!double.TryParse(timeToCompleteEntered, out TimeToMaster))
                    {
                        Console.WriteLine("This is not a valId time. Please enter a number as time to complete");
                        timeToCompleteEntered = Console.ReadLine();
                    }
                    updateFields.TimeToMaster = Convert.ToDouble(TimeToMaster);


                    Console.WriteLine("Enter time spent");
                    var timeSpentEntered = Console.ReadLine();
                    while (!int.TryParse(timeSpentEntered, out TimeSpent))
                    {
                        Console.WriteLine("This is not a valId time. Please enter a number as time spent");
                        timeSpentEntered = Console.ReadLine();
                    }
                    updateFields.TimeSpent = Convert.ToInt32(TimeSpent);

                    Console.WriteLine("Enter a source");
                    updateFields.Source = Console.ReadLine();


                    Console.WriteLine("Enter a start date (dd/mm/yyyy)");
                    var date = DateTime.Parse(Console.ReadLine());
                    var formatted = date.ToString("dd-MM-yyyy");

                    var StartLearningDate1 = Convert.ToDateTime(formatted);
                    updateFields.StartLearningDate = StartLearningDate1;

                    Console.WriteLine("Is the Topic still ongoing? (y / n)");
                    inProg = Console.ReadLine();

                    InProgress = true;
                    if (inProg != null && inProg == "n")
                    {
                        InProgress = false;
                    }
                    else if (inProg != null && inProg == "y")
                    {
                        InProgress = true;
                    }
                    else
                    {
                        Console.WriteLine("InvalId value");
                    }

                    updateFields.InProgress = InProgress;



                }
                else
                {
                    Console.WriteLine("Didn't find");
                }
                conn.SaveChanges();

            }
        }
        public static void TulostaKaikki()
        {
            using (LearningDiaryContext conn = new LearningDiaryContext())
            {
                var tulostus = conn.Topics.Select(t => t);

                foreach (var i in tulostus)
                {
                    Console.WriteLine("Id: {0}", i.Id);
                    Console.WriteLine("Title: {0}", i.Title);
                    Console.WriteLine("Description: {0}", i.Description);
                    Console.WriteLine("Estimated time to complete: {0}", i.TimeToMaster);
                    Console.WriteLine("Time spent: {0}", i.TimeSpent);
                    Console.WriteLine("Source: {0}", i.Source);
                    Console.WriteLine("Start date: {0}", i.StartLearningDate);
                    Console.WriteLine("Topic in progress: {0}", i.InProgress);

                }

            }
        }
    }
}
