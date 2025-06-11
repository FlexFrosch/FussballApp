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
    public class MatchRoot
    {
        public int Count { get; set; }
        public Filters Filters { get; set; }
        public List<Match> Matches { get; set; }
    }

    public class CompetitionTeamsRoot
    {
        public int Count { get; set; }
        public Filters Filters { get; set; }
        public Competition Competition { get; set; }
        public Season Season { get; set; }
        public List<Team> Teams { get; set; }
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

    public class Match
    {
        public int Id { get; set; }
        public Season Season { get; set; }
        public DateTime UtcDate { get; set; }
        public string Status { get; set; }
        public int Matchday { get; set; }
        public string Stage { get; set; }
        public string Group { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public Score Score { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Time
    {
        public string Minutes = "90";
    }
    public class Score
    {
        public string Winner { get; set; }
        public ScoreDetails FullTime { get; set; }
        public ScoreDetails HalfTime { get; set; }
        public string ScoreString { get; set; }
    }

    public class ScoreDetails
    {
        public int? Home { get; set; }
        public int? Away { get; set; }
    }
}
