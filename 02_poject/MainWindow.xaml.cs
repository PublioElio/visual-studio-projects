using System;
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
        private double MIN_HEIGHT = 0.65;
        private double MAX_HEIGHT = 2.30;
        private string ACCEPT_TXT = "ACEPTAR";
        private string MODIFY_TXT = "MODIFICAR";
        private string ERROR_MSG = "No es posible dejar campos en blanco.";
        private class User
        {
            public string name { get; set; }
            public string surname { get; set; }
            public string adress { get; set; }
            public string phone { get; set; }
            public int children { get; set; }
            public double height { get; set; }
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

        private void acccept_Click(object sender, RoutedEventArgs e)
        {
            string name, surname, adress, phone;
            int children;
            double height;
            initalizeUser(out name, out surname, out adress, out phone, out children, out height);

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
                    selectedUser.height = Double.Parse(tbHeight.Text);
                    dataGridUsers.Items.Refresh();
                    dataGridUsers.SelectedItem = null;
                }
                else
                    userList.Add(new User { name = name, surname = surname, adress = adress, phone = phone, children = children, height = height });
                dataGridUsers.Items.Refresh();
                clearForm();
            }
            else
                MessageBox.Show(ERROR_MSG);
        }

        private void clearForm()
        {
            textBoxUserName.Clear();
            textBoxSurname.Clear();
            textBoxAdress.Clear();
            textBoxPhone.Clear();
            checkBox.IsChecked = false;
            slider.Value = double.MinValue;
            tbHeight.Text = MIN_HEIGHT.ToString();
            btnAdd.Content = ACCEPT_TXT;
        }

        private static bool isFilled(string name, string surname, string adress, string phone)
        {
            return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(adress) && !string.IsNullOrEmpty(phone);
        }

        private void initalizeUser(out string name, out string surname, out string adress, out string phone, out int children, out double height)
        {
            name = textBoxUserName.Text;
            surname = textBoxSurname.Text;
            adress = textBoxAdress.Text;
            phone = textBoxPhone.Text;
            children = (bool) checkBox.IsChecked ? (int)slider.Value : 0;
            height = Double.Parse(tbHeight.Text);
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
            btnAdd.Content = MODIFY_TXT;
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
            tbHeight.Text = selectedUser.height.ToString();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridUsers.SelectedItem != null)
            {
                User selectedUser = (User)dataGridUsers.SelectedItem;
                userList.Remove(selectedUser);
                clearForm();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clearForm();
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

        private void Increase(object sender, RoutedEventArgs e)
        {
            double num = Convert.ToDouble(tbHeight.Text);
            double result = num >= MAX_HEIGHT ? MAX_HEIGHT : num + 0.05;
            tbHeight.Text = result.ToString("F2"); // this is to limit the number of decimal places to two
        }

        private void Decrease(object sender, RoutedEventArgs e)
        {
            double num = Convert.ToDouble(tbHeight.Text);
            double result = num <= MIN_HEIGHT ? MIN_HEIGHT : num - 0.05;
            tbHeight.Text = result.ToString("F2");
        }
    }
}
