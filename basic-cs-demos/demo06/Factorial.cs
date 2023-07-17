public class Factorial
{

	public static int Calculate(int x)
	{
		int fx=1;
		while(x>1)
			fx*=x--;

		return fx;
	}
}