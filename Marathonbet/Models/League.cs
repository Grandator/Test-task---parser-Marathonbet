using System.Collections.Generic;

namespace Marathonbet.Models
{
    public class League
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Match> Matches { get; set; }
    }
}
