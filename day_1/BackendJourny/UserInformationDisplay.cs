public class UserInformation // im creating a container that is avalabe for other files called user_information_display that has a way (method) to display the user information
{
    //a method is an action the class can preform
    public static void Display() //by using public we let other files use this method
    //static means that we can call this method without creating an instance of the class ( you dont need to create an object to use this method)
    //void means that this method does not return any value (it just performs an action)
    {
        System.Console.WriteLine("enter your name: ");
        string? name = System.Console.ReadLine();
        System.Console.WriteLine("My name is " + name +" and I am learning C# to become backend engineer");
        int currenthour = DateTime.Now.Hour; // gets current hour (0-23)

        if (currenthour < 12)
        {
            Console.WriteLine("It's morning! " + currenthour);
        }
        else if (currenthour < 18)
        {
            Console.WriteLine("It's afternoon! " + currenthour);
        }
        else if (currenthour < 22)
        {
            Console.WriteLine("It's evening! " + currenthour);
        }
        else
        {
            Console.WriteLine("It's night! " + currenthour);
        }
    
    }

}