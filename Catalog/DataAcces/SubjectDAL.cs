using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataAcces
{
    class SubjectDAL
    {
        public ObservableCollection<Subject> getAllSubjects()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("SelectAllSubjects", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Subject materie = new Subject();    
                    materie.Id = (int)(reader[0]);
                    materie.Name = (string)(reader[1]);
                    result.Add(materie);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public void insertIntoSubjects(Subject materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertIntoMaterii", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", materie.Id);
                SqlParameter paramNume = new SqlParameter("@nume", materie.Name);
                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramNume);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteSubjectWhereIdIs(int id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteSubjectWhereIdIs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", id);
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public int getIdOfSubjectWithName(string name)
        {
            SqlConnection con = DALHelper.Connection;
            int result = -1;
            try
            {
                SqlCommand cmd = new SqlCommand("getIdOfSubjectWithName", con);
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
