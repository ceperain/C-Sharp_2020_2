using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Base_Form : Form
    {
        
        public Base_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl1 userControl1 = new UserControl1();
            panel1.Controls.Add(userControl1);
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl2 userControl2 = new UserControl2();
            panel1.Controls.Add(userControl2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl3 userControl = new UserControl3();
            panel1.Controls.Add(userControl);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl4 userControl4 = new UserControl4();
            panel1.Controls.Add(userControl4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            UserControl7 userControl = new UserControl7();
            panel2.Controls.Add(userControl);
        }

        
        private void button8_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            UserControl7 userControl = new UserControl7();
            panel2.Controls.Add(userControl);
            BookLoad_Form form = new BookLoad_Form();
            form.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            UserControl7 userControl = new UserControl7();
            panel2.Controls.Add(userControl);
            ISBN_Redundant_Form form = new ISBN_Redundant_Form();
            form.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            UserControl7 userControl = new UserControl7();
            panel2.Controls.Add(userControl);
            Id_Redundant_Form form = new Id_Redundant_Form();
            form.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            UserControl7 userControl = new UserControl7();
            panel2.Controls.Add(userControl);
            Check_Form form = new Check_Form();
            form.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            BookSearch bookSearchForm = new BookSearch();
            bookSearchForm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            BookInformation bookInformation = new BookInformation();
            bookInformation.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            BarcodePrint barcodePrint = new BarcodePrint();
            barcodePrint.Show();
        }

        

        private void button16_Click(object sender, EventArgs e)
        {
            SignPrint signPrint = new SignPrint();
            signPrint.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            UserControl6 userControl = new UserControl6();
            panel3.Controls.Add(userControl);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            SearchUser searchUser = new SearchUser();
            searchUser.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            Print print = new Print();
            print.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            UserPrint userPrint = new UserPrint();
            userPrint.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {
            MessageBox.Show("조회된 삭제 회원이 없습니다.");
            DeleteUser deleteUser = new DeleteUser();
            deleteUser.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            ClassUser classUser = new ClassUser();
            classUser.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Windows windows = new Windows();
            windows.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Configuration configuration = new Configuration();
            configuration.Show();
        }
    }
}
