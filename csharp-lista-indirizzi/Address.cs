﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    internal class Address
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public int Zip { get; set; }

        //Costruttore
        public Address(string name, string surname, string street, string city, string province, int zip ) 
        {
            this.Name = name;
            this.Surname = surname;
            this.Street = street;
            this.City = city;
            this.Province = province;
            this.Zip = zip;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}, via: {Street}, città: {City} ({Province}), cap: {Zip}";
        }
    }
}
