class Input
{

	public int ReadInt(string prompt)
	{
		System.Console.Write(prompt);
		string value=System.Console.ReadLine();
		return int.Parse(value);	
	}
}