using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Entities
{
    internal class ClasaDAL
    {  
        public ObservableCollection<Class> getAllClasses()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("SelectAllClasses", con);
                ObservableCollection<Class> result = new ObservableCollection<Class>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Class clasa = new Class();
                    clasa.Id = (int)(reader[0]);
                    clasa.Level = (int)(reader[1]);
                    clasa.Specialization = (string)(reader[2]);
                    result.Add(clasa);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Class> getTheClassWhereIdIs(int id)
        {

            SqlConnection con = DALHelper.Connection;
            try
            {
                ObservableCollection<Class> clase = new ObservableCollection<Class>();
                con.Open();
                SqlCommand cmd = new SqlCommand("SelectTheClassWhereIdIs", con);
                cmd.CommandType=System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Class clasa = new Class();
                    clasa.Level = (int)(reader[0]);
                    clasa.Specialization = (string)(reader[1]);
                    clase.Add(clasa);
                    break;
                }
                return clase;
            }
            finally
            {
                con.Close();
            }
        }    
        public void insertIntoClasses(Class clasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertIntoClase", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", clasa.Id);
                SqlParameter paramAn = new SqlParameter("@an", clasa.Level);
                SqlParameter paramSpecializare = new SqlParameter("@profil", clasa.Specialization);
                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramAn);
                cmd.Parameters.Add(paramSpecializare);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteClassWhereIdIs(int id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClassWhereIdIs", con);
                cmd.CommandType= CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", id);
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();  
            }
        }
    }
}
