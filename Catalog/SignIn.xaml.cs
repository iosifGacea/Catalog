using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Catalog.Entities;
using Catalog.Role;

namespace Catalog
{ 
    public partial class SignIn : Window
    {
        DALHelper dalhepler=new DALHelper();

        private role _role;
        
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public SignIn()
        {
            InitializeComponent();
            _role = MainWindow.GetRole();
        }
        private void Enter_click(object sender, EventArgs e)
        {
            Name = n.Text;   //the name from keyboard
            string Pass = p.Text;   //the pass from keyboard
            bool ok = false;

            if (_role==role.admin)
            {
                ObservableCollection<Admin> admins = dalhepler.adminDAL.GetAllAdmins();
                foreach (var it in admins)
                {
                    if (it.Name == this.Name)
                        if (it.Password == Pass)
                        {
                            AdminMainWindow adminMainWindow = new AdminMainWindow();
                            adminMainWindow.Show();
                            ok = true;
                        }
                }
            }
            else if(_role==role.class_master)
            {
                ObservableCollection<Teacher> classMasters = dalhepler.teacherMasterDAL.GetAllTeacherMasters();
                foreach (var c in classMasters)
                {
                    if (c.Name == this.Name)
                        if (c.Password == Pass)
                        {
                            ClassMasterMainWindow classMasterWindow = new ClassMasterMainWindow();
                            classMasterWindow.Show(); 
                            ok = true;
                        }
                }
            }
            else if(_role==role.teacher) 
            {
                ObservableCollection<Teacher> teachers=new ObservableCollection<Teacher>();
                foreach(var t in  teachers)
                {
                    if(t.Name == this.Name)
                        if (t.Password == Pass)
                        {
                            TeacherMainWindow teacherMainWindow = new TeacherMainWindow();
                            teacherMainWindow.Show(); 
                            ok = true;
                        }
                }
            }
            else
            {
                ObservableCollection<Student> students = new ObservableCollection<Student>();
                foreach(var s in students)
                {
                    if(s.Name == this.Name)
                        if(s.Password == Pass)
                        {
                            StudentMainWindow studentMainWindow = new StudentMainWindow();
                            studentMainWindow.Show();
                            ok = true;
                        }
                }
            }
            
            
            if (!ok)
            {
                MessageBox.Show("password or name is not valid!");
            }
        }
    }
}
