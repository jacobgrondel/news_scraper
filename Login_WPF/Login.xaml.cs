using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Login_WPF;

namespace Newsy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        Registration registration = new Registration();
        Welcome welcome = new Welcome();
        // NewScrapperHome newScrapper = new NewScrapperHome();

        /*private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            this.Left = mainWindow.Left + (mainWindow.Width - this.ActualWidth) / 2;
            this.Top = mainWindow.Top + (mainWindow.Height - this.ActualHeight) / 2;
        }*/

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (username.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";
                textBoxEmail.Focus();
            }
            
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;
                SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Registration where Email='" + email + "'  and password='" + password + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    string username = dataSet.Tables[0].Rows[0]["FirstName"].ToString() + " " + dataSet.Tables[0].Rows[0]["LastName"].ToString();
                    welcome.TextBlockName.Text = username;//Sending value from one form to another form.
                    welcome.Show();
                    Close();
                }
                else
                {
                    errormessage.Text = "Sorry! Please enter existing emailid/password.";
                }*/
            //  con.Close();
            // }
        }

        // Allows this page to de dragged and moved
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }

        // Moves to the Register Page
        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }

        // Moves to the Register Page
        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (Usern.Text == "admin" && password.Password == "admin")
            {
                HomePage newScrapper = new HomePage();
               
                
                newScrapper.Show();
                // welcome.Show();
                Close();
            } else
            {
                errormessage.Text = "Username or Password Invalid.";
                Usern.Text = "Username";
                password.Password = "Pass";
            }
        }

        // Closes page
        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Usern_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Usern_GotFocus;
        }

        private void password_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = (PasswordBox)sender;
            pb.Password = string.Empty;
            pb.GotFocus -= password_GotFocus;
        }
    }
}
