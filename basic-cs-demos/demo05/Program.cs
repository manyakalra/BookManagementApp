class Program
{
	static void Main()
	{
		int n=5;
		int r=3;

		Permutation permutation=new Permutation();
		int p= permutation.Calculate(n,r);

		Combination combination=new Combination();
		int c = combination.Calculate(n,r);

		System.Console.WriteLine(n+" P "+r+" = "+p);

		System.Console.WriteLine("{0} C {1} = {2}",n,r,c);
	}
}