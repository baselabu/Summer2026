/*
Exercies 1:

program to ask for user age if under 18 its a minor if over 18 its an adult

START 
INPUT userAge
IF userAge is < 18 THEN
    PRINT "Minor"
END IF
ELSE
    PRINT "Adult"
END ELSE
END
*/

int userAge;
Console.Write("Enter your age: ");
bool success = int.TryParse(Console.ReadLine(), out userAge);
if (success)
{
    System.Console.WriteLine(success);
}
else{
    System.Console.WriteLine(success);
}

if(userAge < 18)
{
    System.Console.WriteLine("Minor");
}
else
{
    System.Console.WriteLine("Adult");
}


/*
Exercies 2:

the program will take two number and apply different math calculations 

START
INPUT NUMBER1, NUMBER2, operator
IF operator EQUAL + THEN
    PRINT number1 + number 2
END IF
ELSE IF operator  EQUAL - THEN
    PRINT number1 - number2
END ELSE IF
ELSE IF operator EQUAL / THEN
    PRINT number1 / number 2
END ELSE IF
ELSE IF operator EQUAL * THEN
    PRINT number1 * number2
END ELSE IF
END

*/

double num1, num2;
string? MathOperator;

System.Console.WriteLine("enter a number: ");
double.TryParse(Console.ReadLine(), out num1);
System.Console.WriteLine("enter a second number: ");
double.TryParse(Console.ReadLine(), out num2);
System.Console.WriteLine("choose your operation (+,-,/,*)");
MathOperator = Console.ReadLine();
if(MathOperator == "+")
{
    System.Console.WriteLine(num1 + num2);
}else if(MathOperator == "-")
{
    System.Console.WriteLine(num1 - num2);
}else if(MathOperator == "/")
{
    System.Console.WriteLine(num1 / num2);
}
else if(MathOperator == "*")
{
    System.Console.WriteLine(num1 * num2);
}

