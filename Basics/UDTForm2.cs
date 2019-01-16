using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Basics
{
    public partial class UDTForm2 : Form
    {
        private List<Student> students;
        public UDTForm2()
        {
            InitializeComponent();

            initStudents();

            dataGridView1.DataSource = students;
        }

        private void initStudents()
        {
            students = new List<Student>
            {
            new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
        }

        //select
        private void button1_Click(object sender, EventArgs e)
        {          
            dataGridView1.DataSource = students;

            var studentsMini = from s in students
                               select new StudentMini()
                               {
                                   FirstMidName = s.FirstMidName,
                                   LastName = s.LastName
                               };
            //or
            var studentsMini2 = students.Select(s => new StudentMini()
            {
                FirstMidName = s.FirstMidName,
                LastName = s.LastName
            });
            
            dataGridView2.DataSource = studentsMini2.ToList();

            //also
            IList<string> names = students.Select(s => s.FirstMidName).ToList();
            listBox1.DataSource = names;

            //same as
            var studs = students.Select(s => s.FirstMidName).ToList();
            listBox2.DataSource = studs;
        }      

        //Anonymous
        private void button2_Click(object sender, EventArgs e)
        {
            var studentsMini1 = students.Select(s => new 
            {
                //Anonymous type
                s.FirstMidName,
                s.LastName
            });

            //also
            var studentsMini2 = students
                .Where(s => s.FirstMidName.ToLower().Contains("a"))
                .Select(s => new
                {
                    s.FirstMidName,
                    s.LastName
                });

            dataGridView2.DataSource = studentsMini2.ToList();

            //same as this, but generally the former is prefered
            var studentsMini3 = students               
                .Select(s => new
                {
                    s.FirstMidName,
                    s.LastName
                }).Where(s => s.FirstMidName.ToLower().Contains("a"));

            dataGridView3.DataSource = studentsMini3.ToList();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
