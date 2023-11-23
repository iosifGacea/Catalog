using Catalog.DataAcces;
using Catalog.Entities;
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
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
        {
            InitializeComponent();
        }
        private void delete(object sender, RoutedEventArgs e)
        {
            if (AdminMainWindow.D == 1)
            {
                StudentDAL studentDAL = new StudentDAL();
                studentDAL.DeleteStudentWhereIdIs(Convert.ToInt32(id.Text));
            }
            else if (AdminMainWindow.D == 2)
            {
                TeacherDAL teacherDAL = new TeacherDAL();
                teacherDAL.DeleteTeacherWhereIdIs(Convert.ToInt32(id.Text));
            }
            else if(AdminMainWindow.D == 3)
            {
                ClasaDAL clasaDAL = new ClasaDAL();
                clasaDAL.DeleteClassWhereIdIs(Convert.ToInt32(id.Text));
            }
            else
            {
                SubjectDAL subjectDAL = new SubjectDAL();
                subjectDAL.DeleteSubjectWhereIdIs(Convert.ToInt32(id.Text));    
            }
        }
    }
}
