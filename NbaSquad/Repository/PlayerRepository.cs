using Microsoft.EntityFrameworkCore;
using NbaSquad.Data;
using NbaSquad.Interfaces;
using NbaSquad.Models;

namespace NbaSquad.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DataContext _context;

        public PlayerRepository(DataContext context)
        {
            _context = context;
        }

        public  async Task<ICollection<Player>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player> GetPlayer(int id)
        {
            return await _context.Players.Where(n => n.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreatePlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlayer(Player player)
        {
            _context.Update(player);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlayer(Player player)
        {
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }
    }
}