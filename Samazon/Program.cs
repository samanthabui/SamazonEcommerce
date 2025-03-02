//SAMANTHA BUI
//SAMAZON ECOMMERCE APP I

//USING
using System;

using Samazon.Models;
using Library.eCommerce.Services;

//NAMESPACE DIFFERENT NAME TO PREVENT INTERFERENCE 
namespace MyApp
{
    //INTERNAL CLASS PROGRAM
    internal class Program
    {
        //STATIC VOID MAIN(STRING[] ARGS){}
        static void Main(string[] args)
        {
            //SHALLOW COPY SMART POINTER
            List<Product?> list = ProductServiceProxy.Current.Products;
            
            //OUTPUT CONSOLE.WRITELINE("");
            Console.WriteLine("WELCOME TO SAMAZON!" + Environment.NewLine);
            //CRUD SELECTION USING CASE SWITCH OR IF ELSE CONDITIONS
            char choice;

            //DO WHILE SELECTION LOOP
            do
            {
                Console.WriteLine("INPUT [C] TO CREATE INVENTORY ITEM.");
                Console.WriteLine("INPUT [R] TO READ INVENTORY ITEMS.");
                Console.WriteLine("INPUT [U] TO UPDATE INVENTORY ITEM.");
                Console.WriteLine("INPUT [D] TO DELETE INVENTORY ITEM.");
                Console.WriteLine("INPUT [T] TO TERMINATE PROGRAM." + Environment.NewLine);

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
                        Console.WriteLine("INVENTORY ITEM CREATED." + Environment.NewLine);
                        break;
                    case 'R':
                    case 'r':
                        Console.WriteLine("READING INVENTORY ITEMS: ");
                        list.ForEach(Console.WriteLine);
                        Console.WriteLine("INVENTORY ITEMS READ." + Environment.NewLine);
                        break;
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
                        Console.WriteLine("INVENTORY ITEM UPDATED." + Environment.NewLine);
                        break;
                    case 'D':
                    case 'd':
                        Console.WriteLine("DELETE INVENTORY ITEM: ");
                        selection = int.Parse(Console.ReadLine() ?? "-1");
                        ProductServiceProxy.Current.Delete(selection);
                        Console.WriteLine("INVENTORY ITEM DELETED.");
                        break;
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

/* NOTES II

LECTURES I
MVVM MODEL - VIEW - VIEWMODEL
MODELS STORE STATE, OFTEN DATABASE. 
VIEWS PROVIDE ACCES TO STATE AND BEHAVIOR THROUGH UI.
VIEWODELS WHICH SIT BETWEEN TWO AND PROVIDE BINDING AND BEHAVIOR.

RESTRICT AS MUCH BEHAVIOR AS POSSIBLE IN MODELS. RESTRICT AS MUCH DATA AS POSSIBLE IN VIEWS. 
DO NOT TIGHTLY COUPLE UI TO DATA, SUCH AS IN JAVA GUI SWING.
YOU WANT THE PIECES TO BE ABLE TO WORK AS A STAND ALONE.
MAXIMIZE THE CODE'S ABILITY TO BE REUSED.

SCALABLE, SIMPLE, PERFORMANT IN RATIO. CHOOSE DESIGN PATTERN TO SERVE YOUR NEED.
SCALABLE, EASE OF ADDING FUNCTIONALITY AND USERS.
SIMPLE, PRIORITIZE DEVELOPER SIMPLICITY AND USER SIMPLICITY. 
PERFORMANT, MINIMIZE KAG TUNE BETWEEN USER AND SYSTEM.

LECTURES II
.XAML SCRIPT UI.
.XAML.CS SCRIPT LOGIC
DESIGNER ABLE TO WORK ON .XAML WITHOUT INTEFERING WITH LOGIC.
DEVELOPER ABLE TO WORK ON .XAML.CS WITHOUT INTERFERING WITH UI.
*/

/* NOTES I

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
