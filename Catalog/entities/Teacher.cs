using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Teacher
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
        Class clas = new Class();       //clasa la care este diriginte
        public Class Clas
        {
            get { return clas; }
            set { clas = value; }
        }
        List<Class> classes = new List<Class>();
        public List<Class> Classes
        {
            get { return classes; }
            set { Classes = value; }
        }
        List<Subject> subjects = new List<Subject>();
        public List<Subject> Subjects
        {
            get { return subjects; }
            set { subjects = value; }
        }
        public Teacher() { }
        public Teacher(int _id, string _nume, int _idClasa, string _parola)
        {
            Id = _id;
            Name = _nume;
            Clas.Id = _idClasa;
            Password = _parola;
        }
    }
}
