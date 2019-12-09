using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TayBac_28_06_17.Models.EntityModels;

namespace TayBac_28_06_17.Models.EntityModels
{
    public class HuyetapViewModel
    {
        #region Benhvien
        public string idbv { get; set; }

        public string tenbv { get; set; }

        public string dienthoaibv { get; set; }

        public string faxbv { get; set; }

        public string IPbv { get; set; }

        public string xabv { get; set; }

        public string huyenbv { get; set; }

        public string tinhbv { get; set; }

        //public Hospital hosital { get; set; }

        #endregion Benhvien
        #region Benhnhan
        //id benh nhan
        public string idbn { get; set; }
        //ten benh nha
        public string tenbn { get; set; }

        public DateTime? ngaysinh { get; set; }

        public bool? gioitinh { get; set; }

        public string nghenghiep { get; set; }

        public string dantoc { get; set; }

        public string ngoaikieu { get; set; }

        public string noilamviec { get; set; }

        public string dienthoai { get; set; }

        public string email { get; set; }

        public string xa { get; set; }

        public string huyen { get; set; }

        public string tinh { get; set; }

        #endregion Benhnhan
        #region Benhsu
        //id benh su
        public string idbs { get; set; }

        #endregion Benhsu
        #region HuyetAp

        public string idhuyetap { get; set; }

        public string HA_I { get; set; }

        public string HA_II_A { get; set; }

        public bool HA_II_B_1 { get; set; }

        public string HA_II_B_1_1 { get; set; }

        public bool HA_II_B_2 { get; set; }

        public string HA_II_B_2_1 { get; set; }

        public bool? HA_II_B_3 { get; set; }

        public string HA_II_B_3_1 { get; set; }

        public bool? HA_II_B_4 { get; set; }

        public string HA_II_B_4_1 { get; set; }

        public string HA_II_B_5 { get; set; }

        public bool? HA_II_B_6 { get; set; }

        public string HA_II_B_6_1 { get; set; }

        public float? HA_III_1_1 { get; set; }

        public float? HA_III_1_2 { get; set; }

        public int? HA_III_1_3_1 { get; set; }

        public int? HA_III_1_3_2 { get; set; }

        public int? HA_III_1_4 { get; set; }

        public float? HA_III_1_5 { get; set; }

        public float? HA_III_1_6 { get; set; }

        public string HA_III_2 { get; set; }

        public string HA_IV_1 { get; set; }

        public float? HA_IV_2 { get; set; }

        public float? HA_IV_3 { get; set; }

        public float? HA_IV_4 { get; set; }

        public float? HA_IV_5 { get; set; }

        public float? HA_IV_6 { get; set; }

        public bool? HA_IV_7 { get; set; }

        public bool? HA_IV_8 { get; set; }

        public bool? HA_IV_9 { get; set; }

        public bool? HA_IV_10 { get; set; }

        public bool? HA_IV_11 { get; set; }

        public bool? HA_IV_12 { get; set; }

        public bool? HA_IV_13 { get; set; }

        public bool? HA_IV_14 { get; set; }

        public bool? HA_V_15 { get; set; }
        public bool? HA_V_16 { get; set; }
        public bool? HA_V_17 { get; set; }
        public bool? HA_V_18 { get; set; }
        public bool? HA_V_19 { get; set; }
        public bool? HA_V_20 { get; set; }
        public bool? HA_V_21 { get; set; }
        public bool? HA_V_22 { get; set; }
        public bool? HA_V_23 { get; set; }
        public bool? HA_V_24 { get; set; }
        public bool? HA_V_25 { get; set; }


        public DateTime? ngaynhapvien { get; set; }

        #endregion HuyetAp
    }
}