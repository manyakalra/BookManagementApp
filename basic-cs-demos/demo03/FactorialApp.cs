class Program
{
	static void Main()
	{
		int  n = 5;
		Factorial f=new Factorial();
		int fn = f.Calculate(n);

		System.Console.WriteLine("Factorial of "+n+" is "+fn);	
	}
}

class Factorial
{

	public int Calculate(int x)
	{
		int fx=1;
		while(x>1)
			fx*=x--;

		return fx;
	}
}