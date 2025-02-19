//SAMANTHA BUI
//ECOMMERCE CONSOLE

using Samazon.Models;
using Library.eCommerce.Services;
using System;
using System.Xml.Serialization;

namespace MyApp
{
    internal class Program
    {
        //MAIN IS STATIC. CANNOT CALL NOT STATIC THING IN STATIC FUNCTION.
        static void Main(string[] args)
        {
            //var LastKey = 1;

            //OUTPUT CONSOLE.WRITELINE("");
            Console.WriteLine("WELCOME TO SAMAZON!");
            Console.WriteLine("INPUT [C] TO CREATE INVENTORY ITEM.");
            Console.WriteLine("INPUT [R] TO READ INVENTORY ITEMS.");
            Console.WriteLine("INPUT [U] TO UPDATE INVENTORY ITEM.");
            Console.WriteLine("INPUT [D] TO DELETE INVENTORY ITEM.");
            Console.WriteLine("INPUT [T] TO TERMINATE PROGRAM.");

            //List<Product?> list = new List<Product?>();
            //SHALLOW COPY SMART POINTER
            List<Product?> list = ProductServiceProxy.Current.Products;
            
            char choice;
            do
            {
                //INPUT CONSOLE.READLINE();
                string? input = Console.ReadLine();
                choice = input[0];
                switch(choice)
                {
                    case 'C':
                    case 'c':
                        //CONSOLIDATION
                        Console.WriteLine("CREATE INVENTORY ITEM: ");
                        ProductServiceProxy.Current.AddOrUpdate(new Product
                        {
                            Name = Console.ReadLine()
                        });
                        Console.WriteLine("INVENTORY ITEM CREATED.");
                        break;
                        /*
                        list.Add(new Product{
                            //PREFIX V POSTFIX. BE CAUTIOUS.
                            ID = LastKey++,
                            Name = Console.ReadLine()
                        */

                    case 'R':
                    case 'r':
                        Console.WriteLine("INVENTORY ITEMS: ");
                        list.ForEach(Console.WriteLine);
                        break;
                        /*
                        foreach (var prod in list)
                        {
                            Console.WriteLine(prod?.Display ?? "No Product Found");
                        }
                        */

                    case 'U':
                    case 'u':
                        Console.WriteLine("UPDATE INVENTORY ITEM: ");
                        int selection = int.Parse(Console.ReadLine() ?? "-1");
                        var selectedProd = list.FirstOrDefault(p => p.ID == selection);

                        if(selectedProd != null)
                        {
                            selectedProd.Name = Console.ReadLine() ?? "ERROR";
                            ProductServiceProxy.Current.AddOrUpdate(selectedProd);
                        }
                        Console.WriteLine("INVENTORY ITEM UPDATED.");
                        break;
                        /*
                        if(selectedProd != null)
                        {
                            selectedProd.Name = Console.ReadLine() ?? "ERROR";
                        }
                        */

                    case 'D':
                    case 'd':
                        Console.WriteLine("DELETE INVENTORY ITEM: ");
                        selection = int.Parse(Console.ReadLine() ?? "-1");
                        ProductServiceProxy.Current.Delete(selection);
                        Console.WriteLine("INVENTORY ITEM DELETED.");
                        break;
                        /*
                        selectedProd = list.FirstOrDefault(p => p.ID == selection);
                        if(selectedProd != null)
                        {
                            list.Remove(selectedProd);
                        }
                        */

                    case 'T':
                    case 't':
                        Console.WriteLine("PROGRAM TERMINATED.");
                        break;
                    default:
                        Console.WriteLine("INVALID INPUT.");
                        break;
                }
                
            }while(choice != 'T' && choice != 't');
            Console.ReadLine();
        }
    }
}


/* NOTES

LECTURE I
PROGRAMMING LANGUAGE C# AND .NET.
C++ ONE PASS LANGUAGE. WHEN COMPILER READS SOURCE CODE, IT ONLY SEES EVERY LINE ONCE.
C# TWO PASS LANGUAGE. YOU DON'T HAVE TO DECLARE, YOU JUST DEFINE.

SET UP .NET SDK
ADD C# EXTENSION TO VS CODE.
dotnet new console
dotnet build Samazon.csproj
dotnet run --project Samazon.csproj

LECTURE II
OBJECT ORIENTED PROGRAMMING.
USING LOGIC AND FUNCTIONS TO PERFORM OPERATIONS ON DATA.
FUNCTION FUNCTIONS.
METHOD IN AN OBJECT ORIENTED SETTING. MEMBER FUNCTIONS.

L VALUE STRING INPUT = R VALUE CONSOLE.READLINE();
CAUTIOUS OF NULL REFERENCE EXCEPTION. 
MAKE TYPES COMPATIBLE WITH ?. STRING? INPUT = NULL; 
MAKE TYPE CHECK FOR NULL WITH ??. IF LEFT IS NULL RETURN RIGHT. 

TRADITIONAL GETTERS AND SETTERS
private type var; public type get(){return var;} public void set(type var){(var = var;)} 
PROPERTY GETTERS AND SETTERS
public type var { get; set; }

LECTURE III
LIBRARIES DO NOT HAVE A MAIN FUNCTION. INTENDED TO USE IN AN APP WITH MAIN FUNCTION.
APP HAS A MAIN FUNCTION.
HORIZONTAL SCALABILITY. TERMINAL FUNCTIONS TO GUI FUNCTION.
WE DO NOT WANT TO RE ENGINEER. WE WANT TO USE WHAT WORKS.

LECTURE IV
SINGLETON, CONSOLIDATED AND PRESENTED AS IS IN MEMORY TO EVERYONE.
LOCK AND SEMAPHORE.
FIRST THREAD GOES THROUGH LOCK SETS NEW OBJ TO MEM ADDR. POINTER.
SECOND THREAD WILL STOP AT LOCK UNTIL INSTANCE LOCK IS SET TO NULL POINTER.

*/