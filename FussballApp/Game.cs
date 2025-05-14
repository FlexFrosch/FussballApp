using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballApp
{
    class Game
    {
        private Team Team1 { get; set; }
        private Team Team2 { get; set; }
        private int Score1 { get; set; }
        private int Score2 { get; set; }
        private int Time { get; set; }
        private League League { get; set; }

        public Game(Team Team1, Team Team2, League League)
        {
            this.Team1 = Team1;
            this.Team2 = Team2;
            this.League = League;
        }

        public void UpdateScore()
        {
        }

        public string GetScore()
        {
            string score = $"{Score1}:{Score2}";
            return score;
        }
    }
}
