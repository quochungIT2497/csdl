using csdl.model;
using csdl.OBJECT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using csdl.Control;
using csdl.Model;

namespace csdl.VIEW
{
    public partial class FrmNhanVien : Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        NVCtr nvctr = new NVCtr();
        Nhanvien nv = new Nhanvien();
        private void btn_Them_Click(object sender, EventArgs e)
        {
          
           
            nvctr.AddData(nv);
            FrmNhanVien_Load(sender, e);
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = nvctr.GetData();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string ma = txt_ma.Text;
            nvctr.DelData(ma);
            FrmNhanVien_Load(sender, e);
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            nvctr.UpData(nv);
            FrmNhanVien_Load(sender,e);
        }
    }
}
