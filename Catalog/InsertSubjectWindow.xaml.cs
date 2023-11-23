using Catalog.DataAcces;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Catalog
{
    /// <summary>
    /// Interaction logic for InsertSubjectWindow.xaml
    /// </summary>
    public partial class InsertSubjectWindow : Window
    {
        public InsertSubjectWindow()
        {
            InitializeComponent();
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            SubjectDAL subjectDAL = new SubjectDAL();
            Subject subject= new Subject(Convert.ToInt32(idBox.Text), nameBox.Text);
            subjectDAL.insertIntoSubjects(subject);
            MessageBox.Show("All is well");
        }
    }
}
