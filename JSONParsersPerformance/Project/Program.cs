using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParsersPerformance
{
    class Program
    {
        static string g_InputFilePath1 = "httpswww.mockaroo.com.json.txt" ;
        static string g_InputFilePath2 = "httpwww.txtwizard.netcompression.txt";

        static void Main(string[] args)
        {
            TryTest(g_InputFilePath1);
            TryTest(g_InputFilePath2);

            Console.In.Read();
        }

        static void TryTest(string _TestCaseFilePath )
        {
            System.IO.StreamReader SR = new System.IO.StreamReader(_TestCaseFilePath);
            if (null != SR)
            {

                string content = SR.ReadToEnd();
                int testCount = 8;

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
                        case 5: TryParseContent_NewtonJSON_6_0_8(content); break;
                        case 6: TryParseContent_NewtonJSON_9_0_1(content); break;
                        case 7: TryParseContent_NewtonJSON_10_0_2(content); break;
                        default: break;
                    }

                    watch.Stop();
                    Console.Out.WriteLine("Test case:" + _TestCaseFilePath + " Test method(" + i.ToString() + ") watch.ElapsedMilliseconds=" + watch.ElapsedMilliseconds);

                }
            }
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
        static void TryParseContent_NewtonJSON_6_0_8(string _Content)
        {
            var node =  Newtonsoft.Json608.JsonConvert.DeserializeObject(_Content);
        }
        static void TryParseContent_NewtonJSON_9_0_1(string _Content)
        {
            var node = Newtonsoft.Json901.JsonConvert.DeserializeObject(_Content);
        }
        static void TryParseContent_NewtonJSON_10_0_2(string _Content)
        {
            var node = Newtonsoft.Json1002.JsonConvert.DeserializeObject(_Content);
        }
    }
}
