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
using BMASoft.Pages.Piutang;


namespace BMASoft.Services
{

    public interface IPaymentArDpService
    {

        Task<ArTransH> GetTrans(int id);
        Task<List<ArTransH>> GetTransH();
        Task<List<ArTransH>> Get3TransH();
        Task<List<ArTransD>> GetTransD();
        Task<bool> AddTransH(ArTransHView transH);
        Task<bool> DelTransH(int id);
        List<ArPiutng> GetPiutangSisa(string customer);
    }

    public class PaymentArDpService : IPaymentArDpService
    {
        private readonly BmaDbContext _context;

        public PaymentArDpService(BmaDbContext context)
        {
            _context = context;
        }

        #region Transaksi Piutang Pembayaran Class

        public async Task<ArTransH> GetTrans(int id)
        {
            return await _context.ArTransHs.Include(p => p.ArTransDs).Where(x => x.ArTransHId == id).FirstOrDefaultAsync();
        }

        public List<ArPiutng> GetPiutangSisa(string customer)
        {
            return _context.ArPiutngs.Where(x => x.Customer == customer && x.Sisa != 0).ToList();

        }
        public async Task<List<ArTransH>> GetTransH()
        {
            List<ArTransH> arTrans = new List<ArTransH>();
            try
            {
                arTrans = await _context.ArTransHs.OrderByDescending(x => x.Tanggal).Where(x => x.Kode == "13").ToListAsync();
                foreach (var item in arTrans)
                {
                    item.NamaCust = (from e in _context.ArCusts where e.ArCustId == item.ArCustId select e.NamaCust).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return arTrans;
            // return  _context.CbTransHs.Include(p =>p.CbTransDs).OrderByDescending(x =>x.Tanggal).ToListAsync();
            //  return await _context.ArTransHs.OrderByDescending(x => x.Tanggal).ToListAsync();
            //  return await _context.ArTransHs.ToListAsync();

        }

        public async Task<List<ArTransH>> Get3TransH()
        {
            List<ArTransH> arTrans = new List<ArTransH>();

            arTrans = await _context.ArTransHs.OrderByDescending(x => x.Tanggal).Where(x => x.Tanggal > DateTime.Today.AddMonths(-3) && x.Kode == "13").ToListAsync();
            foreach (var item in arTrans)
            {
                item.NamaCust = (from e in _context.ArCusts where e.ArCustId == item.ArCustId select e.NamaCust).FirstOrDefault();
            }

            return arTrans;

            // return  _context.CbTransHs.Include(p =>p.CbTransDs).OrderByDescending(x =>x.Tanggal).ToListAsync();
            //   return _context.ArTransHs.OrderByDescending(x => x.Tanggal).Where(x => x.Tanggal > DateTime.Today.AddMonths(-3)).ToListAsync();

        }

        public async Task<List<ArTransD>> GetTransD()
        {
            return await _context.ArTransDs.Where(x => x.Kode == "13").ToListAsync();
        }

        public async Task<bool> AddTransH(ArTransHView trans)
        {
            //string test = codeview.SrcCode.ToUpper();
            //var cekFirst = _context.CbSrcCodes.Where(x => x.SrcCode == test).ToList();
            string KdSrc = "AR";

            ArTransH transH = new ArTransH
            {
                Bukti = GetNumber(),
                Customer = trans.Customer.ToUpper(),
                Tanggal = trans.Tanggal,
                Keterangan = trans.Keterangan,
                Jumlah = trans.JumBayar,
                Discount = 0,
                Unapplied = trans.UpdateUnapplied,
                Piutang = 0,
                KdBank = trans.KdBank,
                PPn = 0,
                PPh = 0,
                JumPPh = 0,
                JumPPn = 0,
                Bruto = 0,
                Netto = 0,
                Pajak = false,
                Kode = "13",
                ArCustId = trans.ArCustId

              //  ArTransDs = new List<ArTransD>()
            };

            #region detailTrans

            //List<ArPiutng> transaksi = new List<ArPiutng>();
            //transaksi = _context.ArPiutngs.Where(x => x.Customer == trans.Customer && x.Sisa != 0).ToList();

            //foreach (var item in trans.ArTransDs)
            //{
            //    transH.ArTransDs.Add(new ArTransD()
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
            //transH.ArTransDs.RemoveAll(x => x.Bayar == 0 && x.Discount == 0);
            //transaksi.RemoveAll(x => x.Bayar == 0 && x.Discount == 0);

            #endregion

            ArPiutng transaksi = new ArPiutng
            {
                Kode = "CA",
                Dokumen = transH.Bukti,
                Tanggal = transH.Tanggal,
                Customer = transH.Customer,
                Keterangan = transH.Keterangan,
                KodeTran = "13",
                Jumlah = -1*transH.Jumlah,
                SldSisa = -1 * transH.Jumlah,
                Bayar = -1*transH.Jumlah,
                Discount = 0,
                UnApplied = -1 * transH.Unapplied,
                Sisa = -1* transH.Unapplied,
               
                Dpp = 0,
                PPn = 0,
                PPh = 0,
                SldBayar = 0,
                SldDisc = 0,
                SldUnpl = 0
            };

            var customer = (from e in _context.ArCusts where e.Customer == trans.Customer select e).FirstOrDefault();
            customer.Piutang += transH.Jumlah;

            _context.ArCusts.Update(customer);
            _context.ArTransHs.Add(transH);
            _context.ArPiutngs.Add(transaksi);
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
                        Saldo = trans.JumBayar,

                        CbTransDs = new List<CbTransD>()
                    };
                    foreach (var item in trans.ArTransDs)
                    {
                        transBank.CbTransDs.Add(new CbTransD()
                        {
                            SrcCode = KdSrc,
                            Keterangan = "Pembayaran Uang Muka " + trans.Customer.ToUpper(),
                            Terima = item.Bayar,
                            Jumlah = item.Bayar,

                        });
                    }
                    var bank = (from e in _context.Banks where e.KodeBank == trans.KdBank select e).FirstOrDefault();
                    bank.Saldo += trans.JumBayar;

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
                var ExistingTrans = _context.ArTransHs.Where(x => x.ArTransHId == id).FirstOrDefault();
                if (ExistingTrans != null)
                {
                    var cekFirst = _context.ArPiutngs.Where(x => x.Dokumen == ExistingTrans.Bukti).FirstOrDefault();
                    var customer = (from e in _context.ArCusts where e.Customer == ExistingTrans.Customer select e).FirstOrDefault();

                    customer.Piutang -= ExistingTrans.Jumlah;


                    _context.ArCusts.Update(customer);
                    _context.ArTransHs.Remove(ExistingTrans);
                    _context.ArPiutngs.Remove(cekFirst);
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

        #endregion Transaksi Piutang Class

        public string GetNumber()
        {
            string kodeno = "UMY";
            string kodeurut = kodeno + '-';
            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeurut + thnbln.Substring(0, 2) + '2' + thnbln.Substring(2, 2) + '-';
            var maxvalue = "";
            var maxlist = _context.ArTransHs.Where(x => x.Bukti.Substring(0, 10).Equals(xbukti)).ToList();
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
