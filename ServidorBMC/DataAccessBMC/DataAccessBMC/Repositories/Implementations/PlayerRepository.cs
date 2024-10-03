using DataAccessBMC.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessBMC.Repositories.Implementations
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {

        public PlayerRepository(BMCDBEntities context) : base(context){}

        public Player GetByUsername(string username)
        {
            var query = from player in _context.Player
                        where player.Username == username
                        select player;

            return query.SingleOrDefault();
        }

        public Player GetByEmail(string email)
        {
            var query = from player in _context.Player
                        where player.Email == email
                        select player;

            return query.SingleOrDefault();
        }

        public void UpdatePasswordHash(int playerId, string passwordHash)
        {
            var player = GetById(playerId);
            if (player != null)
            {
                player.PasswordHash = passwordHash;
                Update(player);
                Save();
            }
        }
    }
}
