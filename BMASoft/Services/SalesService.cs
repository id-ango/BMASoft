using BMASoft.Data;
using BMASoft.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;


namespace BMASoft.Services
{

    public interface ISalesService
    {
        OeTransH GetOeTrans(int id);
        Task<List<OeTransH>> GetTransH();
        Task<List<OeTransH>> Get3TransH();
        Task<List<OeTransD>> GetTransD();
        Task<bool> AddTransH(OeTransHView trans);
        Task<bool> DelTransH(int id);
        Task<bool> EditTransH(OeTransHView trans);
    }

    public class SalesService : ISalesService
    {
        private readonly BmaDbContext _context;

        public SalesService(BmaDbContext context)
        {
            _context = context;
        }

        #region getclass

        private ArCust GetCustomerId(string id)
        {
            return _context.ArCusts.Where(x => x.Customer == id).FirstOrDefault();
        }

        public ArPiutng GetPiutang(string bukti)
        {
            return _context.ArPiutngs.Where(x => x.Dokumen == bukti).FirstOrDefault();

        }

        #endregion getclass

        #region OeTransH class

        public OeTransH GetOeTrans(int id)
        {
            return _context.OeTransHs.Include(p => p.OeTransDs).Where(x => x.OeTransHId == id).FirstOrDefault();
        }


