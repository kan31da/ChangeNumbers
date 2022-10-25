using System.Text;

const string fileExport = "Eport.txt";
const string fileImport = "Import.txt";

StringBuilder sb = new();

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Encoding encodingCyr = Encoding.GetEncoding(1251);

try
{
    // Create an instance of StreamReader to read from a file.
    // The using statement also closes the StreamReader.
    using (StreamReader sr = new(fileImport, encodingCyr))
    {
        string line;
        // Read and display lines from the file until the end of
        // the file is reached.
        while ((line = sr.ReadLine()) != null)
        {

            string[] arrayLine = line.Split(';').ToArray();
            string number = arrayLine[2].Trim();

            if (number.Length < 5)
            {
                number = number.PadLeft(5, '0');
            }

            arrayLine[2] = number;

            sb.Append($"{String.Join(";", arrayLine)}");
            Console.WriteLine(String.Join(";", arrayLine));

            using (StreamWriter writer = new(fileExport, append: true))
            {
                await writer.WriteLineAsync(sb);
                writer.Close();
            }

            sb.Clear();
        }
    }
}
catch (Exception e)
{
    // Let the user know what went wrong.
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}


//StreamReader streamReader = new(fileImport, encodingCyr);
//using (streamReader)
//{
//    int lineNumber = 0;
//    string line = streamReader.ReadLine();
//    // Тестов ред на кирилица
//    // Тестов ред на кирилица
//    while (line != null)
//    {
//        lineNumber++;
//        if (lineNumber % 2 == 1) // If the line-number is  odd
//        {
//            Console.WriteLine("Line {0}: {1}", lineNumber, line);
//        }
//        line = streamReader.ReadLine();
//    }
//}