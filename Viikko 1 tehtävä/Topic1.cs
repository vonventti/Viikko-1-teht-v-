//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//namespace Viikko_1_tehtävä
//{
//    // Luokka Topic1 sekä argumentit
//    public class Topic1
//    {
//        // Argumentit

//        public int ID { get; set; }
//        public string Title { get; set; }
//        public string Description { get; set; }
//        public double TimeToMaster { get; set; }
//        public double TimeSpent { get; set; }
//        public string Source { get; set; }
//        public DateTime StartLearningDate { get; set; }
//        public bool InProgress { get; set; }
//        public DateTime CompletionDate { get; set; }

//        // Constructori


//        public Topic1(int ID, string Title, string Description, double TimeToMaster, double TimeSpent, string Source, DateTime StartLearningDate, bool InProgress, DateTime CompletionDate)
//        {
//            this.ID = ID;
//            this.Title = Title;
//            this.Description = Description;
//            this.TimeToMaster = TimeToMaster;
//            this.TimeSpent = TimeSpent;
//            this.Source = Source;
//            this.StartLearningDate = StartLearningDate;
//            this.InProgress = InProgress;
//            this.CompletionDate = CompletionDate;

//        }

//        public Topic1(int ID, string Title, string Description, double TimeToMaster, double TimeSpent, string Source, DateTime StartLearningDate, bool InProgress)
//        {
//            this.ID = ID;
//            this.Title = Title;
//            this.Description = Description;
//            this.TimeToMaster = TimeToMaster;
//            this.TimeSpent = TimeSpent;
//            this.Source = Source;
//            this.StartLearningDate = StartLearningDate;
//            this.InProgress = InProgress;


//        }

//        public Topic1()
//        {
           


//        }

//        // Luodaan lista nimeltä "Topic1s"
//        public static List<Topic1> Topic1s = new List<Topic1>();


//        // kerääTiedot() => Kerätään käyttäjän tiedot ja tallennetaan listaan "Topic1s" Add-kommennolla
//        public static void kerääTiedot()
//        {
//            //Topic1 Topic1 = new Topic1();



//            Console.WriteLine("Enter an ID");
//            var idEntered = Console.ReadLine();
//            int ID;
//            while (!int.TryParse(idEntered, out ID))
//            {
//                Console.WriteLine("This is not a valid ID. Please enter a number as ID");
//                idEntered = Console.ReadLine();
//            }



//            Console.WriteLine("Enter a title");
//            string Title = Console.ReadLine();


//            Console.WriteLine("Enter a description");
//            string Description = Console.ReadLine();


//            Console.WriteLine("Enter time to complete");
//            var timeToCompleteEntered = Console.ReadLine();
//            double TimeToMaster;
//            while (!double.TryParse(timeToCompleteEntered, out TimeToMaster))
//            {
//                Console.WriteLine("This is not a valid time. Please enter a number as time to complete");
//                timeToCompleteEntered = Console.ReadLine();
//            }
//            TimeToMaster = Convert.ToDouble(TimeToMaster);


//            Console.WriteLine("Enter time spent");
//            double TimeSpent;
//            var timeSpentEntered = Console.ReadLine();
//            while (!double.TryParse(timeSpentEntered, out TimeSpent))
//            {
//                Console.WriteLine("This is not a valid time. Please enter a number as time spent");
//                timeSpentEntered = Console.ReadLine();
//            }
//            TimeSpent = Convert.ToDouble(TimeSpent);

//            Console.WriteLine("Enter a source");
//            string Source = Console.ReadLine();


//            Console.WriteLine("Enter a start date (dd/mm/yyyy)");
//            DateTime date = DateTime.Parse(Console.ReadLine());
//            string formatted = date.ToString("dd-MM-yyyy");

//            DateTime StartLearningDate1 = Convert.ToDateTime(formatted);
//            DateTime StartLearningDate = StartLearningDate1;


