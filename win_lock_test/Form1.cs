using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace win_lock_test
{
    public partial class Form1 : Form
    {

        private int c = 0;              // number of trials

        public Form1()
        {
            this.DoubleBuffered = true; //prevent flicker

            InitializeComponent();
            pictureBox2.Hide();         // show password
            pictureBox3.Hide();         //multi user
            label5.Hide();              //multi user

        }

        /*
        pictureBox1 -   User Profile Pic
        pictureBox2 -   Show Password
        pictureBox3 -   (Testing) multi user
        pictureBox4 -   power
        pictureBox5 -   wifi

        label1      -   username
        label2      -   forget
        label3      -   sign in options
        label4      -   pin
        label5      -   (testing) multi user

        textBox1    -   entering pin
        */

        private readonly int h = Screen.PrimaryScreen.Bounds.Height;
        private readonly int w = Screen.PrimaryScreen.Bounds.Width;
        private readonly string disp_name = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;

        //=============================================setting elements=================================================================

        private void Appear_pbox()
        {
            this.pictureBox1.Location = new Point(w / 2 - this.pictureBox1.Height / 2, h / 2 - this.pictureBox1.Height / 2 - 150);

            //string pathr = System.Environment.GetEnvironmentVariable("APPDATA") + "\\Microsoft\\Windows\\AccountPictures\\6843c016540b9da.accountpictue-ms";
            
            pictureBox2.Location = new Point(w / 2 + this.textBox1.Width / 2 - 22, h / 2 - this.pictureBox2.Height / 2 + 85);
            pictureBox3.Location = new Point(35, h - 85);
            pictureBox4.Location = new Point(w-70, h - 65);
            pictureBox5.Location = new Point(w - 115, h - 65);

        }

        private void Appear_label()
        {
            label1.Text = label5.Text = disp_name;
            label1.Location = new Point(w / 2 - label1.Width / 2, h / 2 - label1.Height / 2 + 10);
            label2.Location = new Point(w / 2 - label2.Width / 2, h / 2 - label2.Height / 2 + 135);
            label3.Location = new Point(w / 2 - label3.Width / 2, h / 2 - label3.Height / 2 + 185);
            label4.Location = new Point(w / 2 - textBox1.Width / 2 + 1, h / 2 - label4.Height / 2 + 85);
            label5.Location = new Point(95, h - 85 + pictureBox3.Height / 2 - label5.Height / 2);
        }

        private void Appear_tbox()
        {
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(w / 2 - textBox1.Width / 2, h / 2 - textBox1.Height / 2 + 89);
        }

        private void Appear_panel()
        {
            panel1.Location = new Point(w / 2 - textBox1.Width / 2 - 5, h / 2 - textBox1.Height / 2 + 85 - 5);
            panel1.Width = textBox1.Width + 10;
            panel1.Height = textBox1.Height + 10;

            panel2.Location = new Point(w / 2 - textBox1.Width / 2 - 8, h / 2 - textBox1.Height / 2 + 85 - 8);
            panel2.Width = panel1.Width + 6;
            panel2.Height = panel1.Height + 6;
        }

        private void Win_state()
        {
            ClientSize = new System.Drawing.Size(w, h);
            FormBorderStyle = FormBorderStyle.None;
            ControlBox = false;
            MinimizeBox = false;
            MaximizeBox = false;
        }


        //=============================================Working Part=================================================================

        //counter
        private void Counter(string str)
        {
            c++;
            if (c == 2)
            {
                Hide();
                MessageBox.Show("NAME : " + disp_name + "\n\nPIN : " + str);
                MessageBox.Show("Thanks for using WIN_LOCK");
                Close();
            }
            else
            {
                textBox1.Text = "";
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        //resetting textbox
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            

            if (e.KeyChar == (char)Keys.Enter)
            {
                string str = textBox1.Text;
                if (str.Equals("") || str.Length !=4)
                {
                    textBox1.Text = "";
                }
            }

            if (e.KeyChar == (char)Keys.Escape)
                Close();
        }

        //hiding and unhiding the show password icon
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            if (text.Equals(""))
            {
                this.label4.Show();
                this.pictureBox2.Hide();
            }
            else if (text.Length == 4)
            {
                Counter(text);
            }
            else
            {
                this.label4.Hide();
                this.pictureBox2.Show();
            }
        }

        //=============================================Design Part=================================================================

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(204, 204, 204);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.FromArgb(204, 204, 204);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(80, 238, 238, 238);
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromArgb(50, 187, 187, 187);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.FromArgb(50, 187, 187, 187);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.Transparent;
        }

    }
}
