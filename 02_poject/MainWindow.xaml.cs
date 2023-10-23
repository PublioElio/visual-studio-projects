using System;
using System.Collections.Generic;
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

namespace _02_poject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> userList = new List<User> { };

        public MainWindow()
        {
            InitializeComponent();
            dataGridUsers.ItemsSource = userList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            User user = new User();
            user.name = textBoxUserName.Text;
            user.surname = textBoxSurname.Text;
            user.adress = textBoxAdress.Text;
            user.phone = textBoxPhone.Text;
            userList.Add(user);
            
        }

        private class User
        {
            public string name { get; set; }
            public string surname { get; set; }
            public string adress { get; set; }
            public string phone { get; set; }
        }
    }
}
