using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task22.interfaces;

namespace task22.models
{
    internal class Magazine : IlibraryItem
    {
        private int _publishmonth;
        private int _issueNumber;
        private string _Author;
        
        public string Title { get; init; }
        public Magazine(string title, int issueNum, int month,string author)
        {
            Title = title;
            issuesNumber = issueNum;
            PublishMonth = month;
            Author = author;
        }
        public int PublishMonth
        {
            get { return _publishmonth; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentOutOfRangeException("Publish month must be between 1 and 12.");
                }
                _publishmonth = value;
            }
        }
        public string Author { get => _Author; set => _Author = value; }
        public int issuesNumber
        {
            get { return _issueNumber; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Issue number cannot be negative.");
                }
                _issueNumber = value;
            }
        }
        public void BorrowItem()
        {
            Console.WriteLine("Borrowing failed: Magazines are for in-library reading only and cannot be taken home.");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, Publish Month: {PublishMonth}, Author: {Author}, Issue Number: {issuesNumber}");
        }
    }
}
