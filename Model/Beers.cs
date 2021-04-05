using System;
using System.Collections.Generic;
using System.Text;

namespace TCPServerBeer.Model
{
    public static class Beers
    {
        public static List<Beer> BeerList = new List<Beer>()
        {
            new Beer {Id = 1, Name = "Carlsberg", Abv = 5, Price = 49 },
            new Beer {Id = 2, Name = "Turborg", Abv = 4, Price = 39}
        };

        public static List<Beer> GetAll()
        {
            return BeerList;
        }

        public static Beer GetById(int id)
        {
            return BeerList.Find(x => x.Id == id);
        }

        public static void Addbeer(Beer beer)
        {
            BeerList.Add(beer);
        }
    }
}
