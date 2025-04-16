using System.Net.Mail;

public class counter{
    public int threshold;
    int count=0;
    public delegate  void thresholdreachedhandler(object sender,int e);
    public event thresholdreachedhandler thresholdreached;
    public counter(int a){
        this.threshold=a;

    }
    public void add(int c){
        count+=c;
        if (count>threshold){
            onthresholdreached();      
            }

    }
    public void onthresholdreached(){
        thresholdreached?.Invoke(this, count);
    }
        public void alarming(object sender,int e){
            Console.WriteLine("you hav reached the limit");
        }
    
        public void logger(object sender,int e){

        Console.WriteLine($"the count value is logged into the system:{e}");

        }
    
}
public class main{
    static void Main(string[] args){
        counter obj=new counter(5);
        obj.thresholdreached+=obj.alarming;
        obj.thresholdreached+=obj.logger;
        obj.add(1);
        obj.add(2);
        obj.add(3);
        obj.add(4);



    }
}