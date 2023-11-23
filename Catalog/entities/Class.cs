using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Class
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
            get { return level.ToString() + "  " + specialization; }
            set { name = level.ToString() + "  " + specialization; }
        }
        private int level;
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        private string specialization = "";
        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }
        public Class() { }
        public Class(int _id, int _an, string _specializare)
        {
            id = _id;
            level = _an;
            specialization = _specializare;
        }
    }
}
