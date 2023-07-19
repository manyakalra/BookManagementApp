using Concept.Data;
using Concept.Furnitures;

public class Program 
{ 
	static void Main()
	{
		System.Console.WriteLine("Program V3");
		Chair c=new Chair();
		System.Console.WriteLine(c);

		List l=new List();
		System.Console.WriteLine(l);

		Bed b=new Bed();
		System.Console.WriteLine(b);

		//Get Furniture Table
		Concept.Furnitures.Table t=new Concept.Furnitures.Table(5000); 
		System.Console.WriteLine("{0} has price {1}", t, t.price);

		//Get Data Table
		Concept.Data.Table t0=new Concept.Data.Table(); 
		System.Console.WriteLine("{0} has {1} rows and {2} columns",t0,t0.rows,t0.columns);	

	}
} 
