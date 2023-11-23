using Catalog.DataAcces;
using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Catalog
{
    public partial class AdminMainWindow : Window
    {

        ClasaDAL clasaDAL = new ClasaDAL();
        private static int d = 0;   //în această variabilă vom reține 1 dacă admin-ul vrea să șteargă un elev,
                             //2 dacă admin-ul vrea să șteargă un profesor, 3 dacă admin-ul vrea să șteargă
                             //o clasă și 4 dacă admin-ul vrea să șteargă o materie
        public static int D
        {
            get
            {
                return d;
            }
        }
        public AdminMainWindow()
        {
            InitializeComponent();
        }

        private void _STUDENTS_click(object sender, RoutedEventArgs e)
        {
            StudentDAL studentDAL = new StudentDAL();
            ObservableCollection<Student> elevi = studentDAL.GetAllStudents();
            mainList.ItemsSource = elevi;
        }
        private void _TEACHERS_click(object sender, RoutedEventArgs e)
        {
            TeacherDAL teacherDAL = new TeacherDAL();
            ObservableCollection<Teacher> profesori = teacherDAL.GetAllTeachers();
            mainList.ItemsSource = profesori;
        }
        private void _CLASSES_click(object sender, RoutedEventArgs e)
        {
            ClasaDAL clasaDAL = new ClasaDAL();
            ObservableCollection<Class> clase = clasaDAL.getAllClasses();
            mainList.ItemsSource = clase;
        }
        private void _SUBJECTS_click(object sender, RoutedEventArgs e)
        {
            SubjectDAL subjectDAL = new SubjectDAL();
            ObservableCollection<Subject> materii = subjectDAL.getAllSubjects();
            mainList.ItemsSource = materii;
        }
        private void delete_student(object sender, RoutedEventArgs e)
        {
            d = 1;
            DeleteWindow deleteWindow = new DeleteWindow();
            deleteWindow.Show();
        }
        private void insert_subject(object sender, RoutedEventArgs e)
        {
            InsertSubjectWindow window = new InsertSubjectWindow();
            window.Show();
        }
        private void delete_subject(object sender, RoutedEventArgs e)
        {
            d = 4;
            DeleteWindow deleteWindow = new DeleteWindow();
            deleteWindow.Show();
        }
        private void insert_class(object sender, RoutedEventArgs e)
        {
            InsertClassWindow window = new InsertClassWindow();
            window.Show();
        }
        private void delete_class(object sender, RoutedEventArgs e)
        {
            d = 3;
            DeleteWindow deleteWindow = new DeleteWindow();
            deleteWindow.Show();
        }
        private void insert_student(object sender, RoutedEventArgs e)
        {
            InsertStudentWindow window = new InsertStudentWindow();
            window.Show();
        }
        private void delete_teacher(object sender, RoutedEventArgs e)
        {
            d = 2;
            DeleteWindow deleteWindow = new DeleteWindow();
            deleteWindow.Show();
        }
        private void insert_teacher(object sender, RoutedEventArgs e)
        {
            InsertTeacherWindow window = new InsertTeacherWindow();
            window.Show();
        }
        private void insert_grade(object sender, RoutedEventArgs e)
        {
            InsertGradeWindow window = new InsertGradeWindow();
            window.Show();
        }
        private void mainList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name;
            if (mainList.SelectedItem as Student != null)
            {
                ObservableCollection<Class> _clas = clasaDAL.getTheClassWhereIdIs((mainList.SelectedItem as Student).Clas.Id);
                string text = "id elev:  " + (mainList.SelectedItem as Student).Id + "\n" + "clasa a " +
                    _clas[0].Level.ToString() + "-a , specializare: " + _clas[0].Specialization.ToString() +
                    "\n" + "parola: " + (mainList.SelectedItem as Student).Password;
                details.Text = text;
            }
            else if (mainList.SelectedItem as Teacher != null)
            {
                ObservableCollection<Class> _clas = clasaDAL.getTheClassWhereIdIs((mainList.SelectedItem as Teacher).Clas.Id);
                string text = "id profesor: " + (mainList.SelectedItem as Teacher).Id + "\n" +
                    "este diriginte la clasa:";
                if ((mainList.SelectedItem as Teacher).Clas != null)
                    if (_clas.Count > 0)
                        text += " a " + _clas[0].Level.ToString() + "-a, specializarea " +
                            _clas[0].Specialization.ToString();
                    else
                        text += " - ";

                if ((mainList.SelectedItem as Teacher).Clas != null)
                    if (_clas.Count > 0)
                        details.Background = new SolidColorBrush(Colors.Green);
                    else
                        details.Background = new SolidColorBrush(Colors.Red);

                text += "\n" + "parola: " + (mainList.SelectedItem as Teacher).Password;
                details.Text = text;

            }
            else if (mainList.SelectedItem as Class != null)
            {
                details.Text = "id: " + (mainList.SelectedItem as Class).Id.ToString();
            }
            else if (mainList.SelectedItem as Subject != null)
            {
                details.Text = "id: " + (mainList.SelectedItem as Subject).Id.ToString();
            }
        }
    }
}
