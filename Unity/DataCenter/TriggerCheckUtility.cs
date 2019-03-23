/**

MIT License

Copyright (c) 2017 - 2019 NDark

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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TriggerCheckUtility
{
	const string CONST_OPERATOR_EQUAL = "==" ;

	public static bool IsTriggered( DataPage _Center , TriggerChecker _Checker )
	{
		bool ret = false;
		string valueInCenter = _Center.Get( _Checker.Label ) ;
		string valueStandard = _Checker.Value;
		if( string.Empty != valueInCenter )
		{
			ret = IsTriggered( valueInCenter , _Checker.Value , _Checker.Operator ) ;
		}
		return ret;
	}

	public static bool IsTriggered( string _Value , string _Standard , string _Operator )
	{
		bool ret = false;

		switch( _Operator )
		{
		case CONST_OPERATOR_EQUAL :
			ret = (_Value == _Standard) ;
			break ;
		}

		return ret;
	}
}
