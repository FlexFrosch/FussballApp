using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Formats.Asn1.AsnWriter;

namespace FussballApp
{
    // Großteil von ChatGPT machen lassen da es nur abschreib Arbeit war
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

    public class StandingsRoot
    {
        public Filters Filters { get; set; }
        public Area Area { get; set; }
        public Competition Competition { get; set; }
        public Season Season { get; set; }
        public List<Standing> Standings { get; set; }
    }

    public class TopScorersRoot
    {
        public int Count { get; set; }
        public Filters Filters { get; set; }
        public List<Scorer> Scorers { get; set; }
    }

    public class UeberpruefungsRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string League { get; set; }
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
        public object Winner { get; set; }
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
        public string ShortName { get; set; }
        public string Tla { get; set; }
        public string Crest { get; set; }
    }
    public class Time
    {
        public string Minutes { get; set; }
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
    public class Standing
    {
        public string Stage { get; set; }
        public string Type { get; set; }
        public object Group { get; set; }
        public List<TableItem> Table { get; set; }
    }
    public class TableItem
    {
        public int Position { get; set; }
        public Team Team { get; set; }
        public int PlayedGames { get; set; }
        public string Form { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }
        public int Points { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
    }
    public class Scorer
    {
        public Player Player { get; set; }
        public Team Team { get; set; }
        public int PlayedMatches { get; set; }
        public int Goals { get; set; }
        public int? Assists { get; set; }
        public int? Penalties { get; set; }
    }
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Section { get; set; }
        public object Position { get; set; }
        public int? ShirtNumber { get; set; }
        public string LastUpdated { get; set; }
    }
}
