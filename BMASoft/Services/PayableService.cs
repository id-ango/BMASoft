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
    public interface IPayableService
    {
        List<ApSuppl> GetSupplier();
        ApSuppl GetSupplierId(int id);
        Task<bool> AddSupplier(SupplierView suppliers);
        Task<bool> EditSupplier(SupplierView suppliers);
        Task<bool> DelSupplier(int suppliers);
        Task<List<ApAcct>> GetApAkunSet();
        ApAcct GetApAkunSetId(int id);
        Task<bool> AddAkunSet(ApAcctView codeview);
        Task<bool> EditAkunSet(ApAcctView codeview);
        Task<bool> DelAkunSet(int codeview);
        Task<List<ApDist>> GetDist();
        ApDist GetDistId(int id);
        Task<bool> AddDist(ApDistView codeview);
        Task<bool> EditDist(ApDistView codeview);
        Task<bool> DelDist(ApDistView codeview);
        Task<ApTransH> GetTrans(int id);
        Task<List<ApTransH>> GetTransH();
        Task<List<ApTransH>> Get3TransH();
        Task<List<ApTransD>> GetTransD();
        Task<bool> AddTransH(ApTransHView transH);
        Task<bool> EditTransH(ApTransHView transH);
        Task<bool> DelTransH(int id);
        ApHutang GetHutang(string bukti);
    }

    public class PayableService : IPayableService
    {
        private readonly BmaDbContext _context;

        public PayableService(BmaDbContext context)
        {
            _context = context;
        }

        public List<ApSuppl> GetSupplier()
        {
            return _context.ApSuppls.OrderBy(x => x.NamaSup).ToList();
        }

        public ApSuppl GetSupplierId(int id)
        {
            return _context.ApSuppls.Where(x =>x.ApSupplId == id).FirstOrDefault();
        }

        public async Task<bool> AddSupplier(SupplierView suppliers)
        {
            string test = suppliers.Supplier.ToUpper();
            var cekFirst = _context.ApSuppls.Where(x => x.Supplier == test).ToList();
            if (cekFirst.Count == 0)
            {
                ApSuppl Supplier = new ApSuppl()
                {
                    Supplier = suppliers.Supplier.ToUpper(),
                    NamaSup = suppliers.NamaSup,
                    Alamat = suppliers.Alamat,
                    Kota = suppliers.Kota,
                    Telpon = suppliers.Telpon,
                    NamaLengkap = suppliers.NamaLengkap

                };
                _context.ApSuppls.Add(Supplier);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }

        }

        public async Task<bool> EditSupplier(SupplierView suppliers)
        {
            try
            {
                var ExistingSupplier = _context.ApSuppls.Where(x => x.ApSupplId == suppliers.ApSupplId).FirstOrDefault();
                if (ExistingSupplier != null)
                {
                    ExistingSupplier.NamaSup = suppliers.NamaSup;
                    ExistingSupplier.Alamat = suppliers.Alamat;
                    ExistingSupplier.Kota = suppliers.Kota;
                    ExistingSupplier.Telpon = suppliers.Telpon;
                    ExistingSupplier.NamaLengkap = suppliers.NamaLengkap;
                    _context.ApSuppls.Update(ExistingSupplier);
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

        public async Task<bool> DelSupplier(int suppliers)
        {
            try
            {
                var ExistingSupplier = _context.ApSuppls.Where(x => x.ApSupplId == suppliers).FirstOrDefault();
                if (ExistingSupplier != null)
                {
                    _context.ApSuppls.Remove(ExistingSupplier);
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

        #region ApAcct Class

        public async Task<List<ApAcct>> GetApAkunSet()
        {
            return await _context.ApAccts.ToListAsync();
        }

        public ApAcct GetApAkunSetId(int id)
        {
            return _context.ApAccts.Where(x => x.ApAcctId == id).FirstOrDefault();
        }

        public async Task<bool> AddAkunSet(ApAcctView codeview)
        {
            string test = codeview.AcctSet.ToUpper();
            var cekFirst = _context.ApAccts.Where(x => x.AcctSet == test).ToList();
            if (cekFirst.Count == 0)
            {
                ApAcct AcctCode = new ApAcct()
                {
                    AcctSet = codeview.AcctSet.ToUpper(),
                    Description = codeview.Description,
                    Acct1 = codeview.Acct1

                };
                _context.ApAccts.Add(AcctCode);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }


        }

        public async Task<bool> EditAkunSet(ApAcctView codeview)
        {
            try
            {
                var ExistingAkunSet = _context.ApAccts.Where(x => x.ApAcctId == codeview.ApAcctId).FirstOrDefault();
                if (ExistingAkunSet != null)
                {
                    ExistingAkunSet.Description = codeview.Description;
                    ExistingAkunSet.Acct1 = codeview.Acct1;

                    _context.ApAccts.Update(ExistingAkunSet);
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

        public async Task<bool> DelAkunSet(int codeview)
        {
            try
            {
                var ExistingAkunSet = _context.ApAccts.Where(x => x.ApAcctId == codeview).FirstOrDefault();
                if (ExistingAkunSet != null)
                {
                    _context.ApAccts.Remove(ExistingAkunSet);
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
        #endregion ApAcct Class

        #region ApDist Class

        public async Task<List<ApDist>> GetDist()
        {
            return await _context.ApDists.ToListAsync();
        }

        public ApDist GetDistId(int id)
        {
            return _context.ApDists.Where(x => x.ApDistId == id).FirstOrDefault();
        }

        public async Task<bool> AddDist(ApDistView codeview)
        {
            string test = codeview.DistCode.ToUpper();
            var cekFirst = _context.ApDists.Where(x => x.DistCode == test).ToList();
            if (cekFirst.Count == 0)
            {
                ApDist AcctCode = new ApDist()
                {
                    DistCode = codeview.DistCode.ToUpper(),
                    Description = codeview.Description,
                    Dist1 = codeview.Dist1

                };
                _context.ApDists.Add(AcctCode);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }


        }

        public async Task<bool> EditDist(ApDistView codeview)
        {
            try
            {
                var ExistingDist = _context.ApDists.Where(x => x.ApDistId == codeview.ApDistId).FirstOrDefault();
                if (ExistingDist != null)
                {
                    ExistingDist.Description = codeview.Description;
                    ExistingDist.Dist1 = codeview.Dist1;

                    _context.ApDists.Update(ExistingDist);
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

        public async Task<bool> DelDist(ApDistView codeview)
        {
            try
            {
                var ExistingDist = _context.ApDists.Where(x => x.ApDistId == codeview.ApDistId).FirstOrDefault();
                if (ExistingDist != null)
                {
                    _context.ApDists.Remove(ExistingDist);
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
        #endregion ApDist Class

        #region Transaksi Hutang Class

        public async Task<ApTransH> GetTrans(int id)
        {
            return await _context.ApTransHs.Include(p => p.ApTransDs).Where(x => x.ApTransHId == id).FirstOrDefaultAsync();
        }

        public ApHutang GetHutang(string bukti)
        {
            return _context.ApHutangs.Where(x => x.Dokumen == bukti).FirstOrDefault();

        }
        public async Task<List<ApTransH>> GetTransH()
        {
            List<ApTransH> ApTrans = new List<ApTransH>();
            try
            {
                ApTrans = await _context.ApTransHs.OrderByDescending(x => x.Tanggal).Where(x => x.Kode == "21").ToListAsync();
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

            ApTrans = await _context.ApTransHs.OrderByDescending(x => x.Tanggal).Where(x => x.Tanggal > DateTime.Today.AddMonths(-3) && x.Kode == "21").ToListAsync();
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
            return await _context.ApTransDs.ToListAsync();
        }

        public async Task<bool> AddTransH(ApTransHView trans)
        {
            //string test = codeview.SrcCode.ToUpper();
            //var cekFirst = _context.CbSrcCodes.Where(x => x.SrcCode == test).ToList();

            ApTransH transH = new ApTransH
            {
                Bukti = GetNumber(),
                Supplier = trans.Supplier.ToUpper(),
                Tanggal = trans.Tanggal,
                Keterangan = trans.Keterangan,
                Jumlah = trans.Jumlah,
                PPn = 0,
                PPh = 0,
                JumPPh = 0,
                JumPPn = 0,
                Bruto = trans.Jumlah,
                Netto = 0,
                Discount = 0,
                Hutang = 0,
                Pajak = false,
                Unapplied = 0,
                Kode = "21",
                ApSupplId = trans.ApSupplId,

                ApTransDs = new List<ApTransD>()
            };
            foreach (var item in trans.ApTransDs)
            {
                transH.ApTransDs.Add(new ApTransD()
                {
                    DistCode = item.DistCode,
                    Keterangan = item.Keterangan,
                    Jumlah = item.Jumlah,
                    Kode = "21",
                    KodeTran = "21",
                    Lpb = transH.Bukti,
                    Sisa = item.Jumlah,
                    Discount = 0,
                    Bayar = 0,
                    Tanggal = trans.Tanggal
                });
            }
            ApHutang transaksi = new ApHutang
            {
                Kode = "IN",
                Dokumen = transH.Bukti,
                Tanggal = transH.Tanggal,
                Supplier = transH.Supplier,
                Keterangan = transH.Keterangan,
                KodeTran = "21",
                Jumlah = transH.Jumlah,
                Bayar = 0,
                Discount = 0,
                UnApplied = 0,
                Sisa = transH.Jumlah,
                SldSisa = transH.Jumlah,
                Dpp = transH.Jumlah,
                PPn = 0,
                PPh = 0,
                SldBayar = 0,
                SldDisc = 0,
                SldUnpl = 0
            };

            var Supplier = (from e in _context.ApSuppls where e.Supplier == trans.Supplier select e).FirstOrDefault();
            Supplier.Hutang += trans.Jumlah;

            _context.ApSuppls.Update(Supplier);
            _context.ApTransHs.Add(transH);
            _context.ApHutangs.Add(transaksi);
            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<bool> EditTransH(ApTransHView trans)
        {
            //string test = codeview.SrcCode.ToUpper();
            //var cekFirst = _context.CbSrcCodes.Where(x => x.SrcCode == test).ToList();
            var cekFirst = _context.ApHutangs.Where(x => x.Dokumen == trans.Bukti).FirstOrDefault();


            ApTransH transH = new ApTransH
            {

                Supplier = trans.Supplier.ToUpper(),
                Tanggal = trans.Tanggal,
                Keterangan = trans.Keterangan,
                Jumlah = trans.Jumlah,
                PPn = 0,
                PPh = 0,
                JumPPh = 0,
                JumPPn = 0,
                Bruto = trans.Jumlah,
                Netto = 0,
                Discount = 0,
                Hutang = 0,
                Pajak = false,
                Unapplied = 0,
                Kode = "21",
                ApSupplId = trans.ApSupplId,

                ApTransDs = new List<ApTransD>()
            };
            foreach (var item in trans.ApTransDs)
            {
                transH.ApTransDs.Add(new ApTransD()
                {
                    DistCode = item.DistCode,
                    Keterangan = item.Keterangan,
                    Jumlah = item.Jumlah,
                    Kode = "21",
                    KodeTran = "21",
                    Lpb = transH.Bukti,
                    Sisa = item.Jumlah,
                    Discount = 0,
                    Bayar = 0,
                    Tanggal = trans.Tanggal
                });
            }

            ApHutang transaksi = new ApHutang
            {
                Kode = "IN",
                Tanggal = transH.Tanggal,
                Supplier = transH.Supplier,
                Keterangan = transH.Keterangan,
                KodeTran = "21",
                Jumlah = transH.Jumlah,
                Bayar = 0,
                Discount = 0,
                UnApplied = 0,
                Sisa = transH.Jumlah,
                SldSisa = transH.Jumlah,
                Dpp = transH.Jumlah,
                PPn = 0,
                PPh = 0,
                SldBayar = 0,
                SldDisc = 0,
                SldUnpl = 0
            };

            try
            {
                var ExistingTrans = _context.ApTransHs.Where(x => x.ApTransHId == trans.ApTransHId).FirstOrDefault();
                if (ExistingTrans != null)
                {
                    transH.Bukti = ExistingTrans.Bukti;
                    transaksi.Dokumen = ExistingTrans.Bukti;

                    _context.ApTransHs.Remove(ExistingTrans);

                    var Supplier = (from e in _context.ApSuppls where e.Supplier == trans.Supplier select e).FirstOrDefault();

                    Supplier.Hutang -= ExistingTrans.Jumlah;
                    Supplier.Hutang += trans.Jumlah;

                    _context.ApSuppls.Update(Supplier);
                    _context.ApHutangs.Remove(cekFirst);

                    _context.ApTransHs.Add(transH);
                    _context.ApHutangs.Add(transaksi);
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

        public async Task<bool> DelTransH(int id)
        {
            try
            {
                var ExistingTrans = _context.ApTransHs.Where(x => x.ApTransHId == id).FirstOrDefault();
                if (ExistingTrans != null)
                {
                    var cekFirst = _context.ApHutangs.Where(x => x.Dokumen == ExistingTrans.Bukti).FirstOrDefault();
                    var Supplier = (from e in _context.ApSuppls where e.Supplier == ExistingTrans.Supplier select e).FirstOrDefault();

                    Supplier.Hutang -= ExistingTrans.Jumlah;


                    _context.ApSuppls.Update(Supplier);
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
            string kodeno = "API";
            string kodeurut = kodeno + '-';
            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeurut + thnbln.Substring(0, 2) + '2' + thnbln.Substring(2, 2) + '-';
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
