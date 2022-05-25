using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jpx
{
    public partial class Form1 : Form
    {
        private float width;
        private float height;
        private int count=0;
        private string str;
        public Form1()
        {
            InitializeComponent();
            width = this.Width;
            height = this.Height;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / width;
            float newy = (this.Height) / height;
            width = this.Width;
            height = this.Height;
            

            foreach (Control con in this.Controls)
            {
                try{
                    con.Width = Convert.ToInt32(con.Width * newx);//宽度
                    con.Height = Convert.ToInt32(con.Height * newy);//高度
                    con.Left = Convert.ToInt32(con.Left * newx);//左边距
                    con.Top = Convert.ToInt32(con.Top * newy);//顶边距
                    Single currentSize = System.Convert.ToSingle(con.Font.Size) * newy;//字体大小
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                }
                catch
                {
                    Console.WriteLine("跳过一个异常");
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Visible==true)
            {
                textBox2.Visible = false;
                button1.Text = "修改底稿";
                textBox1.Text = "";
                textBox1.Visible = true;
                str = textBox2.Text+"\r\n\r\n都结束了，还敲啥呢？";
                count = 0;
            }
            else
            {
                textBox1.Visible = false;
                textBox2.Visible = true;
                button1.Text = "开始码字";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (count < str.Length)
            {
                textBox1.AppendText(str.Substring(count, 1));
                count++;
            }
        }
    }
}
