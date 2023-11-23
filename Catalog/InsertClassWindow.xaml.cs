using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    /// Interaction logic for InsertClassWindow.xaml
    /// </summary>
    public partial class InsertClassWindow : Window
    {
        public InsertClassWindow()
        {
            InitializeComponent();
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            ClasaDAL clasaDAL = new ClasaDAL();
            Class clasa = new Class(Convert.ToInt32(idBox.Text), Convert.ToInt32(yearBox.Text), specializationBox.Text);
            clasaDAL.insertIntoClasses(clasa);
            MessageBox.Show("All is well");
        }
    }
}
