using DataAccessBMC.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessBMC.Repositories.Implementations
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly BMCContext _context;

        public PlayerRepository(BMCContext context)
        {
            _context = context;
        }

        public void DeletePlayer(int id)
        {
            var player = _context.Player.Find(id);
            if (player != null)
            {
                _context.Player.Remove(player);
            }
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _context.Player.ToList();
        }

        public Player GetPlayerById(int id)
        {
            return _context.Player.Find(id);
        }

        public void InsertPlayer(Player player)
        {
            _context.Player.Add(player);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdatePlayer(Player player)
        {
            var recoveredPlayer = _context.Player.Find(player.PlayerID);

            if (recoveredPlayer != null)
            {
                _context.Entry(recoveredPlayer).CurrentValues.SetValues(player);
                _context.SaveChanges();
            }
        }

        public Player FindByUsername(string username)
        {
            var query = from player in _context.Player
                        where player.Username == username
                        select player;

            return query.SingleOrDefault();
        }
    }
}
