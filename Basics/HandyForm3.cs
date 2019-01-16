using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basics
{
    //Handy Methods
    public partial class HandyForm3 : Form
    {
        public HandyForm3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an array of Pets.
            Pet[] pets =
                { new Pet { Name="Barley", Age=8, Vaccinated=true },
          new Pet { Name="Boots", Age=4, Vaccinated=false },
          new Pet { Name="Whiskers", Age=1, Vaccinated=false } };

            // Determine whether any pets over age 1 are also unvaccinated.
            bool unvaccinated =
                pets.Any(p => p.Age > 1 && p.Vaccinated == false);

            MessageBox.Show(
                string.Format("There {0} unvaccinated animals over age one.", unvaccinated ? "are" : "are not any"));
        }

        //count
        private void button2_Click(object sender, EventArgs e)
        {
            Pet[] pets = { new Pet { Name="Barley", Vaccinated=true },
                   new Pet { Name="Boots", Vaccinated=false },
                   new Pet { Name="Whiskers", Vaccinated=false } };

            int numberUnvaccinated = pets.Count(p => p.Vaccinated == false);
            textBox1.Text+=string.Format("There are {0} unvaccinated animals.", numberUnvaccinated);

        }

        //except
        private void button3_Click(object sender, EventArgs e)
        {
            double[] numbers1 = { 2.0, 2.0, 2.1, 2.2, 2.3, 2.3, 2.4, 2.5 };
            double[] numbers2 = { 2.2 };

            var onlyInFirstSet = numbers1.Except(numbers2);

            foreach (double number in onlyInFirstSet)
                textBox1.Text+=(number)+Environment.NewLine;
        }
    }

    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Vaccinated { get; set; }
    }

}
