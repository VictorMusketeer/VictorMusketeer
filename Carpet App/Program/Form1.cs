using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Room r = new Room();
            r.Length = double.Parse(txtLength.Text);
            r.Width = double.Parse(txtWidth.Text);
            lblArea.Text = r.Area().ToString();
            lblPerimeter.Text = r.Perimeter().ToString();
            grpCalculations.Visible = true;
            lblArea.Text = r.Area().ToString();
            lblPerimeter.Text = r.Perimeter().ToString();
            txtTotalCost.Text = (r.Area() * double.Parse(txtCarpetCost.Text)).ToString("F2");
            MessageBox.Show("Cost to carpet:\n Length: " + r.Length + "m\nWidth: "+ r.Width + "m\nArea: " + r.Area() + "sq m\n Total Cost: " +txtTotalCost.Text+ "\n Perimeter: " + r.Perimeter() + "m skirting needed");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grpCalculations.Visible = false;

        }
    }
}
