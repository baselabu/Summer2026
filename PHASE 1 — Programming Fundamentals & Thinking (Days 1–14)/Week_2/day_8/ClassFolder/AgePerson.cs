using System;

namespace day_8.ClassFolder;

public class AgePerson
{
    public AgePerson(int PersonAge)
    {
        Age = PersonAge;
    }
    private int age;
    public int Age
    {
        get {return age;} // reading the value 
        set // assigning the value to age
        {
            if(value >= 0) // if the incomming value is greater or equal 0
            {
                age = value; // the value gets stored inside private field age;
            }
        }
    }    

}