//            Console.WriteLine("Is the Topic1 still ongoing? (y / n)");
//            string inProg = Console.ReadLine();
//            bool InProgress = true;
//            if (inProg != null && inProg == "n")
//            {
//                Console.WriteLine("Enter a completion date (dd/mm/yyyy)");
//                DateTime date1 = DateTime.Parse(Console.ReadLine());
//                string formatted1 = date1.ToString("dd-MM-yyyy");
//                DateTime CompletionDate1 = Convert.ToDateTime(formatted1);
//                DateTime CompletionDate = CompletionDate1;
//                InProgress = false;

//                Topic1s.Add(new Topic1(ID, Title, Description, TimeToMaster, TimeSpent, Source, StartLearningDate, InProgress, CompletionDate));
//            }
//            else
//            {
//                Topic1s.Add(new Topic1(ID, Title, Description, TimeToMaster, TimeSpent, Source, StartLearningDate, InProgress));
//            }






//        }

//        // tulostaTiedot() => printtaa olioon (Topic1) tallennetut tiedot konsoliin (Completion date sekä the Topic1 lasted-teksti tulee myös loppuun jos InProgress on false)
//        public static void tulostaTiedot()
//        {
//            foreach (Topic1 i in Topic1s)
//            {
//                Console.WriteLine("ID: {0}", i.ID);
//                Console.WriteLine("Title: {0}", i.Title);
//                Console.WriteLine("Description: {0}", i.Description);
//                Console.WriteLine("Estimated time to complete: {0}", i.TimeToMaster);
//                Console.WriteLine("Time spent: {0}", i.TimeSpent);
//                Console.WriteLine("Source: {0}", i.Source);
//                Console.WriteLine("Start date: {0}", i.StartLearningDate);
//                Console.WriteLine("Topic1 in progress: {0}", i.InProgress);
//                if (i.InProgress == false)
//                {
//                    Console.WriteLine("Completion date: {0}", i.CompletionDate);
//                    Console.WriteLine("The Topic1 lasted: " + (i.CompletionDate - i.StartLearningDate).TotalDays + " days");
//                }
//            }

//        }

//        // tekstiTiedosto() => tallentaa olion (Topic1) tiedot tekstidokumenttiin (textfile.txt) (Completion date sekä the Topic1 lasted-teksti tulee myös loppuun jos InProgress on false)
//        public static void teksiTiedosto()
//        {
//            string Path = @"C:\Users\Anders\textfile1.txt";

//            using (StreamWriter sw = File.AppendText(Path))
//            {
//                foreach (Topic1 i in Topic1s)
//                {
//                    sw.WriteLine(string.Format(
//                    "ID: {0}  \nTitle: {1}  \nDecription: {2}  \nTime to Complete: {3}  \nTime spent: {4}  \nSource: {5}  \nStart date: {6}  \nTopic1 ongoing: {7}",
//                    i.ID.ToString(),
//                    i.Title,
//                    i.Description,
//                    i.TimeToMaster.ToString(),
//                    i.TimeSpent.ToString(),
//                    i.Source,
//                    i.StartLearningDate.ToString(),
//                    i.InProgress.ToString()));
//                    if (i.InProgress == false)
//                    {
//                        sw.WriteLine("Completion date: " + i.CompletionDate);
//                        sw.WriteLine("The Topic1 lasted: " + (i.CompletionDate - i.StartLearningDate).TotalDays + " days");
//                    }
//                    sw.WriteLine("-----------------------------------------------------------------------------------------");
//                }

//            }
//        }

//        // Etsii ID:n tai Titlen perusteella

//        public static void EtsiIdtaiTitle(List<Topic1> lista)
//        {
//            Console.WriteLine("Syötä '1' jos haluat etsiä ID:n perusteella, tai '2' jos haluat etsiä otsikon perusteella");
//            string input = Console.ReadLine();
//            if (input == "1")
//            {
//                Console.WriteLine("Enter ID to search");
//                var idEntered = Console.ReadLine();
//                int ID;
//                while (!int.TryParse(idEntered, out ID))
//                {
//                    Console.WriteLine("This is not a valid ID. Please enter a number as ID");
//                    idEntered = Console.ReadLine();
//                }
//                List<Topic1> searchById = lista.FindAll(i => i.ID == ID).ToList();

