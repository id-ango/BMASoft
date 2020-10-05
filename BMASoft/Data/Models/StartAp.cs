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
    public class ApSuppl
    {
        [Key]
        public int ApSupplId { get; set; }
        public string Supplier { get; set; }
        public string NamaSup { get; set; }
        public string Person { get; set; }
        public string Alamat { get; set; }
        public string Kota { get; set; }
        public string Provinsi { get; set; }
        public string Telpon { get; set; }
        public string NPWP_Sup { get; set; }
        public string AlmtNPWP { get; set; }
        public int Termin { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Disc1 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Disc2 { get; set; }
        public string Kontak { get; set; }
        public string Fax { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal SldAwal { get; set; }
        public bool Pajak { get; set; }
        public string AcctSet { get; set; }
        public string AcctPjk { get; set; }
        [AllowNull]
        public Nullable<DateTime> TglPost { get; set; }
        [AllowNull]
        public Nullable<DateTime> TglMasuk { get; set; }
        [AllowNull]
        public Nullable<DateTime> LstOrder { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Hutang { get; set; }
        public string NamaLengkap { get; set; }


    }

    public class ApTransH
    {
        [Key]
        public int ApTransHId { get; set; }
        [StringLength(2)]
        public string Kode { get; set; }
        public string Bukti { get; set; }
        public DateTime Tanggal { get; set; }
        public string KdBank { get; set; }
        public string Supplier { get; set; }
        public string NoFaktur { get; set; }
        public string Keterangan { get; set; }
        public Nullable<DateTime> JthTempo { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PPn { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PPh { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal JumPPh { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal JumPPn { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Bruto { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Netto { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Jumlah { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Discount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Hutang { get; set; }
        public bool Pajak { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Unapplied { get; set; }
        public string AcctSet { get; set; }
        public List<ApTransD> ApTransDs { get; set; }
        public int ApSupplId { get; set; }
        public string NamaSup { get; set; }
        //     public ArCust ArCust { get; set; }


    }

    public class ApTransD
    {
        [Key]
        public int ApTransDId { get; set; }
        public DateTime Tanggal { get; set; }
        [StringLength(2)]
        public string Kode { get; set; }
        [StringLength(2)]
        public string KodeTran { get; set; }
        public string Lpb { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Jumlah { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Bayar { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Sisa { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Discount { get; set; }
        public string Keterangan { get; set; }
        public string DistCode { get; set; }
        public int ApTransHId { get; set; }
        public ApTransH ApTransH { get; set; }
    }

    public class ApHutang
    {
        public int ApHutangId { get; set; }
        public string Kode { get; set; }
        public string Dokumen { get; set; }
        public DateTime Tanggal { get; set; }
        public Nullable<DateTime> DueDate { get; set; }
        public string KodeTran { get; set; }
        public string LPB { get; set; }
        public string Keterangan { get; set; }
        public string Supplier { get; set; }
        public bool Pajak { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Jumlah { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Bayar { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Sisa { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Discount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal UnApplied { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Dpp { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PPn { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PPh { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal SldSisa { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal SldBayar { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal SldDisc { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal SldUnpl { get; set; }


    }

    public class ApAcct
    {
        public int ApAcctId { get; set; }
        public string AcctSet { get; set; }
        public string Description { get; set; }
        public string Acct1 { get; set; }
        public string Acct2 { get; set; }
        public string Acct3 { get; set; }
        public string Acct4 { get; set; }
        public string Acct5 { get; set; }
        public string Acct6 { get; set; }
    }

    public class ApDist
    {
        public int ApDistId { get; set; }
        public string DistCode { get; set; }
        public string Description { get; set; }
        public string Dist1 { get; set; }
    }

    public class SupplierView
    {
        [Key]
        public int ApSupplId { get; set; }
        [Required]
        [MinLength(5)]
        [StringLength(5, ErrorMessage = "Kode Bank terlalu panjang (5 character limit).")]
        public string Supplier { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Nama Supplier terlalu panjang (100 character limit).")]
        public string NamaSup { get; set; }
        public string Person { get; set; }
        [Required(ErrorMessage = "Alamat Harus Diisi")]
        public string Alamat { get; set; }
        [Required(ErrorMessage = "Kota Harus Diisi")]
        public string Kota { get; set; }
        public string Provinsi { get; set; }
        public string AlmtKrm { get; set; }
        public string KotaKrm { get; set; }
        public string ProvKirim { get; set; }
        [Required(ErrorMessage = "Telpon Harus Diisi")]
        public string Telpon { get; set; }
        public string NPWP_Sup { get; set; }
        public string AlmtNPWP { get; set; }
        public string Expedisi { get; set; }
        public int Termin { get; set; } = 0;
        [Column(TypeName = "decimal(18,4)")]
        public decimal Disc1 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Disc2 { get; set; }
        public string Kontak { get; set; }
        public string Fax { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal SldAwal { get; set; }
        public bool Pajak { get; set; }
        public string AcctSet { get; set; }
        public string AcctPjk { get; set; }
        public DateTime TglPost { get; set; }
        public DateTime TglMasuk { get; set; }
        public DateTime LstOrder { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Hutang { get; set; }
        public string NamaLengkap
        {
            get
            {
                return NamaSup + " [" + Supplier.ToUpper() + "]" + " (" + Alamat + ")";
            }
        }
    }

    public class ApAcctView
    {
        public int ApAcctId { get; set; }
        [Required(ErrorMessage = "AkunSet harus diisi")]
        public string AcctSet { get; set; }
        [StringLength(100, ErrorMessage = "Keterangan terlalu panjang (100 character limit).")]
        public string Description { get; set; }
        public string Acct1 { get; set; }
        public string Acct2 { get; set; }
        public string Acct3 { get; set; }
        public string Acct4 { get; set; }
        public string Acct5 { get; set; }
        public string Acct6 { get; set; }
    }

    public class ApDistView
    {
        public int ApDistId { get; set; }
        [Required(ErrorMessage = "Distribution Code harus diisi")]
        public string DistCode { get; set; }
        [StringLength(100, ErrorMessage = "Keterangan terlalu panjang (100 character limit).")]
        public string Description { get; set; }
        public string Dist1 { get; set; }
    }

    public class ApTransHView
    {
        [Key]
        public int ApTransHId { get; set; }
        public string Kode { get; set; }
        public string Bukti { get; set; }
        public DateTime Tanggal { get; set; }
        public string KdBank { get; set; }
        public string Supplier { get; set; }
        public string NoFaktur { get; set; }
        public string Keterangan { get; set; }
        public DateTime JthTempo { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PPn { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PPh { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal JumPPh { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal JumPPn { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Bruto { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Netto { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Jumlah
        {
            get
            {
                return ApTransDs.Sum(p => p.Jumlah);
            }
        }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Discount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Hutang { get; set; }
        public bool Pajak { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Unapplied { get; set; }
        public string AcctSet { get; set; }
        public List<ApTransDView> ApTransDs { get; set; }
        public int ApSupplId { get; set; }
        public ApSuppl ApSuppl { get; set; }
        public decimal JumBayar { get; set; }
        public decimal UpdateUnapplied
        {
            get
            {
                return JumBayar - ApTransDs.Sum(p => p.Bayar);
            }
        }

        public decimal JumDiskon
        {
            get
            {
                return ApTransDs.Sum(p => p.Discount);
            }
        }

        public decimal JumHutang
        {
            get
            {
                return ApTransDs.Sum(p => p.Bayar + Discount);
            }
        }
    }

    public class ApTransDView
    {
        [Key]
        public int ApTransDId { get; set; }
        public DateTime Tanggal { get; set; }
        public string KodeTran { get; set; }
        public string Lpb { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Jumlah { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Bayar { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Sisa { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Discount { get; set; }
        public string Keterangan { get; set; }
        public decimal UpdateSisa
        {
            get
            {
                return Jumlah - Bayar - Discount;
            }
        }
        public string DistCode { get; set; }
        public int ApTransHId { get; set; }
        public ApTransHView ApTransH { get; set; }
    }
}


