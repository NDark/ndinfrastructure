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
#define ENABLE_STOP_AT_THE_END_PROGRAM

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVToJSON
{

    class Program
    {

        static List<List<string>> m_Sheet = null;

        static string m_InputTextPath = "../DOC/Input.txt";
        static string m_OutputTextPath = "../DOC/Output.txt";


        static void Main(string[] args)
        {
            SimpleJSON.JSONArray arrayNode = SimpleJSON.JSON.Parse("[]") as SimpleJSON.JSONArray;

            if (true == LoadSheet(m_InputTextPath))
            {
                ParseSheetToStructure(m_Sheet, ref arrayNode);

                System.IO.StreamWriter SW = new System.IO.StreamWriter(m_OutputTextPath);
                SW.Write(arrayNode.ToString());
                SW.Close();

            }


#if ENABLE_STOP_AT_THE_END_PROGRAM
            Console.WriteLine("Programe terminate, press enter to leave");
            Console.Read();
#endif
            // ENABLE_STOP_AT_THE_END_PROGRAM

        }

        static bool LoadSheet(string _InputPath)
        {
            bool ret = true;

            System.IO.StreamReader SR = new System.IO.StreamReader(_InputPath);
            if (null != SR )
            {
                m_Sheet = new List<List<string>>() ;

                string content = SR.ReadToEnd();
                string[] lineSplitor = { "\r\n", "\n" };
                string[] cellSplitor = { "\t" };
                var strVec = content.Split(lineSplitor,StringSplitOptions.None);
                foreach (var line in strVec)
                {
                    var cells = line.Split(cellSplitor, StringSplitOptions.None);
                    if (cells.Length> 0)
                    {
                        List<string> row = new List<string>() ;
                        foreach (var str in cells)
                        {
                            row.Add(str);
                        }
                        m_Sheet.Add(row);
                    }
                }

                Console.WriteLine("m_Sheet.Count=" + m_Sheet.Count );
                SR.Close();
            }
            
            return ret ;
        }

        static void ParseSheetToStructure(List<List<string>> _Sheet
            , ref SimpleJSON.JSONArray _ArrayNode)
        {
            List<string> labels = new List<string>();
            for (int i = 0; i < _Sheet.Count; ++i)
            {
                var firstRow = _Sheet[i];
                for (int j = 0; j < firstRow.Count; ++j)
                {
                    labels.Add(firstRow[j] as string);
                }

                break;
            }
            if (labels.Count <= 0)
            {
                return;
            }

            for (int rowIndex = 1; rowIndex < _Sheet.Count; ++rowIndex)
            {
                var row = _Sheet[rowIndex];
                bool isEmpty = true;

                SimpleJSON.JSONNode contentNode = SimpleJSON.JSON.Parse("{}");
                for (int columnIndex = 0; columnIndex < row.Count && columnIndex < labels.Count; ++columnIndex)
                {
                    var content = row[columnIndex] as string;
                    if (!content.Equals(string.Empty))
                    {
                        isEmpty = false;
                        contentNode.Add(labels[columnIndex], content);
                    }

                }


                if (!isEmpty)
                {
                    SimpleJSON.JSONNode tagNode = SimpleJSON.JSON.Parse("{}");
                    _ArrayNode.Add(contentNode);
                }

            }
        }
    }
}
