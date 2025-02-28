using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class KetQua
    {
        public int Id { set; get; }
        public string MaSV { set; get; }
        public string MaMH { set; get; }
        public Double? Diem { set; get; }
        public string HoTenSV { set; get; }
    }
}