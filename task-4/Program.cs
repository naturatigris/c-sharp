using System;
using System.Collections.Generic;
using System.Security.Cryptography;
public class student{
    public string Name;
    public int Age;
    public int Grade{get; set;}
    public override string ToString() {
        return $"Name: {Name}, Age: {Age}, Grade: {Grade}";
    }

 }
 public class namelist{
    public List<student> list=new List<student>();

 public void addstudent(string name,int grade,int age){
    student obj=new student();
    obj.Name=name;
    obj.Age=age;
    obj.Grade=grade;
    list.Add(obj);


}
public void display(int grade){
    IEnumerable<student> query1 = from stu in list where stu.Grade>grade select stu;
        IEnumerable<student> query2 = from stu in query1 orderby stu.Grade descending select stu;



foreach (student stu in query2)
{
    Console.WriteLine(stu);
}
}

}
public class test{

    static void Main(string[] args){
            namelist obj=new namelist();

                while(true){
;
        Console.WriteLine("Choose Operation: 1.add 2.exit 3.display ");
        string op=Console.ReadLine().Trim();
        if (op=="add"){
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter grade: ");
                int grade = Convert.ToInt32(Console.ReadLine());

                obj.addstudent(name, grade, age);
                Console.WriteLine("Student added successfully.");
        
        } else if (op == "display") {
            Console.WriteLine("Enter grade threshold");
                int grade = Convert.ToInt32(Console.ReadLine());
                obj.display(grade);
            }else if(op=="exit"){
            break;

            }
            else{
            Console.WriteLine("ennter valid operation");
        }
}


    }
}