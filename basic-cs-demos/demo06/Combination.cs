public class Combination
{
	public int Calculate(int n, int r)
	{
		Permutation p=new Permutation();
		return p.Calculate(n,r)/Factorial.Calculate(r);
	}
}