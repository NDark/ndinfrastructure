using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParsersPerformance
{
    class Program
    {
        static string g_InputFilePath = "httpswww.mockaroo.com.json.txt" ;

        static void Main(string[] args)
        {
            System.IO.StreamReader SR = new System.IO.StreamReader(g_InputFilePath);
            if (null != SR)
            {

                string content = SR.ReadToEnd();
                int testCount = 2;
                for (int i = 0; i < testCount; ++i)
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    switch (i)
                    {
                        case 0: TryParseContent_SimpleJSON20121217(content); break;
                        case 1: TryParseContent_SimpleJSON20121217_StringBuilderEscape(content); break;
                    }
                    
                    watch.Stop();
                    Console.Out.WriteLine( "(" + i.ToString() + ") watch.ElapsedMilliseconds=" + watch.ElapsedMilliseconds);

                }
            }

            Console.In.Read();
        }


        static void TryParseContent_SimpleJSON20121217(string _Content)
        {
            var node = SimpleJSON_20121217.JSON.Parse(_Content);
        }


        static void TryParseContent_SimpleJSON20121217_StringBuilderEscape(string _Content)
        {
            var node = SimpleJSON_20121217_StringBuilderEscape.JSON.Parse(_Content);
        }
    }
}
