using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vivekdahiya
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //dialogform df = new dialogform();
            //df.FormBorderStyle = FormBorderStyle.None;
            //df.ShowInTaskbar = false;           
            //this.Enabled = false;
            //df.Show(this);


            var disabledForms = DisableForms();
            using (var dlg = new dialogform())
            {
                dlg.ShowDialog();
            }
            EnableForms(disabledForms);
        }


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

        static List<Form> DisableForms()
        {
            var list = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                if (!form.InvokeRequired && form.Enabled && form.TopLevel)
                {
                    EnableWindow(form.Handle, false);
                    list.Add(form);
                }
            }
            return list;
        }

        static void EnableForms(List<Form> list)
        {
            foreach (var form in list)
            {
                EnableWindow(form.Handle, true);
            }
        }
    }
}
