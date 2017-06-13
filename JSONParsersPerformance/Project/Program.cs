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
                int testCount = 5;

                for (int i = 0; i < testCount; ++i)
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    switch (i)
                    {
                        case 0: TryParseContent_SimpleJSON20121217(content); break;
                        case 1: TryParseContent_SimpleJSON20121217_StringBuilderEscape(content); break;
                        case 2: TryParseContent_SimpleJSON_20121217_StringBuilderEscapeToken(content); break;
                        case 3: TryParseContent_SimpleJSON_20140921_StringBuilderEscapeTokenNumberize(content); break;
                        case 4: TryParseContent_SimpleJSON_20170308_StringBuilderEscapeTokenJSONObject(content); break;
                        default: break;
                    }
                    
                    watch.Stop();
                    Console.Out.WriteLine( "Test case:" + g_InputFilePath + " Test method(" + i.ToString() + ") watch.ElapsedMilliseconds=" + watch.ElapsedMilliseconds);

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


        static void TryParseContent_SimpleJSON_20121217_StringBuilderEscapeToken(string _Content)
        {
            var node = SimpleJSON_20121217_StringBuilderEscapeToken.JSON.Parse(_Content);
        }


        static void TryParseContent_SimpleJSON_20140921_StringBuilderEscapeTokenNumberize(string _Content)
        {
            var node = SimpleJSON_20140921_StringBuilderEscapeTokenNumberize.JSON.Parse(_Content);
        }
        static void TryParseContent_SimpleJSON_20170308_StringBuilderEscapeTokenJSONObject(string _Content)
        {
            var node = CymaticLabs.Unity3D.Amqp.SimpleJSON_20170308_StringBuilderEscapeTokenJSONObject.JSON.Parse(_Content);
        }

        
    }
}
