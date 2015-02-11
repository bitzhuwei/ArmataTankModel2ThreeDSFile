using System;

namespace ArmadaTank.DTMParser
{
    /// <summary>
    /// 文法ArmadaTanksModel的语法树结点的值
    /// </summary>
    public class TreeNodeValueDTM : ICloneable
    {
        private string m_NodeName = string.Empty;
        /// <summary>
        /// 结点名称
        /// </summary>
        public string NodeName
        {
            get { return m_NodeName; }
            set { m_NodeName = value; }
        }
        private EnumVTypeDTM m_NodeType = EnumVTypeDTM.Unknown;
        /// <summary>
        /// 结点类型
        /// </summary>
        public EnumVTypeDTM NodeType
        {
            get { return m_NodeType; }
            set { m_NodeType = value; }
        }
        /// <summary>
        /// "名称, 类型"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}", m_NodeName, m_NodeType);
        }
        public object Clone()
        {
            var result = new TreeNodeValueDTM();
            result.NodeName = NodeName;
            result.NodeType = NodeType;
            return result;
        }
    }

}

