using NbaSquad.Models;

namespace NbaSquad.Dto
{
    public class TeamResponse
    {
        public string Name { get; set; }
        public ICollection<PlayerResponse>? Players { get; set; }
    }
}
