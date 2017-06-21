using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClassGen
{
    public partial class ClassGenForm : Form
    {
        public class MemberData
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string GetTypeString()
            {
                string ret = this.Type;
                if (string.Empty == ret)
                {
                    ret = "int";
                }
                return ret;
            }

            public string GetSimpleJSONAsType()
            {
                string ret = string.Empty ;
                switch (this.Type)
                {
                    case "int" : ret = "AsInt"; break;
                    case "float": ret = "AsFloat"; break;
                    default : ret = "Value"; break;
                }
                return ret;
            }
        }

        const string CONST_InputName = "./Input.txt";
        const string CONST_FormatDir = "./TEMPLATE/";

        public ClassGenForm()
        {
            InitializeComponent();

            InitializeTemplateList();

        }

        const string KEY_ClassName = "<Class>";
        const string KEY_ProtocolName = "<Protocol>";
        const string KEY_FileName = "<File>";
        const string KEY_MemberRows = "<MemberRows>";
        const string KEY_MemberDebugRows = "<MemberDebugRows>";
        const string KEY_MemberCopyRows = "<MemberCopyRows>";
        const string KEY_MemberName = "<MemberName>";
        const string KEY_MemberType = "<MemberType>";
        const string KEY_GenerateDate6 = "<GenerateDate6>";
        const string KEY_SimpleJSONAsType = "<SimpleJSONAsType>";

        const string KEY_MemberRowSentence = "	public <MemberType> <MemberName> { get; set; }";
        const string KEY_MemberDebugSentence = "	+ \"\\n <MemberName>=\" + this.<MemberName>";
        const string KEY_MemberCopySentence = "	ret.<MemberName> = _Node[\"<MemberName>\"].<SimpleJSONAsType> ;";


        private void ReadInput( string _InputFilePath 
            , ref List<MemberData> _Members 
            , ref string _Class 
            , ref string _Protocol
            )
        {
            System.IO.StreamReader SR = new System.IO.StreamReader(_InputFilePath);
            if (null == SR)
            {
                return;
            }

            const string KEY_Class = "Class:" ;
            const string KEY_Protocol = "Protocol:";
            string[] separators = { " " };

            string strRead = string.Empty;
            while (!SR.EndOfStream)
            {
                strRead = SR.ReadLine();

                if (strRead == string.Empty)
                {
                    continue;
                }
                
                
                if (-1 != strRead.IndexOf(KEY_Class))
                {
                    strRead = strRead.Substring(KEY_Class.Length);
                    _Class = strRead;
                }
                else if (-1 != strRead.IndexOf(KEY_Protocol))
                {
                    strRead = strRead.Substring(KEY_Protocol.Length);
                    _Protocol = strRead;
                }
                else
                {
                    var strVec = strRead.Split(separators, StringSplitOptions.None);
                    MemberData member = null;
                    if (1 == strVec.Length)
                    {
                        member = new MemberData();
                        member.Name = strVec[0];
                    }
                    else if( 2 == strVec.Length )
                    {
                        member = new MemberData();
                        member.Type = strVec[0];
                        member.Name = strVec[1];
                    }

                    if (null != member)
                    {
                        _Members.Add(member);
                    }
                    
                }

            }
        }

        private string GenerateExportFileName(string _ExportFileNameWithTemplate, string _ClassName, string _ProtocolName)
        {
            string ret = _ExportFileNameWithTemplate;
            ret = ret.Replace(KEY_ClassName, _ClassName);
            ret = ret.Replace(KEY_ProtocolName, _ProtocolName);
            return ret;
        }

        private string ReadTemplateFileContent(string _TemplateFilePath)
        {
            string ret = string.Empty;
            if ( false == System.IO.File.Exists(_TemplateFilePath))
            {
                return ret;
            }
            System.IO.StreamReader SR = new System.IO.StreamReader(_TemplateFilePath);

            if (null == SR)
            {
                return ret;
            }

            ret = SR.ReadToEnd();
            SR.Close();
            return ret;
        }

        private string ReplaceTemplate(
            string _TemplateContent
            , string _FileNameWithoutExt
            , string _ClassName
            , string _ProtocolName
            , string _GenerateDate6
            )
        {
            string ret = _TemplateContent;

            ret = ret.Replace(KEY_FileName, _FileNameWithoutExt);

            ret = ret.Replace(KEY_ClassName, _ClassName);
            ret = ret.Replace(KEY_ProtocolName, _ProtocolName);
            ret = ret.Replace(KEY_GenerateDate6, _GenerateDate6);

            string memberRows = GenerateMemberRows(KEY_MemberRowSentence, m_MemberDatas);
            ret = ret.Replace(KEY_MemberRows, memberRows);

            string memberDebugRows = GenerateMemberRows(KEY_MemberDebugSentence, m_MemberDatas);
            ret = ret.Replace(KEY_MemberDebugRows, memberDebugRows);

            string memberCopyRows = GenerateMemberRows(KEY_MemberCopySentence, m_MemberDatas);
            ret = ret.Replace(KEY_MemberCopyRows, memberCopyRows);

            return ret;
        }

        private string GenerateMemberRows(string _TemlateSentence, List<MemberData> _Members )
        {
            string ret = string.Empty;
            string tmp = string.Empty;

            foreach (var member in _Members)
            {
                tmp = _TemlateSentence;
                tmp = tmp.Replace(KEY_MemberName, member.Name );
                tmp = tmp.Replace(KEY_MemberType, member.GetTypeString() ) ;
                tmp = tmp.Replace(KEY_SimpleJSONAsType, member.GetSimpleJSONAsType() );
                ret += ( tmp + Environment.NewLine) ; 
            }
            return ret;
        }

        private void ReplaceAll( string _Class , string _Protocol , string _GenerateDate )
        {
            var i = m_TemplateList.GetEnumerator();
            while (i.MoveNext())
            {
                var templateContent = ReadTemplateFileContent(CONST_FormatDir + i.Current.Value);
                if (string.Empty == templateContent)
                {
                    continue;
                }

                var saveFilePath = GenerateExportFileName(i.Current.Key, _Class, _Protocol);
                System.IO.FileInfo fi = new System.IO.FileInfo(saveFilePath);
                var saveFilePathWithOutExt = fi.Name.Replace(fi.Extension, string.Empty );

                var replaceResult = ReplaceTemplate(templateContent
                    , saveFilePathWithOutExt
                    , _Class 
                    , _Protocol 
                    , _GenerateDate) ;

                textBoxPreview.AppendText("saveFilePath=" + saveFilePath  + Environment.NewLine );
                System.IO.StreamWriter SW = new System.IO.StreamWriter(saveFilePath);
                if (null != SW)
                {
                    SW.Write(replaceResult);
                    SW.Close();
                }
            }
        }

        private void InitializeTemplateList()
        {
            m_TemplateList.Add(KEY_ClassName + ".cs", "TEMPLATE_Class.txt") ;
            m_TemplateList.Add(KEY_ClassName + "JSONHelper.cs", "TEMPLATE_SimpleJSONHelper.txt");
            m_TemplateList.Add("SeqOp_" + KEY_ProtocolName + ".cs", "TEMPLATE_SeqOp.txt");
            
        }

        List<MemberData> m_MemberDatas = new List<MemberData>();
        Dictionary<string, string> m_TemplateList = new Dictionary<string, string>();

        private void buttonSTART_Click(object sender, EventArgs e)
        {
            string className = string.Empty;
            string protocolKey = string.Empty;
            string generateDate = string.Format("{0:0000}{1:00}{2:00}", System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day);
            ReadInput(CONST_InputName, ref m_MemberDatas, ref className, ref protocolKey);

            textBoxPreview.AppendText("className=" + className + Environment.NewLine);
            textBoxPreview.AppendText("protocolKey=" + protocolKey + Environment.NewLine);
            foreach (var member in m_MemberDatas)
            {
                textBoxPreview.AppendText( member.Type + " " + member.Name + Environment.NewLine);
            }

            ReplaceAll(className, protocolKey, generateDate);
        }
    }
}
