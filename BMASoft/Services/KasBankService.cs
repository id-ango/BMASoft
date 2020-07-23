using BMASoft.Data;
using BMASoft.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMASoft.Services
{
    public interface IKasBankService
    {
        Task<List<CbBank>> GetBank();
        Task<bool> AddBank(BankView banks);
        Task<bool> EditBank(BankView banks);
        Task<bool> DelBank(BankView banks);
        Task<List<CbSrcCode>> GetSrcCode();
        Task<bool> AddSrcCode(SrcCodeView codeview);
        Task<bool> EditSrcCode(SrcCodeView codeview);
        Task<bool> DelSrcCode(SrcCodeView codeview);
        Task<CbTransH> GetTrans(int id);
        Task<List<CbTransH>> GetTransH();
        Task<List<CbTransD>> GetTransD();
        Task<bool> AddTransH(TranshView transH);
        Task<bool> EditTransH(TranshView transH);
        Task<bool> DelTransH(int id);
    }

    public class KasBankService : IKasBankService
    {
        private readonly BmaDbContext _context;

        public KasBankService(BmaDbContext context)
        {
            _context = context;
        }

        #region Bank Class

        public async Task<List<CbBank>> GetBank()
        {
            return await _context.Banks.ToListAsync();
        }

        public async Task<bool> AddBank(BankView banks)
        {
            string test = banks.kdbank.ToUpper();
            var cekFirst = _context.Banks.Where(x => x.KodeBank == test).ToList();
            if (cekFirst.Count == 0)
            {
                CbBank Bank = new CbBank()
                {
                    KodeBank = banks.kdbank.ToUpper(),
                    NmBank = banks.namabank,
                    Kurs = banks.kurs,
                    ClrDate = DateTime.Today
                };
                _context.Banks.Add(Bank);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                
                return false;
            }
           
        }

        public async Task<bool> EditBank(BankView banks)
        {
            try
            {
                var ExistingBank = _context.Banks.Where(x => x.CbBankId == banks.bankId).FirstOrDefault();
                if (ExistingBank != null)
                {
                    ExistingBank.NmBank = banks.namabank;
                    ExistingBank.Kurs = banks.kurs;
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

        public async Task<bool> DelBank(BankView banks)
        {
            try
            {
                var ExistingBank = _context.Banks.Where(x => x.CbBankId == banks.bankId).FirstOrDefault();
                if (ExistingBank != null)
                {
                    _context.Banks.Remove(ExistingBank);
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
        #endregion Bank Class

        #region SrcCode Class

        public async Task<List<CbSrcCode>> GetSrcCode()
        {
            return await _context.CbSrcCodes.ToListAsync();
        }

        public async Task<bool> AddSrcCode(SrcCodeView codeview)
        {
            string test = codeview.SrcCode.ToUpper();
            var cekFirst = _context.CbSrcCodes.Where(x => x.SrcCode == test).ToList();
            if (cekFirst.Count == 0)
            {
                CbSrcCode BankCode = new CbSrcCode()
                {
                    SrcCode = codeview.SrcCode.ToUpper(),
                    NamaSrc = codeview.NamaSrc,
                    GlAcct = codeview.GlAcct
                   
                };
                _context.CbSrcCodes.Add(BankCode);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {

                return false;
            }


        }

        public async Task<bool> EditSrcCode(SrcCodeView codeview)
        {
            try
            {
                var ExistingSrcCode = _context.CbSrcCodes.Where(x => x.CbSrcCodeId == codeview.SrcCodeId).FirstOrDefault();
                if (ExistingSrcCode != null)
                {
                    ExistingSrcCode.NamaSrc = codeview.NamaSrc;
                    ExistingSrcCode.GlAcct = codeview.GlAcct;
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

        public async Task<bool> DelSrcCode(SrcCodeView codeview)
        {
            try
            {
                var ExistingSrcCode = _context.CbSrcCodes.Where(x => x.CbSrcCodeId == codeview.SrcCodeId).FirstOrDefault();
                if (ExistingSrcCode != null)
                {
                    _context.CbSrcCodes.Remove(ExistingSrcCode);
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
        #endregion srcode Class

        #region Transaksi Bank Class

        public async Task<CbTransH> GetTrans(int id)
        {
            return await _context.CbTransHs.Include(p => p.CbTransDs).Where(x =>x.CbTransHId == id).FirstOrDefaultAsync();
        }

        public Task<List<CbTransH>> GetTransH()
        {
            return  _context.CbTransHs.Include(p =>p.CbTransDs).OrderByDescending(x =>x.Tanggal).ToListAsync();
        }

        public async Task<List<CbTransD>> GetTransD()
        {
            return await _context.CbTransDs.ToListAsync();
        }

        public async Task<bool> AddTransH(TranshView trans)
        {
            //string test = codeview.SrcCode.ToUpper();
            //var cekFirst = _context.CbSrcCodes.Where(x => x.SrcCode == test).ToList();
           
            CbTransH transH = new CbTransH
            {
                DocNo = GetNumber(trans.KodeBank.ToUpper()),
                KodeBank = trans.KodeBank.ToUpper(),
                Tanggal = trans.Tanggal,
                Keterangan = trans.Keterangan,
                Kurs = trans.Kurs,
                CbTransDs = new List<CbTransD>()
            };
            foreach (var item in trans.TransDs)
            {
                transH.CbTransDs.Add(new CbTransD()
                {
                    SrcCode = item.SrcCode,
                    Keterangan = item.Keterangan,
                    Terima = item.Terima,
                    Bayar = item.Bayar,
                    KTerima = item.KTerima,
                    KBayar = item.KBayar,
                    KValue = item.KValue,
                    Kurs = item.Kurs
                });
            }


            _context.CbTransHs.Add(transH);
            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<bool> EditTransH(TranshView trans)
        {
            //string test = codeview.SrcCode.ToUpper();
            //var cekFirst = _context.CbSrcCodes.Where(x => x.SrcCode == test).ToList();

            CbTransH transH = new CbTransH
            {                
                DocNo = trans.DocNo,
                KodeBank = trans.KodeBank.ToUpper(),
                Tanggal = trans.Tanggal,
                Keterangan = trans.Keterangan,
                Kurs = trans.Kurs,
                CbTransDs = new List<CbTransD>()
            };
            foreach (var item in trans.TransDs)
            {
                transH.CbTransDs.Add(new CbTransD()
                {
                    SrcCode = item.SrcCode,
                    Keterangan = item.Keterangan,
                    Terima = item.Terima,
                    Bayar = item.Bayar,
                    KTerima = item.KTerima,
                    KBayar = item.KBayar,
                    KValue = item.KValue,
                    Kurs = item.Kurs
                });
            }

            try
            {
                var ExistingTrans = _context.CbTransHs.Where(x => x.CbTransHId == trans.CbTransHId).FirstOrDefault();
                if (ExistingTrans != null)
                {
                    transH.DocNo = ExistingTrans.DocNo;
                    _context.CbTransHs.Remove(ExistingTrans);
                    _context.CbTransHs.Add(transH);
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

        #endregion Transaksi Bank Class

        public string GetNumber(string kodeno)
        {
            string kodeurut = kodeno + '-';
            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeurut + thnbln;
            var maxvalue = "";
            var maxlist = _context.CbTransHs.Where(x => x.DocNo.Substring(0, 7).Equals(xbukti)).ToList();
            if (maxlist != null)
            {
                maxvalue = maxlist.Max(x => x.DocNo);

            }

            //            var maxvalue = (from e in db.CbTransHs where  e.Docno.Substring(0, 7) == kodeno + thnbln select e).Max();
            string nourut = "000";
            if (maxvalue == null)
            {
                nourut = "000";
            }
            else
            {
                nourut = maxvalue.Substring(7, 3);
            }

            //  nourut =Convert.ToString(Int32.Parse(nourut) + 1);


            string cAngNo = kodeurut+ thnbln + (Int32.Parse(nourut) + 1).ToString("000");
            // var maxvalue = (from e in db.AptTranss where e.NoRef.Substring(0, 7) == "ANG" + cAngNo select e.NoRef.Max()).FirstOrDefault();
            return cAngNo;

        }
    }

}
