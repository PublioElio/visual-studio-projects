using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            public string birthDate { get; set; }
            public double height { get; set; }
            public int children { get; set; }

            public List<string> childrenList = new List<string>();
        }

        // I've used ObservableCollection because it's a data structure that allows notifying data changes (it implements the INotifyPropertyChanged interface)
        ObservableCollection<User> userList = new ObservableCollection<User> { };

        public MainWindow()
        {
            InitializeComponent();
            dataGridUsers.ItemsSource = userList;
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
            string name, surname, adress, phone, birthDate;
            int children;
            double height;
            initalizeUser(out name, out surname, out adress, out phone, out height, out birthDate, out children);

            if (isFilled(name, surname, adress, phone))
            {
                if (dataGridUsers.SelectedItem != null)
                {
                    User selectedUser = (User)dataGridUsers.SelectedItem;
                    selectedUser.name = textBoxUserName.Text;
                    selectedUser.surname = textBoxSurname.Text;
                    selectedUser.adress = textBoxAdress.Text;
                    selectedUser.phone = textBoxPhone.Text;
                    selectedUser.birthDate = datePicker.Text;
                    selectedUser.height = Double.Parse(tbHeight.Text);
                    selectedUser.children = (bool)checkBox.IsChecked ? (int)slider.Value : 0;
                    selectedUser.childrenList.Clear();
                    foreach (var item in lbChildList.Items)
                    {
                        selectedUser.childrenList.Add(item.ToString());
                    }
                    dataGridUsers.Items.Refresh();
                    dataGridUsers.SelectedItem = null;
                }
                else
                    userList.Add(new User { name = name, surname = surname, adress = adress, phone = phone, height = height, birthDate = birthDate, children = children });
                foreach (var item in lbChildList.Items)
                {
                    userList.Last().childrenList.Add(item.ToString());
                }
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
            datePicker.Text = DateTime.Now.ToString();
            tbHeight.Text = MIN_HEIGHT.ToString();
            textBoxChildName.Clear();
            lbChildList.Items.Clear();
            checkBox.IsChecked = false;
            slider.Value = double.MinValue;
            btnAdd.Content = ACCEPT_TXT;
        }

        private static bool isFilled(string name, string surname, string adress, string phone)
        {
            return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(adress) && !string.IsNullOrEmpty(phone);
        }

        private void initalizeUser(out string name, out string surname, out string adress, out string phone, out double height, out string birthDate, out int children)
        {
            name = textBoxUserName.Text;
            surname = textBoxSurname.Text;
            adress = textBoxAdress.Text;
            phone = textBoxPhone.Text;
            birthDate = datePicker.Text;
            height = Double.Parse(tbHeight.Text);
            children = (bool)checkBox.IsChecked ? (int)slider.Value : 0;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridUsers.SelectedItem != null)
            {
                User selectedUser = (User)dataGridUsers.SelectedItem;
                importToForm(selectedUser);
            }
        }

        private void importToForm(User selectedUser)
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
            datePicker.Text = selectedUser.birthDate.ToString();
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
            if (lbChildList != null && lbChildList.Items.Count > slider.Value)
            {
                MessageBox.Show("Debe de suprimir algún hijo de la lista");
                slider.Value = lbChildList.Items.Count;
            }
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
            tbHeight.Text = result.ToString("F2"); // This is to limit the number of decimal places to two
        }

        private void Decrease(object sender, RoutedEventArgs e)
        {
            double num = Convert.ToDouble(tbHeight.Text);
            double result = num <= MIN_HEIGHT ? MIN_HEIGHT : num - 0.05;
            tbHeight.Text = result.ToString("F2");
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) // Cuando pulsa enter empiezan las comprobaciones
            {
                string newChildren = textBoxChildName.Text.ToLower();
                if (string.IsNullOrEmpty(textBoxChildName.Text)) // Ha introducido un campo vacío
                {
                    MessageBox.Show("Debe introducir un nombre.");
                }
                else
                {
                    bool nameExists = userList.Any(user => user.childrenList.Any(child => child.ToLower() == newChildren)) || lbChildList.Items.Contains(newChildren);
                    if (nameExists) // El nombre del hijo ya existe en el listado
                    {
                        MessageBox.Show("El nombre del hijo ya existe en la lista.");
                    }
                    else
                    {
                        if (lbChildList.Items.Count >= slider.Value) // Ya ha introducido el número máximo de hijos
                        {
                            MessageBox.Show("Ya ha introducido el máximo número de hijos.");
                        }
                        else
                        {
                            lbChildList.Items.Add(textBoxChildName.Text);
                            textBoxChildName.Clear();
                        }
                    }
                }
            }
        }
    }
}
