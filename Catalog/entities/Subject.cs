using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Subject
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
        public Subject(int _id, string _nume)
        {
            id = _id;
            name = _nume;
        }
        public Subject()
        {
        }
    }
}
