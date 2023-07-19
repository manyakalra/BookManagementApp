using Furnitures; //if namespace is not specified search here also
using Data; //if namespace is not specified search here also

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
		Furnitures.Table t=new Furnitures.Table(5000); 
		System.Console.WriteLine("{0} has price {1}", t, t.price);

		//Get Data Table
		Data.Table t2=new Data.Table();
		System.Console.WriteLine("{0} has {1} rows and {2} columns",t2,t2.rows,t2.columns);	

	}
} 
