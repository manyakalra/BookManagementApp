public class Program 
{ 
	static void Main()
	{
		Furnitures.Chair c=new Furnitures.Chair();
		System.Console.WriteLine(c);

		Data.List l=new Data.List();
		System.Console.WriteLine(l);

		Furnitures.Bed b=new Furnitures.Bed();
		System.Console.WriteLine(b);

		//Get Furniture Table
		Furnitures.Table t=new Furnitures.Table(5000); 
		System.Console.WriteLine("{0} has price {1}", t, t.price);

		//Get Data Table
		Data.Table t2=new Data.Table();
		System.Console.WriteLine("{0} has {1} rows and {2} columns",t2,t2.rows,t2.columns);	

	}
} 
