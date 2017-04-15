#define ENABLE_STOP_AT_THE_END_PROGRAM

// Install-Package Google.Apis.Sheets.v4
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace GoogleSpreedSheetToJSON
{
    class Program
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "GoogleSpreedSheetToJSON";

        static String GOOGLE_TARGET_SPREADSHEET_ID = string.Empty;
        
        
        static List<IList<IList<Object>>> m_Sheets = null;

        static string m_OutputTextPath = "../DOC/Output.txt";

        static void Main(string[] args)
        {

            if (args.Length <= 1 )
            {
                Console.WriteLine("args.Length <= 1");
                Console.WriteLine("Format: GoogleSpreedSheetToJSON.exe <spreadsheet_id> <sheetname1> <sheetname2>...");
#if ENABLE_STOP_AT_THE_END_PROGRAM
                Console.Read();
#endif
                // ENABLE_STOP_AT_THE_END_PROGRAM
                return;
            }

            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }


            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // DebugSheetContent(m_DevelopingContent);


            List<string> sheenNames = new List<string>();
            m_Sheets = new List<IList<IList<object>>>();
            GOOGLE_TARGET_SPREADSHEET_ID = args[0];
            for ( int argIndex = 1; argIndex < args.Length; ++argIndex )
            {
                sheenNames.Add(args[argIndex]);
                FetchSheet(service,args[argIndex]);
            }

            SimpleJSON.JSONArray arrayNode = SimpleJSON.JSON.Parse("[]") as SimpleJSON.JSONArray;
            for ( int i = 0; i< m_Sheets.Count && i < sheenNames.Count; ++i )
            {
                ParseSheetToStructure(m_Sheets[i] , sheenNames[ i ] , ref arrayNode );
            }

            System.IO.StreamWriter SW = new StreamWriter(m_OutputTextPath);
            SW.Write(arrayNode.ToString());
            SW.Close();

#if ENABLE_STOP_AT_THE_END_PROGRAM
            Console.WriteLine("Programe terminate, press enter to leave");
            Console.Read();
#endif
// ENABLE_STOP_AT_THE_END_PROGRAM
        }

        static void FetchSheet(SheetsService _Service,string _SheetName)
        {
            var asheet = FetchSheetContent(_Service, _SheetName);
            m_Sheets.Add(asheet);
            if (null != asheet)
            {
                Console.WriteLine("asheet.Count=" + asheet.Count);
            }

        }

        static void ParseSheetToStructure(IList<IList<Object>> _Sheet
            , string _SheetName 
            , ref SimpleJSON.JSONArray _ArrayNode )
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
                    tagNode.Add(_SheetName, contentNode);
                    _ArrayNode.Add(tagNode);
                }
                
            }
        }
        
        
        static IList<IList<Object>> FetchSheetContent(SheetsService _Service , string _SheetName )
        {
            Console.WriteLine("FetchSheetContent...");

            var developingValueRange = new ValueRange();
            string range = _SheetName + "!A:Z";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    _Service.Spreadsheets.Values.Get(
                        GOOGLE_TARGET_SPREADSHEET_ID 
                        , range) ;

            ValueRange response = request.Execute();
            IList<IList<Object>> ret = response.Values;

            if ( null == ret)
            {
                Console.WriteLine("request failed.");
                return null ;
            }

            return ret;
        }
        
        static void DebugSheetContent(IList<IList<Object>>_2DArray)
        {
            if (null == _2DArray)
                return;

            // Debug
            foreach (var row in _2DArray)
            {
                foreach (var cell in row)
                {
                    Console.WriteLine("{0}", cell) ;
                }
            }
        }
       
        
    }
}
