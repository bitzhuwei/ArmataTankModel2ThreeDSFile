using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using bitzhuwei.CompilerBase;

namespace ArmadaTank.DTMParser
{
    /// <summary>
    /// ArmadaTanksModel的词法分析器
    /// </summary>
    public partial class LexicalAnalyzerDTM : LexicalAnalyzerBase<EnumTokenTypeDTM>
    {
        /// <summary>
        /// ArmadaTanksModel的词法分析器
        /// </summary>
        public LexicalAnalyzerDTM()
        { }
        /// <summary>
        /// ArmadaTanksModel的词法分析器
        /// </summary>
        /// <param name="sourceCode">要分析的源代码</param>
        public LexicalAnalyzerDTM(string sourceCode)
            : base(sourceCode)
        { }
        /// <summary>
        /// 从<code>PtNextLetter</code>开始获取下一个<code>Token</code>
        /// </summary>
        /// <returns></returns>
        protected override Token<EnumTokenTypeDTM> NextToken()
        {
            var result = new Token<EnumTokenTypeDTM>();
            result.Line = m_CurrentLine;
            result.Column = m_CurrentColumn;
            result.IndexOfSourceCode = PtNextLetter;
            var count = GetSourceCode().Length;
            if (PtNextLetter < 0 || PtNextLetter >= count) return result;
            var gotToken = false;
            var ct = GetCharType(GetSourceCode()[PtNextLetter]);
            switch (ct)
            {
                case EnumCharTypeDTM.Letter:
                    gotToken = GetIdentifier(result);
                    break;
                case EnumCharTypeDTM.LeftBrace:
                    gotToken = GetLeftBrace(result);
                    break;
                case EnumCharTypeDTM.RightBrace:
                    gotToken = GetRightBrace(result);
                    break;
                case EnumCharTypeDTM.Plus:
                    gotToken = GetPlus(result);
                    break;
                case EnumCharTypeDTM.Number:
                    gotToken = GetConstentNumber(result);
                    break;
                case EnumCharTypeDTM.Minus:
                    gotToken = GetMinus(result);
                    break;
                case EnumCharTypeDTM.Space:
                    gotToken = GetSpace(result);
                    break;
                default:
                    gotToken = GetUnknown(result);
                    break;
            }
            if (gotToken)
            {
                result.Length = PtNextLetter - result.IndexOfSourceCode;
                return result;
            }
            else
                return null;
        }
        #region 获取某类型的单词
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetLeftBrace(Token<EnumTokenTypeDTM> result)
        {
            var count = GetSourceCode().Length;
            //item.CharType: LeftBrace
            //Mapped nodes:
            //    "{"
            //result.TokenType = EnumTokenTypeDTM.token_LeftBrace_;
            if (PtNextLetter + 1 <= count)
            {
                var str = GetSourceCode().Substring(PtNextLetter, 1);
                if ("{" == str)
                {
                    result.TokenType = EnumTokenTypeDTM.token_LeftBrace_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetRightBrace(Token<EnumTokenTypeDTM> result)
        {
            var count = GetSourceCode().Length;
            //item.CharType: RightBrace
            //Mapped nodes:
            //    "}"
            //result.TokenType = EnumTokenTypeDTM.token_RightBrace_;
            if (PtNextLetter + 1 <= count)
            {
                var str = GetSourceCode().Substring(PtNextLetter, 1);
                if ("}" == str)
                {
                    result.TokenType = EnumTokenTypeDTM.token_RightBrace_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetPlus(Token<EnumTokenTypeDTM> result)
        {
            var count = GetSourceCode().Length;
            //item.CharType: Plus
            //Mapped nodes:
            //    "+"
            //result.TokenType = EnumTokenTypeDTM.token_Plus_;
            if (PtNextLetter + 1 <= count)
            {
                var str = GetSourceCode().Substring(PtNextLetter, 1);
                if ("+" == str)
                {
                    result.TokenType = EnumTokenTypeDTM.token_Plus_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetMinus(Token<EnumTokenTypeDTM> result)
        {
            var count = GetSourceCode().Length;
            //item.CharType: Minus
            //Mapped nodes:
            //    "-"
            //result.TokenType = EnumTokenTypeDTM.token_Minus_;
            if (PtNextLetter + 1 <= count)
            {
                var str = GetSourceCode().Substring(PtNextLetter, 1);
                if ("-" == str)
                {
                    result.TokenType = EnumTokenTypeDTM.token_Minus_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        #region GetIdentifier
        /// <summary>
        /// 获取标识符（函数名，变量名，等）
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetIdentifier(Token<EnumTokenTypeDTM> result)
        {
            result.TokenType = EnumTokenTypeDTM.identifier;
            StringBuilder builder = new StringBuilder();
            while (PtNextLetter < GetSourceCode().Length)
            {
                var ct = GetCharType(GetSourceCode()[PtNextLetter]);
                if (ct == EnumCharTypeDTM.Letter
                    || ct == EnumCharTypeDTM.Number
                    || ct == EnumCharTypeDTM.UnderLine
                    || ct == EnumCharTypeDTM.ChineseLetter)
                {
                    builder.Append(GetSourceCode()[PtNextLetter]);
                    PtNextLetter++;
                }
                else
                    break;
            }
            result.Detail = builder.ToString();
            // specify if this string is a keyword
            foreach (var item in keywords)
            {
                if (item.ToString().Substring(6) == result.Detail)
                {
                    result.TokenType = item;
                    break;
                }
            }
            return true;
        }
        
        public static readonly IEnumerable<EnumTokenTypeDTM> keywords = new List<EnumTokenTypeDTM>()
        {
            EnumTokenTypeDTM.token_File,
            EnumTokenTypeDTM.token_endfile,
            EnumTokenTypeDTM.token_FileDesc,
            EnumTokenTypeDTM.token_endfiledesc,
            EnumTokenTypeDTM.token_Faces,
            EnumTokenTypeDTM.token_MapChannel,
            EnumTokenTypeDTM.token_Frame,
            EnumTokenTypeDTM.token_endframe,
            EnumTokenTypeDTM.token_Frames,
            EnumTokenTypeDTM.token_Vertices,
            EnumTokenTypeDTM.token_Map,
            EnumTokenTypeDTM.token_TVertices,
            EnumTokenTypeDTM.token_Face,
            EnumTokenTypeDTM.token_MatID,
            EnumTokenTypeDTM.token_TextureVertices,
            EnumTokenTypeDTM.token_TextureFaces,
            EnumTokenTypeDTM.token_TVertex,
            EnumTokenTypeDTM.token_TFace,
            EnumTokenTypeDTM.token_Vertex,
        };
        
        #endregion GetIdentifier
        #region GetConstentNumber
        /// <summary>
        /// 数值
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetConstentNumber(Token<EnumTokenTypeDTM> result)
        {
            result.TokenType = EnumTokenTypeDTM.number;
            if (GetSourceCode()[PtNextLetter] == '0')//可能是八进制或十六进制数
            {
                if (PtNextLetter + 1 < GetSourceCode().Length)
                {
                    char c = GetSourceCode()[PtNextLetter + 1];
                    if (c == 'x' || c == 'X')
                    {//十六进制数
                        return GetConstentHexadecimalNumber(result);
                    }
                    else if (GetCharType(c) == EnumCharTypeDTM.Number)
                    {//八进制数
                        return GetConstentOctonaryNumber(result);
                    }
                    else//十进制数
                    {
                        return GetConstentDecimalNumber(result);
                    }
                }
                else
                {//源代码最后一个字符 0
                    result.Detail = "0";//0
                    PtNextLetter++;
                    return true;
                }
            }
            else//十进制数
            {
                return GetConstentDecimalNumber(result);
            }
        }
        /// <summary>
        /// 十进制数
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetConstentDecimalNumber(Token<EnumTokenTypeDTM> result)
        {
            char c;
            StringBuilder tag = new StringBuilder();
            c = GetSourceCode()[PtNextLetter];
            string numberSerial1, numberSerial2, numberSerial3;
            numberSerial1 = GetNumberSerial(GetSourceCode(), 10);
            tag.Append(numberSerial1);
            result.LexicalError = string.IsNullOrEmpty(numberSerial1);
            if (PtNextLetter < GetSourceCode().Length)
            {
                c = GetSourceCode()[PtNextLetter];
                if (c == 'l' || c == 'L')
                {
                    tag.Append(c);
                    PtNextLetter++;
                }
                if (c == '.')
                {
                    tag.Append(c);
                    PtNextLetter++;
                    numberSerial2 = GetNumberSerial(GetSourceCode(), 10);
                    tag.Append(numberSerial2);
                    result.LexicalError = result.LexicalError || string.IsNullOrEmpty(numberSerial2);
                    if (PtNextLetter < GetSourceCode().Length)
                    {
                        c = GetSourceCode()[PtNextLetter];
                    }
                }
                if (c == 'e' || c == 'E')
                {
                    tag.Append(c);
                    PtNextLetter++;
                    if (PtNextLetter < GetSourceCode().Length)
                    {
                        c = GetSourceCode()[PtNextLetter];
                        if (c == '+' || c == '-')
                        {
                            tag.Append(c);
                            PtNextLetter++;
                        }
                    }
                    numberSerial3 = GetNumberSerial(GetSourceCode(), 10);
                    tag.Append(numberSerial3);
                    result.LexicalError = result.LexicalError || string.IsNullOrEmpty(numberSerial3);
                }
            }
            result.Detail = tag.ToString();
            if (result.LexicalError)
            {
                result.Tag = string.Format("十进制数[{0}]格式错误，无法解析。", tag.ToString());
            }
            return true;
        }
        /// <summary>
        /// 八进制数
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetConstentOctonaryNumber(Token<EnumTokenTypeDTM> result)
        {
            char c;
            StringBuilder tag = new StringBuilder(GetSourceCode().Substring(PtNextLetter, 1));
            PtNextLetter++;
            string numberSerial = GetNumberSerial(GetSourceCode(), 8);
            tag.Append(numberSerial);
            if (PtNextLetter < GetSourceCode().Length)
            {
                c = GetSourceCode()[PtNextLetter];
                if (c == 'l' || c == 'L')
                {
                    tag.Append(c);
                    PtNextLetter++;
                }
            }
            result.Detail = tag.ToString();
            if (string.IsNullOrEmpty(numberSerial))
            {
                result.LexicalError = true;
                result.Tag = string.Format("八进制数[{0}]格式错误，无法解析。", tag.ToString());
                return false;
            }
            return true;
        }
        /// <summary>
        /// 十六进制数
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetConstentHexadecimalNumber(Token<EnumTokenTypeDTM> result)
        {
            char c;
            StringBuilder tag = new StringBuilder(GetSourceCode().Substring(PtNextLetter, 2));
            PtNextLetter += 2;
            string numberSerial = GetNumberSerial(GetSourceCode(), 16);
            tag.Append(numberSerial);
            if (PtNextLetter < GetSourceCode().Length)
            {
                c = GetSourceCode()[PtNextLetter];
                if (c == 'l' || c == 'L')
                {
                    tag.Append(c);
                    PtNextLetter++;
                }
            }
            result.Detail = tag.ToString();
            if (string.IsNullOrEmpty(numberSerial))
            {
                result.LexicalError = true;
                result.Tag = string.Format("十六进制数[{0}]格式错误。", tag.ToString());
                return false;
            }
            return true;
        }
        /// <summary>
        /// 数字序列
        /// </summary>
        /// <param name="sourceCode"></param>
        /// <param name="scale">进制</param>
        /// <returns></returns>
        protected virtual string GetNumberSerial(string sourceCode, int scale)
        {
            if (scale == 10)
            {
                return GetNumberSerialDecimal(GetSourceCode());
            }
            if (scale == 16)
            {
                return GetNumberSerialHexadecimal(GetSourceCode());
            }
            if (scale == 8)
            {
                return GetNumberSerialOctonary(GetSourceCode());
            }
            return string.Empty;
        }
        /// <summary>
        /// 十进制数序列
        /// </summary>
        /// <param name="sourceCode"></param>
        /// <returns></returns>
        protected virtual string GetNumberSerialDecimal(string sourceCode)
        {
            StringBuilder result = new StringBuilder(String.Empty);
            char c;
            while (PtNextLetter < GetSourceCode().Length)
            {
                c = GetSourceCode()[PtNextLetter];
                if ('0' <= c && c <= '9')
                {
                    result.Append(c);
                    PtNextLetter++;
                }
                else
                    break;
            }
            return result.ToString();
        }
        /// <summary>
        /// 八进制数序列
        /// </summary>
        /// <param name="sourceCode"></param>
        /// <returns></returns>
        protected virtual string GetNumberSerialOctonary(string sourceCode)
        {
            StringBuilder result = new StringBuilder(String.Empty);
            char c;
            while (PtNextLetter < GetSourceCode().Length)
            {
                c = GetSourceCode()[PtNextLetter];
                if ('0' <= c && c <= '7')
                {
                    result.Append(c);
                    PtNextLetter++;
                }
                else
                    break;
            }
            return result.ToString();
        }
        /// <summary>
        /// 十六进制数序列（不包括0x前缀）
        /// </summary>
        /// <param name="sourceCode"></param>
        /// <returns></returns>
        protected virtual string GetNumberSerialHexadecimal(string sourceCode)
        {
            StringBuilder result = new StringBuilder(String.Empty);
            char c;
            while (PtNextLetter < GetSourceCode().Length)
            {
                c = GetSourceCode()[PtNextLetter];
                if (('0' <= c && c <= '9')
                || ('a' <= c && c <= 'f')
                || ('A' <= c && c <= 'F'))
                {
                    result.Append(c);
                    PtNextLetter++;
                }
                else
                    break;
            }
            return result.ToString();
        }
        #endregion GetConstentNumber
        /// <summary>
        /// 未知符号
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetUnknown(Token<EnumTokenTypeDTM> result)
        {
            result.TokenType = EnumTokenTypeDTM.unknown;
            result.Detail = GetSourceCode()[PtNextLetter].ToString();
            result.LexicalError = true;
            result.Tag = string.Format("发现未知字符[{0}]。", result.Detail);
            PtNextLetter++;
            return true;
        }
        /// <summary>
        /// space tab \r \n
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetSpace(Token<EnumTokenTypeDTM> result)
        {
            char c = GetSourceCode()[PtNextLetter];
            PtNextLetter++;
            if (c == '\n')// || c == '\r') //换行：Windows：\r\n Linux：\n
            {
                m_CurrentLine++;
                m_CurrentColumn = 0;
            }
            return false;
        }
        /// <summary>
        /// 跳过多行注释
        /// </summary>
        /// <returns></returns>
        protected virtual void SkipMultilineNote()
        {
            int count = GetSourceCode().Length;
            while (PtNextLetter < count)
            {
                if (GetSourceCode()[PtNextLetter] == '*')
                {
                    PtNextLetter++;
                    if (PtNextLetter < count)
                    {
                        if (GetSourceCode()[PtNextLetter] == '/')
                        {
                            PtNextLetter++;
                            break;
                        }
                        else
                            PtNextLetter++;
                    }
                }
                else
                    PtNextLetter++;
            }
        }
        /// <summary>
        /// 跳过单行注释
        /// </summary>
        /// <returns></returns>
        protected virtual void SkipSingleLineNote()
        {
            int count = GetSourceCode().Length;
            char cNext;
            while (PtNextLetter < count)
            {
                cNext = GetSourceCode()[PtNextLetter];
                if (cNext == '\r' || cNext == '\n')
                {
                    break;
                }
                PtNextLetter++;
            }
        }
        #endregion 获取某类型的单词
        /// <summary>
        /// 获取字符类型
        /// </summary>
        /// <param name="c">要归类的字符</param>
        /// <returns></returns>
        protected virtual EnumCharTypeDTM GetCharType(char c)
        {
            if (('a' <= c && c <= 'z') || ('A' <= c && c <= 'Z')) return EnumCharTypeDTM.Letter;
            if ('0' <= c && c <= '9') return EnumCharTypeDTM.Number;
            if (c == '_') return EnumCharTypeDTM.UnderLine;
            if (c == '.') return EnumCharTypeDTM.Dot;
            if (c == ',') return EnumCharTypeDTM.Comma;
            if (c == '+') return EnumCharTypeDTM.Plus;
            if (c == '-') return EnumCharTypeDTM.Minus;
            if (c == '*') return EnumCharTypeDTM.Multiply;
            if (c == '/') return EnumCharTypeDTM.Divide;
            if (c == '%') return EnumCharTypeDTM.Percent;
            if (c == '^') return EnumCharTypeDTM.Xor;
            if (c == '&') return EnumCharTypeDTM.And;
            if (c == '|') return EnumCharTypeDTM.Or;
            if (c == '~') return EnumCharTypeDTM.Reverse;
            if (c == '$') return EnumCharTypeDTM.Dollar;
            if (c == '<') return EnumCharTypeDTM.LessThan;
            if (c == '>') return EnumCharTypeDTM.GreaterThan;
            if (c == '(') return EnumCharTypeDTM.LeftParentheses;
            if (c == ')') return EnumCharTypeDTM.RightParentheses;
            if (c == '[') return EnumCharTypeDTM.LeftBracket;
            if (c == ']') return EnumCharTypeDTM.RightBracket;
            if (c == '{') return EnumCharTypeDTM.LeftBrace;
            if (c == '}') return EnumCharTypeDTM.RightBrace;
            if (c == '!') return EnumCharTypeDTM.Not;
            if (c == '#') return EnumCharTypeDTM.Pound;
            if (c == '\\') return EnumCharTypeDTM.Slash;
            if (c == '?') return EnumCharTypeDTM.Question;
            if (c == '\'') return EnumCharTypeDTM.Quotation;
            if (c == '"') return EnumCharTypeDTM.DoubleQuotation;
            if (c == ':') return EnumCharTypeDTM.Colon;
            if (c == ';') return EnumCharTypeDTM.Semicolon;
            if (c == '=') return EnumCharTypeDTM.Equality;
            if (regChineseLetter.IsMatch(Convert.ToString(c))) return EnumCharTypeDTM.ChineseLetter;
            if (c == ' ' || c == '\t' || c == '\r' || c == '\n') return EnumCharTypeDTM.Space;
            return EnumCharTypeDTM.Unknown;
        }
        /// <summary>
        /// 汉字 new Regex("^[^\x00-\xFF]")
        /// </summary>
        private static readonly Regex regChineseLetter = new Regex("^[^\x00-\xFF]");
    }

}

