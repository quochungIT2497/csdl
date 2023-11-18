using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csdl.OBJECT
{
    internal class Nhanvien
    {
        string _ma, _ten, _gioitinh, _diachi, _sdt, _matkhau, _namsinh;

        public string DienThoai
        {
            get { return _sdt; }
            set { _sdt = value; }
        }

        public string DiaChi
        {
            get { return _diachi; }
            set { _diachi = value; }
        }

        public string GioiTinh
        {
            get { return _gioitinh; }
            set { _gioitinh = value; }
        }

        public string TenNhanVien
        {
            get { return _ten; }
            set { _ten = value; }
        }

        public string MaNhanVien
        {
            get { return _ma; }
            set { _ma = value; }
        }

        public string NamSinh
        {
            get { return _namsinh; }
            set { _namsinh = value; }
        }

        public string MatKhau
        {
            get { return _matkhau; }
            set { _matkhau = value; }
        }

        public Nhanvien() { }
        public Nhanvien(string ma, string ten, string gioitinh, string namsinh, string diachi, string sdt)
        {
            this._ma = ma;
            this._ten = ten;
            this._gioitinh = gioitinh;
            this._namsinh = namsinh;
            this._diachi = diachi;
            this._sdt = sdt;
        }

    }
}

