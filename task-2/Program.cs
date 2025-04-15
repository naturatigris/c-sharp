using System;

public class Person
{
    public string name;
    public int age; 
        public string Introduce()
    {
        return $"Hi, I'm {name} and I'm {age} years old.";
    }

}

class TestClass
{
    static void Main(string[] args)
    {
        Person obj1 = new Person();
        Person obj2 = new Person();

        obj1.name = "Sandhya";
        obj1.age = 23;

        obj2.name = "Roshni";
        obj2.age = 21;

        Console.WriteLine(obj1.Introduce());
        Console.WriteLine(obj2.Introduce());

    }
}