        public async Task<List<OeTransH>> GetTransH()
        {
            List<OeTransH> OeTrans = new List<OeTransH>();
            try
            {
                OeTrans = await _context.OeTransHs.OrderByDescending(x => x.Tanggal).Where(x => x.Kode == "94").ToListAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
            return OeTrans;
            // return  _context.CbTransHs.Include(p =>p.CbTransDs).OrderByDescending(x =>x.Tanggal).ToListAsync();
            //  return await _context.ApTransHs.OrderByDescending(x => x.Tanggal).ToListAsync();
            //  return await _context.ApTransHs.ToListAsync();

        }

        public async Task<List<OeTransH>> Get3TransH()
        {
            List<OeTransH> OeTrans = new List<OeTransH>();

            OeTrans = await _context.OeTransHs.OrderByDescending(x => x.Tanggal).Where(x => x.Tanggal > DateTime.Today.AddMonths(-3) && x.Kode == "94").ToListAsync();

            return OeTrans;

            // return  _context.CbTransHs.Include(p =>p.CbTransDs).OrderByDescending(x =>x.Tanggal).ToListAsync();
            //   return _context.ApTransHs.OrderByDescending(x => x.Tanggal).Where(x => x.Tanggal > DateTime.Today.AddMonths(-3)).ToListAsync();

        }

        public async Task<List<OeTransD>> GetTransD()
        {
            return await _context.OeTransDs.ToListAsync();
        }

        public async Task<bool> AddTransH(OeTransHView trans)
        {
            //string test = codeview.SrcCode.ToUpper();
            //var cekFirst = _context.CbSrcCodes.Where(x => x.SrcCode == test).ToList();
            decimal mQty5 = 0;

            OeTransH transH = new OeTransH
            {
                NoLpb = GetNumber(),
                Customer = trans.Customer.ToUpper(),
                NamaCust = trans.NamaCust,
                Lokasi = trans.Lokasi.ToUpper(),
                Tanggal = trans.Tanggal,
                Keterangan = trans.Keterangan,
                Jumlah = trans.Jumlah,
                Ongkos = trans.Ongkos,
                Ppn = trans.Ppn,
                PpnPersen = trans.PpnPersen,
                TtlJumlah = trans.TtlJumlah,
                DPayment = trans.DPayment,
                Tagihan = trans.Tagihan,
                TotalQty = trans.TotalQty,
                Kode = "94",
                Cek = "1",

                OeTransDs = new List<OeTransD>()
            };

            foreach (var item in trans.OeTransDs)
            {
                if (item.Qty != 0)
                {
                    if (transH.TotalQty != 0)
                    {
                        mQty5 = (item.Jumlah - item.Discount) - (item.Qty / transH.TotalQty * transH.Ppn) + (item.Qty / transH.TotalQty * transH.Ongkos);
                    }

                   

                    IcItem cekItem = _context.IcItems.Where(x => x.ItemCode == item.ItemCode).FirstOrDefault();

                    if (cekItem != null)
                    {
                        IcAltItem cekLokasi1 = _context.IcAltItems.Where(x => x.ItemCode == item.ItemCode && x.Lokasi == trans.Lokasi).FirstOrDefault();
                        if (cekLokasi1 == null)
                        {
                            IcAltItem Produk = new IcAltItem()
                            {
                                ItemCode = cekItem.ItemCode.ToUpper(),
                                NamaItem = cekItem.NamaItem,
                                Satuan = cekItem.Satuan,
                                Lokasi = trans.Lokasi,
                                Qty = -1*item.Qty
                            };
                            _context.IcAltItems.Add(Produk);

                        }
                        else
                        {
                            cekLokasi1.Qty -= item.Qty;
                            _context.IcAltItems.Update(cekLokasi1);
                        }
                      
                        cekItem.HrgJual = item.Harga;
                      

                        if (cekItem.JnsBrng.Equals("Stock"))   // jika stock
                        {
                            cekItem.Qty -= item.Qty;
                        }

                        if (cekItem.CostMethod.Equals("Moving Avarage"))  // jika moving avarage
                        {

                            cekItem.Cost -= item.Cost;
                        }

                        transH.OeTransDs.Add(new OeTransD()
                        {
                            ItemCode = item.ItemCode.ToUpper(),
                            NamaItem = item.NamaItem,
                            Satuan = item.Satuan,
                            Lokasi = transH.Lokasi,
                            Harga = item.Harga,
                            Qty = item.Qty,
                            Persen = item.Persen,
                            Discount = item.Discount,
                            Jumlah = item.Jumlah,
                            Kode = "94",
                            NoLpb = transH.NoLpb,
                            Tanggal = trans.Tanggal,
                            HrgCost = item.HrgCost,
                            Cost = item.Cost,
                            JumDpp = mQty5
                        });

                        _context.IcItems.Update(cekItem);

                    }
                }
                _context.OeTransHs.Add(transH);
            }

           

            var customer = GetCustomerId(transH.Customer);

            ArPiutng piutang = new ArPiutng
            {
                Kode = "OE",
                Dokumen = transH.NoLpb,
                Tanggal = transH.Tanggal,
                DueDate = transH.Tanggal.AddDays(customer.Termin),
                Customer = transH.Customer,
                Keterangan = transH.Keterangan,
                Jumlah = transH.Jumlah,
                Sisa = transH.Jumlah,
                SldSisa = transH.Jumlah,
                KodeTran = transH.Kode
            };
            _context.ArPiutngs.Add(piutang);

            customer.Piutang += transH.Jumlah;

            _context.ArCusts.Update(customer);

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DelTransH(int id)
        {
            try
            {
                var ExistingTrans = _context.OeTransHs.Where(x => x.OeTransHId == id).FirstOrDefault();

                if (ExistingTrans != null)
                {
                    foreach (var item in ExistingTrans.OeTransDs)
                    {
                        if (item.Qty != 0)
                        {

                            IcItem cekItem = _context.IcItems.Where(x => x.ItemCode == item.ItemCode).FirstOrDefault();
                            if (cekItem != null)
                            {
                                IcAltItem cekLokasi1 = _context.IcAltItems.Where(x => x.ItemCode == item.ItemCode && x.Lokasi == ExistingTrans.Lokasi).FirstOrDefault();
                                if (cekLokasi1 == null)
                                {
                                    IcAltItem Produk = new IcAltItem()
                                    {
                                        ItemCode = cekItem.ItemCode.ToUpper(),
                                        NamaItem = cekItem.NamaItem,
                                        Satuan = cekItem.Satuan,
                                        Lokasi = ExistingTrans.Lokasi,
                                        Qty = item.Qty
                                    };
                                    _context.IcAltItems.Add(Produk);

                                }
                                else
                                {
                                    cekLokasi1.Qty += item.Qty;
                                    _context.IcAltItems.Update(cekLokasi1);
                                }
                             

                                if (cekItem.JnsBrng.Equals("Stock"))   // jika stock
                                {
                                    cekItem.Qty += item.Qty;
                                }

                                if (cekItem.CostMethod.Equals("Moving Avarage"))  // jika moving avarage
                                {

                                    cekItem.Cost += item.Cost;
                                }
                                _context.IcItems.Update(cekItem);

                            }
                        }

                    }
                    var customer = GetCustomerId(ExistingTrans.Customer);
                    var piutang = GetPiutang(ExistingTrans.NoLpb);

                    customer.Piutang -= ExistingTrans.Jumlah;

                    _context.ArCusts.Update(customer);
                    _context.ArPiutngs.Remove(piutang);
                    _context.OeTransHs.Remove(ExistingTrans);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        public async Task<bool> EditTransH(OeTransHView trans)
        {
            decimal mQty5 = 0;

            var cekFirst = _context.ArPiutngs.Where(x => x.Dokumen.Equals(trans.NoLpb)).FirstOrDefault();

            if (cekFirst != null)
            {
                try
                {
                    var ExistingTrans = _context.OeTransHs.Where(x => x.OeTransHId == trans.OeTransHId).FirstOrDefault();

                    if (ExistingTrans != null)
                    {
                        foreach (var item in ExistingTrans.OeTransDs)
                        {
                            if (item.Qty != 0)
                            {

                                IcItem cekItem = _context.IcItems.Where(x => x.ItemCode == item.ItemCode).FirstOrDefault();
                                if (cekItem != null)
                                {
                                    IcAltItem cekLokasi1 = _context.IcAltItems.Where(x => x.ItemCode == item.ItemCode && x.Lokasi == ExistingTrans.Lokasi).FirstOrDefault();
                                    if (cekLokasi1 == null)
                                    {
                                        IcAltItem Produk = new IcAltItem()
                                        {
                                            ItemCode = cekItem.ItemCode.ToUpper(),
                                            NamaItem = cekItem.NamaItem,
                                            Satuan = cekItem.Satuan,
                                            Lokasi = ExistingTrans.Lokasi,
                                            Qty =  item.Qty
                                        };
                                        _context.IcAltItems.Add(Produk);

                                    }
                                    else
                                    {
                                        cekLokasi1.Qty += item.Qty;
                                        _context.IcAltItems.Update(cekLokasi1);
                                    }
                                   


                                    if (cekItem.JnsBrng.Equals("Stock"))   // jika stock
                                    {
                                        cekItem.Qty += item.Qty;
                                    }

                                    if (cekItem.CostMethod.Equals("Moving Avarage"))  // jika moving avarage
                                    {

                                        cekItem.Cost += item.Cost;
                                    }

                                    _context.IcItems.Update(cekItem);

                                }
                            }

                        }

                        var existingsupplier = GetCustomerId(ExistingTrans.Customer);
                        existingsupplier.Piutang -= ExistingTrans.Jumlah;

                        _context.ArCusts.Update(existingsupplier);
                        _context.ArPiutngs.Remove(cekFirst);
                        _context.OeTransHs.Remove(ExistingTrans);

                        await _context.SaveChangesAsync();

                        /* update nya */
                        OeTransH transH = new OeTransH
                        {
                            NoLpb = trans.NoLpb,
                            Customer = trans.Customer.ToUpper(),
                            NamaCust = trans.NamaCust,
                            Lokasi = trans.Lokasi.ToUpper(),
                            Tanggal = trans.Tanggal,
                            Keterangan = trans.Keterangan,
                            Jumlah = trans.Jumlah,
                            Ongkos = trans.Ongkos,
                            Ppn = trans.Ppn,
                            PpnPersen = trans.PpnPersen,
                            TtlJumlah = trans.TtlJumlah,
                            DPayment = trans.DPayment,
                            Tagihan = trans.Tagihan,
                            TotalQty = trans.TotalQty,
                            Kode = "94",
                            Cek = "1",

                           

                            OeTransDs = new List<OeTransD>()
                        };

                        foreach (var item in trans.OeTransDs)
                        {
                            if (item.Qty != 0)
                            {
                                if (transH.TotalQty != 0)
                                {
                                    mQty5 = (item.Jumlah - item.Discount) - (item.Qty / transH.TotalQty * transH.Ppn) + (item.Qty / transH.TotalQty * transH.Ongkos);
                                }

                                


                                IcItem cekItem = _context.IcItems.Where(x => x.ItemCode == item.ItemCode).FirstOrDefault();
                                if (cekItem != null)
                                {
                                    IcAltItem cekLokasi1 = _context.IcAltItems.Where(x => x.ItemCode == item.ItemCode && x.Lokasi == trans.Lokasi).FirstOrDefault();
                                    if (cekLokasi1 == null)
                                    {
                                        IcAltItem Produk = new IcAltItem()
                                        {
                                            ItemCode = cekItem.ItemCode.ToUpper(),
                                            NamaItem = cekItem.NamaItem,
                                            Satuan = cekItem.Satuan,
                                            Lokasi = trans.Lokasi,
                                            Qty = -1*item.Qty
                                        };
                                        _context.IcAltItems.Add(Produk);

                                    }
                                    else
                                    {
                                        cekLokasi1.Qty -= item.Qty;
                                        _context.IcAltItems.Update(cekLokasi1);
                                    }

                                    transH.OeTransDs.Add(new OeTransD()
                                    {
                                        ItemCode = item.ItemCode.ToUpper(),
                                        NamaItem = item.NamaItem,
                                        Satuan = item.Satuan,
                                        Lokasi = transH.Lokasi,
                                        Harga = item.Harga,
                                        Qty = item.Qty,
                                        Persen = item.Persen,
                                        Discount = item.Discount,
                                        Jumlah = item.Jumlah,
                                        Kode = "94",
                                        NoLpb = transH.NoLpb,
                                        Tanggal = trans.Tanggal,
                                        HrgCost = item.HrgCost,
                                        Cost = item.Cost,
                                        JumDpp = mQty5
                                    });

                                    if (cekItem.JnsBrng.Equals("Stock"))   // jika stock
                                    {
                                        cekItem.Qty -= item.Qty;
                                    }

                                    if (cekItem.CostMethod.Equals("Moving Avarage"))  // jika moving avarage
                                    {

                                        cekItem.Cost -= item.Cost;
                                    }
                                    _context.IcItems.Update(cekItem);

                                }
                            }

                        }

                       


                        var customer = GetCustomerId(transH.Customer);
                        customer.Piutang += transH.Jumlah;
                        
                        ArPiutng piutang = new ArPiutng
                        {
                            Kode = "OE",
                            Dokumen = transH.NoLpb,
                            Tanggal = transH.Tanggal,
                            DueDate = transH.Tanggal.AddDays(customer.Termin),
                            Customer = transH.Customer,
                            Keterangan = transH.Keterangan,
                            Jumlah = transH.Jumlah,
                            Sisa = transH.Jumlah,
                            SldSisa = transH.Jumlah,
                            KodeTran = transH.Kode
                        };
                        _context.OeTransHs.Add(transH);
                        _context.ArCusts.Update(customer);
                        _context.ArPiutngs.Add(piutang);

                        await _context.SaveChangesAsync();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }






            return false;
        }

        #endregion IrTransH Class

        public string GetNumber()
        {
            string kodeno = "PJL";
            string kodeurut = kodeno + '-';
            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeurut + thnbln.Substring(0, 2) + '2' + thnbln.Substring(2, 2) + '-';
            var maxvalue = "";
            var maxlist = _context.OeTransHs.Where(x => x.NoLpb.Substring(0, 10).Equals(xbukti)).ToList();
            if (maxlist != null)
            {
                maxvalue = maxlist.Max(x => x.NoLpb);

            }

            //            var maxvalue = (from e in db.CbTransHs where  e.Docno.Substring(0, 7) == kodeno + thnbln select e).Max();
            string nourut = "00000";
            if (maxvalue == null)
            {
                nourut = "00000";
            }
            else
            {
                nourut = maxvalue.Substring(10, 5);
            }

            //  nourut =Convert.ToString(Int32.Parse(nourut) + 1);


            string cAngNo = xbukti + (Int32.Parse(nourut) + 1).ToString("00000");
            // var maxvalue = (from e in db.AptTranss where e.NoRef.Substring(0, 7) == "ANG" + cAngNo select e.NoRef.Max()).FirstOrDefault();
            return cAngNo;

        }
    }
}
