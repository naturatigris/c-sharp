using System; 
using System.Reflection; 
using System.Collections.Generic; 

[System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct|System.AttributeTargets.Method)
]
public class Runnable : System.Attribute{
public string Name{get;set;}
public string description{get;set;}
public Runnable(string name,string description){
    this.Name=name;
    this.description=description;

}
}
public class test{
[Runnable("operation1","to calculate the sum")]
public  int  Operation1(int a){
    Console.WriteLine("performing Operation 1");
    return a+10;
    

}
[Runnable("operation2","to calculate the product")]
public  int  Operation2(int a){
    Console.WriteLine("performing Operation 2");
    return a*10;
    

}
public  int  Operation3(int a){
    Console.WriteLine("performing Operation 3");
    return a-10;
    

}
}
class Mainprogram{
    static void  Main(string[] args){
        PrintAttributInfo(typeof(test));


    }
    private static void PrintAttributInfo(Type classType){
        MethodInfo[] methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            object classInstance = Activator.CreateInstance(classType);

        for (int t = 0; t < methods.GetLength(0); t++) { 


        System.Console.WriteLine($"Attrbiut information for {t+1}");


        System.Attribute[] attrs = System.Attribute.GetCustomAttributes(methods[t]);
        foreach (System.Attribute attr in attrs)
        {
            if (attr is Runnable a)
            {
                Console.WriteLine($"Name:{a.Name}, Description: {a.description}");
                object result = methods[t].Invoke(classInstance, new object[] { 5 });
                Console.WriteLine($"  Result: {result}");

            }
        }
        }
    }
}