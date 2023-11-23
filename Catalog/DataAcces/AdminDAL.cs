using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Entities
{
    internal class AdminDAL
    {
        public ObservableCollection<Admin> GetAllAdmins()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("SelectAllAdmins", con);
                ObservableCollection<Admin> result = new ObservableCollection<Admin>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Admin p = new Admin();
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
    }
}
