using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
namespace crud{
    interface IRepository<T>{
        void Add(T a);
        T Get();
        void Update(T a);
        void Delete(T a);


    }
    public class product{
        public string Name{get; set;}
        public int Price{get; set;}
        public int Quantity{get; set;}
        public override string ToString()
        {
            return $"Nmae:{Name},Price:{Price},Quantity:{Quantity}";
        }


    }

    public class Program: IRepository<product>{
        private List<product> data = new List<product>();

        public void Add(product a){

        data.Add(a);
        }
        public product Get(){
            return data[0];

        }
        public void Update(product a){

        int myIndex = data.FindIndex(p => p.Name == a.Name);
        data[myIndex].Quantity+=1;
        }
        public void Delete(product a){
            data.Remove(a);
        }
        public void display(){
            foreach(product pro in  data){
                Console.WriteLine(pro);
            }
        }



    }
    public class MainProgram{
        static void Main(string[] args){
            Program obj=new Program();
            product bag=new product(){Name="bag",Price=20,Quantity=2};
            product pencil=new product(){Name="pencil",Price=2,Quantity=2};
            product paper=new product(){Name="paper",Price=1,Quantity=5};
            product eraser=new product(){Name="eraser",Price=4,Quantity=1};
            Console.WriteLine("after Add.......");
            obj.Add(bag);
            obj.Add(pencil);
            obj.Add(eraser);
            obj.Add(paper);
            obj.display();
            Console.WriteLine("after Update.......");

            obj.Update(bag);
            obj.display();
            Console.WriteLine("after Delete.......");

            obj.Delete(paper);
            obj.display();
            Console.WriteLine("after Get.......");

            product result=obj.Get();
            Console.WriteLine(result);




            
        }
    }
 }