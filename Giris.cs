using System;
using System.Windows.Forms;

namespace KararDestekSistemi
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kriterler fm = new Kriterler();
            
            this.Hide();
            fm.Show();
        }
    }
}
