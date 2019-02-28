using System;
using System.IO;
using System.Text;

namespace SiteMapGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = DateTime.Today.ToString("yyyy-MM-dd");

            using (var fileStream = File.OpenRead("URLs.txt"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine("<url>");
                    Console.WriteLine($" <loc>{line}</loc>");
                    Console.WriteLine($" <lastmod>{date}</lastmod>");

                    if (line.EndsWith(".com/"))
                        Console.WriteLine(" <changefreq>weekly</changefreq>");                  
                    else
                        Console.WriteLine(" <changefreq>monthly</changefreq>");

                    if (line.Contains("gift-guides"))
                        Console.WriteLine(" <priority>0.8000</priority>");
                    else if (line.EndsWith(".com/"))
                        Console.WriteLine(" <priority>1.0000</priority>");
                    else
                        Console.WriteLine(" <priority>0.5000</priority>");

                    Console.WriteLine("</url>");
                }
            }

            Console.Read();
        }
    }
}
