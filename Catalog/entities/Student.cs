using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Student
    {
            private int id;
            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            private string name = "";
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            private string password = "";
            public string Password
            {
                get { return password; }
                set { password = value; }
            }
            Class clas = new Class();
            public Class Clas
            {
                get { return clas; }
                set { clas = value; }
            }
        public Student(int _id, string _nume, int _idClasa, string _parola)
        {
            Id = _id;
            Name = _nume;
            Clas.Id = _idClasa;
            Password = _parola;
        }
        public Student() { }
    }
}
