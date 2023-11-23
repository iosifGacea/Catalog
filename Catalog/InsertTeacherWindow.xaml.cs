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
    public partial class InsertTeacherWindow : Window
    {
        public InsertTeacherWindow()
        {
            InitializeComponent();
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            TeacherDAL teacherDAL = new TeacherDAL();
            Teacher profesor = new Teacher(Convert.ToInt32(idBox.Text), nameBox.Text, Convert.ToInt32(classIdBox.Text), passwordBox.Text);
            teacherDAL.insertIntoTeachers(profesor);
            MessageBox.Show("All is well");
        }
    }
}
