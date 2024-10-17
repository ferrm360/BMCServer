using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IPlayerScoresRepository
    {
        IEnumerable<UserScores> GetTopScores(int top);
        UserScores GetScoresByPlayerId(int playerId);
        void IncrementWins(int playerId);
        void IncrementLosses(int playerId);
    }
}
