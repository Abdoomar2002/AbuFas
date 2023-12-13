using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_printing;

namespace AbuFas
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
                AppDbContext context = new AppDbContext();
            if (guna2TextBox2.Text == "123") {
              //  context.Database.OpenConnection();
           
                new Home().Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show(context.Database.GenerateCreateScript().ToString()) ;
             MessageBox.Show( "اسم المستخدم أو كلمة المرور غير صحيحه","خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2Button1_Click(null, null); }
        }
    }
}
