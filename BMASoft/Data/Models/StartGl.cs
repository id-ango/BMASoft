using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Syncfusion.Blazor.CircularGauge;

namespace BMASoft.Data.Models
{
    public class GlAccount
    {
        [Key]
        public int GlAccountId { get; set; }
        public string GlAcct { get; set; }
        public string GlNama { get; set; }
        public string GlDept { get; set; }
        public string GlStatus { get; set; }
        public int GlTipe { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlSaldo { get; set; }
        public Nullable<DateTime> GlPost { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlSldAwal { get; set; }
        public string GlKurs { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlFisc1 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlFisc2 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlFisc3 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlFisc4 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlFisc5 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlFisc6 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlFisc7 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlFisc8 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlFisc9 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlFisc10 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlFisc11 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlFisc12 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlPreFisc1 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlPreFisc2 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlPreFisc3 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlPreFisc4 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlPreFisc5 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlPreFisc6 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlPreFisc7 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlPreFisc8 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlPreFisc9 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlPreFisc10 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlPreFisc11 { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GlPreFisc12 { get; set; }
        public string NamaLengkap { get; set; }
    }

    public class GlCode
    {
        [Key]
        public int GlCodeId { get; set; }
        public string KodeGl { get; set; }
        public string NamaGl { get; set; }
    }

    public class GlTransH
    {
        [Key]
        public int GlTransHId { get; set; }
        public string DocNo { get; set; }
        public DateTime Tanggal { get; set; }
        public string GlMemo { get; set; }
        public string KodeGl { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Debet { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Kredit { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Saldo { get; set; }
        public string Kurs { get; set; }
        public List<GlTransD> GlTransDs { get; set; }
    }

    public class GlTransD
    {
        [Key]
        public int GlTransDId { get; set; }
        public string Keterangan { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Debet { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Kredit { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Jumlah { get; set; }
        public int GlTransHId { get; set; }
        public GlTransH GlTransH { get; set; }
    }
}
