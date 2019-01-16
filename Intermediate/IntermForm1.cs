using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intermediate
{
    public partial class IntermForm1 : Form
    {
        PetOwner[] petOwners;
        public IntermForm1()
        {
            InitializeComponent();
            initPetOwners();
        }

        private void initPetOwners()
        {
            petOwners = new[]
            {
                new PetOwner
                {
                    Name = "Higa",
                    Pets = new List<string> { "Scruffy", "Sam" }
                },
                new PetOwner
                {
                    Name = "Ashkenazi",
                    Pets = new List<string> { "Walker", "Sugar" }
                },
                new PetOwner
                {
                    Name = "Price",
                    Pets = new List<string> { "Scratches", "Diesel" }
                },
                new PetOwner
                {
                    Name = "Hines",
                    Pets = new List<string> { "Dusty" }
                }
            };
        }

        //select 
        private void button1_Click(object sender, EventArgs e)
        {
           //using select
            var query =
                petOwners.Select(petOwner => petOwner.Pets);

            List<string> dogNames = new List<string>();
            foreach (List<string> names in query)
                foreach (string name in names)
                    dogNames.Add(name);

            listBox1.DataSource = dogNames;

        }

        //selectMany
        private void button2_Click(object sender, EventArgs e)
        {
            //using SelectMany()
            var query = petOwners.SelectMany(petOwner => petOwner.Pets);
            listBox1.DataSource = query.ToList();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
