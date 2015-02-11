namespace ArmadaTank.DTMParser
{
    /// <summary>
    /// 文法ArmadaTanksModel的语法树结点枚举类型
    /// </summary>
    public enum EnumVTypeDTM
    {
        /// <summary>
        /// 未知的语法结点符号
        /// </summary>
        Unknown,
        /// <summary>
        /// &lt;DTM&gt; ::= &quot;File&quot; &lt;FileContent&gt; &quot;endfile&quot;;
        /// </summary>
        case_ArmadaTanksModel,
        /// <summary>
        /// &lt;FileContent&gt; ::= &quot;{&quot; &lt;BlockList&gt; &quot;}&quot;;
        /// </summary>
        case_FileContent,
        /// <summary>
        /// &lt;BlockList&gt; ::= &lt;Block&gt; &lt;BlockList&gt; | null;
        /// </summary>
        case_BlockList,
        /// <summary>
        /// &lt;Block&gt; ::= &quot;FileDesc&quot; &lt;FileDesc&gt; &quot;endfiledesc&quot; | &quot;Faces&quot; &lt;Faces&gt; | &quot;MapChannel&quot; &lt;SignedNumber&gt; &lt;MapChannel&gt; | &quot;Frame&quot; &lt;SignedNumber&gt; &lt;Frame&gt; &quot;endframe&quot;;
        /// </summary>
        case_Block,
        /// <summary>
        /// &lt;FileDesc&gt; ::= &quot;{&quot; &lt;FileDescItemList&gt; &quot;}&quot;;
        /// </summary>
        case_FileDesc,
        /// <summary>
        /// &lt;FileDescItemList&gt; ::= &lt;FileDescItem&gt; &lt;FileDescItemList&gt; | null;
        /// </summary>
        case_FileDescItemList,
        /// <summary>
        /// &lt;FileDescItem&gt; ::= &quot;Frames&quot; &lt;SignedNumber&gt; | &quot;Vertices&quot; &lt;SignedNumber&gt; | &quot;Faces&quot; &lt;SignedNumber&gt; | &quot;Map&quot; &lt;SignedNumber&gt; &quot;TVertices&quot; &lt;SignedNumber&gt;;
        /// </summary>
        case_FileDescItem,
        /// <summary>
        /// &lt;Faces&gt; ::= &quot;{&quot; &lt;FaceList&gt; &quot;}&quot;;
        /// </summary>
        case_Faces,
        /// <summary>
        /// &lt;FaceList&gt; ::= &lt;Face&gt; &lt;FaceList&gt; | null;
        /// </summary>
        case_FaceList,
        /// <summary>
        /// &lt;Face&gt; ::= &quot;Face&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &quot;MatID&quot; &lt;SignedNumber&gt;;
        /// </summary>
        case_Face,
        /// <summary>
        /// &lt;MapChannel&gt; ::= &quot;{&quot; &lt;TextureList&gt; &quot;}&quot;;
        /// </summary>
        case_MapChannel,
        /// <summary>
        /// &lt;TextureList&gt; ::= &lt;Texture&gt; &lt;TextureList&gt; | null;
        /// </summary>
        case_TextureList,
        /// <summary>
        /// &lt;Texture&gt; ::= &quot;TextureVertices&quot; &lt;TextureVertices&gt; | &quot;TextureFaces&quot; &lt;TextureFaces&gt;;
        /// </summary>
        case_Texture,
        /// <summary>
        /// &lt;TextureVertices&gt; ::= &quot;{&quot; &lt;TVertexList&gt; &quot;}&quot;;
        /// </summary>
        case_TextureVertices,
        /// <summary>
        /// &lt;TVertexList&gt; ::= &lt;TVertex&gt; &lt;TVertexList&gt; | null;
        /// </summary>
        case_TVertexList,
        /// <summary>
        /// &lt;TVertex&gt; ::= &quot;TVertex&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt;;
        /// </summary>
        case_TVertex,
        /// <summary>
        /// &lt;TextureFaces&gt; ::= &quot;{&quot; &lt;TFaceList&gt; &quot;}&quot;;
        /// </summary>
        case_TextureFaces,
        /// <summary>
        /// &lt;TFaceList&gt; ::= &lt;TFace&gt; &lt;TFaceList&gt; | null;
        /// </summary>
        case_TFaceList,
        /// <summary>
        /// &lt;TFace&gt; ::= &quot;TFace&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt;;
        /// </summary>
        case_TFace,
        /// <summary>
        /// &lt;Frame&gt; ::= &quot;{&quot; &lt;FrameContentItemList&gt; &quot;}&quot;;
        /// </summary>
        case_Frame,
        /// <summary>
        /// &lt;FrameContentItemList&gt; ::= &lt;FrameContentItem&gt; &lt;FrameContentItemList&gt; | null;
        /// </summary>
        case_FrameContentItemList,
        /// <summary>
        /// &lt;FrameContentItem&gt; ::= &quot;Vertices&quot; &quot;{&quot; &lt;Vertices&gt; &quot;}&quot;;
        /// </summary>
        case_FrameContentItem,
        /// <summary>
        /// &lt;Vertices&gt; ::= &lt;Vertex&gt; &lt;Vertices&gt; | null;
        /// </summary>
        case_Vertices,
        /// <summary>
        /// &lt;Vertex&gt; ::= &quot;Vertex&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt;;
        /// </summary>
        case_Vertex,
        /// <summary>
        /// &lt;SignedNumber&gt; ::= &quot;+&quot; number | &quot;-&quot; number | number;
        /// </summary>
        case_SignedNumber,
        /// <summary>
        /// &quot;File&quot;
        /// </summary>
        tail_fileLeave,
        /// <summary>
        /// &quot;endfile&quot;
        /// </summary>
        tail_endfileLeave,
        /// <summary>
        /// &quot;{&quot;
        /// </summary>
        tail_leftBrace_Leave,
        /// <summary>
        /// &quot;}&quot;
        /// </summary>
        tail_rightBrace_Leave,
        /// <summary>
        /// null
        /// </summary>
        epsilonLeave,
        /// <summary>
        /// &quot;FileDesc&quot;
        /// </summary>
        tail_fileDescLeave,
        /// <summary>
        /// &quot;endfiledesc&quot;
        /// </summary>
        tail_endfiledescLeave,
        /// <summary>
        /// &quot;Faces&quot;
        /// </summary>
        tail_facesLeave,
        /// <summary>
        /// &quot;MapChannel&quot;
        /// </summary>
        tail_mapChannelLeave,
        /// <summary>
        /// &quot;Frame&quot;
        /// </summary>
        tail_frameLeave,
        /// <summary>
        /// &quot;endframe&quot;
        /// </summary>
        tail_endframeLeave,
        /// <summary>
        /// &quot;Frames&quot;
        /// </summary>
        tail_framesLeave,
        /// <summary>
        /// &quot;Vertices&quot;
        /// </summary>
        tail_verticesLeave,
        /// <summary>
        /// &quot;Map&quot;
        /// </summary>
        tail_mapLeave,
        /// <summary>
        /// &quot;TVertices&quot;
        /// </summary>
        tail_tVerticesLeave,
        /// <summary>
        /// &quot;Face&quot;
        /// </summary>
        tail_faceLeave,
        /// <summary>
        /// &quot;MatID&quot;
        /// </summary>
        tail_matIDLeave,
        /// <summary>
        /// &quot;TextureVertices&quot;
        /// </summary>
        tail_textureVerticesLeave,
        /// <summary>
        /// &quot;TextureFaces&quot;
        /// </summary>
        tail_textureFacesLeave,
        /// <summary>
        /// &quot;TVertex&quot;
        /// </summary>
        tail_tVertexLeave,
        /// <summary>
        /// &quot;TFace&quot;
        /// </summary>
        tail_tFaceLeave,
        /// <summary>
        /// &quot;Vertex&quot;
        /// </summary>
        tail_vertexLeave,
        /// <summary>
        /// &quot;+&quot;
        /// </summary>
        tail_plus_Leave,
        /// <summary>
        /// number
        /// </summary>
        numberLeave,
        /// <summary>
        /// &quot;-&quot;
        /// </summary>
        tail_minus_Leave,
        /// <summary>
        /// #
        /// </summary>
        tail_startEndLeave,
    }

}

