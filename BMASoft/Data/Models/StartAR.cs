using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.Blazor.CircularGauge;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BMASoft.Data.Models
{
    public class ArCust
    {
        [Key]
        public int ArCustId { get; set; }
        public string Customer { get; set; }
        public string NamaCust { get; set; }
        public string Golongan { get; set; }
        public string Alamat { get; set; }
        public string Kota { get; set; }
        public string Provinsi { get; set; }
        public string AlmtKrm { get; set; }
        public string KotaKrm { get; set; }
        public string ProvKirim { get; set; }
        public string Telpon { get; set; }
        public string NPWP_Cust { get; set; }
        public string AlmtNPWP { get; set; }
        public string Expedisi { get; set; }
        public int Termin { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Disc1 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Disc2 { get; set; }
        public string Kontak { get; set; }
        public string Fax { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal SldAwal { get; set; }
        public bool NonPPN { get; set; }
        public string AcctSet { get; set; }
        [AllowNull]
        public Nullable<DateTime> TglPost { get; set; }
        [AllowNull]
        public Nullable<DateTime> TglMasuk { get; set; }
        [AllowNull]
        public Nullable<DateTime> LstOrder { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Piutang { get; set; }
    }

    public class ArTransH
    {
        [Key]
        public int ArTransHId { get; set; }
        public string Kode { get; set; }
        public string Bukti { get; set; }
        public DateTime Tanggal { get; set; }
        public string KdBank { get; set; }
        public string Customer { get; set; }
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
        public decimal Jumlah { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Discount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Piutang { get; set; }
        public bool Pajak { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Unapplied { get; set; }
        public string AcctSet { get; set; }
        public List<ArTransD> ArTransDs { get; set; }
        public ArCust ArCust { get; set; }
        public string NamaCustomer()
        {
            return ArCust.NamaCust;
        }
    }

    public class ArTransD
    {
        [Key]
        public int ArTransDId { get; set; }
        public DateTime Tanggal { get; set; }
        public int KodeTran { get; set; }
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
        public int ArTransHId { get; set; }
        public ArTransH ArTransH { get; set; }
    }

    public class ArPiutng
    {
        public int ArPiutngId { get; set; }
        public string Kode { get; set; }
        public string Dokumen { get; set; }
        public DateTime Tanggal { get; set; }
        public DateTime DueDate { get; set; }
        public string KodeTran { get; set; }
        public string LPB { get; set; }
        public string Keterangan { get; set; }
        public string Customer { get; set; }
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

    public class ArAcct
    {
        public int ArAcctId{ get; set; }
        public string AcctSet { get; set; }
        public string Description { get; set; }
        public string Acct1 { get; set; }
        public string Acct2 { get; set; }
        public string Acct3 { get; set; }
        public string Acct4 { get; set; }
        public string Acct5 { get; set; }
        public string Acct6 { get; set; }
    }

    public class ArDist
    {
        public int ArDistId { get; set; }
        public string DistCode { get; set; }
        public string Description { get; set; }
        public string Dist1 { get; set; }
    }

    public class CustomerView
    {
        [Key]
        public int ArCustId { get; set; }
        [Required]
        [MinLength(5)]
        [StringLength(5, ErrorMessage = "Kode Bank terlalu panjang (5 character limit).")]
        public string Customer { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Nama customer terlalu panjang (100 character limit).")]
        public string NamaCust { get; set; }
        public string Golongan { get; set; }
        [Required(ErrorMessage = "Alamat Harus Diisi")]
        public string Alamat { get; set; }
        [Required(ErrorMessage = "Kota Harus Diisi")]
        public string Kota { get; set; }
        public string Provinsi { get; set; }       
        public string AlmtKrm { get; set; }
        public string KotaKrm { get; set; }
        public string ProvKirim { get; set; }
        [Required(ErrorMessage ="Telpon Harus Diisi")]      
        public string Telpon { get; set; }
        public string NPWP_Cust { get; set; }
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
        public bool NonPPN { get; set; }
        public string AcctSet { get; set; }
        public DateTime TglPost { get; set; }
        public DateTime TglMasuk { get; set; }
        public DateTime LstOrder { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Piutang { get; set; }
    }

    public class ArAcctView
    {
        public int ArAcctId { get; set; }
        [Required(ErrorMessage ="AkunSet harus diisi")]
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
    
    public class ArDistView
    {
        public int ArDistId { get; set; }
        [Required(ErrorMessage = "Distribution Code harus diisi")]
        public string DistCode { get; set; }
        [StringLength(100, ErrorMessage = "Keterangan terlalu panjang (100 character limit).")]
        public string Description { get; set; }
        public string Dist1 { get; set; }
    }

    public class ArTransHView
    {
        [Key]
        public int ArTransHId { get; set; }
        public string Kode { get; set; }
        public string Bukti { get; set; }
        public DateTime Tanggal { get; set; }
        public string KdBank { get; set; }
        public string Customer { get; set; }
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
                return ArTransDs.Sum(p => p.Jumlah);
            }
        }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Discount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Piutang { get; set; }
        public bool Pajak { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Unapplied { get; set; }
        public string AcctSet { get; set; }
        public List<ArTransDView> ArTransDs { get; set; }
        public ArCust ArCust { get; set; }

        public string NamaCustomer()
        {
            return ArCust.NamaCust;
        }
    }

    public class ArTransDView
    {
        [Key]
        public int ArTransDId { get; set; }
        public DateTime Tanggal { get; set; }
        public int KodeTran { get; set; }
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
        public int ArTransHId { get; set; }
        public ArTransHView ArTransH { get; set; }
    }
}
