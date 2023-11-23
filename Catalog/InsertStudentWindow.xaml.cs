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
using System.Windows.Shapes;

namespace Catalog
{
    /// <summary>
    /// Interaction logic for InsertStudentWindow.xaml
    /// </summary>
    public partial class InsertStudentWindow : Window
    {
        public InsertStudentWindow()
        {
            InitializeComponent();
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            StudentDAL studentDAL = new StudentDAL();
            Student student = new Student(Convert.ToInt32(idBox.Text), nameBox.Text, Convert.ToInt32(classIdBox.Text), passwordBox.Text);
            studentDAL.insertIntoStudents(student);
            MessageBox.Show("All is well");
        }
    }
}
