using System.Text;
using System;

namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //nome progetto: **csharp - lista - indirizzi * *
            //nome repo: **csharp - lista - indirizzi * *
            //Oggi esercitazione sui file, ossia vi chiedo di prendere dimestichezza con quanto appena visto sui file in classe,
            //in particolare nel live - coding di oggi.
            //In questo esercizio dovrete leggere un file CSV, che cambia poco da quanto appena visto nel live-coding in classe,
            //e salvare tutti gli indirizzi in esso contenuti all’interno di una lista di oggetti istanziati
            //a partire dalla classe Indirizzo.
            //**Attenzione:**gli ultimi 3 indirizzi presentano dei possibili “casi particolari” che possono accadere a questo genere 
            //di file: vi chiedo di pensarci e di gestire come meglio crediate queste casistiche.

            //----------------------------------------------------------------------------------

            List<Address> addresses = new List<Address>();  

            //Definiamo una stringa per importare il file
            string path = "C:\\Users\\Federico\\source\\repos\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\addresses.csv";

            //Lettura da oggetto a testo
            var text = File.OpenText(path);

            int i = 0;
            while (text.EndOfStream == false)
            {
                //Console.WriteLine($"Sono in posizione {text.BaseStream.Position}/{text.BaseStream.Length}");

                var line = text.ReadLine();
                //Console.WriteLine(line);

                i++;
                if (i <= 1) //ignoro la prima riga
                    continue;

                try
                {
                    //ogni linea corristoponde ad un indirizzo
                    var data = line.Split(',');
                    string name = data[0];
                    string surname = data[1];
                    string street = data[2];
                    string city = data[3];
                    string province = data[4];
                    int zip = int.Parse(data[5]);

                    Address a = new Address(name, surname, street, city, province, zip);
                    addresses.Add(a);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            }

            foreach (var address in addresses)
                Console.WriteLine(address.ToString());

            //Bonus: iterare la lista di indirizzi e risalvarli in un file.

        }
    }
}
