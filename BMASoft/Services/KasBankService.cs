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
    public interface IKasBankService
    {
        Task<List<CbBank>> GetBank();
        CbBank GetBankId(int id);
        Task<bool> AddBank(BankView banks);
        Task<bool> EditBank(BankView banks);
        Task<bool> DelBank(int banks);
        Task<List<CbSrcCode>> GetSrcCode();
        CbSrcCode GetSrcCodeId(int id);
        Task<bool> AddSrcCode(SrcCodeView codeview);
        Task<bool> EditSrcCode(SrcCodeView codeview);
        Task<bool> DelSrcCode(int codeview);
        Task<CbTransH> GetTrans(int id);
        Task<List<CbTransH>> GetTransH();
        Task<List<CbTransH>> Get3TransH();
        Task<List<CbTransD>> GetTransD();
        Task<bool> AddTransH(TranshView transH);
        Task<bool> EditTransH(TranshView transH);
        Task<bool> DelTransH(int id);
        MemoryStream PdfBuktiBank(TranshView trans);
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

        public CbBank GetBankId(int id)
        {
            return _context.Banks.Where(x => x.CbBankId == id).FirstOrDefault();
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
                    ClrDate = banks.ClrDate,
                    SldAWal = banks.SldAWal,
                    KSldAwal = banks.KSldAwal,
                    Saldo =  banks.SldAWal,
                    KSaldo = banks.KSldAwal,
                    Status = banks.Status

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
                    ExistingBank.ClrDate = banks.ClrDate;                  
                    ExistingBank.SldAWal = banks.SldAWal;
                    ExistingBank.KSldAwal = banks.KSldAwal;
                    ExistingBank.Saldo = banks.SldAWal;
                    ExistingBank.KSaldo = banks.KSldAwal;
                    ExistingBank.Status = banks.Status;

                    _context.Banks.Update(ExistingBank);
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

        public async Task<bool> DelBank(int banks)
        {
            try
            {
                var ExistingBank = _context.Banks.Where(x => x.CbBankId == banks).FirstOrDefault();
                if (ExistingBank != null && ExistingBank.Saldo == 0)
                {
                    _context.Banks.Remove(ExistingBank);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

           
          
        }
        #endregion Bank Class

        #region SrcCode Class

        public async Task<List<CbSrcCode>> GetSrcCode()
        {
            return await _context.CbSrcCodes.ToListAsync();
        }

        public CbSrcCode GetSrcCodeId(int id)
        {
            return _context.CbSrcCodes.Where(x => x.CbSrcCodeId == id).FirstOrDefault();
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

                    _context.CbSrcCodes.Update(ExistingSrcCode);
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

        public async Task<bool> DelSrcCode(int codeview)
        {
            try
            {
                var ExistingSrcCode = _context.CbSrcCodes.Where(x => x.CbSrcCodeId == codeview).FirstOrDefault();
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
            // return  _context.CbTransHs.Include(p =>p.CbTransDs).OrderByDescending(x =>x.Tanggal).ToListAsync();
            return _context.CbTransHs.OrderByDescending(x => x.Tanggal).ToListAsync();

        }

        public Task<List<CbTransH>> Get3TransH()
        {
            // return  _context.CbTransHs.Include(p =>p.CbTransDs).OrderByDescending(x =>x.Tanggal).ToListAsync();
            return _context.CbTransHs.OrderByDescending(x => x.Tanggal).Where( x=>x.Tanggal>DateTime.Today.AddMonths(-3)).ToListAsync();

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
                DocNo = GetNumber(trans.KodeDoc.ToUpper()),
                KodeBank = trans.KodeBank.ToUpper(),
                Tanggal = trans.Tanggal,
                Keterangan = trans.Keterangan,
                Kurs = trans.Kurs,
                Saldo = trans.Saldo,
                KSaldo = trans.KSaldo,
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
                    Jumlah = item.Jumlah,
                    KJumlah = item.KJumlah,
                    Kurs = item.Kurs
                });
            }
            var bank = (from e in _context.Banks where e.KodeBank == trans.KodeBank select e).FirstOrDefault();
            bank.Saldo += trans.Saldo;
            bank.KSaldo += trans.KSaldo;
            _context.Banks.Update(bank);
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
                Saldo = trans.Saldo,
                KSaldo = trans.KSaldo,
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
                    Jumlah = item.Jumlah,
                    KJumlah = item.KJumlah,
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
                    var bank = (from e in _context.Banks where e.KodeBank == trans.KodeBank select e).FirstOrDefault();
                    bank.Saldo -= ExistingTrans.Saldo;
                    bank.KSaldo -= ExistingTrans.KSaldo;
                    bank.Saldo += trans.Saldo;
                    bank.KSaldo += trans.KSaldo;
                    _context.Banks.Update(bank);
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

        #endregion Transaksi Bank Class

        public string GetNumber(string kodeno)
        {
            string kodeurut = kodeno + '-';
            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeurut + thnbln.Substring(0,2)+'2'+ thnbln.Substring(2,2)+'-';
            var maxvalue = "";
            var maxlist = _context.CbTransHs.Where(x => x.DocNo.Substring(0,10).Equals(xbukti)).ToList();
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

        public MemoryStream PdfBuktiBank(TranshView trans)
        {
            var buktibank = _context.CbTransHs.Include(p => p.CbTransDs).Where(x => x.DocNo == trans.DocNo).FirstOrDefaultAsync();

            if (buktibank == null)
            {
                throw new ArgumentNullException("Transaksi cannot be null");
            }

            using (PdfDocument pdfDocument = new PdfDocument())
            {
                //  int paragraphAfterSpacing = 8;
                //  int cellMargin = 8;

                //Add page to the PDF document
                PdfPage page = pdfDocument.Pages.Add();

                //Create a new font
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

                //Create a text element to draw a text in PDF page
                PdfTextElement title = new PdfTextElement("BUKTI KAS/BANK", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));


                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream
                    pdfDocument.Save(stream);
                    //Closing the PDF document
                    pdfDocument.Close(true);
                    return stream;

                }
            }
        }
    }

}
