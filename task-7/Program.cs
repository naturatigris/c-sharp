using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace calculating{
    public class program{
            public static async Task Main(string[] args){
            Task<int> task1= Add1(2);
            Task<int> task2= Add2(await(task1));
            Task<int> task3=Add1(3);
            Task<int> task4=Add3(await(task3));
            try{
            int[] tasks=await Task.WhenAll(task1,task2,task3,task4);
            Console.WriteLine($"the aggregated result is:{tasks.Sum()}");
            }
            catch(Exception e){
                Console.WriteLine(e.Message);}


            }

    


    public static async Task<int> Add1(int a){
        Console.WriteLine("Performing task Add1");
        await Task.Delay(1000);
        Console.WriteLine("Delegating task Add1");

        return a+10;


    }
    public static async Task<int> Add2(int b){
        Console.WriteLine("Performing task Add2");

        await Task.Delay(1000);
        int c=b+20;
        Console.WriteLine("Delegating task Add2");

        await Task.Delay(2000);
        return c;


    }
    public static async Task<int> Add3(int b){
        Console.WriteLine("Performing task Add3");

        int c=b+30;
        await Task.Delay(2000);
        Console.WriteLine("Delegating task Add3");

        return c;


    }
    }

}