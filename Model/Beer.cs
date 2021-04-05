using System;
using System.Collections.Generic;
using System.Text;

namespace TCPServerBeer.Model
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Abv { get; set; }
        // Abv = alcohol by volume

        public override string ToString()
        {
            return $"the beer have id {Id}, name {Name}, Price{Price}, and the abv is {Abv} ";
        }
    }
}
