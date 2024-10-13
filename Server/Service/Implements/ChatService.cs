using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implements
{
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class ChatService : IChatService
    {
        private readonly Dictionary<string, IChatServiceCallback> _connectedUsers = new Dictionary<string, IChatServiceCallback>();

        public void RegisterUser(string username)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IChatServiceCallback>();

            if (!_connectedUsers.ContainsKey(username))
            {
                _connectedUsers.Add(username, callback);

                SendMessage("System", $"{username} has joined the chat.");
            }
        }

        public void DisconnectUser(string username)
        {
            if (_connectedUsers.ContainsKey(username))
            {
                _connectedUsers.Remove(username);

                SendMessage("System", $"{username} has left the chat.");
            }
        }

        public void SendMessage(string username, string message)
        {
            string fullMessage = $"{username}: {message}";

            foreach (var userCallback in _connectedUsers.Values)
            {
                try
                {
                    userCallback.ReceiveMessage(fullMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending message to {username}: {ex.Message}");
                }
            }
        }
    }
}

