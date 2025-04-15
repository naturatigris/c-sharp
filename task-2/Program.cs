public class Person
{
   string name;
   int age; 
}
class TestClass
{
    static void  Main(string[] args)
    {
        Person obj1=new Person();
        Person obj2=new Person();
        obj1.name='Sandhya';
        obj1.age=23;
        obj2.name='roshni';
        obj2.age=21;
        Console.WriteLine("Hello"+obj1.name);
    }
}