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
    public class CredencialPdfService
    {
        public async Task<byte[]> GenerarCredencialPdfAsync(Conductor conductor)
        {
            using (var memoryStream = new MemoryStream())
            {
                try
                {
                    var writer = new PdfWriter(memoryStream);
                    var pdf = new PdfDocument(writer);
                    var estiloNegrita = PdfFontFactory.CreateFont("Helvetica-Bold");
                    var document = new Document(pdf);

                    var logoPath = "wwwroot/images/encabezado.png";
                    var logo = new Image(ImageDataFactory.Create(logoPath)).ScaleToFit(70, 50);
                    document.Add(logo);
                    document.Add(new Paragraph("CREDENCIAL").SetFont(estiloNegrita).SetFontSize(30).SetTextAlignment(TextAlignment.CENTER));

                 
                    var table = new Table(2);
                    table.SetWidth(UnitValue.CreatePercentValue(100));

                    // Add text content to the left cell
                    var textCell = new Cell().Add(new Paragraph($"NOMBRE: {conductor.NombreCompleto}")
    .SetFont(estiloNegrita)
    .SetFontSize(18) // Set the desired font size
    .Add("\n" +
        $"NUMERO DE CI: {conductor.CI}\n" +
        $"NUMERO DE LIECENCIA: {conductor.NumeroLicencia}\n" +
        $"NUMERO DE PLACA: {conductor.NumeroPlaca}\n" +
        $"DIRECCION: {conductor.Direccion}"));


                    // Check and add the image to the right cell
                    if (!string.IsNullOrEmpty(conductor.Foto))
                    {
                        var imagePath = Path.Combine("wwwroot/uploads", conductor.Foto);

                        if (File.Exists(imagePath))
                        {
                            var image = new Image(ImageDataFactory.Create(imagePath));

                            // Optionally set a maximum width for the image
                            const float maxWidth = 90f; // You can adjust this value as needed

                            if (image.GetImageWidth() > maxWidth)
                            {
                                image.SetWidth(maxWidth);
                                image.SetAutoScaleWidth(true);
                            }

                            var imageCell = new Cell().Add(image);
                            table.AddCell(textCell);
                            table.AddCell(imageCell);
                        }
                        else
                        {
                            Console.WriteLine($"La imagen no se encuentra en la ruta especificada: {imagePath}");
                        }
                    }
                    else
                    {
                        table.AddCell(textCell);
                    }


                    var imgPath = "wwwroot/images/LOGO3.png";
                    var fondo = new Image(ImageDataFactory.Create(imgPath)).SetOpacity(0.2f);
                    document.Add(table);
                    document.Add(fondo);

                    document.Close();

                    return memoryStream.ToArray();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al generar la credencial: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
