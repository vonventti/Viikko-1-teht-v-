using System;


namespace Viikko_1_tehtävä
{
    class Program
    {


        static void Main(string[] args)
        {
            //ClassLibrary käytetään tässä 1
            Console.WriteLine("Jos haluat syöttää uuden topicin, paina 1");
            Console.WriteLine("Jos haluat etsiä topicin Id:n tai Titlen perusteella, paina 2");
            Console.WriteLine("Jos haluat poistaa topicin, paina 3");
            Console.WriteLine("Jos haluat päivittää topicin tietoja Id:n tai Titlen perusteella, paina 4");
            Console.WriteLine("Jos haluat nähdä kaikki syötetyt topicit, paina 5");
            var syöte = Console.ReadLine();

            if (syöte == "1")
            {
                Metodit.SyötäUusi();
            }
            else if (syöte == "2")
            {
                Metodit.EtsiTopic();
            }
            else if (syöte == "3")
            {
                Metodit.PoistaTopic();
            }
            else if (syöte == "4")
            {
                Metodit.MuokkaaTopic();
            }
            else if (syöte == "5")
            {
                Metodit.TulostaKaikki();
            }
        }
    }
}




