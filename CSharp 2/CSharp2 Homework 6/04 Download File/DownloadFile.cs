using System;
using System.IO;
using System.Net;

class DownloadFile
{
    static void Main()
    {
        Console.WriteLine("Task 04 - Download a file from given URI\n\n");

        string uri = "http://www.devbg.org/img/Logo-BASD.jpg";

        Console.WriteLine();

        Console.Write("Please enter full URI to download (or press enter for default): ");
        string file = Console.ReadLine();
        if (file.Length == 0) file = uri;
        WebClient client = null;
        try
        {
            string filename = Path.GetFullPath(".") + @"\" + Path.GetFileName(file);
            Console.WriteLine("\nDownloading {0}\n\nDestination: {1}\n\n", file, filename);
            client = new WebClient();
            client.DownloadFile(file, filename);
        }
        catch (SystemException se)
        {
            Console.WriteLine("Exception: " + se.Message);
        }
        finally
        {
            if (client != null) client.Dispose();
        }


        Console.WriteLine("\n\nPress Enter to finish");
        Console.ReadLine();
    }
}

