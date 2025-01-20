using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    public class Match
    {
        /// <summary>
        /// Герой #1 из матчапа
        /// </summary>
        private Hero hero_1;
       public Hero Hero_1 {  get { return hero_1; } set { hero_1 = value; } }


        /// <summary>
        /// Герой #2 из матчапа
        /// </summary>
        private Hero hero_2;
        public Hero Hero_2 { get { return hero_2; } set { hero_2 = value; } }

        /// <summary>
        /// Id матча
        /// </summary>
        private int matchId;
       // [JsonProperty("match_id")]
        public int MatchId { get { return matchId; } set { matchId = value; } }


        /// <summary>
        /// Герой победивший в матче
        /// </summary>
        private string winningHero;
        public string WinningHero { get { return winningHero; } set { winningHero = value; } }


    }
}
