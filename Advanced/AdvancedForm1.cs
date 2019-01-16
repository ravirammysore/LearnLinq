using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced
{
    public partial class AdvancedForm1 : Form
    {
        PetOwner[] petOwners;
        public AdvancedForm1()
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

        //selectMany (cross)
        private void button1_Click(object sender, EventArgs e)
        {
            // Project the pet owner's name and the pet's name.
            var query =
                petOwners
                .SelectMany(petOwner => petOwner.Pets,
                    (petOwner, petName) => new { petOwner, petName })
                .Where(ownerAndPet => ownerAndPet.petName.StartsWith("S"))
                .Select(ownerAndPet =>
                        new
                        {

                            Owner = ownerAndPet.petOwner.Name,
                            Pet = ownerAndPet.petName
                        }
                );

            //the above query can be broken down more meaningfully as below

            var ownerPetName =
                petOwners
                 .SelectMany(owner => owner.Pets,
                    (owner, petname) => new { owner, petname });
            // * Each item in ownerPetName collection is of type <PetOwner owner, String petname> *


            var ownerNamePetName = ownerPetName
                    .Where(item => item.petname.StartsWith("S"))
                        .Select(item =>
                            new
                            {
                                item.owner.Name,
                                item.petname
                            });
            // * Each item in ownerNamePetName collection is of type <string Name, string petName> *

            //notice the header columns in output
            dataGridView1.DataSource = ownerNamePetName.ToList();

            //we can optionally rename the columns in the final output as shown below
            var ownerNamePetName2 = ownerPetName
                   .Where(item => item.petname.StartsWith("S"))
                       .Select(item =>
                           new
                           {
                               //Renaming the columns
                               DogOwner = item.owner.Name,
                               DogName = item.petname
                           });
            // * Each item in ownerNamePetName2 collection is of type <string DogOwner, string DogName> *

            //notice the header columns in output
            dataGridView2.DataSource = ownerNamePetName2.ToList();
        }

        private Product[] getFruits()
        {
            Product[] fruits = { new Product { Name = "apple", Code = 9 },
                       new Product { Name = "orange", Code = 4 },
                       new Product { Name = "lemon", Code = 12 } };           

            return fruits;

        }
        //Contains()
        private void button2_Click(object sender, EventArgs e)
        {
            Product[] fruits = getFruits();

            Product apple = new Product { Name = "apple", Code = 9 };
            Product kiwi = new Product { Name = "kiwi", Code = 8 };

            ProductComparer prodc = new ProductComparer();

            bool hasApple = fruits.Contains(apple, prodc);
            bool hasKiwi = fruits.Contains(kiwi, prodc);

            textBox1.Text+=("Apple? " + hasApple);
            textBox1.Text += ("Kiwi? " + hasKiwi);
        }
    }
}
