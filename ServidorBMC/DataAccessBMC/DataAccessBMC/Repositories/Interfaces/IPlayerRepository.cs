using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessBMC.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAllPlayers();
        Player GetPlayerById(int id);
        void InsertPlayer(Player player);
        void UpdatePlayer(Player player);
        void DeletePlayer(int id);
        Player FindByUsername (string username);
        void Save();
    }
}
