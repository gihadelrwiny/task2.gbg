using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.interfaces;

namespace task22.models
{
    internal class Ebook : IlibraryItem
    {
        private int _fileSize;
        private string _format;
        private int _downloadLimit;
        public string Title { get; init; }
        public Ebook(string title, string format, int fileSize,int downloadlimit)
        {
            Title = title;
            Format = format;
            FileSize = fileSize;
            DownloadLimit = downloadlimit;
        }
        public int FileSize { get => _fileSize;
            set {    
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("File size cannot be negative.");
                }
                _fileSize = value;
            }
        }
        public string Format { get => _format; set => _format = value; }
        public int DownloadLimit { get => _downloadLimit; set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Download limit cannot be negative.");
                }
                _downloadLimit = value;
            }
        }
        public void BorrowItem()
        {
            Console.WriteLine("Access granted! Your download link is http/ebook");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, File Size: {FileSize}MB, Format: {Format}, Download Limit: {DownloadLimit}");
        }
    }
}
