using ConceptArchitect.Data;
using ConceptArchitect.Furnitures;
using System;
using Table = ConceptArchitect.Data.Table;

namespace ConceptArchitect.FurnitureMain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Furniture App");
            Input input=new Input();
            Console.WriteLine(input);

            Chair chair = new Chair();
            Console.WriteLine(chair);

            Table table = new Table();
            Console.WriteLine(table);

            List list =new List();
            Console.WriteLine(list);


        }
    }
}
