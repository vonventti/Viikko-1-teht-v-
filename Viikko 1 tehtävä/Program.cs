using System;
using System.Linq;
using Viikko_1_tehtävä.Models;

namespace Viikko_1_tehtävä
{
    class Program
    {


        static void Main(string[] args)
        {


            int ID, TimeToMaster, TimeSpent;
            string Title, Description, Source, inProg;
            DateTime StartLearningDate;
            bool InProgress;



            using (LearningDiaryContext conn = new LearningDiaryContext())
            {
                Console.WriteLine("Jos haluat syöttää uuden topicin, paina 1");
                Console.WriteLine("Jos haluat etsiä topicin ID:n tai Titlen perusteella, paina 2");
                Console.WriteLine("Jos haluat poistaa topicin, paina 3");
                Console.WriteLine("Jos haluat päivittää topicin tietoja ID:n tai Titlen perusteella, paina 4");
                Console.WriteLine("Jos haluat nähdä kaikki syötetyt topicit, paina 5");
                var syöte = Console.ReadLine();
                if (syöte == "1")
                {
                    Console.WriteLine("Enter an ID");
                    var idEntered = Console.ReadLine();
                    while (!int.TryParse(idEntered, out ID))
                    {
                        Console.WriteLine("This is not a valid ID. Please enter a number as ID");
                        idEntered = Console.ReadLine();
                    }



                    Console.WriteLine("Enter a title");
                    Title = Console.ReadLine();


                    Console.WriteLine("Enter a description");
                    Description = Console.ReadLine();


                    Console.WriteLine("Enter time to complete");
                    var timeToCompleteEntered = Console.ReadLine();
                    while (!int.TryParse(timeToCompleteEntered, out TimeToMaster))
                    {
                        Console.WriteLine("This is not a valid time. Please enter a number as time to complete");
                        timeToCompleteEntered = Console.ReadLine();
                    }
                    TimeToMaster = Convert.ToInt32(TimeToMaster);


                    Console.WriteLine("Enter time spent");
                    var timeSpentEntered = Console.ReadLine();
                    while (!int.TryParse(timeSpentEntered, out TimeSpent))
                    {
                        Console.WriteLine("This is not a valid time. Please enter a number as time spent");
                        timeSpentEntered = Console.ReadLine();
                    }
                    TimeSpent = Convert.ToInt32(TimeSpent);

                    Console.WriteLine("Enter a source");
                    Source = Console.ReadLine();


                    Console.WriteLine("Enter a start date (dd/mm/yyyy)");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    string formatted = date.ToString("dd-MM-yyyy");

                    DateTime StartLearningDate1 = Convert.ToDateTime(formatted);
                    StartLearningDate = StartLearningDate1;


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
                        Console.WriteLine("Invalid value");
                    }


                    Topic uusi = new Topic()
                    {
                        ID = ID,
                        Description = Description,
                        Title = Title,
                        TimeToMaster = TimeToMaster,
                        TimeSpent = TimeSpent,
                        Source = Source,
                        StartLearningDate = StartLearningDate,
                        InProgress = InProgress
                    };

                    conn.Topics.Add(uusi);
                    var tulostus = conn.Topics.Select(t => t);

                    foreach (var i in tulostus)
                    {
                        Console.WriteLine("ID: {0}", i.ID);
                        Console.WriteLine("Title: {0}", i.Title);
                        Console.WriteLine("Description: {0}", i.Description);
                        Console.WriteLine("Estimated time to complete: {0}", i.TimeToMaster);
                        Console.WriteLine("Time spent: {0}", i.TimeSpent);
                        Console.WriteLine("Source: {0}", i.Source);
                        Console.WriteLine("Start date: {0}", i.StartLearningDate);
                        Console.WriteLine("Topic in progress: {0}", i.InProgress);

                    }

                    conn.SaveChanges();
                }
                else if (syöte == "2")
                {
                    Console.WriteLine("Syötä '1' jos haluat etsiä ID:n perusteella, tai '2' jos haluat etsiä otsikon perusteella");
                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.WriteLine("Enter ID to search");
                        var idEntered = Console.ReadLine();
                        while (!int.TryParse(idEntered, out ID))
                        {
                            Console.WriteLine("This is not a valid ID. Please enter a number as ID");
                            idEntered = Console.ReadLine();
                        }
                        var tulostus = conn.Topics.Select(t => t);
                        var searchById = tulostus.Where(t => t.ID == ID);

                        foreach (var i in searchById)
                        {
                            Console.WriteLine("ID: {0}", i.ID);
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
                            Console.WriteLine("ID: {0}", i.ID);
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
                else if (syöte == "3")
                {
                    Console.WriteLine("Syötä '1' jos haluat poistaa ID:n perusteella, tai '2' jos haluat poistaa otsikon perusteella");
                    var input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.WriteLine("Enter an ID");
                        var idEntered = Console.ReadLine();
                        while (!int.TryParse(idEntered, out ID))
                        {
                            Console.WriteLine("This is not a valid ID. Please enter a number as ID");
                            idEntered = Console.ReadLine();
                        }
                        conn.Remove(conn.Topics.Single(x => x.ID == ID));

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
                else if (syöte == "4")
                {
                    Console.WriteLine("Syötä '1' jos haluat päivittää tietoja ID:n perusteella, tai '2' jos haluat päivittää tietoja otsikon perusteella");
                    var input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.WriteLine("Enter ID to search");
                        var idEntered = Console.ReadLine();

                        while (!int.TryParse(idEntered, out ID))
                        {
                            Console.WriteLine("This is not a valid ID. Please enter a number as ID");
                            idEntered = Console.ReadLine();
                        }
                        var tulostus = conn.Topics.Select(t => t);
                        var query = tulostus.Where(c => c.ID == ID);

                        var updateFields = query.First();



                        //Console.WriteLine("Enter an ID");
                        //idEntered = Console.ReadLine();

                        //while (!int.TryParse(idEntered, out ID))
                        //{
                        //    Console.WriteLine("This is not a valid ID. Please enter a number as ID");
                        //    idEntered = Console.ReadLine();
                        //}
                        //updateFields.ID = ID;


                        Console.WriteLine("Enter a title");
                        updateFields.Title = Console.ReadLine();


                        Console.WriteLine("Enter a description");
                        updateFields.Description = Console.ReadLine();


                        Console.WriteLine("Enter time to complete");
                        var timeToCompleteEntered = Console.ReadLine();

                        while (!int.TryParse(timeToCompleteEntered, out TimeToMaster))
                        {
                            Console.WriteLine("This is not a valid time. Please enter a number as time to complete");
                            timeToCompleteEntered = Console.ReadLine();
                        }
                        updateFields.TimeToMaster = Convert.ToInt32(TimeToMaster);


                        Console.WriteLine("Enter time spent");
                        var timeSpentEntered = Console.ReadLine();
                        while (!int.TryParse(timeSpentEntered, out TimeSpent))
                        {
                            Console.WriteLine("This is not a valid time. Please enter a number as time spent");
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
                            Console.WriteLine("Invalid value");
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


                        //Console.WriteLine("Enter an ID");
                        //idEntered = Console.ReadLine();

                        //while (!int.TryParse(idEntered, out ID))
                        //{
                        //    Console.WriteLine("This is not a valid ID. Please enter a number as ID");
                        //    idEntered = Console.ReadLine();
                        //}
                        //updateFields.ID = ID;


                        Console.WriteLine("Enter a title");
                        updateFields.Title = Console.ReadLine();


                        Console.WriteLine("Enter a description");
                        updateFields.Description = Console.ReadLine();


                        Console.WriteLine("Enter time to complete");
                        var timeToCompleteEntered = Console.ReadLine();

                        while (!int.TryParse(timeToCompleteEntered, out TimeToMaster))
                        {
                            Console.WriteLine("This is not a valid time. Please enter a number as time to complete");
                            timeToCompleteEntered = Console.ReadLine();
                        }
                        updateFields.TimeToMaster = Convert.ToInt32(TimeToMaster);


                        Console.WriteLine("Enter time spent");
                        var timeSpentEntered = Console.ReadLine();
                        while (!int.TryParse(timeSpentEntered, out TimeSpent))
                        {
                            Console.WriteLine("This is not a valid time. Please enter a number as time spent");
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
                            Console.WriteLine("Invalid value");
                        }

                        updateFields.InProgress = InProgress;



                    }
                    else
                    {
                        Console.WriteLine("Didn't find");
                    }
                    conn.SaveChanges();

                }
                else if (syöte == "5")
                {
                    var tulostus = conn.Topics.Select(t => t);

                    foreach (var i in tulostus)
                    {
                        Console.WriteLine("ID: {0}", i.ID);
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
                    Console.WriteLine("Virheellinen syöte");
                }
            }
        }
    }
}




