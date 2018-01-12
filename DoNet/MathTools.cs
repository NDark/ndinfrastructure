
public partial class MathTools 
{
	/**
	 * http://floating-point-gui.de/errors/comparison/
	*/
	public static bool RelativeEqual(float a, float b, float _RatioUnderSum ) 
	{
		float absA = System.Math.Abs(a);
		float absB = System.Math.Abs(b);
		float diff = System.Math.Abs(a - b);

		if (a == b) 
		{ 
			// shortcut, handles infinities
			return true;
		} 
		else if (a == 0 || b == 0 || diff < float.Epsilon) 
		{
			// a or b is zero or both are extremely close to it
			// relative error is less meaningful here
			return diff < (_RatioUnderSum * float.Epsilon);
		} 
		else 
		{ 
			// use relative error
			return diff / System.Math.Min( (absA + absB) , float.MaxValue ) < _RatioUnderSum;
		}
	}

	public static bool FloatDigitEqual(float a, float b, float _MinDifference = 0.001f ) 
	{
		int aInt = (int) System.Math.Floor( a ) ;
		int bInt = (int) System.Math.Floor( b ) ;
		if( aInt != bInt )
		{
			return false ;
		}
		else 
		{
			float aFloat = a - (float)aInt ;
			float bFloat = b - (float)bInt ;

			return System.Math.Abs( aFloat - bFloat ) < _MinDifference ;
		}
	}
}
