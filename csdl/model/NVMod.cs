using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using csdl.OBJECT;
using csdl.Control;
using csdl.model;
using csdl.VIEW;
using csdl.Model;

namespace csdl.model
{
    class NVMod
    {
        ConnectSql con = new ConnectSql();
        SqlCommand cmd = new SqlCommand();
        NhanvienOBJ nv = new NhanvienOBJ();
        public DataTable getdt()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select MaNV, TenNV, GioiTinh, NamSinh, DiaChi, SDT from tb_NhanVien";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.Openconn();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch(Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.Closeconn();
            }
            return dt;
        }
        public bool AddData(NhanvienOBJ nvobj)
        {
            cmd.CommandText = " Insert into tb_NhanVien values('" + nvobj.MaNhanVien + "',N'" + nvobj.TenNhanVien
                + "',N'" + nvobj.GioiTinh + "',CONVERT(DATE,'" + nvobj.NamSinh + "',103),"
                + "N'" + nvobj.DiaChi + "','" + nvobj.DienThoai + "','" + nvobj.MatKhau + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            //using(SqlConnection con = Connection.GetSqlConnection())
            try
            {
                con.Openconn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose() ;
                con.Closeconn();
            }
            return false;
        }
        public bool UpData(NhanvienOBJ nvobj)
        {
            cmd.CommandText = "Update tb_NhanVien set TenNV = N'" +  nvobj.TenNhanVien + "',"
                + " GioiTinh = N'" + nvobj.GioiTinh + "', NamSinh = CONVERT(DATE,'" + nvobj.NamSinh + "',103),"
                + " DiaChi = N'" + nvobj.DiaChi + "',SDT = '" + nvobj.DienThoai + "' Where MaNV = '" + nvobj.MaNhanVien + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.Openconn();
                cmd.ExecuteNonQuery() ;
                return true;
            }
            catch(Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.Closeconn();
            }
            return false;
        }

        public bool UpMK(NhanvienOBJ nv)
        {
            cmd.CommandText = "Update tb_NhanVien set MatKhau ='" + nv.MatKhau + "' where MaNV ='" + nv.MaNhanVien + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {

            }
            catch(Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.Closeconn() ;
            }
            return false;
        }
        public bool DelData(string ma)
        {
            cmd.CommandText = "Delete tb_NhanVien where MaNV = '" + ma + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.Openconn();
                cmd.ExecuteNonQuery() ;
                return true;
            }
            catch( Exception ex )
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.Closeconn() ;
            }
            return false;
        }
    }
}
