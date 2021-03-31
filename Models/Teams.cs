using System;
using System.Collections.Generic;

namespace Mike10.Models
{
    public partial class Teams
    {
        public Teams()
        {
            Bowlers = new HashSet<Bowlers>();
            TourneyMatchesEvenLaneTeam = new HashSet<TourneyMatches>();
            TourneyMatchesOddLaneTeam = new HashSet<TourneyMatches>();
        }

        public long TeamId { get; set; }
        public string TeamName { get; set; }
        public long? CaptainId { get; set; }

        public virtual ICollection<Bowlers> Bowlers { get; set; }
        public virtual ICollection<TourneyMatches> TourneyMatchesEvenLaneTeam { get; set; }
        public virtual ICollection<TourneyMatches> TourneyMatchesOddLaneTeam { get; set; }
    }
}
