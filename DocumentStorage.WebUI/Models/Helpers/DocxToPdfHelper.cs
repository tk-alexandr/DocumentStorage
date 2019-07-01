using iDiTect.Converter;
using System.IO;

namespace DocumentStorage.WebUI.Models.Helpers
{
    public class DocxToPdfHelper
    {
        public static void Convert(string absolutePath)
        {

            DocxToPdfConverter converter = new DocxToPdfConverter();


            using (Stream stream = System.IO.File.OpenRead(absolutePath))
            {
                converter.Load(stream);
            }
            converter.PdfStandard = PdfStandard.Pdf;

            using (var stream = System.IO.File.OpenWrite(absolutePath + ".pdf"))
            {
                converter.Save(stream);
            }

        }
    }
}