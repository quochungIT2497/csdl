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
using System.Diagnostics;

namespace csdl.VIEW
{
    public partial class FrmNhanVien : Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        NVCtr nvctr = new NVCtr();
        NhanvienOBJ nv;
        private NhanvienOBJ ValueTxtBox()
        {
                return nv = new NhanvienOBJ(txt_ma.Text, txt_ten.Text, comboBox_gioitinh.Text, dtp_namsinh.Text, txt_diachi.Text, txt_sdt.Text);
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            nvctr.AddData(ValueTxtBox());
            FrmNhanVien_Load(sender, e);
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = nvctr.GetData();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            ValueTxtBox();
            nvctr.DelData(nv.MaNhanVien);
            FrmNhanVien_Load(sender, e);
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            nvctr.UpData(ValueTxtBox());
            FrmNhanVien_Load(sender, e);
        }
    }
}
