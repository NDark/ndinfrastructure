/**

MIT License

Copyright (c) 2017 - 2018 NDark

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
/**
@file SpreadSheetLoader.cs
@author NDark

@date 20170424 by NDark 

*/
using System.Collections;
using System.Collections.Generic;

public static partial class SpreadSheetLoader 
{

	public static bool ParseSpreadSheet( string _Content 
	                                    , ref List< string [] > _Result 
	                                    , bool _WithFirstLow
	                                    , ref string [] _FirstRow
	                                    )
	{
		string content = _Content.Replace ("\r\n", "\n");

		string [] eolSplitor = { "\n" };
		string [] tabSplitor = { "\t" };
		
		string [] strLines = content.Split (eolSplitor 
			, System.StringSplitOptions.RemoveEmptyEntries ); 
			
		for (int i = 0; i < strLines.Length; ++i) 
		{
			string [] columns = strLines[ i ] .Split( tabSplitor 
				, System.StringSplitOptions.None ) ;
			
			if( true == _WithFirstLow && i == 0 )
			{
				_FirstRow = columns ;
			}
			else
			{
				_Result.Add( columns ) ;
			}
		}
		
		return ( _Result.Count > 0 ) ;
	}
	
}
