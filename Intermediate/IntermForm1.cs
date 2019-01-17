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

        List<Pet> pets;
        private void initPets()
        {
            // Create a list of pets.
            pets =
                new List<Pet>{ new Pet { Name="Barley", Age=8 },
                       new Pet { Name="Boots", Age=4 },
                       new Pet { Name="Whiskers", Age=1 },
                       new Pet { Name="Daisy", Age=4 } };
        }
        //GroupBy() 1
        private void button5_Click(object sender, EventArgs e)
        {
            initPets();
            // Group the pets using Age as the key value 
            // and selecting only the pet's Name for each value.
            var query =
                pets.GroupBy(pet => pet.Age, pet => pet.Name);

            // Iterate over each IGrouping in the collection.
            foreach (var petGroup in query)
            {
                // Print the key value of the IGrouping.
                display(petGroup.Key.ToString());
                // Iterate over each value in the 
                // IGrouping and print the value.
                foreach (string name in petGroup)
                    display(name);

                display();
            }
        }

        List<Pet> petsList2;
        private void initPets2()
        {
            // Create a list of pets.
            petsList2 =
                new List<Pet>{ new Pet { Name="Barley", Age=8.3 },
                       new Pet { Name="Boots", Age=4.9 },
                       new Pet { Name="Whiskers", Age=1.5 },
                       new Pet { Name="Jimmy", Age=1.2 },
                       new Pet { Name="Daisy", Age=4.3 } };          
        }       
        //groupBy 2()
        private void button3_Click_2(object sender, EventArgs e)
        {
            initPets2();

            // Group Pet.Age values by the Math.Floor of the age.
            // Then project an anonymous type from each group
            // that consists of the key, the count of the group's
            // elements, and the minimum and maximum age in the group.

            /* Args to GroupBy()
             * 1 - Key selector
             * 2 - Element selector
             * 3-  Result Selector
             */
            var query = petsList2.GroupBy(
                pet => Math.Floor(pet.Age),
                pet => pet.Age,
                (baseAge, ages) => new
                {
                    Key = baseAge,
                    Count = ages.Count(),
                    Min = ages.Min(),
                    Max = ages.Max()
                });

            foreach(var item in query)
            {
                display("Age group: " + item.Key);
                display("Number of pets in this age group: " + item.Count);
                display("Minimum age: " + item.Min);
                display("Maximum age: " + item.Max);
                display();
            }                
        }

        List<Pet> petsList3;
        private void initPets3()
        {
            // Create a list of pets.
            petsList3 =
                new List<Pet>{ new Pet { Name="Barley", Age=8.3, Weight = 20.0 },
                       new Pet { Name="Boots", Age=4.9, Weight = 10.0 },
                       new Pet { Name="Whiskers", Age=1.5, Weight = 8.0 },
                       new Pet { Name="Jimmy", Age=1.2, Weight = 10.0 },
                       new Pet { Name="Daisy", Age=4.3, Weight = 15.0 } };
        }
        //GroupBy() 3
        private void button4_Click(object sender, EventArgs e)
        {
            initPets3();

            var query = petsList3.GroupBy(
                pet => Math.Floor(pet.Age),
                pet => pet.Weight,
                (baseAge, weights) => new
                {
                    Key = baseAge,
                    Count = weights.Count(),
                    Min = weights.Min(),
                    Max = weights.Max(),
                    Avg = weights.Average()
                });

            foreach (var item in query)
            {
                display("Age group: " + item.Key);
                display("Number of pets in this age group: " + item.Count);
                display("Minimum weight: " + item.Min);
                display("Maximum weight: " + item.Max);
                display("Average weight: " + item.Avg);
                display();
            }
        }

        private void display(string msg="")
        {            
            if (!string.IsNullOrEmpty(msg))
                textBox1.Text += msg;

            textBox1.Text += Environment.NewLine;
        }

        //unwanted
        private void IntermForm1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

    }
}
