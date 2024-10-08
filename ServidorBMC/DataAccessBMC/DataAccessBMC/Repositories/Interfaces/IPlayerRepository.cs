using DataAccessBMC.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessBMC.Repositories.Interfaces
{
    public interface IPlayerRepository : IGenericRepository<Player>
    {
        Player GetByUsername (string username);
        Player GetByEmail(string email);
        void UpdatePasswordHash(int player, string passwordHash);
    }
}
