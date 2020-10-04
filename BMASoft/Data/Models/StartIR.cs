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
    public class IrTransH
    {
        [Key]
        public int IrTransHId { get; set; }
        [StringLength(2)]
        public string Kode { get; set; }    
        public string NoLpb { get; set; }
        public string NoPrj { get; set; }
        public string Lokasi { get; set; }
        public DateTime Tanggal { get; set; }
        public DateTime JthTempo { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TtlJumlah { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal DPayment { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Ongkos { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PpnPersen { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Ppn { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Jumlah { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Tagihan { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalQty { get; set; }
        public string Supplier { get; set; }
        public string NamaSup { get; set; }
        public string Keterangan { get; set; }
        public string Cek { get; set; }
        public bool Pajak { get; set; }
        public List<IrTransD>  IrTransDs { get; set; }

    }

    public class IrTransD
    {
        [Key]
        public int IrTransDId{ get; set; }
        [StringLength(2)]
        public string Kode { get; set; }     
        public string NoLpb { get; set; }
        public DateTime Tanggal { get; set; }
        public string ItemCode { get; set; }
        public string NamaItem { get; set; }
        public string Satuan { get; set; }
        public string Lokasi { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Harga { get; set; }      
        [Column(TypeName = "decimal(18,4)")]
        public decimal Persen { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Discount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Qty { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal QtyBo { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal JumDpp { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Jumlah { get; set; }       
        public string Supplier { get; set; }
        public string AcctSet { get; set; }
        public int IrTransHId { get; set; }
        public IrTransH IrTransH { get; set; }
    }

    public class IrTransHView
    {
        [Key]
        public int IrTransHId { get; set; }
        [StringLength(2)]
        public string Kode { get; set; }
        public string NoLpb { get; set; }
        public string NoPrj { get; set; }
        public string Lokasi { get; set; }
        public DateTime Tanggal { get; set; }
        public DateTime JthTempo { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TtlJumlah
        {
            get
            {
                return IrTransDs.Sum(p => p.Jumlah);
            }
        }
        [Column(TypeName = "decimal(18,4)")]
        public decimal DPayment { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Ongkos { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PpnPersen { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Ppn { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Jumlah
        {
            get
            {
                return TtlJumlah+Ongkos+Ppn;
            }
        }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalQty
        {
            get
            {
                return IrTransDs.Sum(p => p.Qty);
            }
        }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Tagihan
        {
            get
            {
                return Jumlah-DPayment;
            }
        }
        public string Supplier { get; set; }
        public string NamaSup { get; set; }
        public string Keterangan { get; set; }
        public string Cek { get; set; }
        public bool Pajak { get; set; }
        public List<IrTransDView> IrTransDs { get; set; }

    }

    public class IrTransDView
    {
        [Key]
        public int IrTransDId { get; set; }
        [StringLength(2)]
        public string Kode { get; set; }
        public string NoLpb { get; set; }
        public DateTime Tanggal { get; set; }
        public string ItemCode { get; set; }
        public string NamaItem { get; set; }
        public string Satuan { get; set; }
        public string Lokasi { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Harga { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Persen { get; set; }       
        [Column(TypeName = "decimal(18,4)")]
        public decimal Discount { get; set; }       
        [Column(TypeName = "decimal(18,4)")]
        public decimal Qty { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal QtyBo { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal JumDpp { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Jumlah { get; set; }

        public decimal UpdateJumlah
        {
            get
            {
                var price = Qty * Harga;           
                return price - Discount;
            }
        }

        public string Supplier { get; set; }
        public string AcctSet { get; set; }
        public int IrTransHId { get; set; }
        public IrTransHView IrTransH { get; set; }
    }
}
