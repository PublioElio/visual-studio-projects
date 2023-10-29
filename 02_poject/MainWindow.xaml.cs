using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            public int children { get; set; }
        }

        // I've used ObservableCollection because it's a data structure that allows notifying data changes (it implements the INotifyPropertyChanged interface)
        ObservableCollection<User> userList = new ObservableCollection<User> { };
        private int children;

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

        private void acccept_Click(object sender, RoutedEventArgs e)
        {
            string name, surname, adress, phone;
            int children;
            initalizeUser(out name, out surname, out adress, out phone, out children);

            if (isFilled(name, surname, adress, phone))
            {
                if (dataGridUsers.SelectedItem != null)
                {
                    User selectedUser = (User)dataGridUsers.SelectedItem;
                    selectedUser.name = textBoxUserName.Text;
                    selectedUser.surname = textBoxSurname.Text;
                    selectedUser.adress = textBoxAdress.Text;
                    selectedUser.phone = textBoxPhone.Text;
                    selectedUser.children = (bool)checkBox.IsChecked ? (int)slider.Value : 0;
                    dataGridUsers.Items.Refresh();
                    dataGridUsers.SelectedItem = null;
                }
                else
                    userList.Add(new User { name = name, surname = surname, adress = adress, phone = phone, children = children });
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
            checkBox.IsChecked = false;
            slider.Value = double.MinValue;
            btnAdd.Content = "ACEPTAR";
        }

        private static bool isFilled(string name, string surname, string adress, string phone)
        {
            return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(adress) && !string.IsNullOrEmpty(phone);
        }

        private void initalizeUser(out string name, out string surname, out string adress, out string phone, out int children)
        {
            name = textBoxUserName.Text;
            surname = textBoxSurname.Text;
            adress = textBoxAdress.Text;
            phone = textBoxPhone.Text;
            children = (bool) checkBox.IsChecked ? (int)slider.Value : 0;
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
            btnAdd.Content = "MODIFICAR";
            textBoxUserName.Text = selectedUser.name;
            textBoxSurname.Text = selectedUser.surname;
            textBoxAdress.Text = selectedUser.adress;
            textBoxPhone.Text = selectedUser.phone;
            if (selectedUser.children > 0)
            {
                checkBox.IsChecked = true;
                slider.Value = selectedUser.children;
                tbCountChildren.Text = "Cantidad: " + slider.Value;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridUsers.SelectedItem != null)
            {
                User selectedUser = (User)dataGridUsers.SelectedItem;
                userList.Remove(selectedUser);
                clearTexBoxes();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clearTexBoxes();
            dataGridUsers.SelectedItem = null;
        }
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            slider.IsEnabled = true;
            updateChildrenNum();
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            slider.IsEnabled = false;
            slider.Value = double.MinValue;
            tbCountChildren.Text = "Cantidad: 0";
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            updateChildrenNum();
        }

        private void updateChildrenNum()
        {
            if (checkBox.IsChecked == true)
            {
                int childrenNum = (int)slider.Value;
                tbCountChildren.Text = "Cantidad: " + childrenNum;
            }

        }
    }
}