//                foreach (Topic1 i in searchById)
//                {
//                    Console.WriteLine("ID: {0}", i.ID);
//                    Console.WriteLine("Title: {0}", i.Title);
//                    Console.WriteLine("Description: {0}", i.Description);
//                    Console.WriteLine("Estimated time to complete: {0}", i.TimeToMaster);
//                    Console.WriteLine("Time spent: {0}", i.TimeSpent);
//                    Console.WriteLine("Source: {0}", i.Source);
//                    Console.WriteLine("Start date: {0}", i.StartLearningDate);
//                    Console.WriteLine("Topic1 in progress: {0}", i.InProgress);
//                    if (i.InProgress == false)
//                    {
//                        Console.WriteLine("Completion date: {0}", i.CompletionDate);
//                        Console.WriteLine("The Topic1 lasted: " + (i.CompletionDate - i.StartLearningDate).TotalDays + " days");
//                    }
//                }


//            }
//            else if (input == "2")
//            {
//                Console.WriteLine("Enter a title");
//                string Title = Console.ReadLine();

//                List<Topic1> searchByTitle = lista.FindAll(i => i.Title == Title).ToList();

//                foreach (Topic1 i in searchByTitle)
//                {
//                    Console.WriteLine("ID: {0}", i.ID);
//                    Console.WriteLine("Title: {0}", i.Title);
//                    Console.WriteLine("Description: {0}", i.Description);
//                    Console.WriteLine("Estimated time to complete: {0}", i.TimeToMaster);
//                    Console.WriteLine("Time spent: {0}", i.TimeSpent);
//                    Console.WriteLine("Source: {0}", i.Source);
//                    Console.WriteLine("Start date: {0}", i.StartLearningDate);
//                    Console.WriteLine("Topic1 in progress: {0}", i.InProgress);
//                    if (i.InProgress == false)
//                    {
//                        Console.WriteLine("Completion date: {0}", i.CompletionDate);
//                        Console.WriteLine("The Topic1 lasted: " + (i.CompletionDate - i.StartLearningDate).TotalDays + " days");
//                    }
//                }
//            }
//            else
//            {
//                Console.WriteLine("Jotain meni pieleen");
//            }
//        }

//        // Poistaa ID:n tai titlen perusteella

//        public static void Delete(List<Topic1> lista)
//        {
//            Console.WriteLine("Syötä '1' jos haluat poistaa ID:n perusteella, tai '2' jos haluat poistaa otsikon perusteella");
//            string input = Console.ReadLine();
//            if (input == "1")
//            {
//                Console.WriteLine("Enter an ID");
//                var idEntered = Console.ReadLine();
//                int ID;
//                while (!int.TryParse(idEntered, out ID))
//                {
//                    Console.WriteLine("This is not a valid ID. Please enter a number as ID");
//                    idEntered = Console.ReadLine();
//                }
//                lista.RemoveAll(x => x.ID == ID);
//            }
//            else if (input == "2")
//            {
//                Console.WriteLine("Enter a title");
//                string Title = Console.ReadLine();
//                lista.RemoveAll(x => x.Title == Title);
//            }
//            else
//            {
//                Console.WriteLine("Jotain meni pieleen.");
//            }

//        }

//        // Päivittää listan ID:n tai titlen perusteella

//        public static void Update(List<Topic1> lista)
//        {

