// See https://aka.ms/new-console-template for more information
class TestClass
{
    static void  Main(string[] args)
    {
    Console.WriteLine("Enter your number:");
    int factorial=1;
    int a = Convert.ToInt32(Console.ReadLine());

    for (int i=1;i<=a;i++){
        factorial*=i;

    }
    Console.WriteLine(factorial);
    }
}