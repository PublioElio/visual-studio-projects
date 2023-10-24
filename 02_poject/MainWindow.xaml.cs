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

namespace _02_poject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private class User
        {
            public string name { get; set; }
            public string surname { get; set; }
            public string adress { get; set; }
            public string phone { get; set; }
        }

        // I've used ObservableCollection because it's a data structure that allows notifying data changes (it implements the INotifyPropertyChanged interface)
        ObservableCollection<User> userList = new ObservableCollection<User> { };

        public MainWindow()
        {
            InitializeComponent();
            dataGridUsers.ItemsSource = userList;       
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name, surname, adress, phone;
            iniztalizeUser(out name, out surname, out adress, out phone);

            if (isFilled(name, surname, adress, phone))
            {
                userList.Add(new User { name = name, surname = surname, adress = adress, phone = phone });
                clearTexBoxes();
            }
            else
                MessageBox.Show("No es posible dejar campos en blanco.");

        }

        private void clearTexBoxes()
        {
            textBoxUserName.Clear();
            textBoxSurname.Clear();
            textBoxAdress.Clear();
            textBoxPhone.Clear();
        }

        private static bool isFilled(string name, string surname, string adress, string phone)
        {
            return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(adress) && !string.IsNullOrEmpty(phone);
        }

        private void iniztalizeUser(out string name, out string surname, out string adress, out string phone)
        {
            name = textBoxUserName.Text;
            surname = textBoxSurname.Text;
            adress = textBoxAdress.Text;
            phone = textBoxPhone.Text;
        }
    }
}
