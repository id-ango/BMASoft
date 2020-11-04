using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using BMASoft.Data;
using BMASoft.Data.Models;
using Newtonsoft.Json;

namespace BMASoft.Printing
{
    public class BuktiKasBank
    {
        public MemoryStream CreatePdfDocument(CbTransH trans)
        {
            string Title = "BUKTI KAS/BANK";
            string Tanggal = "Tanggal";
            string NoDoc = "No.";
            

            // var cetak = JsonConvert.DeserializeObject(trans);
            // Console.WriteLine(trans);
            
            //Create a new PDF document
            PdfDocument document = new PdfDocument();
            // document.PageSettings = new PdfPageSettings(new SizeF(300, 400));
            //Add a page
            document.PageSettings.Margins.All = 0;
            PdfPage page = document.Pages.Add();
            //Create Pdf graphics for the page
            PdfGraphics g = page.Graphics;
            //Create a solid brush
            PdfBrush brush = new PdfSolidBrush(new PdfColor(0, 0, 0));
            PdfBrush tintamerah = new PdfSolidBrush(Color.Red);
            //Set the font
            PdfFont fontJudul = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);
            PdfFont fontField = new PdfStandardFont(PdfFontFamily.TimesRoman, 10);
            //Draw Kotak
            RectangleF rectangle = new RectangleF(20, 120, 50, 50);
            g.DrawRectangle(brush, rectangle);
            g.TranslateTransform(60, 0);
            // Judul 
           
            //Draw the text
           g.DrawString(Title, fontJudul, tintamerah, new PointF(150, 20));
            g.DrawString(Tanggal, fontField, brush, new PointF(0, 50));
            g.DrawString(trans.Tanggal.ToShortDateString(), fontField, brush, new PointF(50, 50));
            g.DrawString(NoDoc, fontField, brush, new PointF(0, 80));
            g.DrawString(trans.DocNo, fontField, brush, new PointF(50, 80));
           
            //Saving the PDF to the MemoryStream
            MemoryStream ms = new MemoryStream();
            document.Save(ms);
            //If the position is not set to '0' then the PDF will be empty.
            ms.Position = 0;
            return ms;
        }
    }
}