//            Console.WriteLine("Syötä '1' jos haluat päivittää tietoja ID:n perusteella, tai '2' jos haluat päivittää tietoja otsikon perusteella");
//            string input = Console.ReadLine();
//            if (input == "1")
//            {
//                Console.WriteLine("Enter ID to search");
//                var idEntered = Console.ReadLine();
//                int ID;
//                while (!int.TryParse(idEntered, out ID))
//                {
//                    Console.WriteLine("This is not a valid ID. Please enter a number as ID");
//                    idEntered = Console.ReadLine();
//                }
//                var query = lista.Where(c => c.ID == ID);

//                var updateFields = query.First();



//                Console.WriteLine("Enter an ID");
//                idEntered = Console.ReadLine();

//                while (!int.TryParse(idEntered, out ID))
//                {
//                    Console.WriteLine("This is not a valid ID. Please enter a number as ID");
//                    idEntered = Console.ReadLine();
//                }
//                updateFields.ID = ID;


//                Console.WriteLine("Enter a title");
//                updateFields.Title = Console.ReadLine();


//                Console.WriteLine("Enter a description");
//                updateFields.Description = Console.ReadLine();


//                Console.WriteLine("Enter time to complete");
//                var timeToCompleteEntered = Console.ReadLine();
//                double TimeToMaster;
//                while (!double.TryParse(timeToCompleteEntered, out TimeToMaster))
//                {
//                    Console.WriteLine("This is not a valid time. Please enter a number as time to complete");
//                    timeToCompleteEntered = Console.ReadLine();
//                }
//                updateFields.TimeToMaster = Convert.ToDouble(TimeToMaster);


//                Console.WriteLine("Enter time spent");
//                double TimeSpent;
//                var timeSpentEntered = Console.ReadLine();
//                while (!double.TryParse(timeSpentEntered, out TimeSpent))
//                {
//                    Console.WriteLine("This is not a valid time. Please enter a number as time spent");
//                    timeSpentEntered = Console.ReadLine();
//                }
//                updateFields.TimeSpent = Convert.ToDouble(TimeSpent);

//                Console.WriteLine("Enter a source");
//                updateFields.Source = Console.ReadLine();


//                Console.WriteLine("Enter a start date (dd/mm/yyyy)");
//                DateTime date = DateTime.Parse(Console.ReadLine());
//                string formatted = date.ToString("dd-MM-yyyy");

//                DateTime StartLearningDate1 = Convert.ToDateTime(formatted);
//                updateFields.StartLearningDate = StartLearningDate1;


//                Console.WriteLine("Is the Topic1 still ongoing? (y / n)");
//                string inProg = Console.ReadLine();
//                updateFields.InProgress = true;
//                if (inProg != null && inProg == "n")
//                {
//                    Console.WriteLine("Enter a completion date (dd/mm/yyyy)");
//                    DateTime date1 = DateTime.Parse(Console.ReadLine());
//                    string formatted1 = date1.ToString("dd-MM-yyyy");
//                    DateTime CompletionDate1 = Convert.ToDateTime(formatted1);
//                    updateFields.CompletionDate = CompletionDate1;
//                    updateFields.InProgress = false;

//                    //lista.Add(new Topic1(ID, Title, Description, TimeToMaster, TimeSpent, Source, StartLearningDate, InProgress, CompletionDate));

//                    foreach (Topic1 i in query)
//                    {
//                        Console.WriteLine("ID: {0}", i.ID);
//                        Console.WriteLine("Title: {0}", i.Title);
//                        Console.WriteLine("Description: {0}", i.Description);
//                        Console.WriteLine("Estimated time to complete: {0}", i.TimeToMaster);
//                        Console.WriteLine("Time spent: {0}", i.TimeSpent);
//                        Console.WriteLine("Source: {0}", i.Source);
//                        Console.WriteLine("Start date: {0}", i.StartLearningDate);
//                        Console.WriteLine("Topic1 in progress: {0}", i.InProgress);
//                        if (i.InProgress == false)
//                        {
//                            Console.WriteLine("Completion date: {0}", i.CompletionDate);
//                            Console.WriteLine("The Topic1 lasted: " + (i.CompletionDate - i.StartLearningDate).TotalDays + " days");
//                        }
//                    }

