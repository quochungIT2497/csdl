using csdl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csdl
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        Command command = new Command();
        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
               //command.DT("Select * from tb_HangHoa");
            }
            catch (SqlException ex)
            {
                DialogResult error = MessageBox.Show("Không lấy được dữ liệu", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                while (error == DialogResult.Retry)
                {
                    FormMain_Load(sender, e);
                }
            }
        }
    }
}
