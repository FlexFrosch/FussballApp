using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballApp
{
    //class Profile
    //{
    //    public List<League> FavoriteLeagues { get; set; } = new List<League>();
    //    public List<Team> FavoriteTeams { get; set;} = new List<Team>();

    //    Profile()
    //    {

    //    }

    //    public void AddLeague(League league)
    //    {
    //        FavoriteLeagues.Add(league);
    //    }
    //    public void RemoveLeague(League league)
    //    {
    //        FavoriteLeagues.Remove(league);
    //    }

    //    public void AddTeam(Team team)
    //    {
    //        FavoriteTeams.Add(team);
    //    }
    //    public void RemoveTeam(Team team)
    //    {
    //        FavoriteTeams.Remove(team);
    //    }
    //}

    // Datei: Profile.cs
 
        public class Profile
        {
            public string Team { get; set; }
            public string Liga { get; set; }

            public string Serialize() => $"{Team}:{Liga}";

            public static Profile Deserialize(string serialized)
            {
                var parts = serialized.Split(':');
                if (parts.Length < 2)
                    throw new FormatException("Ungültiges Profil-Format");
                return new Profile
                {
                    Team = parts[0],
                    Liga = parts[1]
                };
            }
        }
    }


