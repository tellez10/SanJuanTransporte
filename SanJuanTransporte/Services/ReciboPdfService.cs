/*using System.IO;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using SanJuanTransporte.Models;


    public class ReciboPdfService
    {
        public async Task<byte[]> GenerarReciboPdfAsync(Pago pago)
        {
            using (var memoryStream = new MemoryStream())
            {
                try
                {
                    var writer = new PdfWriter(memoryStream);
                    var pdf = new PdfDocument(writer);
                    var document = new Document(pdf);

                    // Agrega contenido al PDF
                    document.Add(new Paragraph($"Número de Recibo: {pago.Numero}"));
                    document.Add(new Paragraph($"Detalles de Pago: {pago.Detalle}"));
                    document.Add(new Paragraph($"Fecha de Emisión: {pago.FechaPago.ToString("dd/MM/yyyy HH:mm:ss")}"));
                    document.Add(new Paragraph($"Monto: {pago.Monto}"));

                    // Puedes agregar más información según tus necesidades

                    // Cierra el documento
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
*/