using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Repositories
{
    public class FriendRequestRepository : IFriendRequestRepository
    {
        private readonly BMCEntities _context;

        public void AcceptRequest(int requestId)
        {
            var request = (from r in _context.FriendRequest
                           where r.RequestID == requestId
                           select r).SingleOrDefault();

            if (request != null)
            {
                request.RequestStatus = "Accepted";
                _context.SaveChanges();
            }
        }

        public IEnumerable<FriendRequest> GetReceivedRequests(int receiverPlayerId)
        {

            return from r in _context.FriendRequest
                   where r.ReceiverPlayerID == receiverPlayerId
                   select r;

        }

        public IEnumerable<FriendRequest> GetSentRequests(int senderPlayerId)
        {
            return from r in _context.FriendRequest
                   where r.SenderPlayerID == senderPlayerId
                   select r;
        }

        public bool IsFriendRequestPending(int senderPlayerId, int receiverPlayerId)
        {
            var query = from request in _context.FriendRequest
                        where request.SenderPlayerID == senderPlayerId
                              && request.ReceiverPlayerID == receiverPlayerId
                              && request.RequestStatus == "Pending"
                        select request;

            return query.Any();
        }

        public void RejectRequest(int requestId)
        {
            var request = (from r in _context.FriendRequest
                           where r.RequestID == requestId
                           select r).SingleOrDefault();

            if (request != null)
            {
                request.RequestStatus = "Rejected";
                _context.SaveChanges();
            }
        }

        public void RemoveFriend(int userId, int friendId)
        {

            var acceptedRequest = (from r in _context.FriendRequest
                                   where (r.SenderPlayerID == userId && r.ReceiverPlayerID == friendId)
                                      || (r.SenderPlayerID == friendId && r.ReceiverPlayerID == userId)
                                      && r.RequestStatus == "Accepted"
                                   select r).FirstOrDefault();

            if (acceptedRequest != null)
            {
                _context.FriendRequest.Remove(acceptedRequest);
                _context.SaveChanges();
            }
        }

        public void SendFriendRequest(int senderPlayerId, int receiverPlayerId)
        {
            var newRequest = new FriendRequest
            {
                SenderPlayerID = senderPlayerId,
                ReceiverPlayerID = receiverPlayerId,
                RequestStatus = "Pending"
            };

            _context.FriendRequest.Add(newRequest);
            _context.SaveChanges();
        }
    }
}
