using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballApp
{
 
        public class RootObject
        {
            public int Count { get; set; }
            public Filters Filters { get; set; }
            public List<Competition> Competitions { get; set; }
        }

        public class Filters
        {
            public string Client { get; set; }
        }

        public class Competition
        {
            public int Id { get; set; }
            public Area Area { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public string Type { get; set; }
            public string Emblem { get; set; }
            public string Plan { get; set; }
            public Season CurrentSeason { get; set; }
            public int NumberOfAvailableSeasons { get; set; }
            public DateTime LastUpdated { get; set; }
        }

        public class Area
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public string Flag { get; set; }
        }

        public class Season
        {
            public int Id { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int CurrentMatchday { get; set; }
            public object Winner { get; set; } // kann auch null sein oder eine Klasse, wenn mehr Infos gebraucht werden
        }

    
}
