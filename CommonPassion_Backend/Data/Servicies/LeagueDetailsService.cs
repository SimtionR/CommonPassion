using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Servicies
{
    public class LeagueDetailsService : ILeagueDetailsService
    {
        private readonly CommonPassionDbContext _ctx;
        public LeagueDetailsService(CommonPassionDbContext ctx)
        {
            _ctx = ctx;     
        }
        public async Task<LeagueDetails> CreateLeagueDetailsAsync(string name, int leagueId)
        {
            var leagueDetails = new LeagueDetails
            {
                LeagueId = leagueId,
                Name = name
            };

            _ctx.LeagueDetails.Add(leagueDetails);
            await _ctx.SaveChangesAsync();
            return leagueDetails;
        }

        public async Task<LeagueDetails> GetLeagueDetailsByIdAsync(int id)
        {
            return await _ctx.LeagueDetails.Where(l => l.Id == id).FirstOrDefaultAsync();
        }
    }
}
