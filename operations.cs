using System;
using System.Windows.Forms;
using System.Numerics;

public class operations
{


    public static BigInteger multiply(int multiplier, string num)
	{
        BigInteger result = Convert.ToInt32(num) * multiplier;
		return result;
	}
    
}
