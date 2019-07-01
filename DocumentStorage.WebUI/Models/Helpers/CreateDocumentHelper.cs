using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DocumentStorage.WebUI.Models.Helpers
{
    public class CreateDocumentHelper
    {
        public static void Create(string absolutePath, string content)
        {
            using (WordprocessingDocument wordDocument =
                     WordprocessingDocument.Create(absolutePath, WordprocessingDocumentType.Document))
            {
                wordDocument.AddMainDocumentPart();
                wordDocument.MainDocumentPart.Document = new Document();
                Body body = wordDocument.MainDocumentPart.Document.AppendChild(new Body());

                int index = 0;
                bool contains = true;
                while (contains)
                {
                    int signInd = content.IndexOf("\n", index);
                    contains = signInd != -1;

                    if (contains)
                        body.AppendChild(
                            new Paragraph(
                                new Run(
                                    new Text(content.Substring(index, (signInd - 1)-index)))));
                    else
                        body.AppendChild(
                        new Paragraph(
                            new Run(
                                new Text(content.Substring(index)))));

                    index = signInd + 1;
                }

            }
        }
    }
}