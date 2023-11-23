using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class StudentDAL
    {
        public ObservableCollection<Student> GetAllStudents()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("SelectAllStudents", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student p = new Student();
                    p.Id = (int)(reader[0]);//reader.GetInt(0);
                    p.Name = reader[1].ToString(); ;//reader[1].ToString();
                    p.Clas.Id = (int)(reader[2]);
                    p.Password = reader[3].ToString();
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public void insertIntoStudents(Student elev)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertIntoElevi", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", elev.Id);
                SqlParameter paramNume = new SqlParameter("@nume", elev.Name);
                SqlParameter paramIdClasa = new SqlParameter("@id_clasa", elev.Clas.Id);
                SqlParameter paramParola = new SqlParameter("@parola", elev.Password);
                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramIdClasa);
                cmd.Parameters.Add(paramParola);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteStudentWhereIdIs(int id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudentWhereIdIs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", id);
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public ObservableCollection<Student> getAllStudentsFromClass(int id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("SelectTheStudentsFromTheClass", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", id);
                cmd.Parameters.Add(paramId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student p = new Student();
                    p.Id = (int)(reader[0]);//reader.GetInt(0);
                    p.Name = reader[1].ToString(); ;//reader[1].ToString();
                    p.Password = reader[2].ToString();
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Student> getAllStudentsOfTeacher(int id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("SelectTheStudentsOfTeacher000", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", id);
                cmd.Parameters.Add(paramId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student p = new Student();
                    p.Id = Convert.ToInt32(reader[0]); ;//reader[1].ToString();
                    p.Name = reader[1].ToString();
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Student> getGradesStudentsOfTeacher(int id0)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("SelectTheGradesStudentsOfTeacher", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id0", id0);
                cmd.Parameters.Add(paramId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student p = new Student();
                    p.Id = Convert.ToInt32(reader[0]); ;//reader[1].ToString();
                    p.Name = reader[1].ToString();
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public int getIdOfStudentWithName(string name)
        {
            SqlConnection con = DALHelper.Connection;
            int result = -1;
            try
            {
                SqlCommand cmd = new SqlCommand("getIdOfStudentWithName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramName = new SqlParameter("@name", name);
                cmd.Parameters.Add(paramName);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = Convert.ToInt32(reader[0]);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
    }
}


