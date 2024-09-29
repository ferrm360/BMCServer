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

        private readonly BMCContext _context;
        private DbContextTransaction _transaction;

        
        public PlayerRepositoryTest()
        {
            _context = new BMCContext();

            _transaction = _context.Database.BeginTransaction();
        }

        
        [Fact]
        public void Dispose()
        {
            ResetIdentity("Player");
            _context.Dispose();
            _transaction.Rollback();
            _transaction.Dispose();
            _context.Dispose();
        }
       
        [Fact]
        public void InsertPlayerSuccess()
        {
            var repository = new PlayerRepository(_context);
            var player = new Player { Username = "FerRMZ", Email = "ferram200011@gmail.com", PasswordHash = "neco2000"};

            
            repository.InsertPlayer(player);
            repository.Save();

            var insertedPlayer = _context.Player.SingleOrDefault(p => p.Username == "FerRMZ");
            Assert.NotNull(insertedPlayer);
            Assert.Equal("FerRMZ", insertedPlayer.Username);
        }

        private void ResetIdentity(string tableName)
        {
            string resetCommand = $"DBCC CHECKIDENT ('{tableName}', RESEED, 0);";

            _context.Database.ExecuteSqlCommand(resetCommand);
        }
    }


}
