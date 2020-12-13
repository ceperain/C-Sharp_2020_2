using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem
{
    public partial class Base_Form : Form
    {

        public DataSet ds = new DataSet();
        public DataGridView dgv = new DataGridView();

        public Base_Form()
        {
            InitializeComponent();
            Text = "도서 대여 프로그램";
        }

        private void Base_Form_Load(object sender, EventArgs e)
        {
            
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
            UserControl7 userControl = new UserControl7();
            panel2.Controls.Add(userControl);
        }

        
        private void button8_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
            comboBox2.DroppedDown = true; 
        }

        private void comboBox2_MouseEnter(object sender, EventArgs e)
        {
            comboBox2.DroppedDown = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
            comboBox3.DroppedDown = true;
        }

        private void comboBox3_MouseEnter(object sender, EventArgs e)
        {
            comboBox3.DroppedDown = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            comboBox4.Visible = true;
            comboBox4.DroppedDown = true;
        }

        private void comboBox4_MouseEnter(object sender, EventArgs e)
        {
            comboBox4.DroppedDown = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            UserControl7 userControl = new UserControl7();
            panel2.Controls.Add(userControl);
            Check_Form form = new Check_Form();
            form.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            UserControl7 userControl = new UserControl7();
            panel2.Controls.Add(userControl);
            BookSearch bookSearchForm = new BookSearch();
            bookSearchForm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            UserControl7 userControl = new UserControl7();
            panel2.Controls.Add(userControl);
            comboBox1.DroppedDown = true;
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            UserControl7 userControl = new UserControl7();
            panel2.Controls.Add(userControl);
            BookInformation bookInformation = new BookInformation();
            bookInformation.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            UserControl7 userControl = new UserControl7();
            panel2.Controls.Add(userControl);
            BarcodePrint barcodePrint = new BarcodePrint();
            barcodePrint.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            UserControl7 userControl = new UserControl7();
            panel2.Controls.Add(userControl);
            SignPrint signPrint = new SignPrint();
            signPrint.Show();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Base_Form baseForm = new Base_Form();
            SignChange1 signChange1 = new SignChange1();
            SignChange2 signChange2 = new SignChange2();
            SignChange3 signChange3 = new SignChange3();
            SignChange4 signChange4 = new SignChange4();
            SignChange5 signChange5 = new SignChange5();
            SignChange6 signChange6 = new SignChange6();

            int mainFormx = baseForm.Location.X;
            int mainFormy = baseForm.Location.Y;
            int mainformwidth = baseForm.Size.Width;
            int mainformheight = baseForm.Size.Height;

            int childformwidth1 = signChange1.Size.Width;
            int childformheight1 = signChange1.Size.Height;

            int childformwidth2 = signChange2.Size.Width;
            int childformheight2 = signChange2.Size.Height;

            int childformwidth3 = signChange3.Size.Width;
            int childformheight3 = signChange3.Size.Height;

            int childformwidth4 = signChange4.Size.Width;
            int childformheight4 = signChange4.Size.Height;

            int childformwidth5 = signChange5.Size.Width;
            int childformheight5 = signChange5.Size.Height;

            int childformwidth6 = signChange6.Size.Width;
            int childformheight6 = signChange6.Size.Height;
            if (cb.SelectedIndex == 0)
            { 
                signChange1.Show();
                signChange1.Location = new Point(mainFormx + (mainformwidth / 2) - (childformwidth1 / 2), mainFormy + (mainformheight / 2) - (childformheight1 - 2));
            }
            if (cb.SelectedIndex == 1)
            {
                signChange2.Show();
                signChange2.Location = new Point(mainFormx + (mainformwidth / 2) - (childformwidth2 / 2), mainFormy + (mainformheight / 2) - (childformheight2 - 2));
            }
            if (cb.SelectedIndex == 2)
            {
                signChange3.Show();
                signChange3.Location = new Point(mainFormx + (mainformwidth / 2) - (childformwidth3 / 2), mainFormy + (mainformheight / 2) - (childformheight3 - 2));
            }
            if (cb.SelectedIndex == 3)
            {
                signChange4.Show();
                signChange4.Location = new Point(mainFormx + (mainformwidth / 2) - (childformwidth4 / 2), mainFormy + (mainformheight / 2) - (childformheight4 - 2));
            }
            if (cb.SelectedIndex == 4)
            {
                signChange5.Show();
                signChange5.Location = new Point(mainFormx + (mainformwidth / 2) - (childformwidth5 / 2), mainFormy + (mainformheight / 2) - (childformheight5 - 2));
            }
            if (cb.SelectedIndex == 5)
            {
                signChange6.Show();
                signChange6.Location = new Point(mainFormx + (mainformwidth / 2) - (childformwidth6 / 2), mainFormy + (mainformheight / 2) - (childformheight6 - 2));
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Base_Form baseForm = new Base_Form();
            BookLoad_Form bookLoad1 = new BookLoad_Form();
            BookLoad_Form bookLoad3 = new BookLoad_Form();

            if (cb.SelectedIndex == 0)
            {
                UserControl7 userControl = new UserControl7();
                panel2.Controls.Add(userControl);
                comboBox2.Visible = false;
                bookLoad1.ShowDialog();
                bookLoad1.Location = new Point(200, 200);
            }
            else if (cb.SelectedIndex == 1)
            {
                UserControl7 userControl = new UserControl7();
                panel2.Controls.Add(userControl);
                comboBox2.Visible = false;
                ds.ReadXml(@"D:\eclipse\git\C-Sharp_2020_2\XMLFile1.xml");
                dgv.DataSource = ds.Tables[0];
                userControl.dataLoad(dgv);
                MessageBox.Show("XML파일의 데이터를 가져왔습니다!!!!");
            }
            else if (cb.SelectedIndex == 2)
            {
                UserControl7 userControl = new UserControl7();
                panel2.Controls.Add(userControl);
                comboBox2.Visible = false;
                bookLoad3.ShowDialog();
                bookLoad3.Location = new Point(200, 200);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Base_Form baseForm = new Base_Form();
            BookLoad_Form bookLoad2 = new BookLoad_Form();

            if (cb.SelectedIndex == 0)
            {
                UserControl7 userControl = new UserControl7();
                panel2.Controls.Add(userControl);
                comboBox3.Visible = false;
                dgv.DataSource = userControl.dataGridView1.DataSource;
                DataTable dt = GetDataTableFromDGV(dgv);
                ds.Tables.Add(dt);
                ds.WriteXml(File.OpenWrite(@"D:\eclipse\git\C-Sharp_2020_2\XMLFile1.xml"));
                MessageBox.Show("데이터를 XML파일로 저장했습니다!!!!");
            }
            else if (cb.SelectedIndex == 1)
            {
                UserControl7 userControl = new UserControl7();
                panel2.Controls.Add(userControl);
                comboBox3.Visible = false;
                bookLoad2.ShowDialog();
                bookLoad2.Location = new Point(200, 200);
            }
        }

        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    dt.Columns.Add();
                }
            }
            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }
            return dt;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Base_Form baseForm = new Base_Form();
            ISBN_Redundant_Form isbn = new ISBN_Redundant_Form();
            Id_Redundant_Form id = new Id_Redundant_Form();

            if (cb.SelectedIndex == 0)
            {
                UserControl7 userControl = new UserControl7();
                panel2.Controls.Add(userControl);
                comboBox4.Visible = false;
                isbn.ShowDialog();
                isbn.Location = new Point(200, 200);
            }
            if (cb.SelectedIndex == 1)
            {
                UserControl7 userControl = new UserControl7();
                panel2.Controls.Add(userControl);
                comboBox4.Visible = false;
                id.ShowDialog();
                id.Location = new Point(200, 200);
            }
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            comboBox3.Visible = false;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            comboBox4.Visible = false;
        }
    }
}
