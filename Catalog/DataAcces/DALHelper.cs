using Catalog.DataAcces;
using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class DALHelper
    {
        public AdminDAL adminDAL=new AdminDAL();
        public TeacherMasterDAL teacherMasterDAL=new TeacherMasterDAL();
        public TeacherDAL teacherDAL=new TeacherDAL();
        public StudentDAL studentDAL=new StudentDAL();


        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["nume"].ConnectionString;

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
