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
    public partial class BasicForm1 : Form
    {
        public BasicForm1()
        {
            InitializeComponent();
        }


        //basics - link to objects
        private void button1_Click(object sender, EventArgs e)
        {
            int[] numbers = { 3, 5, 2, 1, 7, 6, 9, 8, 4 };

            //method syntax
            var res1 = numbers.Where(n => n % 2 == 0);

            //expression syntax (query syntax)
            var res2 = from n in numbers
                       where n % 2 == 0
                       select n;

            listBox1.DataSource = res1.ToList();
        }

        //average - link to objects
        private void button2_Click(object sender, EventArgs e)
        {
            int[] numbers = { 3, 5, 2, 1, 7, 6, 9, 8, 4 };

            var res1 = numbers.Where(n => n > numbers.Average());

            var res2 = from n in numbers
                      where n > numbers.Average()
                      select n;

            richTextBox1.Text = "The average is:" + numbers.Average();

            listBox1.DataSource = res1.ToList();
        }

        //multiple conditions - linq to objects
        private void button3_Click(object sender, EventArgs e)
        {
            string[] fruits = { "banana", "kiwi", "custard", "apple", "grapes", "jack fruit", "Mango", "litchi" };
            var selectedFruits1 = fruits.Where(f => f.Length <= 6 && f.Contains("a"));

            var selectedFruits2 = from f in fruits
                                  where f.Length <= 6 && f.Contains("a")
                                  select f;

            listBox1.DataSource = selectedFruits1.ToList();
        }
        
        //multiple conditions with method chaining - linq to objects
        private void button4_Click(object sender, EventArgs e)
        {
            string[] fruits = { "banana", "kiwi", "custard", "apple", "grapes", "jack fruit", "Mango", "litchi" };

            var selectedFruits = fruits.Where(f => f.Length <= 6 && f.Contains("a"))
                                       .OrderBy(f => f)
                                       .Take(2);

            var selectedFruits2 = from f in fruits
                                  where f.Length <= 6 && f.Contains("a")
                                  orderby f
                                  select f;

            //there is no Take(2) equivalent in query syntax!
            var res = selectedFruits2.Take(2);

            listBox1.DataSource = selectedFruits.ToList();
        }

        //Foreach iteration
        private void button5_Click(object sender, EventArgs e)
        {
            string[] fruits = { "banana", "kiwi", "custard", "apple", "grapes", "jack fruit", "Mango", "litchi" };
            var selectedFruits = fruits.Where(f => f.Contains("a"))
                                        .OrderByDescending(f => f);

            foreach (string f in selectedFruits)
                richTextBox1.Text += f + "\n";
        }    
    }
}
