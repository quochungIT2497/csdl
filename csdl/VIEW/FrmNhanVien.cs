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
using System.Data.SqlClient;

namespace csdl.VIEW
{
    public partial class FrmNhanVien : Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        NVCtr nvctr = new NVCtr();
        private int flag = 0;//Đặt sự kiện
        
        //NhanvienOBJ nv;
        /*private NhanvienOBJ ValueTxtBox()
        {
                return nv = new NhanvienOBJ(txt_ma.Text, txt_ten.Text, comboBox_gioitinh.Text, dtp_namsinh.Text, txt_diachi.Text, txt_sdt.Text);
        }*/
        
        private void btn_Them_Click(object sender, EventArgs e)
        {
            /*nvctr.AddData(ValueTxtBox());
            FrmNhanVien_Load(sender, e);*/
            flag = 0;
            ClearData();
            DisEnl(true);
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = nvctr.GetData();
            DataTable dtDs = new System.Data.DataTable();
            dtDs = nvctr.GetData();
            dataGridView1.DataSource = dtDs;
            binding();
            DisEnl(false);
        }

        private void binding()//kết nối với source data grid view
        {
            txt_ma.DataBindings.Clear();
            txt_ma.DataBindings.Add("Text", dataGridView1.DataSource, "MaNV");
            txt_ten.DataBindings.Clear();
            txt_ten.DataBindings.Add("Text", dataGridView1.DataSource, "TenNV");
            comboBox_gioitinh.DataBindings.Clear();
            comboBox_gioitinh.DataBindings.Add("Text", dataGridView1.DataSource, "GioiTinh");
            txt_diachi.DataBindings.Clear();
            txt_diachi.DataBindings.Add("Text", dataGridView1.DataSource, "DiaChi");
            txt_sdt.DataBindings.Clear();
            txt_sdt.DataBindings.Add("Text", dataGridView1.DataSource, "SDT");
            dtp_namsinh.DataBindings.Clear();
            dtp_namsinh.DataBindings.Add("Text", dataGridView1.DataSource, "NamSinh");
        }

        private void DisEnl(bool e)//Chọn 1 trong 3 chức năng thì 2 chức năng còn lại bị khóa
        {   
            btn_Them.Enabled = !e;
            btn_Xoa.Enabled = !e;
            btn_Sua.Enabled = !e;
            btn_Luu.Enabled = e;
            btn_Huy.Enabled = e;
            txt_ma.Enabled = e;
            txt_ten.Enabled = e;
            txt_diachi.Enabled = e;
            txt_sdt.Enabled = e;
            comboBox_gioitinh.Enabled = e;
            dtp_namsinh.Enabled = e;
        }

        private void loadcb()//Làm mới và add thông tin combo box
        {
            comboBox_gioitinh.Items.Clear();
            comboBox_gioitinh.Items.Add("Nam");
            comboBox_gioitinh.Items.Add("Nữ");
            comboBox_gioitinh.SelectedItem = 0;
        }

        private void ClearData()//Rest lại toàn bộ thông tin nhập
        {
            txt_diachi.Text = "";
            txt_ma.Text = "";
            txt_ten.Text = "";
            txt_sdt.Text = "";
            dtp_namsinh.Value = DateTime.Now.Date;
            loadcb();
        }

        private void addData(NhanvienOBJ nv)//Gắn thông tin nhập với object nhân viên
        {
            nv.MaNhanVien = txt_ma.Text.Trim();
            if (comboBox_gioitinh.SelectedIndex == 0)
            {
                nv.GioiTinh = "Nam";
            }
            else
            { nv.GioiTinh = "Nữ"; }
            nv.DiaChi = txt_diachi.Text.Trim();
            nv.DienThoai = txt_sdt.Text.Trim();
            nv.TenNhanVien = txt_ten.Text.Trim();
            nv.NamSinh = dtp_namsinh.Text;
        }


        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            /*ValueTxtBox();
            nvctr.DelData(nv.MaNhanVien);
            FrmNhanVien_Load(sender, e);*/
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa?","Xác nhận xóa",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (nvctr.DelData(txt_ma.Text.Trim()))
                    MessageBox.Show("Xoá thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xoá thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FrmNhanVien_Load(sender, e);
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            /*nvctr.UpData(ValueTxtBox());
            FrmNhanVien_Load(sender, e);*/
            flag = 1;
            DisEnl(true);
            loadcb();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            NhanvienOBJ nvobj = new NhanvienOBJ();
            addData(nvobj);
            if(flag == 0)
            {
                if (nvctr.AddData(nvobj))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(nvctr.UpData(nvobj))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FrmNhanVien_Load(sender, e);
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn hoàn tác?","Xác nhận hủy",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                FrmNhanVien_Load(sender, e);
            }
            else
                return;
        }

        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
