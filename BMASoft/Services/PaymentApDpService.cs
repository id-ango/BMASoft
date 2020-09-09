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
using BMASoft.Pages.Hutang;


namespace BMASoft.Services
{

    public interface IPaymentApDpService
    {

        Task<ApTransH> GetTrans(int id);
        Task<List<ApTransH>> GetTransH();
        Task<List<ApTransH>> Get3TransH();
        Task<List<ApTransD>> GetTransD();
        Task<bool> AddTransH(ApTransHView transH);
        Task<bool> DelTransH(int id);
        List<ApHutang> GetHutangSisa(string supplier);
    }

    public class PaymentApDpService : IPaymentApDpService
    {
        private readonly BmaDbContext _context;

        public PaymentApDpService(BmaDbContext context)
        {
            _context = context;
        }

        #region Transaksi Hutang Pembayaran Class

        public async Task<ApTransH> GetTrans(int id)
        {
            return await _context.ApTransHs.Include(p => p.ApTransDs).Where(x => x.ApTransHId == id).FirstOrDefaultAsync();
        }

        public List<ApHutang> GetHutangSisa(string supplier)
        {
            return _context.ApHutangs.Where(x => x.Supplier == supplier && x.Sisa != 0).ToList();

        }
        public async Task<List<ApTransH>> GetTransH()
        {
            List<ApTransH> ApTrans = new List<ApTransH>();
            try
            {
                ApTrans = await _context.ApTransHs.OrderByDescending(x => x.Tanggal).Where(x => x.Kode == "23").ToListAsync();
                foreach (var item in ApTrans)
                {
                    item.NamaSup = (from e in _context.ApSuppls where e.ApSupplId == item.ApSupplId select e.NamaSup).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return ApTrans;
            // return  _context.CbTransHs.Include(p =>p.CbTransDs).OrderByDescending(x =>x.Tanggal).ToListAsync();
            //  return await _context.ApTransHs.OrderByDescending(x => x.Tanggal).ToListAsync();
            //  return await _context.ApTransHs.ToListAsync();

        }

        public async Task<List<ApTransH>> Get3TransH()
        {
            List<ApTransH> ApTrans = new List<ApTransH>();

            ApTrans = await _context.ApTransHs.OrderByDescending(x => x.Tanggal).Where(x => x.Tanggal > DateTime.Today.AddMonths(-3) && x.Kode == "23").ToListAsync();
            foreach (var item in ApTrans)
            {
                item.NamaSup = (from e in _context.ApSuppls where e.ApSupplId == item.ApSupplId select e.NamaSup).FirstOrDefault();
            }

            return ApTrans;

            // return  _context.CbTransHs.Include(p =>p.CbTransDs).OrderByDescending(x =>x.Tanggal).ToListAsync();
            //   return _context.ApTransHs.OrderByDescending(x => x.Tanggal).Where(x => x.Tanggal > DateTime.Today.AddMonths(-3)).ToListAsync();

        }

        public async Task<List<ApTransD>> GetTransD()
        {
            return await _context.ApTransDs.Where(x => x.Kode == "23").ToListAsync();
        }

        public async Task<bool> AddTransH(ApTransHView trans)
        {
            //string test = codeview.SrcCode.ToUpper();
            //var cekFirst = _context.CbSrcCodes.Where(x => x.SrcCode == test).ToList();
            string KdSrc = "AP";

            ApTransH transH = new ApTransH
            {
                Bukti = GetNumber(),
                Supplier = trans.Supplier.ToUpper(),
                Tanggal = trans.Tanggal,
                Keterangan = trans.Keterangan,
                Jumlah = trans.JumBayar,
                Discount = 0,
                Unapplied = trans.UpdateUnapplied,
                Hutang = 0,
                KdBank = trans.KdBank,
                PPn = 0,
                PPh = 0,
                JumPPh = 0,
                JumPPn = 0,
                Bruto = 0,
                Netto = 0,
                Pajak = false,
                Kode = "23",
                ApSupplId = trans.ApSupplId

                //  ApTransDs = new List<ApTransD>()
            };

            #region detailTrans

            //List<ApHutang> transaksi = new List<ApHutang>();
            //transaksi = _context.ApHutangs.Where(x => x.supplier == trans.supplier && x.Sisa != 0).ToList();

            //foreach (var item in trans.ApTransDs)
            //{
            //    transH.ApTransDs.Add(new ApTransD()
            //    {
            //        Jumlah = item.Jumlah,
            //        Kode = "14",
            //        KodeTran = item.KodeTran,
            //        Lpb = transH.Bukti,
            //        Tanggal = trans.Tanggal,
            //        Discount = item.Discount,
            //        Bayar = item.Bayar,
            //        Sisa = item.UpdateSisa

            //    });

            //    transaksi.Where(x => x.Dokumen == item.Lpb).ToList()
            //        .ForEach(s =>
            //        {
            //            s.Bayar = item.Bayar + item.Discount;
            //            s.Discount = item.Discount;
            //            s.Sisa = item.UpdateSisa;
            //        });

            //}
            //transH.ApTransDs.RemoveAll(x => x.Bayar == 0 && x.Discount == 0);
            //transaksi.RemoveAll(x => x.Bayar == 0 && x.Discount == 0);

            #endregion

            ApHutang transaksi = new ApHutang
            {
                Kode = "CA",
                Dokumen = transH.Bukti,
                Tanggal = transH.Tanggal,
                Supplier = transH.Supplier,
                Keterangan = transH.Keterangan,
                KodeTran = "23",
                Jumlah = -1 * transH.Jumlah,
                SldSisa = -1 * transH.Jumlah,
                Bayar = -1 * transH.Jumlah,
                Discount = 0,
                UnApplied = -1 * transH.Unapplied,
                Sisa = -1 * transH.Unapplied,

                Dpp = 0,
                PPn = 0,
                PPh = 0,
                SldBayar = 0,
                SldDisc = 0,
                SldUnpl = 0
            };

            var supplier = (from e in _context.ApSuppls where e.Supplier == trans.Supplier select e).FirstOrDefault();
            supplier.Hutang -= transH.Jumlah;

            _context.ApSuppls.Update(supplier);
            _context.ApTransHs.Add(transH);
            _context.ApHutangs.Add(transaksi);
            await _context.SaveChangesAsync();

            var cekBukti = (from e in _context.CbTransHs where e.DocNo == transH.Bukti select e).FirstOrDefault();

            if (cekBukti == null)
            {
                if (transH.KdBank != null && transH.KdBank.Length != 0)
                {
                    CbTransH transBank = new CbTransH
                    {
                        DocNo = transH.Bukti,
                        KodeBank = trans.KdBank,
                        Tanggal = trans.Tanggal,
                        Keterangan = trans.Keterangan,
                        Saldo = -1*trans.JumBayar,

                        CbTransDs = new List<CbTransD>()
                    };
                   
                        transBank.CbTransDs.Add(new CbTransD()
                        {
                            SrcCode = KdSrc,
                            Keterangan = "Pembayaran Uang Muka " + trans.Supplier.ToUpper(),
                            Bayar = trans.JumBayar,
                            Jumlah = -1*trans.JumBayar

                        });
                   
                    var bank = (from e in _context.Banks where e.KodeBank == trans.KdBank select e).FirstOrDefault();
                    bank.Saldo -= trans.JumBayar;

                    _context.Banks.Update(bank);
                    _context.CbTransHs.Add(transBank);
                    await _context.SaveChangesAsync();

                }
            }

            return true;


        }



        public async Task<bool> DelTransH(int id)
        {
            try
            {
                var ExistingTrans = _context.ApTransHs.Where(x => x.ApTransHId == id).FirstOrDefault();
                if (ExistingTrans != null)
                {
                    var cekFirst = _context.ApHutangs.Where(x => x.Dokumen == ExistingTrans.Bukti).FirstOrDefault();
                    var supplier = (from e in _context.ApSuppls where e.Supplier == ExistingTrans.Supplier select e).FirstOrDefault();

                    supplier.Hutang += ExistingTrans.Jumlah;


                    _context.ApSuppls.Update(supplier);
                    _context.ApTransHs.Remove(ExistingTrans);
                    _context.ApHutangs.Remove(cekFirst);
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

        #endregion Transaksi Hutang Class

        public string GetNumber()
        {
            string kodeno = "DPY";
            string kodeurut = kodeno + '-';
            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeurut + thnbln.Substring(0, 2) + '5' + thnbln.Substring(2, 2) + '-';
            var maxvalue = "";
            var maxlist = _context.ApTransHs.Where(x => x.Bukti.Substring(0, 10).Equals(xbukti)).ToList();
            if (maxlist != null)
            {
                maxvalue = maxlist.Max(x => x.Bukti);

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
