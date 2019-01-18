using Intermediate.Models.Set2;
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
    public partial class GroupJoinInterm : Form
    {
        public GroupJoinInterm()
        {
            InitializeComponent();
        }

        List<Person> personCollection;
        List<Pet> petCollection;
        private void preparePeopleWithPets()
        {
            Person magnus = new Person { Name = "Magnus" };
            Person terry = new Person { Name = "Terry" };
            Person charlotte = new Person { Name = "Charlotte" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            personCollection = new List<Person> { magnus, terry, charlotte };
            petCollection = new List<Pet> { barley, boots, whiskers, daisy };

        }
               
        //GroupJoin() 1
        private void button1_Click(object sender, EventArgs e)
        {
            // Create a list where each element is an anonymous 
            // type that contains a person's name and 
            // a collection of names of the pets they own.


            // I feel method based syntax is not as clear as query based syntax, 
                //so leaving this for now - Ravi K R
            var query =
                personCollection.GroupJoin(petCollection,
                                 person => person,
                                 pet => pet.Owner,
                                 (person, petCollection) =>
                                     new
                                     {
                                         OwnerName = person.Name,
                                         Pets = petCollection.Select(pet => pet.Name)
                                     });

            foreach (var obj in query)
            {
                // Output the owner's name.
                Console.WriteLine("{0}:", obj.OwnerName);
                // Output each of the owner's pet's names.
                foreach (string pet in obj.Pets)
                {
                    Console.WriteLine("  {0}", pet);
                }
            }
        }
    }
}
