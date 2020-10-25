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
        [Column(TypeName = "decimal(18,4)")]
        public decimal HrgUsd { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Cost { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Harga { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Qty { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal QtyPo { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal BefNetto { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal HrgNetto { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [DisplayFormat(DataFormatString = "#,###.##")]
        public decimal HrgJual { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal SaldoAwal { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal CostAwal { get; set; }
        public string AcctSet { get; set; }
        public string Category { get; set; }
        public bool SerialNo { get; set; }
        public string CostMethod { get; set; }
        public string JnsBrng { get; set; }
        public string Foto { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal StdPrice { get; set; }
        [AllowNull]
        public Nullable<DateTime> TglPost { get; set; }
        [AllowNull]
        public Nullable<DateTime> LastNetto { get; set; }
        public string NamaLengkap { get; set; }

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
        [Column(TypeName = "decimal(18,4)")]
        public decimal Cost { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Harga { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Qty { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal QtyPo { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal BefNetto { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal HrgNetto { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [DisplayFormat(DataFormatString = "#,###.##")]
        public decimal HrgJual { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal SaldoAwal { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal CostAwal { get; set; }
        public string AcctSet { get; set; }
        public string Category { get; set; }
        public bool SerialNo { get; set; }
        public int CostMethod { get; set; }
        public int JnsBrng { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal StdPrice { get; set; }
        [AllowNull]
        public Nullable<DateTime> TglPost { get; set; }
        [AllowNull]
        public Nullable<DateTime> LastNetto { get; set; }

    }

    public class IcLokasi
    {
        [Key]
        public int IcLokasiId { get; set; }
        public string Lokasi { get; set; }
        public string NamaLokasi { get; set; }
        public string Alamat { get; set; }
        public string Kota { get; set; }
        public string Telpon { get; set; }

    }

    public class IcDept
    {
        [Key]
        public int IcDeptId { get; set; }
        public string DeptCode { get; set; }
        public string NamaDept { get; set; }
    }

    public class IcDiv
    {
        [Key]
        public int IcDivId { get; set; }
        public string Divisi { get; set; }
        public string NamaDiv { get; set; }
    }

    public class IcTransH
    {
        [Key]
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
        public bool Pajak { get; set; }
        public List<IcTransD> IcTransDs { get; set; }
    }

    public class IcTransD
    {
        [Key]
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
        [Column(TypeName = "decimal(18,4)")]
        public decimal Harga { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal QtyBo { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal QtyShp { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Jumlah { get; set; }
        public string AcctSet { get; set; }
        public int IcTransHId { get; set; }
        public IcTransH IcTransH { get; set; }
    }

    public class IcAcct
    {
        [Key]
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
        [Key]
        public int IcCatId { get; set; }
        public string CatCode { get; set; }
        public string Description { get; set; }
        public string Cat1 { get; set; }
        public string Cat2 { get; set; }
        public string Cat3 { get; set; }
        public string Cat4 { get; set; }
        public string Cat5 { get; set; }
        public string Cat6 { get; set; }
    }

  

    public class IcItemView
    {
        [Key]
        public int IcItemId { get; set; }
        [Required]
        public string ItemCode { get; set; }
        [Required]
        public string NamaItem { get; set; }
        [StringLength(5, ErrorMessage = "Satuan terlalu panjang (5 character limit).")]
        public string Satuan { get; set; }
        public string Divisi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Harga { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "#,###.##")]
        public decimal Qty { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal QtyPo { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BefNetto { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HrgNetto { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HrgJual { get; set; }
        [DisplayFormat(DataFormatString = "#,###.##")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoAwal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString ="#,###.##")]
        public decimal CostAwal { get; set; }
        public string AcctSet { get; set; }
        public string Category { get; set; }
        public bool SerialNo { get; set; }
        [Required]
        public string CostMethod { get; set; }
        [Required]
        public string JnsBrng { get; set; }     
        [Column(TypeName = "decimal(18,2)")]
        public decimal StdPrice { get; set; }
        [AllowNull]
        public Nullable<DateTime> TglPost { get; set; }
        [AllowNull]
        public Nullable<DateTime> LastNetto { get; set; }
        public string NamaLengkap
        {
            get
            {
                return NamaItem + " [" + ItemCode.ToUpper() + "]" + " (" + Satuan + ")";
            }
        }
    }

    public class IcDivView
    {
        [Key]
        public int IcDivId { get; set; }
        [Required]
        [StringLength(2, ErrorMessage = "Satuan terlalu panjang (2 character limit).")]
        public string Divisi { get; set; }
        [Required]
        public string NamaDiv { get; set; }
    }

    public class IcAcctView
    {
        [Key]
        public int IcAcctId { get; set; }
        [Required]
        public string AcctSet { get; set; }
        public string Description { get; set; }
        public string Acct1 { get; set; }
        public string Acct2 { get; set; }
        public string Acct3 { get; set; }
        public string Acct4 { get; set; }
        public string Acct5 { get; set; }
        public string Acct6 { get; set; }
    }

    public class IcCatView
    {
        [Key]
        public int IcCatId { get; set; }
        [Required]
        public string CatCode { get; set; }
        public string Description { get; set; }
        public string Cat1 { get; set; }
        public string Cat2 { get; set; }
        public string Cat3 { get; set; }
        public string Cat4 { get; set; }
        public string Cat5 { get; set; }
        public string Cat6 { get; set; }
    }

    public class IcLokasiView
    {
        [Key]
        public int IcLokasiId { get; set; }
        [Required]
        public string Lokasi { get; set; }
        public string NamaLokasi { get; set; }
        public string Alamat { get; set; }
        public string Kota { get; set; }
        public string Telpon { get; set; }

    }

    public class IcTransHView
    {
        [Key]
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
        public List<IcTransDView> IcTransDs { get; set; }
    }

    public class IcTransDView
    {
        [Key]
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
        [Column(TypeName = "decimal(18,4)")]
        public decimal Harga { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal QtyBo { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal QtyShp { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Jumlah { get; set; }
        public string AcctSet { get; set; }
        public int IcTransHId { get; set; }
        public IcTransHView IcTransH { get; set; }
    }
}
