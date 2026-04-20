using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using task22.interfaces;
using static System.Collections.Specialized.BitVector32;

namespace task22.models
{
    internal class Book : IlibraryItem
    {
        
        private  int _pagecount;
        private decimal _price;
        private int _publichyear;
        public string Title{ get; init; }
        public Book(string title, int pageCount, decimal price,int publishyear)
        {
            Title = title;
            PageCount = pageCount;
            Price = price;
            Publichyear = publishyear;
        }
        public int PageCount
        {
            get { return _pagecount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Page count cannot be negative.");
                }
                _pagecount = value;
            }
        }
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative.");
                }
                _price = value;
            }
        }
        public int Publichyear
        {
            get { return _publichyear; }
            set
            {
                if (value > DateTime.Now.Year)
                {
                    throw new ArgumentOutOfRangeException("Publish year cannot be in the future.");
                }
                _publichyear = value;
            }
        }
        public void BorrowItem()
        {
            Console.WriteLine("This book is available in the Physical Section.Please pick it up from Shelf #B12.");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title},pagecount: {PageCount},price:{Price}");
        }
    }
}
