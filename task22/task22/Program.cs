using System.ComponentModel.DataAnnotations;
using task22.GenericRepositories;
using task22.Interfaces;
using task22.Models;
using task22.Repositories;
using task22.Validators;

namespace task22
{
    internal class Program
    {

        static void Main(string[] args)
        {


            ConsolePrinter.PrintResult();
            ConsolePrinter.PrintPair();
            ConsolePrinter.PrintMinMax();
            ConsolePrinter.PrintRepository();
            ConsolePrinter.PrintQueue();
            ConsolePrinter.PrintZip();
            ConsolePrinter.PrintBoxing();
            ConsolePrinter.PrintValidator();


        }
    }
}

