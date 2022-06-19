namespace Viikko_1_tehtävä
{
    class Program
    {
        // Sovellus toteutettu käyttäen luokkaa, listaa sekä metodeja

        static void Main(string[] args)
        {
            //HUOM! Sovellus ei pysty vielä tässä vaiheessa poistamaan tai päivittämään tietoja tekstitiedostossa. 
            //Sovellus pystyy konsolin ollessa auki hakemaan, päivittämään ja poistamaan tietoja, ja ne ajetaan lopuksi tekstitiedostoon.
            //Tämän demonstroidakseni tein ensin 3 kertaa kerääTiedot-metodi joilla kerätään tiedot, sitten etsiIdtaiTitle-metodi jolla voi etsiä topicin,
            //sitten Update-metodin jolla voi päivittää topicin ja sitten Delete-metodi jolla voi poistaa topicin
            //Sitten sovellus tulostaa nämä topicit konsoliin 
            //Viimeisenä teksiTiedosto- metodi joka luo tekstitiedoston yllä olevilla topiceilla

            Topic.kerääTiedot();
            Topic.kerääTiedot();
            Topic.kerääTiedot();
            var lista = Topic.Topics;
            Topic.tulostaTiedot();
            Topic.EtsiIdtaiTitle(lista);
            Topic.tulostaTiedot();
            Topic.Update(lista);
            Topic.tulostaTiedot();
            Topic.Delete(lista);
            Topic.tulostaTiedot();

            Topic.teksiTiedosto();


        }
    }

}

