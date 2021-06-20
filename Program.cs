using GhostscriptSharp;
using iText.IO.Codec;
using iText.Kernel.Pdf;
using System;
using System.IO;
using Tesseract;
namespace hi
{
    public static class Program
    {
        public static void Main()
        {
            //Input File Path
            string input_path = @"C:\Users\HP\Desktop\input.pdf";
            //Output File Path
            string output_path = @"C:\Users\HP\Desktop\output";
            //Tessdata Folder
            string training_data = @"C:\Users\HP\Desktop\tessdata";
            
            PdfReader pdf = new PdfReader(input_path);
            PdfDocument pdfDoc = new PdfDocument(pdf);
            int n = pdfDoc.GetNumberOfPages();
            pdf.Close();
            using (IResultRenderer renderer = Tesseract.PdfResultRenderer.CreatePdfRenderer(output_path, training_data, false))
            {
                using (renderer.BeginDocument("Serachablepdftest"))
                {
                    for (int i = 1; i <= n; i++)
                    {

                        GhostscriptWrapper.GeneratePageThumbs(input_path, "example" + i + ".jpg", i, n, 200, 200);
                        string configurationFilePath = training_data;
                        string configfile = Path.Combine(training_data, "pdf.ttf");
                        using (TesseractEngine engine = new TesseractEngine(configurationFilePath, "eng", EngineMode.TesseractAndLstm, configfile))
                        {
                                using (var img = Pix.LoadFromFile("example" + i + ".jpg"))
                                {
                                    using (var page = engine.Process(img, "Serachablepdftest"))
                                    {
                                        renderer.AddPage(page);

                                    }
                                }
                        }
                        Console.WriteLine("Page " + i + "done\n");
                    }
                }
            }   
        }
        
        
    }   
}