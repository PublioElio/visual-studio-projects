using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private string ERROR_EMPTY_FIELDS = "No es posible dejar campos en blanco.";
        private string ERROR_EMPTY_CHILD_NAMES = "Debe introducir todos los nombres de sus hijos.";
        private class User
        {
            public string name { get; set; }
            public string surname { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
            public string birthDate { get; set; }
            public double height { get; set; }
            public int children { get; set; }
            public List<string> childrenList = new List<string>();
        }

        // I've used ObservableCollection because it's a data structure that allows notifying data changes (it implements the INotifyPropertyChanged interface)
        private ObservableCollection<User> userList = new ObservableCollection<User> { };

        public MainWindow()
        {
            InitializeComponent();
            dataGridUsers.ItemsSource = userList;

            LoadDefaultUsers();
        }

        private void textBox_gotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
                textBox.Background = Brushes.LightGray;
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
                if (lbChildList.Items.Count == (int)slider.Value)
                {
                    if (dataGridUsers.SelectedItem != null)
                    {
                        User selectedUser = (User)dataGridUsers.SelectedItem;
                        selectedUser.name = textBoxUserName.Text;
                        selectedUser.surname = textBoxSurname.Text;
                        selectedUser.address = textBoxAddress.Text;
                        selectedUser.phone = textBoxPhone.Text;
                        selectedUser.birthDate = datePicker.Text;
                        selectedUser.height = Double.Parse(tbHeight.Text);
                        selectedUser.children = (bool)toggleHijos.IsChecked ? (int)slider.Value : 0;
                        selectedUser.childrenList.Clear();
                        foreach (var item in lbChildList.Items)
                            selectedUser.childrenList.Add(item.ToString());
                        dataGridUsers.Items.Refresh();
                        dataGridUsers.SelectedItem = null;
                    }
                    else
                    {
                        userList.Add(new User { name = name, surname = surname, address = adress, phone = phone, height = height, birthDate = birthDate, children = children });
                        foreach (var item in lbChildList.Items)
                            userList.Last().childrenList.Add(item.ToString());
                    }
                    dataGridUsers.Items.Refresh();
                    clearForm();
                }
                else {
                    MessageBox.Show(ERROR_EMPTY_CHILD_NAMES);
                }
            }
            else
                MessageBox.Show(ERROR_EMPTY_FIELDS);
        }

        private void clearForm()
        {
            textBoxUserName.Clear();
            textBoxSurname.Clear();
            textBoxAddress.Clear();
            textBoxPhone.Clear();
            datePicker.Text = DateTime.Now.ToString();
            tbHeight.Text = MIN_HEIGHT.ToString();
            tbChildName.Clear();
            lbChildList.Items.Clear();
            toggleHijos.IsChecked = false;
            slider.Value = double.MinValue;
            treeView.Items.Clear();
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
            adress = textBoxAddress.Text;
            phone = textBoxPhone.Text;
            birthDate = string.IsNullOrWhiteSpace(datePicker.Text) ? DateTime.Now.ToString() : datePicker.Text;
            height = Double.Parse(tbHeight.Text);
            children = (bool)toggleHijos.IsChecked ? (int)slider.Value : 0;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridUsers.SelectedItem != null)
            {
                clearForm();
                User selectedUser = (User)dataGridUsers.SelectedItem;
                importToForm(selectedUser);

                TreeViewItem userItem = new TreeViewItem();
                userItem.Header = selectedUser.name;
                foreach (var child in selectedUser.childrenList)
                {
                    TreeViewItem childItem = new TreeViewItem();
                    childItem.Header = child;
                    userItem.Items.Add(childItem);
                }
                treeView.Items.Clear();
                treeView.Items.Add(userItem);
            }
        }

        private void importToForm(User selectedUser)
        {
            btnAdd.Content = MODIFY_TXT;
            textBoxUserName.Text = selectedUser.name;
            textBoxSurname.Text = selectedUser.surname;
            textBoxAddress.Text = selectedUser.address;
            textBoxPhone.Text = selectedUser.phone;
            if (selectedUser.children > 0)
            {
                toggleHijos.IsChecked = true;
                slider.Value = selectedUser.children;
                tbCountChildren.Text = "Cantidad: " + slider.Value;
            }
            tbHeight.Text = selectedUser.height.ToString();
            datePicker.Text = selectedUser.birthDate.ToString();
            foreach (var child in selectedUser.childrenList)
                lbChildList.Items.Add(child);
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
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            slider.IsEnabled = true;
            spChildData.IsEnabled = true;
            slider.Value = 1;
            updateChildrenNum();
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            slider.IsEnabled = false;
            spChildData.IsEnabled = false;
            tbChildName.Clear();
            lbChildList.Items.Clear();
            slider.Value = 0;
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
            if (slider.Value < 1) 
                toggleHijos.IsChecked = false;
        }

        private void updateChildrenNum()
        {
            if (toggleHijos.IsChecked == true)
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
            if (e.Key == Key.Return) // Pressing Intro starts checking the entered value
            {
                string newChildren = tbChildName.Text.ToLower();
                if (string.IsNullOrEmpty(tbChildName.Text)) // Empty textbox
                    MessageBox.Show(ERROR_EMPTY_FIELDS);
                else
                {
                    bool nameExists = lbChildList.Items.Cast<string>().Any(item => item.ToLower() == newChildren.ToLower());
                    if (nameExists) // Children name already in the listbox
                        MessageBox.Show("El nombre del hijo ya existe en la lista.");
                    else
                    {
                        if (lbChildList.Items.Count >= (int) slider.Value) // Maximum number of children reached
                            MessageBox.Show("Ya ha introducido el máximo número de hijos.");
                        else
                        {
                            lbChildList.Items.Add(tbChildName.Text);
                            tbChildName.Clear();
                        }
                    }
                }
            }
        }

        private void datePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            if (datePicker.SelectedDate.HasValue && datePicker.SelectedDate > DateTime.Now)
            {
                MessageBox.Show("Debe seleccionar una fecha posterior a la actual.");
                datePicker.SelectedDate = DateTime.Now;
            }
        }

        private void lbChildList_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && lbChildList.SelectedItem != null)
            {
                lbChildList.Items.Remove(lbChildList.SelectedItem);
                lbChildHelp.Content = "";
            }    
        }

        private void tbChildName_GotFocus(object sender, RoutedEventArgs e)
        {
            lbChildHelp.Content = "Escriba un nuevo nombre y pulse Enter";
            tbChildName.Background = Brushes.LightGray;
        }

        private void tbChildName_LostFocus(object sender, RoutedEventArgs e)
        {
            lbChildHelp.Content = "";
            tbChildName.Background = Brushes.White;
        }

        private void lbChildList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbChildHelp.Content = "Pulse Suprimir para eliminar el nombre";
        }

        private void CambiarColor_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            string header = menuItem.Header.ToString();

            switch (header)
            {
                case "Cambiar fondo rojo":
                    mainGrid.Background = Brushes.LightCoral;
                    break;
                case "Cambiar fondo verde":
                    mainGrid.Background = Brushes.LightGreen;
                    break;
                case "Cambiar fondo azul":
                    mainGrid.Background = Brushes.LightSkyBlue;
                    break;
                default:
                    break;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = tbSearch.Text;

            if (string.IsNullOrEmpty(searchText))
                MessageBox.Show("Ingrese un término de búsqueda");
            else
            {
                List<User> foundUsers = SearchUsers(searchText);
                if (foundUsers.Count > 0)
                {
                    userList.Clear();
                    foreach (User user in foundUsers)
                        userList.Add(user);
                }
                else
                    MessageBox.Show("No se ha encontrado ningún usuario");
            }
        }

        private List<User> SearchUsers(string searchText)
        {
            return userList.Where(user => user.surname.Contains(searchText)).ToList();
        }

        private void LoadDefaultUsers()
        {
            userList.Add(new User
            {
                name = "Antonio",
                surname = "Pérez Jiménez",
                address = "C/ Conejito",
                phone = "654888145",
                birthDate = "04/03/1990",
                height = 170.5,
                children = 2,
                childrenList = new List<string> { "Miguel", "Damián" }
            });

            userList.Add(new User
            {
                name = "Francisco Javier",
                surname = "Huerta Martínez",
                address = "Avda. Velázquez",
                phone = "956283485",
                birthDate = "08/19/1991",
                height = 170.5,
                children = 2,
                childrenList = new List<string> { "Pedro", "Susana" }
            });

            userList.Add(new User
            {
                name = "Jairo",
                surname = "Gómez Díaz",
                address = "C/ Conejito",
                phone = "658989232",
                birthDate = "09/06/1998",
                height = 175.0,
                children = 1,
                childrenList = new List<string> { "Alicia" }
            });

            userList.Add(new User
            {
                name = "Francisca",
                surname = "Hernández Pont",
                address = "Avda. Andalucía",
                phone = "987654321",
                birthDate = "18/10/1995",
                height = 160.0,
                children = 1,
                childrenList = new List<string> { "Manuela" }
            });

            userList.Add(new User
            {
                name = "Pablo",
                surname = "Martínez Alvarado",
                address = "C/ Toneleros",
                phone = "658989232",
                birthDate = "23/03/1985",
                height = 180.0,
                children = 0,
                childrenList = new List<string>()
            });

            userList.Add(new User
            {
                name = "Susana",
                surname = "Domínguez Piñeiro",
                address = "Pasaje de Jeréz",
                phone = "956283485",
                birthDate = "20/04/2000",
                height = 165.5,
                children = 3,
                childrenList = new List<string> { "Miguel", "Pedro", "Sara" }
            });

            userList.Add(new User
            {
                name = "Carlos",
                surname = "Díaz Gómez",
                address = "C/ Voltaire",
                phone = "985658325",
                birthDate = "15/05/1998",
                height = 175.0,
                children = 1,
                childrenList = new List<string> { "Sandra" }
            });
        }

    }
}
