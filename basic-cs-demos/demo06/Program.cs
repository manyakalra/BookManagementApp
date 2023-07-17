class Program
{
	static void Main()
	{
		int n;
		int r;
		int choice;
		Input input=new Input();
		int result;

		while(true)
		{
			choice=	input.ReadInt("1. Factorial\t2.Permutation\t3.Combination\t0.Exit\nchoose: ");

			switch(choice)
			{
				case 1:
					n=input.ReadInt("n?");
					result=Factorial.Calculate(n);
					System.Console.WriteLine("{0} ! = {1}",n,result);
					break;
				case 2:
					n=input.ReadInt("n?");
					r=input.ReadInt("r?");
					Permutation p=new Permutation();
					result=p.Calculate(n,r);
					System.Console.WriteLine("{0} P {1} = {2}",n,r,result);	
					break;
				case 3:

					n=input.ReadInt("n?");
					r=input.ReadInt("r?");
					Combination c=new Combination();
					result=c.Calculate(n,r);
					System.Console.WriteLine("{0} C {1} = {2}",n,r,result);	
					break;
				default:
					System.Console.WriteLine("Invalid Input");
					break;
				case 0:	
					System.Console.WriteLine("Thanks for using the program");
					return;

		
			}
			System.Console.WriteLine();
			
		}

	}
}