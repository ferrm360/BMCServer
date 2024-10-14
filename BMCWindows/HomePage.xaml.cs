using BMCWindows.Patterns.Singleton;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BMCWindows
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page, ChatServer.IChatServiceCallback
    {
        public ObservableCollection<Friend> Friends { get; set; }
        public ObservableCollection<Message> Messages { get; set; }
        public ChatService chatService = new ChatService();

        public HomePage()
        {
            InitializeComponent();
            Server.PlayerDTO player = new Server.PlayerDTO();
            player = UserSessionManager.getInstance().getPlayerUserData();
            InstanceContext context = new InstanceContext(this);
            ChatServer.ChatServiceClient proxy = new ChatServer.ChatServiceClient(context);
            proxy.RegisterUser(player.Username);
            LoadRecentMessages();

            Friends = new ObservableCollection<Friend>

        {
            new Friend { Name = "Marla" },
            new Friend { Name = "Tearp89" },
            new Friend { Name = "Swizzy" },
            new Friend { Name = "RAW" }
        };
            FriendsList.ItemsSource = Friends;
            Chat.ItemsSource = Friends;
            textBoxSearchFriends.TextChanged += SearchFriends;
            textBoxSearchFriendsChats.TextChanged += SearchFriendsChat;
        }

        private void SearchFriends(object sender, TextChangedEventArgs e)
        {
            var filtered = Friends.Where(f => f.Name.ToLower().Contains(textBoxSearchFriends.Text.ToLower())).ToList();
            FriendsList.ItemsSource = filtered;
        }

        private void SearchFriendsChat(object sender, TextChangedEventArgs e)
        {
            var filtered = Friends.Where(f => f.Name.ToLower().Contains(textBoxSearchFriendsChats.Text.ToLower())).ToList();
            Chat.ItemsSource = filtered;

        }

        private void FriendsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Chat.SelectedItem != null)
            {
                // Oculta la lista de amigos y muestra el chat
                Chat.Visibility = Visibility.Collapsed;
                ChatGrid.Visibility = Visibility.Visible;

                // Carga los mensajes de ejemplo
                Messages = new ObservableCollection<Message>
            {
                new Message { Sender = "Yo", Messages = "Hola!", TimeSent = DateTime.Now.AddMinutes(-10) },
                new Message { Sender = ((Friend)Chat.SelectedItem).Name, Messages = "Hola, ¿cómo estás?", TimeSent = DateTime.Now.AddMinutes(-9) }
            };

                MessagesList.ItemsSource = Messages;
            }
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext context = new InstanceContext(this);
            ChatServer.ChatServiceClient proxy = new ChatServer.ChatServiceClient(context);

            if (!string.IsNullOrEmpty(MessageTextBox.Text))
            {
                proxy.SendMessage("", MessageTextBox.Text);   
            }
        }

        private void BackToFriends_Click(object sender, RoutedEventArgs e)
        {
            ChatGrid.Visibility = Visibility.Collapsed;
            Chat.Visibility = Visibility.Visible;
        }

        private void LoadRecentMessages()
        {
            generalMessages.ItemsSource = null;  // Limpiar la fuente de datos
            var recentMessages = chatService.GetRecentMessages();
            generalMessages.ItemsSource = recentMessages;
        }

        private void SendGeneralMessage_Click(object sender, RoutedEventArgs e)
        {

            Server.PlayerDTO player = new Server.PlayerDTO();
            player = UserSessionManager.getInstance().getPlayerUserData();

            if (!string.IsNullOrEmpty(textboxGeneralChat.Text))
            {

                chatService.AddMessage(player.Username, textboxGeneralChat.Text);
                textboxGeneralChat.Clear();

                // Actualizar los mensajes mostrados en la interfaz
                LoadRecentMessages();
            }
        }

        public void ReceiveMessage(string message)
        {
            generalMessages.ItemsSource += message;
        }
    }

    public class Friend
    {
        public string Name { get; set; }
    }

    public class Message
    {
        public string Sender { get; set; }
        public string Messages { get; set; }
        public DateTime TimeSent { get; set; }
    }
}
