class Permutation
{
	public int Calculate(int n, int r)
	{
		return Factorial.Calculate(n)/Factorial.Calculate(n-r);
	}
}