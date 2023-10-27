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

            // Creating focus events for the text boxes
            TextBoxFocusEvents(textBoxUserName);
            TextBoxFocusEvents(textBoxSurname);
            TextBoxFocusEvents(textBoxAdress);
            TextBoxFocusEvents(textBoxPhone);
        }

        private void TextBoxFocusEvents(TextBox textBox)
        {
            textBox.GotFocus += textBox_gotFocus;
            textBox.LostFocus += textBox_LostFocus;
        }

        private void textBox_gotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
                textBox.Background = Brushes.Coral;
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
                textBox.Background = Brushes.White;
        }

        private void aceptar_Click(object sender, RoutedEventArgs e)
        {
            string name, surname, adress, phone;
            initalizeUser(out name, out surname, out adress, out phone);

            if (isFilled(name, surname, adress, phone))
            {
                if (dataGridUsers.SelectedItem != null)
                {
                    User selectedUser = (User)dataGridUsers.SelectedItem;
                    selectedUser.name = textBoxUserName.Text;
                    selectedUser.surname = textBoxSurname.Text;
                    selectedUser.adress = textBoxAdress.Text;
                    selectedUser.phone = textBoxPhone.Text;
                    dataGridUsers.Items.Refresh();
                    dataGridUsers.SelectedItem = null;
                }
                else
                {
                    userList.Add(new User { name = name, surname = surname, adress = adress, phone = phone });
                }
                dataGridUsers.Items.Refresh();
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

        private void initalizeUser(out string name, out string surname, out string adress, out string phone)
        {
            name = textBoxUserName.Text;
            surname = textBoxSurname.Text;
            adress = textBoxAdress.Text;
            phone = textBoxPhone.Text;
        }
        
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridUsers.SelectedItem != null)
            {
                User selectedUser = (User)dataGridUsers.SelectedItem;
                importToTextBoxes(selectedUser);
            }
        }

        private void importToTextBoxes(User selectedUser)
        {
            textBoxUserName.Text = selectedUser.name;
            textBoxSurname.Text = selectedUser.surname;
            textBoxAdress.Text = selectedUser.adress;
            textBoxPhone.Text = selectedUser.phone;
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridUsers.SelectedItem != null)
            {
                User selectedUser = (User)dataGridUsers.SelectedItem;
                userList.Remove(selectedUser);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clearTexBoxes();
        }
    }
}
