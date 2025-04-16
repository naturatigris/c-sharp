using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {

try
{
    using StreamReader reader = new("read.txt");

    string str = reader.ReadToEnd();

        int l = 0; 
        int wrd = 1; 
        while (l <= str.Length - 1)
        {
            if (str[l] == ' ' || str[l] == '\n' || str[l] == '\t')
            {
                wrd++; 
            }

            l++;        }
            using (StreamWriter writer = new("result.txt")){
            writer.WriteLine(wrd);}


        Console.Write("Total number of words in the string is: {0}\n", new StreamReader("result.txt").ReadToEnd());
}
catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
    }
}
}