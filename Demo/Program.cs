using Demo.Classes;
using Demo.Data;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Xml.Linq;
using static Demo.Classes.ListGenerators;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Implicitly Typed Local Variable [Var , Dynamic]

            #region var
            //string data = "Ahmed";
            var Data = "Ahmed"; //Implicit Type
                                //Compiler will Detect the datatype of variable at compilation time
                                //Based on its intial value

            //var number = null; //Invalid
            // var can't be Intialized to Null

            Data = null; //Valid

            Data = 5;
            //After Intializtion , You can't Change Variable datatype


            var x; // var must be Intialized

            Data = "Mohamed"; //Valid
            #endregion

            #region Dynamic

            //dynamic Data = "Ahmed";
            ////CLR will detect the datatype of the variable
            ////Based on its last assigned Value

            ////dynamic y = null; //Valid
            ////You can declare a variable without Intializtion

            //Data = null; //Valid
            //// it can be intialized By Null
            //dynamic X;

            //Data = 5;
            //After Intializtion , You can't Change Variable datatype

            //Data = "ahmed";
            //Data = true;
            //Data = 3.3;
            //Data = 'A';
            //Data= new[] {1,2,3,4,5,};

            #endregion
            //You Cant't use var in parameter or return type or Attributes in class
            //You can only use it to declare local variable
            for (int i = 0; i < 10; i++) { }
            foreach (var x in Data)
                Console.WriteLine(x);

            //var is recommended
            //Errors=>Compilation time

            var x = null; //Compilation Error

            dynamic y = null;
            Console.WriteLine(y); //RunTimeBinderException


            #endregion


            #region Extenstion Method
            int x = 12345;
            int y = x.Reverse();
            Console.WriteLine(y); //54321 
            #endregion

            #region Anonymous Type

            Employee employee = new Employee() { Id = 10, Name = "Ahmed", Salary = 1000 };

            object emp1 = new { Id = 20, salary = 20 };
            Console.WriteLine(emp1.salary); //Invalid

            int X = 5;
            Console.WriteLine(X.GetType().Name); //Int32

            var emp2 = new { Id = 10, Name = "Omar", Salary = 2000 };
            //Object will be created from anonymous type is immutable[Can't be changed] =>String

            Console.WriteLine(emp2.GetType().Name); //AnonymousType0`3
            Console.WriteLine(emp3.Id);

            Console.WriteLine(emp2.Salary); //2000

            emp2.Salary = 1000; //Invalid

            var emp3 = new { Id = emp2.Id, Name = emp2.Name, Salary = 3000 }; //till c# 9
            Console.WriteLine(emp3);


            var emp4 = emp3 with { Salary = 4000 }; C# 10 Feature .Net 6

            Console.WriteLine(emp2.GetType().Name); ////AnonymousType0`3
            Console.WriteLine(emp3.GetType().Name); ////AnonymousType0`3
            Console.WriteLine(emp4.GetType().Name); ////AnonymousType0`3


            //The Same anonymous Type as long as:
            //1 - Same properties Name[Case Sensetive]
            //2 - Same preoprties order


            var emp5 = new { id = 50, Name = "Ahmed", Salary = 3000 };

            Console.WriteLine(emp5.GetType().Name); ////AnonymousType1`3

            var emp6 = new { Id = 20, Name = "Ahmed" };
            //Console.WriteLine(emp5.GetType().Name); //AnonymousType2`2

            #endregion

            #region What is LINQ
            //Stand For =>Language Integrated Query
            //LINQ method +40 Method
            //Categoriezed Into  13 Categories

            List<int> Number = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<int> OddNumbers = Number.Where(x => x % 2 == 1).ToList();
            foreach (var i in OddNumbers)
            {
                Console.Write($"{i} ");

                //Sequence
                //the object from class that implement interface "IEnumerable"
                //1.Local{static-xml} => {l2Object-L2Xml}
                //2.Remote :L2EF
                #endregion

                #region LINQ Syntax [Fluent - Query] Syntax

                #region Fluent Syntax
                //fluent
                //1.1 Call "LINQ Operators" as Static Method
                //var num1 = Enumerable.Where(Number, num=>num%2==0);

                foreach (var i in num1)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
                //1.2 Call "LINQ Operators" As Extension Method[Recommended]
                var num = Number.Where(Num => Num % 2 == 0);
                #endregion

                #region Query Syntax - Like Sql server style
                foreach (var i in num)
                {
                    Console.Write($"{i} ");
                }
                //query syntax
                //select*
                //from Number N
                //where N% 2 == 0

                var EvenNumber = from N in Number
                                 where N % 2 == 0
                                 select N;
                foreach (var i in EvenNumber)
                {
                    Console.Write($"{i} ");
                }
                //must start with from
                //must end with group by or select
                #endregion

                #endregion

                #region LINQ  Execution Ways

                #region Deferred Execution[Latest Version of data]

                var num = Number.Where(x => x % 2 == 0);
                Number.AddRange([11, 12, 13, 14]);
                foreach (var i in num)
                {
                    Console.Write($"{i} ");
                }
                #endregion

                #region Immediate Execution [Elements Operators, Casting Operators, Aggregate Operators]

                var num = Number.Where(x => x % 2 == 0).ToList();
                Number.AddRange([11, 12, 13, 14]);
                foreach (var i in num)
                {
                    Console.Write($"{i} ");
                }
                #endregion
                #endregion

                #region LINQ Categories

                #region Filtration [Restrication] Operators - Where 


                #region Get Elements Out Of Stock

                //Fluent Syntax

                var result = productsList.Where(P => P.UnitsInStock == 0);

                //Query Syntax

                result = from P in productsList
                         where P.UnitsInStock == 0
                         select P;


                foreach (var i in result)
                {
                    Console.WriteLine(i);
                }
                #endregion

                #region Get Elements In Stock And In Category Of Meat/Poultry 
                //Fluent Syntax

                var result = productsList.Where(P => P.UnitsInStock > 0 && P.Category == "Meat/Poultry");

                //Query Syntax

                var result = from P in productsList
                             where P.UnitsInStock > 0 && P.Category == "Meat/Poultry"
                             select P;


                foreach (var i in result)
                {
                    Console.WriteLine(i);
                }
                #endregion
                #region Get Elements Out Of Stock In First 10 Elements

                var result = productsList.Where((P, I) => P.UnitsInStock == 0 && I < 10);

                foreach (var i in result)
                {
                    Console.WriteLine(i);
                }
                #endregion

                #endregion

                #region Transformation [Projection] Operators [Select , Select Many]

                #region Select Product Name

                //Fluent syntax

                var result = productsList.Select(P => P.ProductName);

                //Query Syntax

                var result = from P in productsList
                             select P.ProductName;


                foreach (var i in result)
                {
                    Console.WriteLine(i);
                }

                #endregion

                #region Select Customer Name

                //Fluent syntax

                var result = CustomersList.Select(C => C.CustomerName);

                //Query Syntax

                var result = from C in CustomersList
                             select C.CustomerName;


                foreach (var i in result)
                {
                    Console.WriteLine(i);
                }

                #endregion

                #region  Select Customer Orders

                //Fluent Synatx

                var result = CustomersList.SelectMany(C => C.Orders);

                //Query Syntax


                var result = from C in CustomersList
                             from O in C.Orders
                             select O;


                foreach (var i in result)
                {
                    Console.WriteLine(i);
                }
                #endregion

                #region Select Product Id and Product Name

                //Fluent Syntax 

                var result = productsList.Select(P => new { ProductId = P.ProductID, ProductName = P.ProductName });

                //Query Syntax

                var result = from P in productsList
                             select new { P.ProductID, P.ProductName };


                foreach (var i in result)
                {
                    Console.WriteLine(i);
                }

                #endregion
                #region Select Product In Stock And Apply Discount 10 % On Its Price

                //Fluent Syntax

                var result = productsList.Where(P => P.UnitsInStock > 0)
                                         .Select(P => new
                                         {
                                             P.ProductID,
                                             P.ProductName,
                                             P.UnitPrice,
                                             NewPrice = P.UnitPrice - (P.UnitPrice * 0.1M)

                                         });


                //Query syntax

                var result = from P in productsList
                             where P.UnitsInStock > 0
                             select new
                             {
                                 P.ProductID,
                                 P.ProductName,
                                 P.UnitPrice,
                                 NewPrice = P.UnitPrice - (P.UnitPrice * 0.1M)

                             };


                foreach (var i in result)
                {
                    Console.WriteLine(i);
                }
                #endregion
                #region Indexed Where
                var result = productsList.Where(P => P.UnitsInStock > 0)
                                         .Select((P, I) => new
                                         {
                                             Index = I,
                                             PPP = P.ProductName
                                         });

                foreach (var i in result)
                {
                    Console.WriteLine(i);
                }
                #endregion
                #endregion

                #region Ording Operators [Ascending , Descending , Reverse , ThenBy , ThenByDescending]

                #region Get Products Ordered By Price Asc
                //Fluent Syntax

                var result = productsList.OrderBy(P => P.UnitPrice);

                //Query Syntax

                var result = from P in productsList
                             orderby P.UnitPrice
                             select P;

                foreach (var i in result)
                    Console.WriteLine(item);
                #endregion

                #region Get Products Ordered By Price Desc

                //Fluent Syntax

                var result = productsList.OrderByDescending(P => P.UnitPrice);

                //Query Syntax

                var result = from P in productsList
                             orderby P.UnitPrice descending
                             select P;
                foreach (var i in result)
                    Console.WriteLine(i);

                #region Get Products Ordered By Price Asc and Number Of Items In Stock
                //Fluent Syntax

                var result = productsList.OrderBy(P => P.UnitPrice).ThenByDescending(P => P.UnitsInStock).Reverse();
                var result = productsList.Where(P => P.UnitPrice == 0).Reverse();

                foreach (var i in result)
                    Console.WriteLine(i);
                #endregion

                #endregion
                #endregion

                #region Elements Operator - Immediate Execution [Valid Only With Fluent Syntax]

                #region Fluent Syntax

                var result = productsList.First(); //Get First Element At Sequence
                var result = productsList.Last(); //Get Last Element At Sequence

                List<int> test = new List<int>();
                var result = test.First(); //InvalidOperationException: Sequence contains no elements
                var result = test.Last(); //InvalidOperationException: Sequence contains no elements

                //First And last may be Throw an Exception -> Will Exception if sequence is empty

                var result = productsList.FirstOrDefault(); //Get First Element At Sequence
                                                            //var result = productsList.LastOrDefault();  //Get Last Element At Sequence

                //FirstOrDefault and lastordeafult =>if sequence is empty =>return null

                var result = productsList.First(P => P.UnitsInStock == 0);  ////Get First Element At Sequence That Matches Condition
                var result = productsList.Last(P => P.UnitsInStock == 0);  ////Get last Element At Sequence That Matches Condition

                //First And last => if  there is no matching => throw an exception

                var result = productsList.FirstOrDefault(P => P.UnitsInStock == 0);
                var result = productsList.LastOrDefault(P => P.UnitsInStock == 0);

                //if there is not matching => Return Null

                var result = productsList.ElementAt(77);
                //ArgumentOutOfRangeException: Index was out of range. 
                var result = productsList.ElementAtOrDefault(77);

                //if index was out of range =>return null

                var result = productsList.Single(P => P.UnitsInStock == 0);
                //InvalidOperationException: Sequence contains more than one matching element
                //if Sequence contain only one element that match condition =>return it
                //else  Throw an Exception

                var result = productsList.SingleOrDefault(P => P.ProductID == 1);
                //if Sequence contain no elemnt  that match condition =>return Null
                //if Sequence contain More one element that match condition =>Throw an Exception
                //if Sequence contain only one element that match condition =>return it

                Console.WriteLine(result?.ProductName ?? "Not found");

                #endregion

                #region Hybird Syntax

                //Hybird Syntax = fluent Syntx + Query Syntax
                //Hybird Syntax = (Query Syntax).Fluent Syntax

                var result = (from P in productsList
                              where P.UnitsInStock == 0
                              select new
                              {
                                  P.ProductID,
                                  P.ProductName,
                                  P.UnitPrice,
                              }).First();
                Console.WriteLine(result);
                #endregion
                #endregion

                #region  Aggregate Operators  - Immediate Execution

                #region Count
                var result = productsList.Count; //Linq Property
                var result = productsList.Count(); //Linq operator
                Console.WriteLine(result); //77

                var result = productsList.Count(P => P.UnitsInStock == 0);
                Console.WriteLine(result); //5

                #endregion

                #region Max - Min

                var result = productsList.Max(); //ArgumentException: At least one object must implement IComparable.
                Console.WriteLine(result);

                var result = productsList.Max(P => P.UnitPrice);
                Console.WriteLine(result); //263.5000

                var result = productsList.Min(); ////ArgumentException: At least one object must implement IComparable.
                Console.WriteLine(result);

                var MinLength = productsList.Min(P => P.ProductName.Length);
                Console.WriteLine(MinLength); //4

                var result = (from P in productsList
                              where P.ProductName.Length == MinLength
                              select P).FirstOrDefault();

                Console.WriteLine(result); //ProductID:1,ProductName:Chai,CategoryBeverages,UnitPrice:18.00,UnitsInStock:100

                #endregion
                #region Sum & Average

                var result = productsList.Sum(P => P.UnitPrice);
                Console.WriteLine(result); //2222.7100

                var result = productsList.Average(P => P.UnitPrice);
                Console.WriteLine(result); //28.866363636363636363636363636
                #endregion
                #region Aggregate

                string[] Names = { "Ahmed", "Omar", "Mohamed", "Zeyad" };

                var result = Names.Aggregate((str1, str2) => $"{str1},{str2}");
                //str1 = Ahmed , str2=Omar
                //Str1 = Ahmed Omar , str2 = Mohamed
                //str1 = Ahmed Omar Mohamed , str2 = zeyad
                //Str1= Ahmed Omar Mohamed Zeyad , str2 null


                Console.WriteLine(result);
                #endregion
                #endregion
                #endregion
            }
        }
    } 
}
