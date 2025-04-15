using System;
using System.Collections.Generic;
public class lists{
    public  List<string> list=new List<string>();
    public void add(){
        string item=Console.ReadLine();
        list.Add(item);
    }
        public void remove(){
        string item=Console.ReadLine();
        list.Remove(item);
    }
    public void display(){
        for (int i=0;i<list.Count;i++){
            Console.WriteLine(list[i]);
        }
    }

}
class test{
    static void Main(string[] args){
        lists obj=new lists();
        while(true){
        Console.WriteLine("Choose Operation: 1.add 2.remove 3.display 4.stop ");
        string op=Console.ReadLine().Trim();
        if (op=="add"){
        Console.WriteLine("enter an item ");
            obj.add();

        }
        else if (op=="remove"){
            Console.WriteLine("enter an item ");
            obj.remove();

        }else if (op=="display"){
            obj.display();

        }else if (op=="stop"){
            obj.display();
            break;

        }else{
            Console.WriteLine("ennter valid operation");
        }
}
        

    }
}