using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practical05.ClothingSalesForm
{
    public partial class Form1 : Form
    {
        private const decimal discountRate = 0.3m;
        private const decimal GSTrate = 0.07m;

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void calcTotal(int itemQuantity, decimal price)
        {
            decimal extendedPrice = 0, discountAmt = 0;

            extendedPrice = Math.Round(itemQuantity * price, 2);
            discountAmt = Math.Round(extendedPrice * discountRate, 2);

            textBoxExtendedPrc.Text = extendedPrice.ToString("c");
            textBoxDiscount.Text = discountAmt.ToString("c");

            compute(extendedPrice, discountAmt);
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            int itemQuantity = 0;
            decimal price = 0;
            try
            {
                itemQuantity = int.Parse(textBoxNofItems.Text);
                try
                {
                    price = decimal.Parse(textBoxPrc.Text);
                    calcTotal(itemQuantity, price);
                }
                catch
                {
                    MessageBox.Show("Invalid Price", "Data Error");
                    textBoxPrc.Focus();
                    textBoxPrc.SelectAll();
                }
            }
            catch
            {
                MessageBox.Show("Invalid Quantity", "Data Error");
                textBoxNofItems.Focus();
                textBoxNofItems.SelectAll();
            }
        }

        private void compute(decimal extendedPrice, decimal discountAmt)
        {
            decimal GST = 0, amtDue = 0;

            GST = Math.Round(extendedPrice * GSTrate, 2);
            amtDue = Math.Round(extendedPrice - discountAmt + GST, 2);

            textBoxGST.Text = GST.ToString("c");
            textBoxAmtDue.Text = amtDue.ToString("c");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxNofItems.Text = "";
            textBoxNofItems.Clear();
            textBoxNofItems.Text = string.Empty;

            textBoxPrc.Text = "";
            textBoxPrc.Clear();
            textBoxPrc.Text = string.Empty;

            textBoxExtendedPrc.Text = "";
            textBoxExtendedPrc.Clear();
            textBoxExtendedPrc.Text = string.Empty;

            textBoxDiscount.Text = "";
            textBoxDiscount.Clear();
            textBoxDiscount.Text = string.Empty;

            textBoxGST.Text = "";
            textBoxGST.Clear();
            textBoxGST.Text = string.Empty;

            textBoxAmtDue.Text = "";
            textBoxAmtDue.Clear();
            textBoxAmtDue.Text = string.Empty;




        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
