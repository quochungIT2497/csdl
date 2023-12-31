﻿using csdl.model;
using csdl.OBJECT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csdl.Control
{
    class NVCtr
    {
        NVMod nvmod = new NVMod();
        public DataTable GetData()
        {
            return nvmod.getdt();
        }
        public bool AddData(NhanvienOBJ nvobj)
        {
            return nvmod.AddData(nvobj);
        }
        public bool UpData(NhanvienOBJ nvobj) 
        {
            return nvmod.UpData(nvobj);
        }
        public bool UpdMK(NhanvienOBJ nvobj)
        {
            return nvmod.UpMK(nvobj);
        }
        public bool DelData(string ma)
        {
            return nvmod.DelData(ma);
        }

        internal void AddData(object v)
        {
            throw new NotImplementedException();
        }
    }
}
