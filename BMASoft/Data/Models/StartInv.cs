using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace BMASoft.Data.Models
{
    public class IcItem
    {
        [Key]
        public int IcItemId { get; set; }
        public string ItemCode { get; set; }
        public string NamaItem { get; set; }
        public string Satuan { get; set; }
        public string Divisi { get; set; }
        public decimal Cost { get; set; }
        public decimal  Harga { get; set; }
        public decimal Qty { get; set; }
        public decimal QtyPo { get; set; }
        public decimal BefNetto { get; set; }
        public decimal HrgNetto { get; set; }
        public decimal HrgJual { get; set; }
        public decimal SaldoAwal { get; set; }
        public decimal CostAwal { get; set; }       
        public string AcctSet { get; set; }
        public string Category { get; set; }
        public bool SerialNo { get; set; }
        public int  CostMethod { get; set; }
        public int JnsBrng { get; set; }
        public decimal StdPrice { get; set; }
        [AllowNull]
        public Nullable<DateTime> TglPost { get; set; }
        [AllowNull]
        public Nullable<DateTime> LastNetto { get; set; }
     
    }

    public class IcAltItem
    {
        [Key]
        public int IcAltItemId { get; set; }    
        public string ItemCode { get; set; }
        public string Lokasi { get; set; }
        public string NamaItem { get; set; }
        public string Satuan { get; set; }
        public string Divisi { get; set; }
        public decimal Cost { get; set; }
        public decimal Harga { get; set; }
        public decimal Qty { get; set; }
        public decimal QtyPo { get; set; }
        public decimal BefNetto { get; set; }
        public decimal HrgNetto { get; set; }
        public decimal HrgJual { get; set; }
        public decimal SaldoAwal { get; set; }
        public decimal CostAwal { get; set; }
        public string AcctSet { get; set; }
        public string Category { get; set; }
        public bool SerialNo { get; set; }
        public int CostMethod { get; set; }
        public int JnsBrng { get; set; }
        public decimal StdPrice { get; set; }
        [AllowNull]
        public Nullable<DateTime> TglPost { get; set; }
        [AllowNull]
        public Nullable<DateTime> LastNetto { get; set; }

    }

    public class IcLokasi
    {
        public int IcLokasiId { get; set; }
        public string Lokasi { get; set; }
        public string NamaLokasi { get; set; }
        public string Alamat { get; set; }
        public string Kota { get; set; }
        public string Telpon { get; set; }

    }

    public class IcDept
    {
        public int IcDeptId { get; set; }
        public string DeptCode { get; set; }
        public string NamaDept { get; set; }
    }

    public class IcDiv
    {
        public int IcDivId { get; set; }
        public string Divisi { get; set; }
        public string NamaDiv { get; set; }
    }

    public class IcTransH
    {
        public int IcTransHId { get; set; }
        public string Kode { get; set; }
        public string NoOrder { get; set; }
        public string NoFaktur { get; set; }
        public string NoSj { get; set; }
        public DateTime Tanggal { get; set; }
        public string Lokasi { get; set; }
        public string Lokasi2 { get; set; }
        public string Keterangan { get; set; }
        public string AcctSet { get; set; }
    }

    public class IcTransD
    {
        public int IcTransDId { get; set; }
        public string Kode { get; set; }
        public string NoOrder { get; set; }
        public string NoFaktur { get; set; }
        public string NoSj { get; set; }
        public DateTime Tanggal { get; set; }
        public string Lokasi { get; set; }
        public string Lokasi2 { get; set; }
        public string ItemCode { get; set; }
        public string NamaItem { get; set; }
        public string Satuan { get; set; }
        public decimal Harga { get; set; }
        public decimal QtyBo { get; set; }
        public decimal QtyShp { get; set; }
        public decimal Jumlah { get; set; }
        public string AcctSet { get; set; }
    }

    public class IcAcct
    {
        public int IcAcctId { get; set; }
        public string AcctSet { get; set; }
        public string Description { get; set; }
        public string Acct1 { get; set; }
        public string Acct2 { get; set; }
        public string Acct3 { get; set; }
        public string Acct4 { get; set; }
        public string Acct5 { get; set; }
        public string Acct6 { get; set; }
    }

    public class IcCat
    {
        public int IcCatID { get; set; }
        public string CatCode { get; set; }
        public string Description { get; set; }
        public string Cat1 { get; set; }
        public string Cat2 { get; set; }
        public string Cat3 { get; set; }
        public string Cat4 { get; set; }
        public string Cat5 { get; set; }
        public string Cat6 { get; set; }
    }
}
