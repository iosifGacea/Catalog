using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataAcces
{
    internal class NotaDAL
    {
        public void insertIntoGrades(int id_elev, int id_profesor, int nota)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertIntoNote", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@id_elev", id_elev);
                SqlParameter paramIdProfesor = new SqlParameter("@id_materie", id_profesor);
                SqlParameter paramNota = new SqlParameter("@nota", nota);
                SqlParameter param1 = new SqlParameter("@are_teza", 1);
                SqlParameter param2 = new SqlParameter("data", "1/1/1");
                cmd.Parameters.Add(paramIdElev);
                cmd.Parameters.Add(paramIdProfesor);
                cmd.Parameters.Add(paramNota);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2); 
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
