using Application.Abstractions.Documents;
using Domain.Transactions;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Globalization;

namespace Infrastructure.Documents;

public class CreateDocument : ICreateDocument
{    
    public async Task<byte[]> CreateAccountStatement(string CardNumber, int Month, IEnumerable<History> histories) 
    {
        using MemoryStream ms = new MemoryStream();
        PdfWriter writer = new PdfWriter(ms);
        PdfDocument pdf = new PdfDocument(writer);
        pdf.SetDefaultPageSize(PageSize.LETTER);
        iText.Layout.Document document = new iText.Layout.Document(pdf);

        document.SetMargins(21.80806f, 21.80806f, 21.80806f, 21.80806f);

        DateTime dateHeader = new DateTime(2020, Month, 1);
        
        dateHeader.ToString("MMMM", new CultureInfo("es-ES"));
        
        Paragraph header = new Paragraph($"Estado de cuenta tarjeta numero {CardNumber} del mes {dateHeader.ToString("MMMM", new CultureInfo("es-ES"))}").SetTextAlignment(TextAlignment.CENTER).SetFontSize(14);
        document.Add(header);

        var table = new Table(new float[] { 150f, 100f, 100f, 200f }, false);

        table.AddHeaderCell(new Cell().SetHeight(40).SetTextAlignment(TextAlignment.CENTER).SetBorder(new SolidBorder(1))
            .Add(new Paragraph("\n").SetFontSize(10))
            .Add(new Paragraph("Fecha").SetFontSize(10)));
        table.AddHeaderCell(new Cell().SetHeight(40).SetTextAlignment(TextAlignment.CENTER).SetBorder(new SolidBorder(1))
           .Add(new Paragraph("\n").SetFontSize(10))
           .Add(new Paragraph("Tipo transacción").SetFontSize(10)));
        table.AddHeaderCell(new Cell().SetHeight(40).SetTextAlignment(TextAlignment.CENTER).SetBorder(new SolidBorder(1))
           .Add(new Paragraph("\n").SetFontSize(10))
           .Add(new Paragraph("Monto").SetFontSize(10)));
        table.AddHeaderCell(new Cell().SetHeight(40).SetTextAlignment(TextAlignment.CENTER).SetBorder(new SolidBorder(1))
           .Add(new Paragraph("\n").SetFontSize(10))
           .Add(new Paragraph("Descripcion").SetFontSize(10)));

        foreach (var history in histories)
        {            
            DateTime date = history.payment_date ?? DateTime.Now;
            table.AddCell(new Cell().SetHeight(15).SetTextAlignment(TextAlignment.LEFT).SetBorder(new SolidBorder(1))
            .Add(new Paragraph(date.ToString("dd/MM/yyyy HH:mm:ss")).SetFontSize(10)));
            table.AddCell(new Cell().SetHeight(15).SetTextAlignment(TextAlignment.LEFT).SetBorder(new SolidBorder(1))
            .Add(new Paragraph(history.transaction_type).SetFontSize(10)));
            table.AddCell(new Cell().SetHeight(15).SetTextAlignment(TextAlignment.RIGHT).SetBorder(new SolidBorder(1))
               .Add(new Paragraph($"$ {history.Amount.ToString("N2")}").SetFontSize(10)));
            table.AddCell(new Cell().SetHeight(15).SetTextAlignment(TextAlignment.LEFT).SetBorder(new SolidBorder(1))
               .Add(new Paragraph(history.Description).SetFontSize(10)));
        }
        document.Add(table);
        document.Close();

        return ms.ToArray();
    }
}
