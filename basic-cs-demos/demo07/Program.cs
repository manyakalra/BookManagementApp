public class Program 
{ 
	static void Main()
	{
		Chair c=new Chair();
		System.Console.WriteLine(c);

		List l=new List();
		System.Console.WriteLine(l);

		Bed b=new Bed();
		System.Console.WriteLine(b);

		//What is in the LHS?
		Table t=new Table(5000); //RHS looks like furntiures.Table

	}
} 