//                }



//            }
//            else if (input == "2")
//            {
//                Console.WriteLine("Enter a title");
//                string Title = Console.ReadLine();

//                var query = lista.Where(c => c.Title == Title);

//                var updateFields = query.First();


//                Console.WriteLine("Enter an ID");
//                var idEntered = Console.ReadLine();
//                int ID;
//                while (!int.TryParse(idEntered, out ID))
//                {
//                    Console.WriteLine("This is not a valid ID. Please enter a number as ID");
//                    idEntered = Console.ReadLine();
//                }
//                updateFields.ID = ID;


//                Console.WriteLine("Enter a title");
//                updateFields.Title = Console.ReadLine();


//                Console.WriteLine("Enter a description");
//                updateFields.Description = Console.ReadLine();


//                Console.WriteLine("Enter time to complete");
//                var timeToCompleteEntered = Console.ReadLine();
//                double TimeToMaster;
//                while (!double.TryParse(timeToCompleteEntered, out TimeToMaster))
//                {
//                    Console.WriteLine("This is not a valid time. Please enter a number as time to complete");
//                    timeToCompleteEntered = Console.ReadLine();
//                }
//                updateFields.TimeToMaster = Convert.ToDouble(TimeToMaster);


//                Console.WriteLine("Enter time spent");
//                double TimeSpent;
//                var timeSpentEntered = Console.ReadLine();
//                while (!double.TryParse(timeSpentEntered, out TimeSpent))
//                {
//                    Console.WriteLine("This is not a valid time. Please enter a number as time spent");
//                    timeSpentEntered = Console.ReadLine();
//                }
//                updateFields.TimeSpent = Convert.ToDouble(TimeSpent);

//                Console.WriteLine("Enter a source");
//                updateFields.Source = Console.ReadLine();


//                Console.WriteLine("Enter a start date (dd/mm/yyyy)");
//                DateTime date = DateTime.Parse(Console.ReadLine());
//                string formatted = date.ToString("dd-MM-yyyy");

//                DateTime StartLearningDate1 = Convert.ToDateTime(formatted);
//                updateFields.StartLearningDate = StartLearningDate1;


//                Console.WriteLine("Is the Topic1 still ongoing? (y / n)");
//                string inProg = Console.ReadLine();
//                updateFields.InProgress = true;
//                if (inProg != null && inProg == "n")
//                {
//                    Console.WriteLine("Enter a completion date (dd/mm/yyyy)");
//                    DateTime date1 = DateTime.Parse(Console.ReadLine());
//                    string formatted1 = date1.ToString("dd-MM-yyyy");
//                    DateTime CompletionDate1 = Convert.ToDateTime(formatted1);
//                    updateFields.CompletionDate = CompletionDate1;
//                    updateFields.InProgress = false;



//                    foreach (Topic1 i in query)
//                    {
//                        Console.WriteLine("ID: {0}", i.ID);
//                        Console.WriteLine("Title: {0}", i.Title);
//                        Console.WriteLine("Description: {0}", i.Description);
//                        Console.WriteLine("Estimated time to complete: {0}", i.TimeToMaster);
//                        Console.WriteLine("Time spent: {0}", i.TimeSpent);
//                        Console.WriteLine("Source: {0}", i.Source);
//                        Console.WriteLine("Start date: {0}", i.StartLearningDate);
//                        Console.WriteLine("Topic1 in progress: {0}", i.InProgress);
//                        if (i.InProgress == false)
//                        {
//                            Console.WriteLine("Completion date: {0}", i.CompletionDate);
//                            Console.WriteLine("The Topic1 lasted: " + (i.CompletionDate - i.StartLearningDate).TotalDays + " days");
//                        }
//                    }

//                }


//            }
//            else
//            {
//                Console.WriteLine("Didn't find");
//            }

//        }


//    }

//}


