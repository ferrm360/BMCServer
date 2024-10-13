using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    public partial class HomePage : Page
    {
        public ObservableCollection<Friend> Friends { get; set; }
        public ObservableCollection<Message> Messages { get; set; }

        public HomePage()
        {
            InitializeComponent();
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
            if (FriendsList.SelectedItem != null)
            {
                // Oculta la lista de amigos y muestra el chat
                FriendsList.Visibility = Visibility.Collapsed;
                ChatGrid.Visibility = Visibility.Visible;

                // Carga los mensajes de ejemplo
                Messages = new ObservableCollection<Message>
            {
                new Message { Sender = "Yo", Messages = "Hola!", TimeSent = DateTime.Now.AddMinutes(-10) },
                new Message { Sender = ((Friend)FriendsList.SelectedItem).Name, Messages = "Hola, ¿cómo estás?", TimeSent = DateTime.Now.AddMinutes(-9) }
            };

                MessagesList.ItemsSource = Messages;
            }
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MessageTextBox.Text))
            {
                Messages.Add(new Message
                {
                    Sender = "Yo",
                    Messages = MessageTextBox.Text,
                    TimeSent = DateTime.Now
                });

                MessageTextBox.Clear();
            }
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
