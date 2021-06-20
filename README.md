# ScannedPDF-to-SearchablePDF

This is a C# code to convert Scanned PDFs to Searchable PDF using Google Tesseract.

To launch this project download and open in visual studio with Microsoft .NET assembly

Now using Nuget Package installer, install all the packages as listed in packages.config file with their appropriate versions.

Next Open Program.cs file and Change the input PDF and output PDF path.
Also check path of tessdata folder(you just downloaded), and replace it's path in Program.cs file.(training_data variable)

The traning data (tessdata folder) is from Google Tesseract, and can be updated with new versions.
