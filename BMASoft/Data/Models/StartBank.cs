using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BMASoft.Data.Models
{
    public class CbBank
    {
        [Key]
        public int CbBankId { get; set; }
        public string KodeBank { get; set; }
        [StringLength(100)]
        public string NmBank { get; set; }
        [StringLength(3)]
        public string Kurs { get; set; }
        [StringLength(6)]
        public string Acctset { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal SldAWal { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal KSldAwal { get; set; }
        public DateTime ClrDate { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Saldo { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal KSaldo { get; set; }
        public bool NonPpn { get; set; }
        public bool Pajak { get; set; }
        public string GrpBank { get; set; }
    }

    public class CbTransH
    {
        [Key]
        public int CbTransHId { get; set; }
        public string DocNo { get; set; }
        public string KodeBank { get; set; }
        public string Refno { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tanggal { get; set; }
        public string Acctset { get; set; }
        public string Supplier { get; set; }
        public string Customer { get; set; }
        public string Giro { get; set; }
        [StringLength(3)]
        public string Kurs { get; set; }     
        public bool NonPPN { get; set; }
        public bool Pajak { get; set; }
        public bool Cek { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Saldo { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal KSaldo { get; set; }
        
        public List<CbTransD> CbTransDs { get; set; }

   
    }

    

    public class CbTransD
    {
        [Key]
        public int CbTransDId { get; set; }
        public string NoPrj { get; set; }
        public int SrcCodeId { get; set; }
        public string SrcCode { get; set; }
        public string GlAcct { get; set; }
        public string Keterangan { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Jumlah { get; set; }       
        [Column(TypeName = "decimal(18,4)")]
        public decimal Terima { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Bayar { get; set; }
        public string Kurs { get; set; }
        [Column(TypeName ="decimal(18,4)")]
        public decimal KValue { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal KJumlah { get; set; }      
        [Column(TypeName = "decimal(18,4)")]
        public decimal KTerima { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal KBayar { get; set; }
        public int CbTransHId { get; set; }
        public CbTransH CbTransH { get; set; }

    }

    public class CbTransfer
    {
        [Key]
        public int CbTransferId { get; set; }
        public string DocNo { get; set; }
        public string KodeBank1 { get; set; }
        public string KodeBank2 { get; set; }
        public string Refno { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tanggal { get; set; }
        public string Acctset { get; set; }
        public string Giro { get; set; }
        [StringLength(3)]
        public string Kurs { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal KValue { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Saldo { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal KSaldo { get; set; }
        public bool NonPPN { get; set; }
        public bool Pajak { get; set; }
        public bool Cek { get; set; }
    }

    public class CbSrcCode
    {
        public int CbSrcCodeId { get; set; }
        public string SrcCode { get; set; }
        public string NamaSrc { get; set; }
        public string GlAcct { get; set; }
        [StringLength(3)]
        public string Grp { get; set; }
    }

    public class CbGrp
    {
        [Key]
        public int CbGrpId { get; set; }
        [StringLength(3)]
        public string Grp { get; set; }
        public string NamaGrp { get; set; }
    }

    // ----- Section View

    public class BankView
    {
       
        public int bankId { get; set; }
        [Required]
        [MinLength(2)]
        [StringLength(2, ErrorMessage = "Kode Bank terlalu panjang (2 character limit).")]
        public string kdbank { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Nama Bank terlalu panjang (100 character limit).")]
        public string namabank { get; set; }
        [StringLength(3, ErrorMessage = "Kurs terlalu panjang (3 character limit).")]
        public string kurs { get; set; }
        [StringLength(7, ErrorMessage ="Akun terlalu panjang (7 character limit).")]
        public string Acctset { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal SldAWal { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal KSldAwal { get; set; }
        public DateTime ClrDate { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Saldo { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal KSaldo { get; set; }
        public bool NonPpn { get; set; }
        public bool Pajak { get; set; }
    }

    public class SrcCodeView
    {
        
        public int SrcCodeId { get; set; }
        [Required]
        [MinLength(2)]
        [StringLength(3, ErrorMessage = "Source Code terlalu panjang (3 character limit).")]
        public string SrcCode { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Nama terlalu panjang (100 character limit).")]
        public string NamaSrc { get; set; }
        [StringLength(7)]
        public string GlAcct { get; set; }
        [StringLength(3)]
        public string Grp { get; set; }
    }

    public class TranshView
    {
 
        public int CbTransHId { get; set; }
        [StringLength(3, ErrorMessage = "Code terlalu panjang (3 character limit).")]
        public string KodeDoc { get; set; }
        public string DocNo { get; set; }
        public string KodeBank { get; set; }
        public string Refno { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tanggal { get; set; } 
        [StringLength(3)]
        public string Kurs { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Saldo
        {
            get
            {
                return TransDs.Sum(p => p.Jumlah);
            }
        }
        [Column(TypeName = "decimal(18,4)")]
        public decimal KSaldo
        {
            get
            {
                return TransDs.Sum(p => p.KJumlah);
            }
        }

        public bool NonPPN { get; set; }
        public bool Pajak { get; set; }
        public bool Cek { get; set; }


        public List<TransDView> TransDs { get; set; }

    }

    public class TransDView
    {

        public int CbTransDId { get; set; }
        public string NoPrj { get; set; }
        public string SrcCode { get; set; }
        public string GlAcct { get; set; }
        public string Keterangan { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Jumlah
        {
            get
            {
                return Terima - Bayar;
            }

        }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Terima { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Bayar { get; set; }
        public string Kurs { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal KValue { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal KJumlah
        {
            get
            {
                return KTerima - KBayar;
            }
        }
        [Column(TypeName = "decimal(18,4)")]
        public decimal KTerima { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal KBayar { get; set; }
        public int TransHId { get; set; }
        public TranshView TransH { get; set; }

    }

}
