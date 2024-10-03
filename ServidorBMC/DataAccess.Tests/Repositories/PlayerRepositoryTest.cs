using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Xunit;
using Moq;
using DataAccessBMC;
using DataAccessBMC.Repositories.Implementations;
using System.Runtime.Remoting.Contexts;

namespace DataAccess.Tests.Repositories
{
    public class PlayerRepositoryTest
    {
        private readonly BMCDBEntities _context;
   
        public PlayerRepositoryTest()
        {
            _context = new BMCDBEntities();
        }

        
        [Fact]
        public void Dispose()
        {
            ResetIdentity("Player");
            _context.Dispose();
        }
       
        [Fact]
        public void InsertPlayerSuccess()
        {
            var repository = new PlayerRepository(_context);
            var player = new Player { Username = "FerRMZ", Email = "ferram2@gmail.com", PasswordHash = "ferr2000"};

            
            repository.Add(player);
            repository.Save();

            var insertedPlayer = _context.Player.SingleOrDefault(p => p.Username == "FerRMZ");
            Assert.Equal("FerRMZ", insertedPlayer.Username);
        }

        private void ResetIdentity(string tableName)
        {
            string resetCommand = $"DBCC CHECKIDENT ('Player', RESEED, 0);";

            _context.Database.ExecuteSqlCommand(resetCommand);
            _context.Database.ExecuteSqlCommand("DELETE FROM Player");     
        }
    }


}
