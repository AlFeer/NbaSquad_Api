using NbaSquad.Models;

namespace NbaSquad.Interfaces
{
    public interface ITeamRepository
    {
        Task<ICollection<Team>> GetTeams();
        Task<Team> GetTeam(int id);
        Task CreateTeam(Team team);
        Task UpdateTeam(Team team);
        Task DeleteTeam(Team team);
    }
}