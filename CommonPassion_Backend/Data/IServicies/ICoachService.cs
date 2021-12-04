using CommonPassion_Backend.Data.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface ICoachService
    {
        Task<ApiCoach> GetCoachByTeamId(int teamId);
        Task<ApiCoach> GetCoachByName(string coachName);

    }
}
