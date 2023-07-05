using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NbaSquad.Data;
using NbaSquad.Interfaces;
using NbaSquad.Models;

namespace NbaSquad.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DataContext _context;

        public TeamRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Team> GetTeam(int id)
        {
            return await _context.Teams.Include(n => n.Players).Where(n => n.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Team>> GetTeams()
        {
            return await _context.Teams.Include(n => n.Players).ToListAsync();
        }
        public async Task CreateTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeam(Team team)
        {
            _context.Update(team);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeam(Team team)
        {
            _context.Remove(team);
            await _context.SaveChangesAsync();
        }
    }
}
