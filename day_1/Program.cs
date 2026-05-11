// See https://aka.ms/new-console-template for more information
 // we can call the display method without creating an instance of the class because it is static
Console.WriteLine("Hello, World!");
UserInformation.Display();

/*
Exercise1: Finding the largest of three numbers
start
input number1, number2, number3
largest number = number1
if largest number < number2
largest number = number2
if largest number < number3
largest number = number3

print largest number
end
*/

Console.Write("Choose number1: ");
String? number1 = Console.ReadLine(); 
int num1 = Convert.ToInt32(number1);
Console.Write("Choose number2: ");
String? number2 = Console.ReadLine();
int num2 = Convert.ToInt32(number2);
Console.Write("Choose number3: ");
String? number3 = Console.ReadLine();
int num3 = Convert.ToInt32(number3);
int largest = num1;
if (largest < num2)
{    largest = num2;
}
if (largest < num3)
{    largest = num3;
}
Console.WriteLine("The largest number is: " + largest);

/*
reflection

there are three types of converting string to int
1. Convert.ToInt32(string) : if the string is null, it returns 0. If the string is not a valid number, it throws a FormatException.
2. int.Parse(string) : if the string is null or not a valid number, it throws an exception.
3. int.TryParse(string, out int result) : if the string is null or not a valid number, it returns false and sets result to 0. Otherwise, it returns true and sets result to the parsed integer.

feedback tip from chatGPT:
1. Consider using int.TryParse instead of Convert.ToInt32 to handle invalid input more gracefully and not just crash the program.
*/

/*
Exercise2: is the number even or odd
start
Take largest number as input
if largest number % 2 == 0
print "The number is even"
else
print "The number is odd"
end
*/

if (largest % 2 == 0)
{
    Console.WriteLine("The number is even");
}
else
{
    Console.WriteLine("The number is odd");
}