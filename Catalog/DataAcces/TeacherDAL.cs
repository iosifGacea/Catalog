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
    internal class TeacherDAL
    {
        public ObservableCollection<Teacher> GetAllTeachers()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("SelectAllTeacher", con);
                ObservableCollection<Teacher> result = new ObservableCollection<Teacher>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher p = new Teacher();
                    p.Id = (int)(reader[0]);//reader.GetInt(0);
                    p.Name = reader[1].ToString(); ;//reader[1].ToString();
                    if (reader[2] != System.DBNull.Value)
                        p.Clas.Id = (int)(reader[2]);
                    else 
                        p.Clas.Id = 0;
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
        public void insertIntoTeachers(Teacher profesor)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertIntoProfesori", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", profesor.Id);
                SqlParameter paramNume = new SqlParameter("@nume", profesor.Name);
                SqlParameter paramIdClasa = new SqlParameter("@id_clasa", profesor.Clas.Id);
                SqlParameter paramParola = new SqlParameter("@parola", profesor.Password);
                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramIdClasa);
                cmd.Parameters.Add(paramParola);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteTeacherWhereIdIs(int id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacherWhereIdIs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", id);
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
