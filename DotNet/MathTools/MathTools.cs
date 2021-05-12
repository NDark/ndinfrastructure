/**

MIT License

Copyright (c) 2017 - 2021 NDark

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/
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
