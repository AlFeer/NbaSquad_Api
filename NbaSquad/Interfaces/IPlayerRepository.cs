using NbaSquad.Models;

namespace NbaSquad.Interfaces
{
    public interface IPlayerRepository
    {
        Task<ICollection<Player>> GetPlayers();
        Task<Player> GetPlayer(int id);
        Task CreatePlayer(Player player);
        Task UpdatePlayer(Player player);
        Task DeletePlayer(Player player);
    }
}