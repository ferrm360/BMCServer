using DataAccess.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess.Repositories
{
    public class PlayerScoresRepository : IPlayerScoresRepository
    {
        private readonly BMCEntities _context;

        public PlayerScoresRepository(BMCEntities context)
        {
            _context = context;
        }

        public UserScores GetScoresByPlayerId(int playerId)
        {
            if (playerId <= 0)
            {
                throw new ArgumentException("Player ID must be greater than zero.", nameof(playerId));
            }

            try
            {
                return _context.UserScores.FirstOrDefault(us => us.PlayerID == playerId);
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An unexpected error occurred while retrieving scores by player ID.", ex);
            }
        }

        public IEnumerable<UserScores> GetTopScores(int top)
        {
            if (top <= 0)
            {
                throw new ArgumentException("Top value must be greater than zero.", nameof(top));
            }

            try
            {
                return _context.UserScores.OrderByDescending(us => us.Wins).Take(top).ToList();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An unexpected error occurred while retrieving top scores.", ex);
            }
        }

        public void IncrementWins(int playerId)
        {
            if (playerId <= 0)
            {
                throw new ArgumentException("Player ID must be greater than zero.", nameof(playerId));
            }

            try
            {
                EnsureScoreExists(playerId);
                var scores = GetScoresByPlayerId(playerId);
                if (scores == null)
                {
                    throw new InvalidOperationException($"No scores found for player with ID {playerId}.");
                }

                scores.Wins++;
                Update(scores);
                Save();
            }
            catch (DbUpdateException ex)
            {
                throw new DataAccessException("Error occurred while updating the database during win increment.", ex);
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An unexpected error occurred while incrementing wins.", ex);
            }
        }

        public void IncrementLosses(int playerId)
        {
            if (playerId <= 0)
            {
                throw new ArgumentException("Player ID must be greater than zero.", nameof(playerId));
            }

            try
            {
                EnsureScoreExists(playerId);
                var scores = GetScoresByPlayerId(playerId);
                if (scores == null)
                {
                    throw new InvalidOperationException($"No scores found for player with ID {playerId}.");
                }

                scores.Losses++;
                Update(scores);
                Save();
            }
            catch (DbUpdateException ex)
            {
                throw new DataAccessException("Error occurred while updating the database during loss increment.", ex);
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An unexpected error occurred while incrementing losses.", ex);
            }
        }

        private void EnsureScoreExists(int playerId)
        {
            var existingScore = GetScoresByPlayerId(playerId);
            if (existingScore == null)
            {
                AddScore(playerId);
            }
        }

        private void AddScore(int playerId)
        {
            var newScores = new UserScores
            {
                PlayerID = playerId,
                Wins = 0,
                Losses = 0
            };

            _context.UserScores.Add(newScores);
            Save();
        }

        private void Update(UserScores scores)
        {
            _context.Entry(scores).State = System.Data.Entity.EntityState.Modified;
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
