using System.Text;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Net;

namespace csharp_lista_indirizzi
{
    internal class Program
    {
        // Funzione per leggere il file testo
        public static List<Address> ReadFromText(string path)
        {
            List<Address> addresses = new List<Address>();

            //Lettura da oggetto a testo
            var stream = File.OpenText(path);

            int i = 0;
            while (stream.EndOfStream == false)
            {
                //Console.WriteLine($"Sono in posizione {text.BaseStream.Position}/{text.BaseStream.Length}");

                var line = stream.ReadLine();
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

                    //Nel caso in cui nel zip(cap) viene inserita una stringa al posto del numero
                    if (!int.TryParse(data[5], out zip))
                    {

                        Console.WriteLine($"Il cap '{data[5]}' non è un numero valido.");
                        continue;
                    }

                    //Se i nomi o i cognomi non sono presenti quindi stringa vuota
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        name = "nessun nome";
                    }

                    if (string.IsNullOrWhiteSpace(surname))
                    {
                        surname = "nessun cognome";
                    }

                    Address addressNew = new Address(name, surname, street, city, province, zip);
                    addresses.Add(addressNew);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(" ");
                }

            }

            stream.Close();

            return addresses;
        }

        //Funzione che ricavo dalla mia lista di indirizzi e la scrivo in un file di testo
        public static void WriteInText(List<Address> addresses, string path)
        {
           StreamWriter stream = File.CreateText(path);
            foreach (var address in addresses)
            {
                stream.WriteLine(address.ToString());
            }

            stream.Close();
        }
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

            //Definiamo una stringa per importare il file
            string path = "C:\\Users\\Federico\\source\\repos\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\addresses.csv";

            var addresses = ReadFromText(path);

            foreach(var address in addresses)
            {
                Console.WriteLine(address.ToString());
                Console.WriteLine(" ");
            }

            //Bonus: iterare la lista di indirizzi e risalvarli in un file.

            string pathWrite = "C:\\Users\\Federico\\source\\repos\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\addressesWrite.txt";
            WriteInText(addresses, pathWrite);
        }
    }
}
