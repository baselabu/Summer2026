using day_3;
using day_3.HigherOrLowerGame;


MathtMethods testsub = new MathtMethods();
int result = testsub.AddSum(1, 2, 3, 4, 5);
int result2 = testsub.AddSum(1,3,4);
Console.WriteLine(result +" and " + result2);


MathtMethods testeven = new MathtMethods();
System.Console.WriteLine(testeven.EvenChek(5024));

GreetingByName.SayHello("Basel and radwan");

System.Console.WriteLine(FizzBuzzSolver.Solve(6));

PlayHigherOrLower.PlayGame();