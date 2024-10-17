using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repostitories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly BMCEntities _context;

        // Constructor que recibe el contexto
        public PlayerRepository(BMCEntities context)
        {
            _context = context;
        }


        public Player GetByUsername(string username)
        {
            return _context.Player.SingleOrDefault(p => p.Username == username);
        }

        public Player GetByEmail(string email)
        {
            return _context.Player.SingleOrDefault(p => p.Email == email);
        }

        public void Add(Player player)
        {
            _context.Player.Add(player);
            _context.SaveChanges(); // Guardar los cambios en la base de datos
        }

        public void UpdatePasswordHash(string username, string passwordHash)
        {
            
         var player = GetByUsername(username);
         if (player != null)
         {
            player.PasswordHash = passwordHash;
            _context.Entry(player).State = EntityState.Modified;
            _context.SaveChanges();
         }
            
        }
    }
}
