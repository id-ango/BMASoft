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
    public interface IReceivableService
    {
        Task<List<ArCust>> GetCustomer();
        Task<bool> AddCustomer(CustomerView customers);
        Task<bool> EditCustomer(CustomerView customers);
        Task<bool> DelCustomer(CustomerView customers);
        Task<List<ArAcct>> GetArAkunSet();
        Task<bool> AddAkunSet(ArAcctView codeview);
        Task<bool> EditAkunSet(ArAcctView codeview);
        Task<bool> DelAkunSet(ArAcctView codeview);
        Task<List<ArDist>> GetDist();
        Task<bool> AddDist(ArDistView codeview);
        Task<bool> EditDist(ArDistView codeview);
        Task<bool> DelDist(ArDistView codeview);
        Task<ArTransH> GetTrans(int id);
        Task<List<ArTransH>> GetTransH();
        Task<List<ArTransH>> Get3TransH();
        Task<List<ArTransD>> GetTransD();
        Task<bool> AddTransH(ArTransHView transH);
        Task<bool> EditTransH(ArTransHView transH);
        Task<bool> DelTransH(int id);
    }

    public class ReceivableService:IReceivableService
    {
        private readonly BmaDbContext _context;

        public ReceivableService(BmaDbContext context)
        {
            _context = context;
        }

        public async Task<List<ArCust>> GetCustomer()
        {
            return await _context.ArCusts.ToListAsync();
        }

        public async Task<bool> AddCustomer(CustomerView customers)
        {
            string test = customers.Customer.ToUpper();
            var cekFirst = _context.ArCusts.Where(x => x.Customer == test).ToList();
            if (cekFirst.Count == 0)
            {
                ArCust Customer = new ArCust()
                {
                    Customer = customers.Customer.ToUpper(),
                    NamaCust = customers.NamaCust,
                    Alamat = customers.Alamat,
                    Kota = customers.Kota,
                    Telpon = customers.Telpon

                };
                _context.ArCusts.Add(Customer);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }

        }

        public async Task<bool> EditCustomer(CustomerView customers)
        {
            try
            {
                var ExistingCustomer = _context.ArCusts.Where(x => x.ArCustId == customers.ArCustId).FirstOrDefault();
                if (ExistingCustomer != null)
                {
                    ExistingCustomer.NamaCust = customers.Customer;
                    ExistingCustomer.Alamat = customers.Alamat;
                    ExistingCustomer.Kota = customers.Kota;
                    ExistingCustomer.Telpon = customers.Telpon;
                    

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

        public async Task<bool> DelCustomer(CustomerView customers)
        {
            try
            {
                var ExistingCustomer = _context.ArCusts.Where(x => x.ArCustId == customers.ArCustId).FirstOrDefault();
                if (ExistingCustomer != null)
                {
                    _context.ArCusts.Remove(ExistingCustomer);
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

        #region ArAcct Class

        public async Task<List<ArAcct>> GetArAkunSet()
        {
            return await _context.ArAccts.ToListAsync();
        }

       

        public async Task<bool> AddAkunSet(ArAcctView codeview)
        {
            string test = codeview.AcctSet.ToUpper();
            var cekFirst = _context.ArAccts.Where(x => x.AcctSet == test).ToList();
            if (cekFirst.Count == 0)
            {
                ArAcct AcctCode = new ArAcct()
                {
                    AcctSet = codeview.AcctSet.ToUpper(),
                    Description = codeview.Description,
                    Acct1 = codeview.Acct1

                };
                _context.ArAccts.Add(AcctCode);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }


        }

        public async Task<bool> EditAkunSet(ArAcctView codeview)
        {
            try
            {
                var ExistingAkunSet = _context.ArAccts.Where(x => x.ArAcctId == codeview.ArAcctId).FirstOrDefault();
                if (ExistingAkunSet != null)
                {
                    ExistingAkunSet.Description = codeview.Description;
                    ExistingAkunSet.Acct1 = codeview.Acct1;
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

        public async Task<bool> DelAkunSet(ArAcctView codeview)
        {
            try
            {
                var ExistingAkunSet = _context.ArAccts.Where(x => x.ArAcctId == codeview.ArAcctId).FirstOrDefault();
                if (ExistingAkunSet != null)
                {
                    _context.ArAccts.Remove(ExistingAkunSet);
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
        #endregion ArAcct Class

        #region ArDist Class

        public async Task<List<ArDist>> GetDist()
        {
            return await _context.ArDists.ToListAsync();
        }



        public async Task<bool> AddDist(ArDistView codeview)
        {
            string test = codeview.DistCode.ToUpper();
            var cekFirst = _context.ArDists.Where(x => x.DistCode == test).ToList();
            if (cekFirst.Count == 0)
            {
                ArDist AcctCode = new ArDist()
                {
                    DistCode = codeview.DistCode.ToUpper(),
                    Description = codeview.Description,
                    Dist1 = codeview.Dist1

                };
                _context.ArDists.Add(AcctCode);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }


        }

        public async Task<bool> EditDist(ArDistView codeview)
        {
            try
            {
                var ExistingDist = _context.ArDists.Where(x => x.ArDistId == codeview.ArDistId).FirstOrDefault();
                if (ExistingDist != null)
                {           
                    ExistingDist.Description = codeview.Description;
                    ExistingDist.Dist1 = codeview.Dist1;
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

        public async Task<bool> DelDist(ArDistView codeview)
        {
            try
            {
                var ExistingDist = _context.ArDists.Where(x => x.ArDistId == codeview.ArDistId).FirstOrDefault();
                if (ExistingDist != null)
                {
                    _context.ArDists.Remove(ExistingDist);
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
        #endregion ArDist Class

        #region Transaksi Piutang Class

        public async Task<ArTransH> GetTrans(int id)
        {
            return await _context.ArTransHs.Include(p => p.ArTransDs).Where(x => x.ArTransHId == id).FirstOrDefaultAsync();
        }

        public Task<List<ArTransH>> GetTransH()
        {
            // return  _context.CbTransHs.Include(p =>p.CbTransDs).OrderByDescending(x =>x.Tanggal).ToListAsync();
            return _context.ArTransHs.OrderByDescending(x => x.Tanggal).ToListAsync();

        }

        public Task<List<ArTransH>> Get3TransH()
        {
            // return  _context.CbTransHs.Include(p =>p.CbTransDs).OrderByDescending(x =>x.Tanggal).ToListAsync();
            return _context.ArTransHs.OrderByDescending(x => x.Tanggal).Where(x => x.Tanggal > DateTime.Today.AddMonths(-3)).ToListAsync();

        }

        public async Task<List<ArTransD>> GetTransD()
        {
            return await _context.ArTransDs.ToListAsync();
        }

        public async Task<bool> AddTransH(ArTransHView trans)
        {
            //string test = codeview.SrcCode.ToUpper();
            //var cekFirst = _context.CbSrcCodes.Where(x => x.SrcCode == test).ToList();
            
            ArTransH transH = new ArTransH
            {
                Bukti = GetNumber(),
                Customer = trans.Customer.ToUpper(),
                Tanggal = trans.Tanggal,
                Keterangan = trans.Keterangan,
                Jumlah = trans.Jumlah,
                PPn = 0,
                PPh = 0,
                JumPPh = 0,
                Bruto = trans.Jumlah,
                Netto = 0,
                JumPPn = 0,
                Discount = 0,
                Piutang = 0,
                Kode = "11",
                ArCustId = trans.ArCustId,
                
                ArTransDs = new List<ArTransD>()
            };
            foreach (var item in trans.ArTransDs)
            {
                transH.ArTransDs.Add(new ArTransD()
                {
                    DistCode = item.DistCode,
                    Keterangan = item.Keterangan,
                    Jumlah = item.Jumlah,
                    KodeTran = "11",
                    Lpb = transH.Bukti,
                    Sisa = item.Jumlah,
                    Discount = 0,
                    Bayar = 0,
                     Tanggal = trans.Tanggal
                });
            }
            ArPiutng transaksi = new ArPiutng
            {
                Kode = "IN",
                Dokumen = transH.Bukti,
                Tanggal = transH.Tanggal,
                Customer = transH.Customer,
                Keterangan = transH.Keterangan,
                KodeTran = "11",
                Jumlah = transH.Jumlah,
                Sisa = transH.Jumlah,
                SldSisa = transH.Jumlah,
                Dpp = transH.Jumlah
            };

            var customer = (from e in _context.ArCusts where e.Customer == trans.Customer select e).FirstOrDefault();
            customer.Piutang += trans.Jumlah;
          
            _context.ArCusts.Update(customer);
         //   _context.ArTransHs.Add(transH);
        //    _context.ArPiutngs.Add(transaksi);
            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<bool> EditTransH(ArTransHView trans)
        {
            //string test = codeview.SrcCode.ToUpper();
            //var cekFirst = _context.CbSrcCodes.Where(x => x.SrcCode == test).ToList();
            var cekFirst = _context.ArPiutngs.Where(x => x.Dokumen == trans.Bukti).FirstOrDefault();
            if(cekFirst.Jumlah-cekFirst.Sisa != 0)
            {
                return true;
            }

            ArTransH transH = new ArTransH
            {
                Bukti = trans.Bukti,
                Customer = trans.Customer.ToUpper(),
                Tanggal = trans.Tanggal,
                Keterangan = trans.Keterangan,
                Jumlah = trans.Jumlah,
                ArTransDs = new List<ArTransD>()
            };
            foreach (var item in trans.ArTransDs)
            {
                transH.ArTransDs.Add(new ArTransD()
                {
                    DistCode = item.DistCode,
                    Keterangan = item.Keterangan,
                    Jumlah = item.Jumlah
                });
            }

            try
            {
                var ExistingTrans = _context.ArTransHs.Where(x => x.ArTransHId == trans.ArTransHId).FirstOrDefault();
                if (ExistingTrans != null)
                {
                    transH.Bukti = ExistingTrans.Bukti;
                    _context.ArTransHs.Remove(ExistingTrans);
                    var customer = (from e in _context.ArCusts where e.Customer == trans.Customer select e).FirstOrDefault();
                  
                    customer.Piutang -= ExistingTrans.Jumlah;                
                    customer.Piutang += trans.Jumlah;
                    _context.ArCusts.Update(customer);
                    _context.ArTransHs.Add(transH);
               //     _context.ArPiutngs.Add(transaksi);
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
                var ExistingTrans = _context.CbTransHs.Where(x => x.CbTransHId == id).FirstOrDefault();
                if (ExistingTrans != null)
                {
                    var bank = (from e in _context.Banks where e.KodeBank == ExistingTrans.KodeBank select e).FirstOrDefault();
                    bank.Saldo -= ExistingTrans.Saldo;
                    bank.KSaldo -= ExistingTrans.KSaldo;
                    _context.Banks.Update(bank);
                    _context.CbTransHs.Remove(ExistingTrans);
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
            string kodeno = "ARI";
            string kodeurut = kodeno + '-';
            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeurut + thnbln.Substring(0, 2) + '2' + thnbln.Substring(2, 2) + '-';
            var maxvalue = "";
            var maxlist = _context.CbTransHs.Where(x => x.DocNo.Substring(0, 10).Equals(xbukti)).ToList();
            if (maxlist != null)
            {
                maxvalue = maxlist.Max(x => x.DocNo);

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
