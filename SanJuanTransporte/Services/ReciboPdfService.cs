using System;
using System.IO;
using System.Threading.Tasks;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using SanJuanTransporte.Models;

namespace SanJuanTransporte.Services
{
    public class ReciboPdfService
    {
        public async Task<byte[]> GenerarReciboPdfAsync(Pago pago, string firmaConductor, string firmaEncargado)
        {
            using (var memoryStream = new MemoryStream())
            {
                try
                {
                    // Código del método GenerarReciboPdfAsync

                    var writer = new PdfWriter(memoryStream);
                    var pdf = new PdfDocument(writer);
                    var document = new Document(pdf);
                    var estiloNegrita = PdfFontFactory.CreateFont("Helvetica-Bold");
                    var estiloSubrayado = PdfFontFactory.CreateFont("Helvetica");
               

                    // Agregar logo en la esquina
                    var logoPath = "wwwroot/images/encabezado.png";  // Cambia la ruta del logo
                    var logo = new Image(ImageDataFactory.Create(logoPath)).ScaleToFit(70, 50);
                    document.Add(logo);

                    document.Add(new Paragraph("RECIBO").SetFont(estiloNegrita).SetFontSize(30).SetTextAlignment(TextAlignment.CENTER));

                    // Agregar tabla al final del recibo
                    var tabla = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();
                    tabla.AddCell(new Cell().Add(new Paragraph("Número de Recibo:")).SetFont(estiloSubrayado));
                    tabla.AddCell(new Cell().Add(new Paragraph(pago.Numero.ToString())));

                    tabla.AddCell(new Cell().Add(new Paragraph("Detalles de Pago:")).SetFont(estiloSubrayado));
                    tabla.AddCell(new Cell().Add(new Paragraph(pago.Detalle)));

                    tabla.AddCell(new Cell().Add(new Paragraph("Fecha de Emisión:")).SetFont(estiloSubrayado));
                    tabla.AddCell(new Cell().Add(new Paragraph(pago.FechaPago.ToString("dd/MM/yyyy HH:mm:ss"))));

                    tabla.AddCell(new Cell().Add(new Paragraph("Monto:")).SetFont(estiloSubrayado));
                    tabla.AddCell(new Cell().Add(new Paragraph(pago.Monto.ToString("C"))));

                    document.Add(tabla);


                    // Agregar imagen de marca de agua en el fondo
                    var imgPath = "wwwroot/images/LOGO3.png";  // Cambia la ruta de la imagen
                    var fondo = new Image(ImageDataFactory.Create(imgPath)).SetOpacity(0.2f);
                    document.Add(fondo);

                   

                    document.Close();

                    return memoryStream.ToArray();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al generar el PDF: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
