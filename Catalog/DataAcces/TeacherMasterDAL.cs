using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataAcces
{
    internal class TeacherMasterDAL
    {
        public ObservableCollection<Teacher> GetAllTeacherMasters()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("SelectAllTeacherMasters", con);
                ObservableCollection<Teacher> result = new ObservableCollection<Teacher>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher p = new Teacher();
                    p.Id = (int)(reader[0]);//reader.GetInt(0);
                    p.Name = reader[1].ToString(); ;//reader[1].ToString();
                    if (reader[2] != null)
                        p.Clas.Id = (int)(reader[2]);
                    else
                        p.Clas = null;
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
        
    }
}
