namespace ArmadaTank.DTMParser
{
    /// <summary>
    /// 文法ArmadaTanksModel的单词枚举类型
    /// </summary>
    public enum EnumTokenTypeDTM
    {
        /// <summary>
        /// 未知的单词符号
        /// </summary>
        unknown,
        /// <summary>
        /// &quot;File&quot;
        /// </summary>
        token_File,
        /// <summary>
        /// &quot;endfile&quot;
        /// </summary>
        token_endfile,
        /// <summary>
        /// &quot;{&quot;
        /// </summary>
        token_LeftBrace_,
        /// <summary>
        /// &quot;}&quot;
        /// </summary>
        token_RightBrace_,
        /// <summary>
        /// null
        /// </summary>
        epsilon,
        /// <summary>
        /// &quot;FileDesc&quot;
        /// </summary>
        token_FileDesc,
        /// <summary>
        /// &quot;endfiledesc&quot;
        /// </summary>
        token_endfiledesc,
        /// <summary>
        /// &quot;Faces&quot;
        /// </summary>
        token_Faces,
        /// <summary>
        /// &quot;MapChannel&quot;
        /// </summary>
        token_MapChannel,
        /// <summary>
        /// &quot;Frame&quot;
        /// </summary>
        token_Frame,
        /// <summary>
        /// &quot;endframe&quot;
        /// </summary>
        token_endframe,
        /// <summary>
        /// &quot;Frames&quot;
        /// </summary>
        token_Frames,
        /// <summary>
        /// &quot;Vertices&quot;
        /// </summary>
        token_Vertices,
        /// <summary>
        /// &quot;Map&quot;
        /// </summary>
        token_Map,
        /// <summary>
        /// &quot;TVertices&quot;
        /// </summary>
        token_TVertices,
        /// <summary>
        /// &quot;Face&quot;
        /// </summary>
        token_Face,
        /// <summary>
        /// &quot;MatID&quot;
        /// </summary>
        token_MatID,
        /// <summary>
        /// &quot;TextureVertices&quot;
        /// </summary>
        token_TextureVertices,
        /// <summary>
        /// &quot;TextureFaces&quot;
        /// </summary>
        token_TextureFaces,
        /// <summary>
        /// &quot;TVertex&quot;
        /// </summary>
        token_TVertex,
        /// <summary>
        /// &quot;TFace&quot;
        /// </summary>
        token_TFace,
        /// <summary>
        /// &quot;Vertex&quot;
        /// </summary>
        token_Vertex,
        /// <summary>
        /// &quot;+&quot;
        /// </summary>
        token_Plus_,
        /// <summary>
        /// number
        /// </summary>
        number,
        /// <summary>
        /// &quot;-&quot;
        /// </summary>
        token_Minus_,
        /// <summary>
        /// #
        /// </summary>
        token_startEnd,
        /// <summary>
        /// 标识符
        /// </summary>
        identifier,
    }

}

