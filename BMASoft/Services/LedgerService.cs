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
    public interface ILedgerService
    {
        Task<List<GlAccount>> GetGlAccount();
    }

        public class LedgerService : ILedgerService
    {

        private readonly BmaDbContext _context;

        public LedgerService(BmaDbContext context)
        {
            _context = context;
        }

        public async Task<List<GlAccount>> GetGlAccount()
        {
            return await _context.GlAccounts.OrderBy(x => x.GlAcct).ToListAsync();
        }
    }
}
