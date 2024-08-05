using PdfSharpCore;
using PdfSharpCore.Pdf;
using HtmlRendererCore.PdfSharp;

namespace pdfsharp_fromhtml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            createPdf("output_file.pdf.");

            Console.WriteLine("Html file saved.");
        }

        private static void createPdf(string saveFilepath)
        {
            var document = new PdfDocument();
            // var html = "<html><body style='color:black'>PMKJ</body></html>";
            string html = generateHTMLFile(10);
            PdfGenerator.AddPdfPages(document, html, PageSize.A4);

            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                res = ms.ToArray();
            }

            File.WriteAllBytes(saveFilepath, res);
        }

        private static string generateHTMLFile(int numberOfRows)
        {
            string returnValue = "" +
                "    <style>" +
                "       table {" +
                "               border-collapse: collapse;" +
                "               width: auto;}" +
                "               th, td {" +
                "                       border: 1px solid black;" +
                "                       text-align: left;" +
                "                       padding: 8px;}" +
                "       </style>" +
                "<h1>Prayer Journal List</h1>" +
                "<table border='1'>" +
                "    <tr> " +
                "   <td width='20%' style='text-align: left; background-color: lightgray;font-weight: bold;'>Headline</td>" +
                "   <td width='60%' style='text-align: left; background-color: lightgray;font-weight: bold;'>Details</td>" +
                "   <td width='10%' style='text-align: center; background-color: lightgray;font-weight: bold;'>Date</td>" +
                "   <td width='5%' style='text-align: center; background-color: lightgray;font-weight: bold;'>Is History</td>" +
                "</tr>";

            
            for (int i = 1; i < numberOfRows; i++)
            {
                string newRow = $"<tr><td>{i}</td>" +
                    $"<td>This is row number {i}</td>" +
                    $"<td style='font-size:8px;text-align: center;'>2024-08-04</td>" +
                    $"<td style='text-align: center;'>Yes</td></tr>";
                returnValue += newRow;
            }

            returnValue += "</table>";
            return returnValue;
        }
    }
}
