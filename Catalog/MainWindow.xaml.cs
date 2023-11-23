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
using Catalog.Role;
//adauga nota
namespace Catalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static role _role;
       
        private void admin_Click(object sender, RoutedEventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
            _role = role.admin;
        }
        private void class_master_Click(object sender, RoutedEventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
            _role = role.class_master;
        }
        private void teacher_Click(object obj, RoutedEventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
            _role = role.teacher;
        }
        private void student_Click(object sender,  EventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
            _role = role.student;
        }
        public static role GetRole()
        {
            return _role;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
