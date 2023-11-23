using Catalog.DataAcces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for InsertGradeWindow.xaml
    /// </summary>
    public partial class InsertGradeWindow : Window
    {
        public InsertGradeWindow()
        {
            InitializeComponent();
            
            StudentDAL studentDAL = new StudentDAL();
            ObservableCollection<Student> students = studentDAL.GetAllStudents();
            studentBox.DataContext = students;

            SubjectDAL subjectDAL = new SubjectDAL();
            ObservableCollection<Subject> subjects=subjectDAL.getAllSubjects();
            subjectBox.DataContext = subjects;

            TeacherDAL teacherDAL= new TeacherDAL();
            ObservableCollection<Teacher> teachers=teacherDAL.GetAllTeachers();
            teacherBox.DataContext = teachers;
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            StudentDAL studentDAL= new StudentDAL();
            SubjectDAL subjectDAL= new SubjectDAL();
            
            int studentID=studentDAL.getIdOfStudentWithName(studentBox.SelectedItem.ToString());
            int subjectID=subjectDAL.getIdOfSubjectWithName(subjectBox.SelectedItem.ToString());
            int grade = Convert.ToInt32(gradeBox.Text);

            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertIntoNote", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramStudentId = new SqlParameter("@id_elev", studentID);
                SqlParameter paramSubjectId = new SqlParameter("@id_materie", subjectID);
                SqlParameter paramGrade = new SqlParameter("@nota", grade);
                cmd.Parameters.Add(paramStudentId);
                cmd.Parameters.Add(paramSubjectId);
                cmd.Parameters.Add(paramGrade);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
