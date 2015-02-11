using System;
using bitzhuwei.CompilerBase;

namespace ArmadaTank.DTMParser
{
    /// <summary>
    /// ArmadaTanksModel的LL1语法分析器
    /// </summary>
    public partial class LL1SyntaxParserDTM : LL1SyntaxParserBase<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
    {
        #region 分析表中的元素
        
        /// <summary>
        /// 对 &lt;DTM&gt; ::= &quot;File&quot;... 进行分析
        /// <para>&lt;DTM&gt; ::= &quot;File&quot; &lt;FileContent&gt; &quot;endfile&quot;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_ArmadaTanksModel___tail_fileLeave;
        /// <summary>
        /// 对 &lt;FileContent&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;FileContent&gt; ::= &quot;{&quot; &lt;BlockList&gt; &quot;}&quot;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FileContent___tail_leftBrace_Leave;
        /// <summary>
        /// 对 &lt;BlockList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;BlockList&gt; ::= null;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_BlockList___tail_rightBrace_Leave;
        /// <summary>
        /// 对 &lt;BlockList&gt; ::= &quot;FileDesc&quot;... 进行分析
        /// <para>&lt;BlockList&gt; ::= &lt;Block&gt; &lt;BlockList&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_BlockList___tail_fileDescLeave;
        /// <summary>
        /// 对 &lt;BlockList&gt; ::= &quot;Faces&quot;... 进行分析
        /// <para>&lt;BlockList&gt; ::= &lt;Block&gt; &lt;BlockList&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_BlockList___tail_facesLeave;
        /// <summary>
        /// 对 &lt;BlockList&gt; ::= &quot;MapChannel&quot;... 进行分析
        /// <para>&lt;BlockList&gt; ::= &lt;Block&gt; &lt;BlockList&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_BlockList___tail_mapChannelLeave;
        /// <summary>
        /// 对 &lt;BlockList&gt; ::= &quot;Frame&quot;... 进行分析
        /// <para>&lt;BlockList&gt; ::= &lt;Block&gt; &lt;BlockList&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_BlockList___tail_frameLeave;
        /// <summary>
        /// 对 &lt;Block&gt; ::= &quot;FileDesc&quot;... 进行分析
        /// <para>&lt;Block&gt; ::= &quot;FileDesc&quot; &lt;FileDesc&gt; &quot;endfiledesc&quot;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_Block___tail_fileDescLeave;
        /// <summary>
        /// 对 &lt;Block&gt; ::= &quot;Faces&quot;... 进行分析
        /// <para>&lt;Block&gt; ::= &quot;Faces&quot; &lt;Faces&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_Block___tail_facesLeave;
        /// <summary>
        /// 对 &lt;Block&gt; ::= &quot;MapChannel&quot;... 进行分析
        /// <para>&lt;Block&gt; ::= &quot;MapChannel&quot; &lt;SignedNumber&gt; &lt;MapChannel&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_Block___tail_mapChannelLeave;
        /// <summary>
        /// 对 &lt;Block&gt; ::= &quot;Frame&quot;... 进行分析
        /// <para>&lt;Block&gt; ::= &quot;Frame&quot; &lt;SignedNumber&gt; &lt;Frame&gt; &quot;endframe&quot;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_Block___tail_frameLeave;
        /// <summary>
        /// 对 &lt;FileDesc&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;FileDesc&gt; ::= &quot;{&quot; &lt;FileDescItemList&gt; &quot;}&quot;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FileDesc___tail_leftBrace_Leave;
        /// <summary>
        /// 对 &lt;FileDescItemList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;FileDescItemList&gt; ::= null;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FileDescItemList___tail_rightBrace_Leave;
        /// <summary>
        /// 对 &lt;FileDescItemList&gt; ::= &quot;Faces&quot;... 进行分析
        /// <para>&lt;FileDescItemList&gt; ::= &lt;FileDescItem&gt; &lt;FileDescItemList&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FileDescItemList___tail_facesLeave;
        /// <summary>
        /// 对 &lt;FileDescItemList&gt; ::= &quot;Frames&quot;... 进行分析
        /// <para>&lt;FileDescItemList&gt; ::= &lt;FileDescItem&gt; &lt;FileDescItemList&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FileDescItemList___tail_framesLeave;
        /// <summary>
        /// 对 &lt;FileDescItemList&gt; ::= &quot;Vertices&quot;... 进行分析
        /// <para>&lt;FileDescItemList&gt; ::= &lt;FileDescItem&gt; &lt;FileDescItemList&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FileDescItemList___tail_verticesLeave;
        /// <summary>
        /// 对 &lt;FileDescItemList&gt; ::= &quot;Map&quot;... 进行分析
        /// <para>&lt;FileDescItemList&gt; ::= &lt;FileDescItem&gt; &lt;FileDescItemList&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FileDescItemList___tail_mapLeave;
        /// <summary>
        /// 对 &lt;FileDescItem&gt; ::= &quot;Faces&quot;... 进行分析
        /// <para>&lt;FileDescItem&gt; ::= &quot;Faces&quot; &lt;SignedNumber&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FileDescItem___tail_facesLeave;
        /// <summary>
        /// 对 &lt;FileDescItem&gt; ::= &quot;Frames&quot;... 进行分析
        /// <para>&lt;FileDescItem&gt; ::= &quot;Frames&quot; &lt;SignedNumber&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FileDescItem___tail_framesLeave;
        /// <summary>
        /// 对 &lt;FileDescItem&gt; ::= &quot;Vertices&quot;... 进行分析
        /// <para>&lt;FileDescItem&gt; ::= &quot;Vertices&quot; &lt;SignedNumber&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FileDescItem___tail_verticesLeave;
        /// <summary>
        /// 对 &lt;FileDescItem&gt; ::= &quot;Map&quot;... 进行分析
        /// <para>&lt;FileDescItem&gt; ::= &quot;Map&quot; &lt;SignedNumber&gt; &quot;TVertices&quot; &lt;SignedNumber&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FileDescItem___tail_mapLeave;
        /// <summary>
        /// 对 &lt;Faces&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;Faces&gt; ::= &quot;{&quot; &lt;FaceList&gt; &quot;}&quot;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_Faces___tail_leftBrace_Leave;
        /// <summary>
        /// 对 &lt;FaceList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;FaceList&gt; ::= null;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FaceList___tail_rightBrace_Leave;
        /// <summary>
        /// 对 &lt;FaceList&gt; ::= &quot;Face&quot;... 进行分析
        /// <para>&lt;FaceList&gt; ::= &lt;Face&gt; &lt;FaceList&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FaceList___tail_faceLeave;
        /// <summary>
        /// 对 &lt;Face&gt; ::= &quot;Face&quot;... 进行分析
        /// <para>&lt;Face&gt; ::= &quot;Face&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &quot;MatID&quot; &lt;SignedNumber&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_Face___tail_faceLeave;
        /// <summary>
        /// 对 &lt;MapChannel&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;MapChannel&gt; ::= &quot;{&quot; &lt;TextureList&gt; &quot;}&quot;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_MapChannel___tail_leftBrace_Leave;
        /// <summary>
        /// 对 &lt;TextureList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;TextureList&gt; ::= null;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_TextureList___tail_rightBrace_Leave;
        /// <summary>
        /// 对 &lt;TextureList&gt; ::= &quot;TextureVertices&quot;... 进行分析
        /// <para>&lt;TextureList&gt; ::= &lt;Texture&gt; &lt;TextureList&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_TextureList___tail_textureVerticesLeave;
        /// <summary>
        /// 对 &lt;TextureList&gt; ::= &quot;TextureFaces&quot;... 进行分析
        /// <para>&lt;TextureList&gt; ::= &lt;Texture&gt; &lt;TextureList&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_TextureList___tail_textureFacesLeave;
        /// <summary>
        /// 对 &lt;Texture&gt; ::= &quot;TextureVertices&quot;... 进行分析
        /// <para>&lt;Texture&gt; ::= &quot;TextureVertices&quot; &lt;TextureVertices&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_Texture___tail_textureVerticesLeave;
        /// <summary>
        /// 对 &lt;Texture&gt; ::= &quot;TextureFaces&quot;... 进行分析
        /// <para>&lt;Texture&gt; ::= &quot;TextureFaces&quot; &lt;TextureFaces&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_Texture___tail_textureFacesLeave;
        /// <summary>
        /// 对 &lt;TextureVertices&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;TextureVertices&gt; ::= &quot;{&quot; &lt;TVertexList&gt; &quot;}&quot;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_TextureVertices___tail_leftBrace_Leave;
        /// <summary>
        /// 对 &lt;TVertexList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;TVertexList&gt; ::= null;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_TVertexList___tail_rightBrace_Leave;
        /// <summary>
        /// 对 &lt;TVertexList&gt; ::= &quot;TVertex&quot;... 进行分析
        /// <para>&lt;TVertexList&gt; ::= &lt;TVertex&gt; &lt;TVertexList&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_TVertexList___tail_tVertexLeave;
        /// <summary>
        /// 对 &lt;TVertex&gt; ::= &quot;TVertex&quot;... 进行分析
        /// <para>&lt;TVertex&gt; ::= &quot;TVertex&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_TVertex___tail_tVertexLeave;
        /// <summary>
        /// 对 &lt;TextureFaces&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;TextureFaces&gt; ::= &quot;{&quot; &lt;TFaceList&gt; &quot;}&quot;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_TextureFaces___tail_leftBrace_Leave;
        /// <summary>
        /// 对 &lt;TFaceList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;TFaceList&gt; ::= null;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_TFaceList___tail_rightBrace_Leave;
        /// <summary>
        /// 对 &lt;TFaceList&gt; ::= &quot;TFace&quot;... 进行分析
        /// <para>&lt;TFaceList&gt; ::= &lt;TFace&gt; &lt;TFaceList&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_TFaceList___tail_tFaceLeave;
        /// <summary>
        /// 对 &lt;TFace&gt; ::= &quot;TFace&quot;... 进行分析
        /// <para>&lt;TFace&gt; ::= &quot;TFace&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_TFace___tail_tFaceLeave;
        /// <summary>
        /// 对 &lt;Frame&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;Frame&gt; ::= &quot;{&quot; &lt;FrameContentItemList&gt; &quot;}&quot;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_Frame___tail_leftBrace_Leave;
        /// <summary>
        /// 对 &lt;FrameContentItemList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;FrameContentItemList&gt; ::= null;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FrameContentItemList___tail_rightBrace_Leave;
        /// <summary>
        /// 对 &lt;FrameContentItemList&gt; ::= &quot;Vertices&quot;... 进行分析
        /// <para>&lt;FrameContentItemList&gt; ::= &lt;FrameContentItem&gt; &lt;FrameContentItemList&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FrameContentItemList___tail_verticesLeave;
        /// <summary>
        /// 对 &lt;FrameContentItem&gt; ::= &quot;Vertices&quot;... 进行分析
        /// <para>&lt;FrameContentItem&gt; ::= &quot;Vertices&quot; &quot;{&quot; &lt;Vertices&gt; &quot;}&quot;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_FrameContentItem___tail_verticesLeave;
        /// <summary>
        /// 对 &lt;Vertices&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;Vertices&gt; ::= null;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_Vertices___tail_rightBrace_Leave;
        /// <summary>
        /// 对 &lt;Vertices&gt; ::= &quot;Vertex&quot;... 进行分析
        /// <para>&lt;Vertices&gt; ::= &lt;Vertex&gt; &lt;Vertices&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_Vertices___tail_vertexLeave;
        /// <summary>
        /// 对 &lt;Vertex&gt; ::= &quot;Vertex&quot;... 进行分析
        /// <para>&lt;Vertex&gt; ::= &quot;Vertex&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt;;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_Vertex___tail_vertexLeave;
        /// <summary>
        /// 对 &lt;SignedNumber&gt; ::= &quot;+&quot;... 进行分析
        /// <para>&lt;SignedNumber&gt; ::= &quot;+&quot; number;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_SignedNumber___tail_plus_Leave;
        /// <summary>
        /// 对 &lt;SignedNumber&gt; ::= number... 进行分析
        /// <para>&lt;SignedNumber&gt; ::= number;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_SignedNumber___numberLeave;
        /// <summary>
        /// 对 &lt;SignedNumber&gt; ::= &quot;-&quot;... 进行分析
        /// <para>&lt;SignedNumber&gt; ::= &quot;-&quot; number;</para>
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsecase_SignedNumber___tail_minus_Leave;
        
        /// <summary>
        /// 对 叶结点&quot;File&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_fileLeave_;
        /// <summary>
        /// 对 叶结点&quot;endfile&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_endfileLeave_;
        /// <summary>
        /// 对 叶结点&quot;{&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_leftBrace_Leave_;
        /// <summary>
        /// 对 叶结点&quot;}&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_rightBrace_Leave_;
        /// <summary>
        /// 对 叶结点null 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParseepsilonLeave_;
        /// <summary>
        /// 对 叶结点&quot;FileDesc&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_fileDescLeave_;
        /// <summary>
        /// 对 叶结点&quot;endfiledesc&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_endfiledescLeave_;
        /// <summary>
        /// 对 叶结点&quot;Faces&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_facesLeave_;
        /// <summary>
        /// 对 叶结点&quot;MapChannel&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_mapChannelLeave_;
        /// <summary>
        /// 对 叶结点&quot;Frame&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_frameLeave_;
        /// <summary>
        /// 对 叶结点&quot;endframe&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_endframeLeave_;
        /// <summary>
        /// 对 叶结点&quot;Frames&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_framesLeave_;
        /// <summary>
        /// 对 叶结点&quot;Vertices&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_verticesLeave_;
        /// <summary>
        /// 对 叶结点&quot;Map&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_mapLeave_;
        /// <summary>
        /// 对 叶结点&quot;TVertices&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_tVerticesLeave_;
        /// <summary>
        /// 对 叶结点&quot;Face&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_faceLeave_;
        /// <summary>
        /// 对 叶结点&quot;MatID&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_matIDLeave_;
        /// <summary>
        /// 对 叶结点&quot;TextureVertices&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_textureVerticesLeave_;
        /// <summary>
        /// 对 叶结点&quot;TextureFaces&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_textureFacesLeave_;
        /// <summary>
        /// 对 叶结点&quot;TVertex&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_tVertexLeave_;
        /// <summary>
        /// 对 叶结点&quot;TFace&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_tFaceLeave_;
        /// <summary>
        /// 对 叶结点&quot;Vertex&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_vertexLeave_;
        /// <summary>
        /// 对 叶结点&quot;+&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_plus_Leave_;
        /// <summary>
        /// 对 叶结点number 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsenumberLeave_;
        /// <summary>
        /// 对 叶结点&quot;-&quot; 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_minus_Leave_;
        /// <summary>
        /// 对 叶结点# 进行分析
        /// </summary>
        private static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            FuncParsetail_startEndLeave_;
        
        #endregion 分析表中的元素
        #region 用于分析栈操作的字段-终结点
        
        private static readonly EnumVTypeDTM m_tail_fileLeave = EnumVTypeDTM.tail_fileLeave;
        private static readonly EnumVTypeDTM m_tail_endfileLeave = EnumVTypeDTM.tail_endfileLeave;
        private static readonly EnumVTypeDTM m_tail_leftBrace_Leave = EnumVTypeDTM.tail_leftBrace_Leave;
        private static readonly EnumVTypeDTM m_tail_rightBrace_Leave = EnumVTypeDTM.tail_rightBrace_Leave;
        private static readonly EnumVTypeDTM m_epsilonLeave = EnumVTypeDTM.epsilonLeave;
        private static readonly EnumVTypeDTM m_tail_fileDescLeave = EnumVTypeDTM.tail_fileDescLeave;
        private static readonly EnumVTypeDTM m_tail_endfiledescLeave = EnumVTypeDTM.tail_endfiledescLeave;
        private static readonly EnumVTypeDTM m_tail_facesLeave = EnumVTypeDTM.tail_facesLeave;
        private static readonly EnumVTypeDTM m_tail_mapChannelLeave = EnumVTypeDTM.tail_mapChannelLeave;
        private static readonly EnumVTypeDTM m_tail_frameLeave = EnumVTypeDTM.tail_frameLeave;
        private static readonly EnumVTypeDTM m_tail_endframeLeave = EnumVTypeDTM.tail_endframeLeave;
        private static readonly EnumVTypeDTM m_tail_framesLeave = EnumVTypeDTM.tail_framesLeave;
        private static readonly EnumVTypeDTM m_tail_verticesLeave = EnumVTypeDTM.tail_verticesLeave;
        private static readonly EnumVTypeDTM m_tail_mapLeave = EnumVTypeDTM.tail_mapLeave;
        private static readonly EnumVTypeDTM m_tail_tVerticesLeave = EnumVTypeDTM.tail_tVerticesLeave;
        private static readonly EnumVTypeDTM m_tail_faceLeave = EnumVTypeDTM.tail_faceLeave;
        private static readonly EnumVTypeDTM m_tail_matIDLeave = EnumVTypeDTM.tail_matIDLeave;
        private static readonly EnumVTypeDTM m_tail_textureVerticesLeave = EnumVTypeDTM.tail_textureVerticesLeave;
        private static readonly EnumVTypeDTM m_tail_textureFacesLeave = EnumVTypeDTM.tail_textureFacesLeave;
        private static readonly EnumVTypeDTM m_tail_tVertexLeave = EnumVTypeDTM.tail_tVertexLeave;
        private static readonly EnumVTypeDTM m_tail_tFaceLeave = EnumVTypeDTM.tail_tFaceLeave;
        private static readonly EnumVTypeDTM m_tail_vertexLeave = EnumVTypeDTM.tail_vertexLeave;
        private static readonly EnumVTypeDTM m_tail_plus_Leave = EnumVTypeDTM.tail_plus_Leave;
        private static readonly EnumVTypeDTM m_numberLeave = EnumVTypeDTM.numberLeave;
        private static readonly EnumVTypeDTM m_tail_minus_Leave = EnumVTypeDTM.tail_minus_Leave;
        private static readonly EnumVTypeDTM m_tail_startEndLeave = EnumVTypeDTM.tail_startEndLeave;
        
        #endregion 用于分析栈操作的字段-终结点
        #region 用于分析栈操作的字段-非终结点
        
        private static readonly EnumVTypeDTM m_case_ArmadaTanksModel = EnumVTypeDTM.case_ArmadaTanksModel;
        private static readonly EnumVTypeDTM m_case_FileContent = EnumVTypeDTM.case_FileContent;
        private static readonly EnumVTypeDTM m_case_BlockList = EnumVTypeDTM.case_BlockList;
        private static readonly EnumVTypeDTM m_case_Block = EnumVTypeDTM.case_Block;
        private static readonly EnumVTypeDTM m_case_FileDesc = EnumVTypeDTM.case_FileDesc;
        private static readonly EnumVTypeDTM m_case_FileDescItemList = EnumVTypeDTM.case_FileDescItemList;
        private static readonly EnumVTypeDTM m_case_FileDescItem = EnumVTypeDTM.case_FileDescItem;
        private static readonly EnumVTypeDTM m_case_Faces = EnumVTypeDTM.case_Faces;
        private static readonly EnumVTypeDTM m_case_FaceList = EnumVTypeDTM.case_FaceList;
        private static readonly EnumVTypeDTM m_case_Face = EnumVTypeDTM.case_Face;
        private static readonly EnumVTypeDTM m_case_MapChannel = EnumVTypeDTM.case_MapChannel;
        private static readonly EnumVTypeDTM m_case_TextureList = EnumVTypeDTM.case_TextureList;
        private static readonly EnumVTypeDTM m_case_Texture = EnumVTypeDTM.case_Texture;
        private static readonly EnumVTypeDTM m_case_TextureVertices = EnumVTypeDTM.case_TextureVertices;
        private static readonly EnumVTypeDTM m_case_TVertexList = EnumVTypeDTM.case_TVertexList;
        private static readonly EnumVTypeDTM m_case_TVertex = EnumVTypeDTM.case_TVertex;
        private static readonly EnumVTypeDTM m_case_TextureFaces = EnumVTypeDTM.case_TextureFaces;
        private static readonly EnumVTypeDTM m_case_TFaceList = EnumVTypeDTM.case_TFaceList;
        private static readonly EnumVTypeDTM m_case_TFace = EnumVTypeDTM.case_TFace;
        private static readonly EnumVTypeDTM m_case_Frame = EnumVTypeDTM.case_Frame;
        private static readonly EnumVTypeDTM m_case_FrameContentItemList = EnumVTypeDTM.case_FrameContentItemList;
        private static readonly EnumVTypeDTM m_case_FrameContentItem = EnumVTypeDTM.case_FrameContentItem;
        private static readonly EnumVTypeDTM m_case_Vertices = EnumVTypeDTM.case_Vertices;
        private static readonly EnumVTypeDTM m_case_Vertex = EnumVTypeDTM.case_Vertex;
        private static readonly EnumVTypeDTM m_case_SignedNumber = EnumVTypeDTM.case_SignedNumber;
        
        #endregion 用于分析栈操作的字段-非终结点
        #region 获取分析表中的元素
        
        /// <summary>
        /// 对 &lt;DTM&gt; ::= &quot;File&quot;... 进行分析
        /// <para>&lt;DTM&gt; ::= &quot;File&quot; &lt;FileContent&gt; &quot;endfile&quot;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_ArmadaTanksModel___tail_fileLeave()
        {
            return FuncParsecase_ArmadaTanksModel___tail_fileLeave;
        }
        /// <summary>
        /// 对 &lt;FileContent&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;FileContent&gt; ::= &quot;{&quot; &lt;BlockList&gt; &quot;}&quot;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FileContent___tail_leftBrace_Leave()
        {
            return FuncParsecase_FileContent___tail_leftBrace_Leave;
        }
        /// <summary>
        /// 对 &lt;BlockList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;BlockList&gt; ::= null;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_BlockList___tail_rightBrace_Leave()
        {
            return FuncParsecase_BlockList___tail_rightBrace_Leave;
        }
        /// <summary>
        /// 对 &lt;BlockList&gt; ::= &quot;FileDesc&quot;... 进行分析
        /// <para>&lt;BlockList&gt; ::= &lt;Block&gt; &lt;BlockList&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_BlockList___tail_fileDescLeave()
        {
            return FuncParsecase_BlockList___tail_fileDescLeave;
        }
        /// <summary>
        /// 对 &lt;BlockList&gt; ::= &quot;Faces&quot;... 进行分析
        /// <para>&lt;BlockList&gt; ::= &lt;Block&gt; &lt;BlockList&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_BlockList___tail_facesLeave()
        {
            return FuncParsecase_BlockList___tail_facesLeave;
        }
        /// <summary>
        /// 对 &lt;BlockList&gt; ::= &quot;MapChannel&quot;... 进行分析
        /// <para>&lt;BlockList&gt; ::= &lt;Block&gt; &lt;BlockList&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_BlockList___tail_mapChannelLeave()
        {
            return FuncParsecase_BlockList___tail_mapChannelLeave;
        }
        /// <summary>
        /// 对 &lt;BlockList&gt; ::= &quot;Frame&quot;... 进行分析
        /// <para>&lt;BlockList&gt; ::= &lt;Block&gt; &lt;BlockList&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_BlockList___tail_frameLeave()
        {
            return FuncParsecase_BlockList___tail_frameLeave;
        }
        /// <summary>
        /// 对 &lt;Block&gt; ::= &quot;FileDesc&quot;... 进行分析
        /// <para>&lt;Block&gt; ::= &quot;FileDesc&quot; &lt;FileDesc&gt; &quot;endfiledesc&quot;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_Block___tail_fileDescLeave()
        {
            return FuncParsecase_Block___tail_fileDescLeave;
        }
        /// <summary>
        /// 对 &lt;Block&gt; ::= &quot;Faces&quot;... 进行分析
        /// <para>&lt;Block&gt; ::= &quot;Faces&quot; &lt;Faces&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_Block___tail_facesLeave()
        {
            return FuncParsecase_Block___tail_facesLeave;
        }
        /// <summary>
        /// 对 &lt;Block&gt; ::= &quot;MapChannel&quot;... 进行分析
        /// <para>&lt;Block&gt; ::= &quot;MapChannel&quot; &lt;SignedNumber&gt; &lt;MapChannel&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_Block___tail_mapChannelLeave()
        {
            return FuncParsecase_Block___tail_mapChannelLeave;
        }
        /// <summary>
        /// 对 &lt;Block&gt; ::= &quot;Frame&quot;... 进行分析
        /// <para>&lt;Block&gt; ::= &quot;Frame&quot; &lt;SignedNumber&gt; &lt;Frame&gt; &quot;endframe&quot;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_Block___tail_frameLeave()
        {
            return FuncParsecase_Block___tail_frameLeave;
        }
        /// <summary>
        /// 对 &lt;FileDesc&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;FileDesc&gt; ::= &quot;{&quot; &lt;FileDescItemList&gt; &quot;}&quot;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FileDesc___tail_leftBrace_Leave()
        {
            return FuncParsecase_FileDesc___tail_leftBrace_Leave;
        }
        /// <summary>
        /// 对 &lt;FileDescItemList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;FileDescItemList&gt; ::= null;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FileDescItemList___tail_rightBrace_Leave()
        {
            return FuncParsecase_FileDescItemList___tail_rightBrace_Leave;
        }
        /// <summary>
        /// 对 &lt;FileDescItemList&gt; ::= &quot;Faces&quot;... 进行分析
        /// <para>&lt;FileDescItemList&gt; ::= &lt;FileDescItem&gt; &lt;FileDescItemList&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FileDescItemList___tail_facesLeave()
        {
            return FuncParsecase_FileDescItemList___tail_facesLeave;
        }
        /// <summary>
        /// 对 &lt;FileDescItemList&gt; ::= &quot;Frames&quot;... 进行分析
        /// <para>&lt;FileDescItemList&gt; ::= &lt;FileDescItem&gt; &lt;FileDescItemList&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FileDescItemList___tail_framesLeave()
        {
            return FuncParsecase_FileDescItemList___tail_framesLeave;
        }
        /// <summary>
        /// 对 &lt;FileDescItemList&gt; ::= &quot;Vertices&quot;... 进行分析
        /// <para>&lt;FileDescItemList&gt; ::= &lt;FileDescItem&gt; &lt;FileDescItemList&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FileDescItemList___tail_verticesLeave()
        {
            return FuncParsecase_FileDescItemList___tail_verticesLeave;
        }
        /// <summary>
        /// 对 &lt;FileDescItemList&gt; ::= &quot;Map&quot;... 进行分析
        /// <para>&lt;FileDescItemList&gt; ::= &lt;FileDescItem&gt; &lt;FileDescItemList&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FileDescItemList___tail_mapLeave()
        {
            return FuncParsecase_FileDescItemList___tail_mapLeave;
        }
        /// <summary>
        /// 对 &lt;FileDescItem&gt; ::= &quot;Faces&quot;... 进行分析
        /// <para>&lt;FileDescItem&gt; ::= &quot;Faces&quot; &lt;SignedNumber&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FileDescItem___tail_facesLeave()
        {
            return FuncParsecase_FileDescItem___tail_facesLeave;
        }
        /// <summary>
        /// 对 &lt;FileDescItem&gt; ::= &quot;Frames&quot;... 进行分析
        /// <para>&lt;FileDescItem&gt; ::= &quot;Frames&quot; &lt;SignedNumber&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FileDescItem___tail_framesLeave()
        {
            return FuncParsecase_FileDescItem___tail_framesLeave;
        }
        /// <summary>
        /// 对 &lt;FileDescItem&gt; ::= &quot;Vertices&quot;... 进行分析
        /// <para>&lt;FileDescItem&gt; ::= &quot;Vertices&quot; &lt;SignedNumber&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FileDescItem___tail_verticesLeave()
        {
            return FuncParsecase_FileDescItem___tail_verticesLeave;
        }
        /// <summary>
        /// 对 &lt;FileDescItem&gt; ::= &quot;Map&quot;... 进行分析
        /// <para>&lt;FileDescItem&gt; ::= &quot;Map&quot; &lt;SignedNumber&gt; &quot;TVertices&quot; &lt;SignedNumber&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FileDescItem___tail_mapLeave()
        {
            return FuncParsecase_FileDescItem___tail_mapLeave;
        }
        /// <summary>
        /// 对 &lt;Faces&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;Faces&gt; ::= &quot;{&quot; &lt;FaceList&gt; &quot;}&quot;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_Faces___tail_leftBrace_Leave()
        {
            return FuncParsecase_Faces___tail_leftBrace_Leave;
        }
        /// <summary>
        /// 对 &lt;FaceList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;FaceList&gt; ::= null;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FaceList___tail_rightBrace_Leave()
        {
            return FuncParsecase_FaceList___tail_rightBrace_Leave;
        }
        /// <summary>
        /// 对 &lt;FaceList&gt; ::= &quot;Face&quot;... 进行分析
        /// <para>&lt;FaceList&gt; ::= &lt;Face&gt; &lt;FaceList&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FaceList___tail_faceLeave()
        {
            return FuncParsecase_FaceList___tail_faceLeave;
        }
        /// <summary>
        /// 对 &lt;Face&gt; ::= &quot;Face&quot;... 进行分析
        /// <para>&lt;Face&gt; ::= &quot;Face&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &quot;MatID&quot; &lt;SignedNumber&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_Face___tail_faceLeave()
        {
            return FuncParsecase_Face___tail_faceLeave;
        }
        /// <summary>
        /// 对 &lt;MapChannel&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;MapChannel&gt; ::= &quot;{&quot; &lt;TextureList&gt; &quot;}&quot;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_MapChannel___tail_leftBrace_Leave()
        {
            return FuncParsecase_MapChannel___tail_leftBrace_Leave;
        }
        /// <summary>
        /// 对 &lt;TextureList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;TextureList&gt; ::= null;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_TextureList___tail_rightBrace_Leave()
        {
            return FuncParsecase_TextureList___tail_rightBrace_Leave;
        }
        /// <summary>
        /// 对 &lt;TextureList&gt; ::= &quot;TextureVertices&quot;... 进行分析
        /// <para>&lt;TextureList&gt; ::= &lt;Texture&gt; &lt;TextureList&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_TextureList___tail_textureVerticesLeave()
        {
            return FuncParsecase_TextureList___tail_textureVerticesLeave;
        }
        /// <summary>
        /// 对 &lt;TextureList&gt; ::= &quot;TextureFaces&quot;... 进行分析
        /// <para>&lt;TextureList&gt; ::= &lt;Texture&gt; &lt;TextureList&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_TextureList___tail_textureFacesLeave()
        {
            return FuncParsecase_TextureList___tail_textureFacesLeave;
        }
        /// <summary>
        /// 对 &lt;Texture&gt; ::= &quot;TextureVertices&quot;... 进行分析
        /// <para>&lt;Texture&gt; ::= &quot;TextureVertices&quot; &lt;TextureVertices&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_Texture___tail_textureVerticesLeave()
        {
            return FuncParsecase_Texture___tail_textureVerticesLeave;
        }
        /// <summary>
        /// 对 &lt;Texture&gt; ::= &quot;TextureFaces&quot;... 进行分析
        /// <para>&lt;Texture&gt; ::= &quot;TextureFaces&quot; &lt;TextureFaces&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_Texture___tail_textureFacesLeave()
        {
            return FuncParsecase_Texture___tail_textureFacesLeave;
        }
        /// <summary>
        /// 对 &lt;TextureVertices&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;TextureVertices&gt; ::= &quot;{&quot; &lt;TVertexList&gt; &quot;}&quot;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_TextureVertices___tail_leftBrace_Leave()
        {
            return FuncParsecase_TextureVertices___tail_leftBrace_Leave;
        }
        /// <summary>
        /// 对 &lt;TVertexList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;TVertexList&gt; ::= null;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_TVertexList___tail_rightBrace_Leave()
        {
            return FuncParsecase_TVertexList___tail_rightBrace_Leave;
        }
        /// <summary>
        /// 对 &lt;TVertexList&gt; ::= &quot;TVertex&quot;... 进行分析
        /// <para>&lt;TVertexList&gt; ::= &lt;TVertex&gt; &lt;TVertexList&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_TVertexList___tail_tVertexLeave()
        {
            return FuncParsecase_TVertexList___tail_tVertexLeave;
        }
        /// <summary>
        /// 对 &lt;TVertex&gt; ::= &quot;TVertex&quot;... 进行分析
        /// <para>&lt;TVertex&gt; ::= &quot;TVertex&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_TVertex___tail_tVertexLeave()
        {
            return FuncParsecase_TVertex___tail_tVertexLeave;
        }
        /// <summary>
        /// 对 &lt;TextureFaces&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;TextureFaces&gt; ::= &quot;{&quot; &lt;TFaceList&gt; &quot;}&quot;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_TextureFaces___tail_leftBrace_Leave()
        {
            return FuncParsecase_TextureFaces___tail_leftBrace_Leave;
        }
        /// <summary>
        /// 对 &lt;TFaceList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;TFaceList&gt; ::= null;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_TFaceList___tail_rightBrace_Leave()
        {
            return FuncParsecase_TFaceList___tail_rightBrace_Leave;
        }
        /// <summary>
        /// 对 &lt;TFaceList&gt; ::= &quot;TFace&quot;... 进行分析
        /// <para>&lt;TFaceList&gt; ::= &lt;TFace&gt; &lt;TFaceList&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_TFaceList___tail_tFaceLeave()
        {
            return FuncParsecase_TFaceList___tail_tFaceLeave;
        }
        /// <summary>
        /// 对 &lt;TFace&gt; ::= &quot;TFace&quot;... 进行分析
        /// <para>&lt;TFace&gt; ::= &quot;TFace&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_TFace___tail_tFaceLeave()
        {
            return FuncParsecase_TFace___tail_tFaceLeave;
        }
        /// <summary>
        /// 对 &lt;Frame&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;Frame&gt; ::= &quot;{&quot; &lt;FrameContentItemList&gt; &quot;}&quot;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_Frame___tail_leftBrace_Leave()
        {
            return FuncParsecase_Frame___tail_leftBrace_Leave;
        }
        /// <summary>
        /// 对 &lt;FrameContentItemList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;FrameContentItemList&gt; ::= null;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FrameContentItemList___tail_rightBrace_Leave()
        {
            return FuncParsecase_FrameContentItemList___tail_rightBrace_Leave;
        }
        /// <summary>
        /// 对 &lt;FrameContentItemList&gt; ::= &quot;Vertices&quot;... 进行分析
        /// <para>&lt;FrameContentItemList&gt; ::= &lt;FrameContentItem&gt; &lt;FrameContentItemList&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FrameContentItemList___tail_verticesLeave()
        {
            return FuncParsecase_FrameContentItemList___tail_verticesLeave;
        }
        /// <summary>
        /// 对 &lt;FrameContentItem&gt; ::= &quot;Vertices&quot;... 进行分析
        /// <para>&lt;FrameContentItem&gt; ::= &quot;Vertices&quot; &quot;{&quot; &lt;Vertices&gt; &quot;}&quot;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_FrameContentItem___tail_verticesLeave()
        {
            return FuncParsecase_FrameContentItem___tail_verticesLeave;
        }
        /// <summary>
        /// 对 &lt;Vertices&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;Vertices&gt; ::= null;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_Vertices___tail_rightBrace_Leave()
        {
            return FuncParsecase_Vertices___tail_rightBrace_Leave;
        }
        /// <summary>
        /// 对 &lt;Vertices&gt; ::= &quot;Vertex&quot;... 进行分析
        /// <para>&lt;Vertices&gt; ::= &lt;Vertex&gt; &lt;Vertices&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_Vertices___tail_vertexLeave()
        {
            return FuncParsecase_Vertices___tail_vertexLeave;
        }
        /// <summary>
        /// 对 &lt;Vertex&gt; ::= &quot;Vertex&quot;... 进行分析
        /// <para>&lt;Vertex&gt; ::= &quot;Vertex&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt;;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_Vertex___tail_vertexLeave()
        {
            return FuncParsecase_Vertex___tail_vertexLeave;
        }
        /// <summary>
        /// 对 &lt;SignedNumber&gt; ::= &quot;+&quot;... 进行分析
        /// <para>&lt;SignedNumber&gt; ::= &quot;+&quot; number;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_SignedNumber___tail_plus_Leave()
        {
            return FuncParsecase_SignedNumber___tail_plus_Leave;
        }
        /// <summary>
        /// 对 &lt;SignedNumber&gt; ::= number... 进行分析
        /// <para>&lt;SignedNumber&gt; ::= number;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_SignedNumber___numberLeave()
        {
            return FuncParsecase_SignedNumber___numberLeave;
        }
        /// <summary>
        /// 对 &lt;SignedNumber&gt; ::= &quot;-&quot;... 进行分析
        /// <para>&lt;SignedNumber&gt; ::= &quot;-&quot; number;</para>
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsecase_SignedNumber___tail_minus_Leave()
        {
            return FuncParsecase_SignedNumber___tail_minus_Leave;
        }
        
        /// <summary>
        /// 对 叶结点&quot;File&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_fileLeave_()
        {
            return FuncParsetail_fileLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;endfile&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_endfileLeave_()
        {
            return FuncParsetail_endfileLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;{&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_leftBrace_Leave_()
        {
            return FuncParsetail_leftBrace_Leave_;
        }
        /// <summary>
        /// 对 叶结点&quot;}&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_rightBrace_Leave_()
        {
            return FuncParsetail_rightBrace_Leave_;
        }
        /// <summary>
        /// 对 叶结点null 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParseepsilonLeave_()
        {
            return FuncParseepsilonLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;FileDesc&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_fileDescLeave_()
        {
            return FuncParsetail_fileDescLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;endfiledesc&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_endfiledescLeave_()
        {
            return FuncParsetail_endfiledescLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;Faces&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_facesLeave_()
        {
            return FuncParsetail_facesLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;MapChannel&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_mapChannelLeave_()
        {
            return FuncParsetail_mapChannelLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;Frame&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_frameLeave_()
        {
            return FuncParsetail_frameLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;endframe&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_endframeLeave_()
        {
            return FuncParsetail_endframeLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;Frames&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_framesLeave_()
        {
            return FuncParsetail_framesLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;Vertices&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_verticesLeave_()
        {
            return FuncParsetail_verticesLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;Map&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_mapLeave_()
        {
            return FuncParsetail_mapLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;TVertices&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_tVerticesLeave_()
        {
            return FuncParsetail_tVerticesLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;Face&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_faceLeave_()
        {
            return FuncParsetail_faceLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;MatID&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_matIDLeave_()
        {
            return FuncParsetail_matIDLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;TextureVertices&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_textureVerticesLeave_()
        {
            return FuncParsetail_textureVerticesLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;TextureFaces&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_textureFacesLeave_()
        {
            return FuncParsetail_textureFacesLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;TVertex&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_tVertexLeave_()
        {
            return FuncParsetail_tVertexLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;TFace&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_tFaceLeave_()
        {
            return FuncParsetail_tFaceLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;Vertex&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_vertexLeave_()
        {
            return FuncParsetail_vertexLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;+&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_plus_Leave_()
        {
            return FuncParsetail_plus_Leave_;
        }
        /// <summary>
        /// 对 叶结点number 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsenumberLeave_()
        {
            return FuncParsenumberLeave_;
        }
        /// <summary>
        /// 对 叶结点&quot;-&quot; 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_minus_Leave_()
        {
            return FuncParsetail_minus_Leave_;
        }
        /// <summary>
        /// 对 叶结点# 进行分析
        /// </summary>
        public static CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            GetFuncParsetail_startEndLeave_()
        {
            return FuncParsetail_startEndLeave_;
        }
        
        #endregion 获取分析表中的元素
        #region 分析表中的元素指向的分析函数
        
        /// <summary>
        /// 对 &lt;DTM&gt; ::= &quot;File&quot;... 进行分析
        /// <para>&lt;DTM&gt; ::= &quot;File&quot; &lt;FileContent&gt; &quot;endfile&quot;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_ArmadaTanksModel___tail_fileLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <DTM> ::= "File" <FileContent> "endfile";
            return Derivationcase_ArmadaTanksModel___tail_fileLeavecase_FileContenttail_endfileLeave(result, parser);
        }
        /// <summary>
        /// 对 &lt;FileContent&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;FileContent&gt; ::= &quot;{&quot; &lt;BlockList&gt; &quot;}&quot;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FileContent___tail_leftBrace_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FileContent> ::= "{" <BlockList> "}";
            return Derivationcase_FileContent___tail_leftBrace_Leavecase_BlockListtail_rightBrace_Leave(result, parser);
        }
        /// <summary>
        /// 对 &lt;BlockList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;BlockList&gt; ::= null;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_BlockList___tail_rightBrace_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <BlockList> ::= null;
            return Derivationcase_BlockList___epsilonLeave(result, parser);
        }
        /// <summary>
        /// 对 &lt;BlockList&gt; ::= &quot;FileDesc&quot;... 进行分析
        /// <para>&lt;BlockList&gt; ::= &lt;Block&gt; &lt;BlockList&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_BlockList___tail_fileDescLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <BlockList> ::= <Block> <BlockList>;
            return Derivationcase_BlockList___case_Blockcase_BlockList(result, parser);
        }
        /// <summary>
        /// 对 &lt;BlockList&gt; ::= &quot;Faces&quot;... 进行分析
        /// <para>&lt;BlockList&gt; ::= &lt;Block&gt; &lt;BlockList&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_BlockList___tail_facesLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <BlockList> ::= <Block> <BlockList>;
            return Derivationcase_BlockList___case_Blockcase_BlockList(result, parser);
        }
        /// <summary>
        /// 对 &lt;BlockList&gt; ::= &quot;MapChannel&quot;... 进行分析
        /// <para>&lt;BlockList&gt; ::= &lt;Block&gt; &lt;BlockList&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_BlockList___tail_mapChannelLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <BlockList> ::= <Block> <BlockList>;
            return Derivationcase_BlockList___case_Blockcase_BlockList(result, parser);
        }
        /// <summary>
        /// 对 &lt;BlockList&gt; ::= &quot;Frame&quot;... 进行分析
        /// <para>&lt;BlockList&gt; ::= &lt;Block&gt; &lt;BlockList&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_BlockList___tail_frameLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <BlockList> ::= <Block> <BlockList>;
            return Derivationcase_BlockList___case_Blockcase_BlockList(result, parser);
        }
        /// <summary>
        /// 对 &lt;Block&gt; ::= &quot;FileDesc&quot;... 进行分析
        /// <para>&lt;Block&gt; ::= &quot;FileDesc&quot; &lt;FileDesc&gt; &quot;endfiledesc&quot;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_Block___tail_fileDescLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <Block> ::= "FileDesc" <FileDesc> "endfiledesc";
            return Derivationcase_Block___tail_fileDescLeavecase_FileDesctail_endfiledescLeave(result, parser);
        }
        /// <summary>
        /// 对 &lt;Block&gt; ::= &quot;Faces&quot;... 进行分析
        /// <para>&lt;Block&gt; ::= &quot;Faces&quot; &lt;Faces&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_Block___tail_facesLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <Block> ::= "Faces" <Faces>;
            return Derivationcase_Block___tail_facesLeavecase_Faces(result, parser);
        }
        /// <summary>
        /// 对 &lt;Block&gt; ::= &quot;MapChannel&quot;... 进行分析
        /// <para>&lt;Block&gt; ::= &quot;MapChannel&quot; &lt;SignedNumber&gt; &lt;MapChannel&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_Block___tail_mapChannelLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <Block> ::= "MapChannel" <SignedNumber> <MapChannel>;
            return Derivationcase_Block___tail_mapChannelLeavecase_SignedNumbercase_MapChannel(result, parser);
        }
        /// <summary>
        /// 对 &lt;Block&gt; ::= &quot;Frame&quot;... 进行分析
        /// <para>&lt;Block&gt; ::= &quot;Frame&quot; &lt;SignedNumber&gt; &lt;Frame&gt; &quot;endframe&quot;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_Block___tail_frameLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <Block> ::= "Frame" <SignedNumber> <Frame> "endframe";
            return Derivationcase_Block___tail_frameLeavecase_SignedNumbercase_Frametail_endframeLeave(result, parser);
        }
        /// <summary>
        /// 对 &lt;FileDesc&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;FileDesc&gt; ::= &quot;{&quot; &lt;FileDescItemList&gt; &quot;}&quot;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FileDesc___tail_leftBrace_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FileDesc> ::= "{" <FileDescItemList> "}";
            return Derivationcase_FileDesc___tail_leftBrace_Leavecase_FileDescItemListtail_rightBrace_Leave(result, parser);
        }
        /// <summary>
        /// 对 &lt;FileDescItemList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;FileDescItemList&gt; ::= null;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FileDescItemList___tail_rightBrace_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FileDescItemList> ::= null;
            return Derivationcase_FileDescItemList___epsilonLeave(result, parser);
        }
        /// <summary>
        /// 对 &lt;FileDescItemList&gt; ::= &quot;Faces&quot;... 进行分析
        /// <para>&lt;FileDescItemList&gt; ::= &lt;FileDescItem&gt; &lt;FileDescItemList&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FileDescItemList___tail_facesLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FileDescItemList> ::= <FileDescItem> <FileDescItemList>;
            return Derivationcase_FileDescItemList___case_FileDescItemcase_FileDescItemList(result, parser);
        }
        /// <summary>
        /// 对 &lt;FileDescItemList&gt; ::= &quot;Frames&quot;... 进行分析
        /// <para>&lt;FileDescItemList&gt; ::= &lt;FileDescItem&gt; &lt;FileDescItemList&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FileDescItemList___tail_framesLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FileDescItemList> ::= <FileDescItem> <FileDescItemList>;
            return Derivationcase_FileDescItemList___case_FileDescItemcase_FileDescItemList(result, parser);
        }
        /// <summary>
        /// 对 &lt;FileDescItemList&gt; ::= &quot;Vertices&quot;... 进行分析
        /// <para>&lt;FileDescItemList&gt; ::= &lt;FileDescItem&gt; &lt;FileDescItemList&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FileDescItemList___tail_verticesLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FileDescItemList> ::= <FileDescItem> <FileDescItemList>;
            return Derivationcase_FileDescItemList___case_FileDescItemcase_FileDescItemList(result, parser);
        }
        /// <summary>
        /// 对 &lt;FileDescItemList&gt; ::= &quot;Map&quot;... 进行分析
        /// <para>&lt;FileDescItemList&gt; ::= &lt;FileDescItem&gt; &lt;FileDescItemList&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FileDescItemList___tail_mapLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FileDescItemList> ::= <FileDescItem> <FileDescItemList>;
            return Derivationcase_FileDescItemList___case_FileDescItemcase_FileDescItemList(result, parser);
        }
        /// <summary>
        /// 对 &lt;FileDescItem&gt; ::= &quot;Faces&quot;... 进行分析
        /// <para>&lt;FileDescItem&gt; ::= &quot;Faces&quot; &lt;SignedNumber&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FileDescItem___tail_facesLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FileDescItem> ::= "Faces" <SignedNumber>;
            return Derivationcase_FileDescItem___tail_facesLeavecase_SignedNumber(result, parser);
        }
        /// <summary>
        /// 对 &lt;FileDescItem&gt; ::= &quot;Frames&quot;... 进行分析
        /// <para>&lt;FileDescItem&gt; ::= &quot;Frames&quot; &lt;SignedNumber&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FileDescItem___tail_framesLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FileDescItem> ::= "Frames" <SignedNumber>;
            return Derivationcase_FileDescItem___tail_framesLeavecase_SignedNumber(result, parser);
        }
        /// <summary>
        /// 对 &lt;FileDescItem&gt; ::= &quot;Vertices&quot;... 进行分析
        /// <para>&lt;FileDescItem&gt; ::= &quot;Vertices&quot; &lt;SignedNumber&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FileDescItem___tail_verticesLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FileDescItem> ::= "Vertices" <SignedNumber>;
            return Derivationcase_FileDescItem___tail_verticesLeavecase_SignedNumber(result, parser);
        }
        /// <summary>
        /// 对 &lt;FileDescItem&gt; ::= &quot;Map&quot;... 进行分析
        /// <para>&lt;FileDescItem&gt; ::= &quot;Map&quot; &lt;SignedNumber&gt; &quot;TVertices&quot; &lt;SignedNumber&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FileDescItem___tail_mapLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FileDescItem> ::= "Map" <SignedNumber> "TVertices" <SignedNumber>;
            return Derivationcase_FileDescItem___tail_mapLeavecase_SignedNumbertail_tVerticesLeavecase_SignedNumber(result, parser);
        }
        /// <summary>
        /// 对 &lt;Faces&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;Faces&gt; ::= &quot;{&quot; &lt;FaceList&gt; &quot;}&quot;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_Faces___tail_leftBrace_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <Faces> ::= "{" <FaceList> "}";
            return Derivationcase_Faces___tail_leftBrace_Leavecase_FaceListtail_rightBrace_Leave(result, parser);
        }
        /// <summary>
        /// 对 &lt;FaceList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;FaceList&gt; ::= null;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FaceList___tail_rightBrace_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FaceList> ::= null;
            return Derivationcase_FaceList___epsilonLeave(result, parser);
        }
        /// <summary>
        /// 对 &lt;FaceList&gt; ::= &quot;Face&quot;... 进行分析
        /// <para>&lt;FaceList&gt; ::= &lt;Face&gt; &lt;FaceList&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FaceList___tail_faceLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FaceList> ::= <Face> <FaceList>;
            return Derivationcase_FaceList___case_Facecase_FaceList(result, parser);
        }
        /// <summary>
        /// 对 &lt;Face&gt; ::= &quot;Face&quot;... 进行分析
        /// <para>&lt;Face&gt; ::= &quot;Face&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &quot;MatID&quot; &lt;SignedNumber&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_Face___tail_faceLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <Face> ::= "Face" <SignedNumber> <SignedNumber> <SignedNumber> <SignedNumber> "MatID" <SignedNumber>;
            return Derivationcase_Face___tail_faceLeavecase_SignedNumbercase_SignedNumbercase_SignedNumbercase_SignedNumbertail_matIDLeavecase_SignedNumber(result, parser);
        }
        /// <summary>
        /// 对 &lt;MapChannel&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;MapChannel&gt; ::= &quot;{&quot; &lt;TextureList&gt; &quot;}&quot;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_MapChannel___tail_leftBrace_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <MapChannel> ::= "{" <TextureList> "}";
            return Derivationcase_MapChannel___tail_leftBrace_Leavecase_TextureListtail_rightBrace_Leave(result, parser);
        }
        /// <summary>
        /// 对 &lt;TextureList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;TextureList&gt; ::= null;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_TextureList___tail_rightBrace_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <TextureList> ::= null;
            return Derivationcase_TextureList___epsilonLeave(result, parser);
        }
        /// <summary>
        /// 对 &lt;TextureList&gt; ::= &quot;TextureVertices&quot;... 进行分析
        /// <para>&lt;TextureList&gt; ::= &lt;Texture&gt; &lt;TextureList&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_TextureList___tail_textureVerticesLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <TextureList> ::= <Texture> <TextureList>;
            return Derivationcase_TextureList___case_Texturecase_TextureList(result, parser);
        }
        /// <summary>
        /// 对 &lt;TextureList&gt; ::= &quot;TextureFaces&quot;... 进行分析
        /// <para>&lt;TextureList&gt; ::= &lt;Texture&gt; &lt;TextureList&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_TextureList___tail_textureFacesLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <TextureList> ::= <Texture> <TextureList>;
            return Derivationcase_TextureList___case_Texturecase_TextureList(result, parser);
        }
        /// <summary>
        /// 对 &lt;Texture&gt; ::= &quot;TextureVertices&quot;... 进行分析
        /// <para>&lt;Texture&gt; ::= &quot;TextureVertices&quot; &lt;TextureVertices&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_Texture___tail_textureVerticesLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <Texture> ::= "TextureVertices" <TextureVertices>;
            return Derivationcase_Texture___tail_textureVerticesLeavecase_TextureVertices(result, parser);
        }
        /// <summary>
        /// 对 &lt;Texture&gt; ::= &quot;TextureFaces&quot;... 进行分析
        /// <para>&lt;Texture&gt; ::= &quot;TextureFaces&quot; &lt;TextureFaces&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_Texture___tail_textureFacesLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <Texture> ::= "TextureFaces" <TextureFaces>;
            return Derivationcase_Texture___tail_textureFacesLeavecase_TextureFaces(result, parser);
        }
        /// <summary>
        /// 对 &lt;TextureVertices&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;TextureVertices&gt; ::= &quot;{&quot; &lt;TVertexList&gt; &quot;}&quot;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_TextureVertices___tail_leftBrace_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <TextureVertices> ::= "{" <TVertexList> "}";
            return Derivationcase_TextureVertices___tail_leftBrace_Leavecase_TVertexListtail_rightBrace_Leave(result, parser);
        }
        /// <summary>
        /// 对 &lt;TVertexList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;TVertexList&gt; ::= null;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_TVertexList___tail_rightBrace_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <TVertexList> ::= null;
            return Derivationcase_TVertexList___epsilonLeave(result, parser);
        }
        /// <summary>
        /// 对 &lt;TVertexList&gt; ::= &quot;TVertex&quot;... 进行分析
        /// <para>&lt;TVertexList&gt; ::= &lt;TVertex&gt; &lt;TVertexList&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_TVertexList___tail_tVertexLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <TVertexList> ::= <TVertex> <TVertexList>;
            return Derivationcase_TVertexList___case_TVertexcase_TVertexList(result, parser);
        }
        /// <summary>
        /// 对 &lt;TVertex&gt; ::= &quot;TVertex&quot;... 进行分析
        /// <para>&lt;TVertex&gt; ::= &quot;TVertex&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_TVertex___tail_tVertexLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <TVertex> ::= "TVertex" <SignedNumber> <SignedNumber> <SignedNumber> <SignedNumber>;
            return Derivationcase_TVertex___tail_tVertexLeavecase_SignedNumbercase_SignedNumbercase_SignedNumbercase_SignedNumber(result, parser);
        }
        /// <summary>
        /// 对 &lt;TextureFaces&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;TextureFaces&gt; ::= &quot;{&quot; &lt;TFaceList&gt; &quot;}&quot;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_TextureFaces___tail_leftBrace_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <TextureFaces> ::= "{" <TFaceList> "}";
            return Derivationcase_TextureFaces___tail_leftBrace_Leavecase_TFaceListtail_rightBrace_Leave(result, parser);
        }
        /// <summary>
        /// 对 &lt;TFaceList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;TFaceList&gt; ::= null;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_TFaceList___tail_rightBrace_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <TFaceList> ::= null;
            return Derivationcase_TFaceList___epsilonLeave(result, parser);
        }
        /// <summary>
        /// 对 &lt;TFaceList&gt; ::= &quot;TFace&quot;... 进行分析
        /// <para>&lt;TFaceList&gt; ::= &lt;TFace&gt; &lt;TFaceList&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_TFaceList___tail_tFaceLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <TFaceList> ::= <TFace> <TFaceList>;
            return Derivationcase_TFaceList___case_TFacecase_TFaceList(result, parser);
        }
        /// <summary>
        /// 对 &lt;TFace&gt; ::= &quot;TFace&quot;... 进行分析
        /// <para>&lt;TFace&gt; ::= &quot;TFace&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_TFace___tail_tFaceLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <TFace> ::= "TFace" <SignedNumber> <SignedNumber> <SignedNumber> <SignedNumber>;
            return Derivationcase_TFace___tail_tFaceLeavecase_SignedNumbercase_SignedNumbercase_SignedNumbercase_SignedNumber(result, parser);
        }
        /// <summary>
        /// 对 &lt;Frame&gt; ::= &quot;{&quot;... 进行分析
        /// <para>&lt;Frame&gt; ::= &quot;{&quot; &lt;FrameContentItemList&gt; &quot;}&quot;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_Frame___tail_leftBrace_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <Frame> ::= "{" <FrameContentItemList> "}";
            return Derivationcase_Frame___tail_leftBrace_Leavecase_FrameContentItemListtail_rightBrace_Leave(result, parser);
        }
        /// <summary>
        /// 对 &lt;FrameContentItemList&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;FrameContentItemList&gt; ::= null;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FrameContentItemList___tail_rightBrace_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FrameContentItemList> ::= null;
            return Derivationcase_FrameContentItemList___epsilonLeave(result, parser);
        }
        /// <summary>
        /// 对 &lt;FrameContentItemList&gt; ::= &quot;Vertices&quot;... 进行分析
        /// <para>&lt;FrameContentItemList&gt; ::= &lt;FrameContentItem&gt; &lt;FrameContentItemList&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FrameContentItemList___tail_verticesLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FrameContentItemList> ::= <FrameContentItem> <FrameContentItemList>;
            return Derivationcase_FrameContentItemList___case_FrameContentItemcase_FrameContentItemList(result, parser);
        }
        /// <summary>
        /// 对 &lt;FrameContentItem&gt; ::= &quot;Vertices&quot;... 进行分析
        /// <para>&lt;FrameContentItem&gt; ::= &quot;Vertices&quot; &quot;{&quot; &lt;Vertices&gt; &quot;}&quot;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_FrameContentItem___tail_verticesLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <FrameContentItem> ::= "Vertices" "{" <Vertices> "}";
            return Derivationcase_FrameContentItem___tail_verticesLeavetail_leftBrace_Leavecase_Verticestail_rightBrace_Leave(result, parser);
        }
        /// <summary>
        /// 对 &lt;Vertices&gt; ::= &quot;}&quot;... 进行分析
        /// <para>&lt;Vertices&gt; ::= null;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_Vertices___tail_rightBrace_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <Vertices> ::= null;
            return Derivationcase_Vertices___epsilonLeave(result, parser);
        }
        /// <summary>
        /// 对 &lt;Vertices&gt; ::= &quot;Vertex&quot;... 进行分析
        /// <para>&lt;Vertices&gt; ::= &lt;Vertex&gt; &lt;Vertices&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_Vertices___tail_vertexLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <Vertices> ::= <Vertex> <Vertices>;
            return Derivationcase_Vertices___case_Vertexcase_Vertices(result, parser);
        }
        /// <summary>
        /// 对 &lt;Vertex&gt; ::= &quot;Vertex&quot;... 进行分析
        /// <para>&lt;Vertex&gt; ::= &quot;Vertex&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt;;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_Vertex___tail_vertexLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <Vertex> ::= "Vertex" <SignedNumber> <SignedNumber> <SignedNumber> <SignedNumber>;
            return Derivationcase_Vertex___tail_vertexLeavecase_SignedNumbercase_SignedNumbercase_SignedNumbercase_SignedNumber(result, parser);
        }
        /// <summary>
        /// 对 &lt;SignedNumber&gt; ::= &quot;+&quot;... 进行分析
        /// <para>&lt;SignedNumber&gt; ::= &quot;+&quot; number;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_SignedNumber___tail_plus_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <SignedNumber> ::= "+" number;
            return Derivationcase_SignedNumber___tail_plus_LeavenumberLeave(result, parser);
        }
        /// <summary>
        /// 对 &lt;SignedNumber&gt; ::= number... 进行分析
        /// <para>&lt;SignedNumber&gt; ::= number;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_SignedNumber___numberLeave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <SignedNumber> ::= number;
            return Derivationcase_SignedNumber___numberLeave(result, parser);
        }
        /// <summary>
        /// 对 &lt;SignedNumber&gt; ::= &quot;-&quot;... 进行分析
        /// <para>&lt;SignedNumber&gt; ::= &quot;-&quot; number;</para>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsecase_SignedNumber___tail_minus_Leave(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            // <SignedNumber> ::= "-" number;
            return Derivationcase_SignedNumber___tail_minus_LeavenumberLeave(result, parser);
        }
        
        /// <summary>
        /// 对 叶结点&quot;File&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_fileLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_fileLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;endfile&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_endfileLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_endfileLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;{&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_leftBrace_Leave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_leftBrace_Leave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;}&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_rightBrace_Leave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_rightBrace_Leave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点null 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            ParseepsilonLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.epsilonLeave;
            result.NodeValue.NodeName = @"null";
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            result.MappedTokenLength = 0;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;FileDesc&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_fileDescLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_fileDescLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;endfiledesc&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_endfiledescLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_endfiledescLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;Faces&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_facesLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_facesLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;MapChannel&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_mapChannelLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_mapChannelLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;Frame&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_frameLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_frameLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;endframe&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_endframeLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_endframeLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;Frames&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_framesLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_framesLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;Vertices&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_verticesLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_verticesLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;Map&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_mapLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_mapLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;TVertices&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_tVerticesLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_tVerticesLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;Face&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_faceLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_faceLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;MatID&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_matIDLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_matIDLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;TextureVertices&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_textureVerticesLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_textureVerticesLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;TextureFaces&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_textureFacesLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_textureFacesLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;TVertex&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_tVertexLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_tVertexLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;TFace&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_tFaceLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_tFaceLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;Vertex&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_vertexLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_vertexLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;+&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_plus_Leave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_plus_Leave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点number 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            ParsenumberLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.numberLeave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点&quot;-&quot; 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_minus_Leave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.tail_minus_Leave;
            result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ptNextToken++;
            result.MappedTokenLength = 1;
            parserArmadaTanksModel.m_ParserStack.Pop();
            return Next(result, parserArmadaTanksModel);
        }
        /// <summary>
        /// 对 叶结点# 进行分析
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// </summary>
        /// <returns></returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Parsetail_startEndLeave_(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result, ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            if (result != null)
            {
                result.NodeValue.NodeType = EnumVTypeDTM.tail_startEndLeave;
                result.NodeValue.NodeName = parserArmadaTanksModel.m_TokenListSource[parserArmadaTanksModel.m_ptNextToken].Detail;
                result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
                result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
                result.MappedTokenLength = 1;
            }
            parserArmadaTanksModel.m_ParserStack.Pop();
            parserArmadaTanksModel.m_ptNextToken++;
            return Next(result, parserArmadaTanksModel);
        }
        
        #endregion 分析表中的元素指向的分析函数
        #region 所有推导式的推导动作函数
        
        /// <summary>
        /// &lt;DTM&gt; ::= &quot;File&quot; &lt;FileContent&gt; &quot;endfile&quot;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_ArmadaTanksModel___tail_fileLeavecase_FileContenttail_endfileLeave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<DTM> ::= "File" <FileContent> "endfile";
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_ArmadaTanksModel;
            result.NodeValue.NodeName = EnumVTypeDTM.case_ArmadaTanksModel.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_endfileLeave);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_FileContent);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_fileLeave);
            // generate syntax tree
            var tail_fileLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_fileLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_fileLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_fileLeaveTree0.Parent = result;
            //tail_fileLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_fileLeave);
            result.Children.Add(tail_fileLeaveTree0);
            var case_FileContentTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_FileContentTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_FileContentTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_FileContentTree1.Parent = result;
            //case_FileContentTree1.Value = new ProductionNode(EnumVTypeDTM.case_FileContent);
            result.Children.Add(case_FileContentTree1);
            var tail_endfileLeaveTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_endfileLeaveTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_endfileLeaveTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_endfileLeaveTree2.Parent = result;
            //tail_endfileLeaveTree2.Value = new ProductionNode(EnumVTypeDTM.tail_endfileLeave);
            result.Children.Add(tail_endfileLeaveTree2);
            return tail_fileLeaveTree0;
        }//<DTM> ::= "File" <FileContent> "endfile";
        /// <summary>
        /// &lt;FileContent&gt; ::= &quot;{&quot; &lt;BlockList&gt; &quot;}&quot;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_FileContent___tail_leftBrace_Leavecase_BlockListtail_rightBrace_Leave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<FileContent> ::= "{" <BlockList> "}";
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_FileContent;
            result.NodeValue.NodeName = EnumVTypeDTM.case_FileContent.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_rightBrace_Leave);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_BlockList);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_leftBrace_Leave);
            // generate syntax tree
            var tail_leftBrace_LeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_leftBrace_LeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_leftBrace_LeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_leftBrace_LeaveTree0.Parent = result;
            //tail_leftBrace_LeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_leftBrace_Leave);
            result.Children.Add(tail_leftBrace_LeaveTree0);
            var case_BlockListTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_BlockListTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_BlockListTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_BlockListTree1.Parent = result;
            //case_BlockListTree1.Value = new ProductionNode(EnumVTypeDTM.case_BlockList);
            result.Children.Add(case_BlockListTree1);
            var tail_rightBrace_LeaveTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_rightBrace_LeaveTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_rightBrace_LeaveTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_rightBrace_LeaveTree2.Parent = result;
            //tail_rightBrace_LeaveTree2.Value = new ProductionNode(EnumVTypeDTM.tail_rightBrace_Leave);
            result.Children.Add(tail_rightBrace_LeaveTree2);
            return tail_leftBrace_LeaveTree0;
        }//<FileContent> ::= "{" <BlockList> "}";
        /// <summary>
        /// &lt;BlockList&gt; ::= &lt;Block&gt; &lt;BlockList&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_BlockList___case_Blockcase_BlockList(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<BlockList> ::= <Block> <BlockList>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_BlockList;
            result.NodeValue.NodeName = EnumVTypeDTM.case_BlockList.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_BlockList);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_Block);
            // generate syntax tree
            var case_BlockTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_BlockTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_BlockTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_BlockTree0.Parent = result;
            //case_BlockTree0.Value = new ProductionNode(EnumVTypeDTM.case_Block);
            result.Children.Add(case_BlockTree0);
            var case_BlockListTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_BlockListTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_BlockListTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_BlockListTree1.Parent = result;
            //case_BlockListTree1.Value = new ProductionNode(EnumVTypeDTM.case_BlockList);
            result.Children.Add(case_BlockListTree1);
            return case_BlockTree0;
        }//<BlockList> ::= <Block> <BlockList>;
        /// <summary>
        /// &lt;BlockList&gt; ::= null;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_BlockList___epsilonLeave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<BlockList> ::= null;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_BlockList;
            result.NodeValue.NodeName = EnumVTypeDTM.case_BlockList.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_epsilonLeave);
            // generate syntax tree
            var epsilonLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            epsilonLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            epsilonLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            epsilonLeaveTree0.Parent = result;
            //epsilonLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.epsilonLeave);
            result.Children.Add(epsilonLeaveTree0);
            return epsilonLeaveTree0;
        }//<BlockList> ::= null;
        /// <summary>
        /// &lt;Block&gt; ::= &quot;FileDesc&quot; &lt;FileDesc&gt; &quot;endfiledesc&quot;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_Block___tail_fileDescLeavecase_FileDesctail_endfiledescLeave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<Block> ::= "FileDesc" <FileDesc> "endfiledesc";
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_Block;
            result.NodeValue.NodeName = EnumVTypeDTM.case_Block.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_endfiledescLeave);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_FileDesc);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_fileDescLeave);
            // generate syntax tree
            var tail_fileDescLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_fileDescLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_fileDescLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_fileDescLeaveTree0.Parent = result;
            //tail_fileDescLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_fileDescLeave);
            result.Children.Add(tail_fileDescLeaveTree0);
            var case_FileDescTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_FileDescTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_FileDescTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_FileDescTree1.Parent = result;
            //case_FileDescTree1.Value = new ProductionNode(EnumVTypeDTM.case_FileDesc);
            result.Children.Add(case_FileDescTree1);
            var tail_endfiledescLeaveTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_endfiledescLeaveTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_endfiledescLeaveTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_endfiledescLeaveTree2.Parent = result;
            //tail_endfiledescLeaveTree2.Value = new ProductionNode(EnumVTypeDTM.tail_endfiledescLeave);
            result.Children.Add(tail_endfiledescLeaveTree2);
            return tail_fileDescLeaveTree0;
        }//<Block> ::= "FileDesc" <FileDesc> "endfiledesc";
        /// <summary>
        /// &lt;Block&gt; ::= &quot;Faces&quot; &lt;Faces&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_Block___tail_facesLeavecase_Faces(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<Block> ::= "Faces" <Faces>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_Block;
            result.NodeValue.NodeName = EnumVTypeDTM.case_Block.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_Faces);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_facesLeave);
            // generate syntax tree
            var tail_facesLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_facesLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_facesLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_facesLeaveTree0.Parent = result;
            //tail_facesLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_facesLeave);
            result.Children.Add(tail_facesLeaveTree0);
            var case_FacesTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_FacesTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_FacesTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_FacesTree1.Parent = result;
            //case_FacesTree1.Value = new ProductionNode(EnumVTypeDTM.case_Faces);
            result.Children.Add(case_FacesTree1);
            return tail_facesLeaveTree0;
        }//<Block> ::= "Faces" <Faces>;
        /// <summary>
        /// &lt;Block&gt; ::= &quot;MapChannel&quot; &lt;SignedNumber&gt; &lt;MapChannel&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_Block___tail_mapChannelLeavecase_SignedNumbercase_MapChannel(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<Block> ::= "MapChannel" <SignedNumber> <MapChannel>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_Block;
            result.NodeValue.NodeName = EnumVTypeDTM.case_Block.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_MapChannel);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_mapChannelLeave);
            // generate syntax tree
            var tail_mapChannelLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_mapChannelLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_mapChannelLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_mapChannelLeaveTree0.Parent = result;
            //tail_mapChannelLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_mapChannelLeave);
            result.Children.Add(tail_mapChannelLeaveTree0);
            var case_SignedNumberTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree1.Parent = result;
            //case_SignedNumberTree1.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree1);
            var case_MapChannelTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_MapChannelTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_MapChannelTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_MapChannelTree2.Parent = result;
            //case_MapChannelTree2.Value = new ProductionNode(EnumVTypeDTM.case_MapChannel);
            result.Children.Add(case_MapChannelTree2);
            return tail_mapChannelLeaveTree0;
        }//<Block> ::= "MapChannel" <SignedNumber> <MapChannel>;
        /// <summary>
        /// &lt;Block&gt; ::= &quot;Frame&quot; &lt;SignedNumber&gt; &lt;Frame&gt; &quot;endframe&quot;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_Block___tail_frameLeavecase_SignedNumbercase_Frametail_endframeLeave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<Block> ::= "Frame" <SignedNumber> <Frame> "endframe";
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_Block;
            result.NodeValue.NodeName = EnumVTypeDTM.case_Block.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_endframeLeave);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_Frame);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_frameLeave);
            // generate syntax tree
            var tail_frameLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_frameLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_frameLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_frameLeaveTree0.Parent = result;
            //tail_frameLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_frameLeave);
            result.Children.Add(tail_frameLeaveTree0);
            var case_SignedNumberTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree1.Parent = result;
            //case_SignedNumberTree1.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree1);
            var case_FrameTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_FrameTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_FrameTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_FrameTree2.Parent = result;
            //case_FrameTree2.Value = new ProductionNode(EnumVTypeDTM.case_Frame);
            result.Children.Add(case_FrameTree2);
            var tail_endframeLeaveTree3 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_endframeLeaveTree3.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_endframeLeaveTree3.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_endframeLeaveTree3.Parent = result;
            //tail_endframeLeaveTree3.Value = new ProductionNode(EnumVTypeDTM.tail_endframeLeave);
            result.Children.Add(tail_endframeLeaveTree3);
            return tail_frameLeaveTree0;
        }//<Block> ::= "Frame" <SignedNumber> <Frame> "endframe";
        /// <summary>
        /// &lt;FileDesc&gt; ::= &quot;{&quot; &lt;FileDescItemList&gt; &quot;}&quot;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_FileDesc___tail_leftBrace_Leavecase_FileDescItemListtail_rightBrace_Leave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<FileDesc> ::= "{" <FileDescItemList> "}";
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_FileDesc;
            result.NodeValue.NodeName = EnumVTypeDTM.case_FileDesc.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_rightBrace_Leave);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_FileDescItemList);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_leftBrace_Leave);
            // generate syntax tree
            var tail_leftBrace_LeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_leftBrace_LeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_leftBrace_LeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_leftBrace_LeaveTree0.Parent = result;
            //tail_leftBrace_LeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_leftBrace_Leave);
            result.Children.Add(tail_leftBrace_LeaveTree0);
            var case_FileDescItemListTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_FileDescItemListTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_FileDescItemListTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_FileDescItemListTree1.Parent = result;
            //case_FileDescItemListTree1.Value = new ProductionNode(EnumVTypeDTM.case_FileDescItemList);
            result.Children.Add(case_FileDescItemListTree1);
            var tail_rightBrace_LeaveTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_rightBrace_LeaveTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_rightBrace_LeaveTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_rightBrace_LeaveTree2.Parent = result;
            //tail_rightBrace_LeaveTree2.Value = new ProductionNode(EnumVTypeDTM.tail_rightBrace_Leave);
            result.Children.Add(tail_rightBrace_LeaveTree2);
            return tail_leftBrace_LeaveTree0;
        }//<FileDesc> ::= "{" <FileDescItemList> "}";
        /// <summary>
        /// &lt;FileDescItemList&gt; ::= &lt;FileDescItem&gt; &lt;FileDescItemList&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_FileDescItemList___case_FileDescItemcase_FileDescItemList(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<FileDescItemList> ::= <FileDescItem> <FileDescItemList>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_FileDescItemList;
            result.NodeValue.NodeName = EnumVTypeDTM.case_FileDescItemList.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_FileDescItemList);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_FileDescItem);
            // generate syntax tree
            var case_FileDescItemTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_FileDescItemTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_FileDescItemTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_FileDescItemTree0.Parent = result;
            //case_FileDescItemTree0.Value = new ProductionNode(EnumVTypeDTM.case_FileDescItem);
            result.Children.Add(case_FileDescItemTree0);
            var case_FileDescItemListTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_FileDescItemListTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_FileDescItemListTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_FileDescItemListTree1.Parent = result;
            //case_FileDescItemListTree1.Value = new ProductionNode(EnumVTypeDTM.case_FileDescItemList);
            result.Children.Add(case_FileDescItemListTree1);
            return case_FileDescItemTree0;
        }//<FileDescItemList> ::= <FileDescItem> <FileDescItemList>;
        /// <summary>
        /// &lt;FileDescItemList&gt; ::= null;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_FileDescItemList___epsilonLeave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<FileDescItemList> ::= null;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_FileDescItemList;
            result.NodeValue.NodeName = EnumVTypeDTM.case_FileDescItemList.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_epsilonLeave);
            // generate syntax tree
            var epsilonLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            epsilonLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            epsilonLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            epsilonLeaveTree0.Parent = result;
            //epsilonLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.epsilonLeave);
            result.Children.Add(epsilonLeaveTree0);
            return epsilonLeaveTree0;
        }//<FileDescItemList> ::= null;
        /// <summary>
        /// &lt;FileDescItem&gt; ::= &quot;Frames&quot; &lt;SignedNumber&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_FileDescItem___tail_framesLeavecase_SignedNumber(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<FileDescItem> ::= "Frames" <SignedNumber>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_FileDescItem;
            result.NodeValue.NodeName = EnumVTypeDTM.case_FileDescItem.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_framesLeave);
            // generate syntax tree
            var tail_framesLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_framesLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_framesLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_framesLeaveTree0.Parent = result;
            //tail_framesLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_framesLeave);
            result.Children.Add(tail_framesLeaveTree0);
            var case_SignedNumberTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree1.Parent = result;
            //case_SignedNumberTree1.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree1);
            return tail_framesLeaveTree0;
        }//<FileDescItem> ::= "Frames" <SignedNumber>;
        /// <summary>
        /// &lt;FileDescItem&gt; ::= &quot;Vertices&quot; &lt;SignedNumber&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_FileDescItem___tail_verticesLeavecase_SignedNumber(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<FileDescItem> ::= "Vertices" <SignedNumber>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_FileDescItem;
            result.NodeValue.NodeName = EnumVTypeDTM.case_FileDescItem.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_verticesLeave);
            // generate syntax tree
            var tail_verticesLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_verticesLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_verticesLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_verticesLeaveTree0.Parent = result;
            //tail_verticesLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_verticesLeave);
            result.Children.Add(tail_verticesLeaveTree0);
            var case_SignedNumberTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree1.Parent = result;
            //case_SignedNumberTree1.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree1);
            return tail_verticesLeaveTree0;
        }//<FileDescItem> ::= "Vertices" <SignedNumber>;
        /// <summary>
        /// &lt;FileDescItem&gt; ::= &quot;Faces&quot; &lt;SignedNumber&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_FileDescItem___tail_facesLeavecase_SignedNumber(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<FileDescItem> ::= "Faces" <SignedNumber>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_FileDescItem;
            result.NodeValue.NodeName = EnumVTypeDTM.case_FileDescItem.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_facesLeave);
            // generate syntax tree
            var tail_facesLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_facesLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_facesLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_facesLeaveTree0.Parent = result;
            //tail_facesLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_facesLeave);
            result.Children.Add(tail_facesLeaveTree0);
            var case_SignedNumberTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree1.Parent = result;
            //case_SignedNumberTree1.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree1);
            return tail_facesLeaveTree0;
        }//<FileDescItem> ::= "Faces" <SignedNumber>;
        /// <summary>
        /// &lt;FileDescItem&gt; ::= &quot;Map&quot; &lt;SignedNumber&gt; &quot;TVertices&quot; &lt;SignedNumber&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_FileDescItem___tail_mapLeavecase_SignedNumbertail_tVerticesLeavecase_SignedNumber(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<FileDescItem> ::= "Map" <SignedNumber> "TVertices" <SignedNumber>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_FileDescItem;
            result.NodeValue.NodeName = EnumVTypeDTM.case_FileDescItem.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_tVerticesLeave);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_mapLeave);
            // generate syntax tree
            var tail_mapLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_mapLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_mapLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_mapLeaveTree0.Parent = result;
            //tail_mapLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_mapLeave);
            result.Children.Add(tail_mapLeaveTree0);
            var case_SignedNumberTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree1.Parent = result;
            //case_SignedNumberTree1.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree1);
            var tail_tVerticesLeaveTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_tVerticesLeaveTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_tVerticesLeaveTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_tVerticesLeaveTree2.Parent = result;
            //tail_tVerticesLeaveTree2.Value = new ProductionNode(EnumVTypeDTM.tail_tVerticesLeave);
            result.Children.Add(tail_tVerticesLeaveTree2);
            var case_SignedNumberTree3 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree3.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree3.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree3.Parent = result;
            //case_SignedNumberTree3.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree3);
            return tail_mapLeaveTree0;
        }//<FileDescItem> ::= "Map" <SignedNumber> "TVertices" <SignedNumber>;
        /// <summary>
        /// &lt;Faces&gt; ::= &quot;{&quot; &lt;FaceList&gt; &quot;}&quot;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_Faces___tail_leftBrace_Leavecase_FaceListtail_rightBrace_Leave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<Faces> ::= "{" <FaceList> "}";
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_Faces;
            result.NodeValue.NodeName = EnumVTypeDTM.case_Faces.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_rightBrace_Leave);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_FaceList);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_leftBrace_Leave);
            // generate syntax tree
            var tail_leftBrace_LeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_leftBrace_LeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_leftBrace_LeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_leftBrace_LeaveTree0.Parent = result;
            //tail_leftBrace_LeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_leftBrace_Leave);
            result.Children.Add(tail_leftBrace_LeaveTree0);
            var case_FaceListTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_FaceListTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_FaceListTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_FaceListTree1.Parent = result;
            //case_FaceListTree1.Value = new ProductionNode(EnumVTypeDTM.case_FaceList);
            result.Children.Add(case_FaceListTree1);
            var tail_rightBrace_LeaveTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_rightBrace_LeaveTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_rightBrace_LeaveTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_rightBrace_LeaveTree2.Parent = result;
            //tail_rightBrace_LeaveTree2.Value = new ProductionNode(EnumVTypeDTM.tail_rightBrace_Leave);
            result.Children.Add(tail_rightBrace_LeaveTree2);
            return tail_leftBrace_LeaveTree0;
        }//<Faces> ::= "{" <FaceList> "}";
        /// <summary>
        /// &lt;FaceList&gt; ::= &lt;Face&gt; &lt;FaceList&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_FaceList___case_Facecase_FaceList(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<FaceList> ::= <Face> <FaceList>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_FaceList;
            result.NodeValue.NodeName = EnumVTypeDTM.case_FaceList.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_FaceList);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_Face);
            // generate syntax tree
            var case_FaceTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_FaceTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_FaceTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_FaceTree0.Parent = result;
            //case_FaceTree0.Value = new ProductionNode(EnumVTypeDTM.case_Face);
            result.Children.Add(case_FaceTree0);
            var case_FaceListTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_FaceListTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_FaceListTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_FaceListTree1.Parent = result;
            //case_FaceListTree1.Value = new ProductionNode(EnumVTypeDTM.case_FaceList);
            result.Children.Add(case_FaceListTree1);
            return case_FaceTree0;
        }//<FaceList> ::= <Face> <FaceList>;
        /// <summary>
        /// &lt;FaceList&gt; ::= null;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_FaceList___epsilonLeave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<FaceList> ::= null;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_FaceList;
            result.NodeValue.NodeName = EnumVTypeDTM.case_FaceList.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_epsilonLeave);
            // generate syntax tree
            var epsilonLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            epsilonLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            epsilonLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            epsilonLeaveTree0.Parent = result;
            //epsilonLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.epsilonLeave);
            result.Children.Add(epsilonLeaveTree0);
            return epsilonLeaveTree0;
        }//<FaceList> ::= null;
        /// <summary>
        /// &lt;Face&gt; ::= &quot;Face&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &quot;MatID&quot; &lt;SignedNumber&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_Face___tail_faceLeavecase_SignedNumbercase_SignedNumbercase_SignedNumbercase_SignedNumbertail_matIDLeavecase_SignedNumber(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<Face> ::= "Face" <SignedNumber> <SignedNumber> <SignedNumber> <SignedNumber> "MatID" <SignedNumber>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_Face;
            result.NodeValue.NodeName = EnumVTypeDTM.case_Face.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_matIDLeave);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_faceLeave);
            // generate syntax tree
            var tail_faceLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_faceLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_faceLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_faceLeaveTree0.Parent = result;
            //tail_faceLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_faceLeave);
            result.Children.Add(tail_faceLeaveTree0);
            var case_SignedNumberTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree1.Parent = result;
            //case_SignedNumberTree1.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree1);
            var case_SignedNumberTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree2.Parent = result;
            //case_SignedNumberTree2.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree2);
            var case_SignedNumberTree3 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree3.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree3.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree3.Parent = result;
            //case_SignedNumberTree3.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree3);
            var case_SignedNumberTree4 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree4.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree4.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree4.Parent = result;
            //case_SignedNumberTree4.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree4);
            var tail_matIDLeaveTree5 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_matIDLeaveTree5.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_matIDLeaveTree5.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_matIDLeaveTree5.Parent = result;
            //tail_matIDLeaveTree5.Value = new ProductionNode(EnumVTypeDTM.tail_matIDLeave);
            result.Children.Add(tail_matIDLeaveTree5);
            var case_SignedNumberTree6 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree6.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree6.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree6.Parent = result;
            //case_SignedNumberTree6.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree6);
            return tail_faceLeaveTree0;
        }//<Face> ::= "Face" <SignedNumber> <SignedNumber> <SignedNumber> <SignedNumber> "MatID" <SignedNumber>;
        /// <summary>
        /// &lt;MapChannel&gt; ::= &quot;{&quot; &lt;TextureList&gt; &quot;}&quot;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_MapChannel___tail_leftBrace_Leavecase_TextureListtail_rightBrace_Leave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<MapChannel> ::= "{" <TextureList> "}";
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_MapChannel;
            result.NodeValue.NodeName = EnumVTypeDTM.case_MapChannel.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_rightBrace_Leave);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_TextureList);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_leftBrace_Leave);
            // generate syntax tree
            var tail_leftBrace_LeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_leftBrace_LeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_leftBrace_LeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_leftBrace_LeaveTree0.Parent = result;
            //tail_leftBrace_LeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_leftBrace_Leave);
            result.Children.Add(tail_leftBrace_LeaveTree0);
            var case_TextureListTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_TextureListTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_TextureListTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_TextureListTree1.Parent = result;
            //case_TextureListTree1.Value = new ProductionNode(EnumVTypeDTM.case_TextureList);
            result.Children.Add(case_TextureListTree1);
            var tail_rightBrace_LeaveTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_rightBrace_LeaveTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_rightBrace_LeaveTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_rightBrace_LeaveTree2.Parent = result;
            //tail_rightBrace_LeaveTree2.Value = new ProductionNode(EnumVTypeDTM.tail_rightBrace_Leave);
            result.Children.Add(tail_rightBrace_LeaveTree2);
            return tail_leftBrace_LeaveTree0;
        }//<MapChannel> ::= "{" <TextureList> "}";
        /// <summary>
        /// &lt;TextureList&gt; ::= &lt;Texture&gt; &lt;TextureList&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_TextureList___case_Texturecase_TextureList(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<TextureList> ::= <Texture> <TextureList>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_TextureList;
            result.NodeValue.NodeName = EnumVTypeDTM.case_TextureList.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_TextureList);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_Texture);
            // generate syntax tree
            var case_TextureTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_TextureTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_TextureTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_TextureTree0.Parent = result;
            //case_TextureTree0.Value = new ProductionNode(EnumVTypeDTM.case_Texture);
            result.Children.Add(case_TextureTree0);
            var case_TextureListTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_TextureListTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_TextureListTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_TextureListTree1.Parent = result;
            //case_TextureListTree1.Value = new ProductionNode(EnumVTypeDTM.case_TextureList);
            result.Children.Add(case_TextureListTree1);
            return case_TextureTree0;
        }//<TextureList> ::= <Texture> <TextureList>;
        /// <summary>
        /// &lt;TextureList&gt; ::= null;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_TextureList___epsilonLeave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<TextureList> ::= null;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_TextureList;
            result.NodeValue.NodeName = EnumVTypeDTM.case_TextureList.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_epsilonLeave);
            // generate syntax tree
            var epsilonLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            epsilonLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            epsilonLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            epsilonLeaveTree0.Parent = result;
            //epsilonLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.epsilonLeave);
            result.Children.Add(epsilonLeaveTree0);
            return epsilonLeaveTree0;
        }//<TextureList> ::= null;
        /// <summary>
        /// &lt;Texture&gt; ::= &quot;TextureVertices&quot; &lt;TextureVertices&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_Texture___tail_textureVerticesLeavecase_TextureVertices(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<Texture> ::= "TextureVertices" <TextureVertices>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_Texture;
            result.NodeValue.NodeName = EnumVTypeDTM.case_Texture.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_TextureVertices);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_textureVerticesLeave);
            // generate syntax tree
            var tail_textureVerticesLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_textureVerticesLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_textureVerticesLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_textureVerticesLeaveTree0.Parent = result;
            //tail_textureVerticesLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_textureVerticesLeave);
            result.Children.Add(tail_textureVerticesLeaveTree0);
            var case_TextureVerticesTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_TextureVerticesTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_TextureVerticesTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_TextureVerticesTree1.Parent = result;
            //case_TextureVerticesTree1.Value = new ProductionNode(EnumVTypeDTM.case_TextureVertices);
            result.Children.Add(case_TextureVerticesTree1);
            return tail_textureVerticesLeaveTree0;
        }//<Texture> ::= "TextureVertices" <TextureVertices>;
        /// <summary>
        /// &lt;Texture&gt; ::= &quot;TextureFaces&quot; &lt;TextureFaces&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_Texture___tail_textureFacesLeavecase_TextureFaces(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<Texture> ::= "TextureFaces" <TextureFaces>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_Texture;
            result.NodeValue.NodeName = EnumVTypeDTM.case_Texture.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_TextureFaces);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_textureFacesLeave);
            // generate syntax tree
            var tail_textureFacesLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_textureFacesLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_textureFacesLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_textureFacesLeaveTree0.Parent = result;
            //tail_textureFacesLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_textureFacesLeave);
            result.Children.Add(tail_textureFacesLeaveTree0);
            var case_TextureFacesTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_TextureFacesTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_TextureFacesTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_TextureFacesTree1.Parent = result;
            //case_TextureFacesTree1.Value = new ProductionNode(EnumVTypeDTM.case_TextureFaces);
            result.Children.Add(case_TextureFacesTree1);
            return tail_textureFacesLeaveTree0;
        }//<Texture> ::= "TextureFaces" <TextureFaces>;
        /// <summary>
        /// &lt;TextureVertices&gt; ::= &quot;{&quot; &lt;TVertexList&gt; &quot;}&quot;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_TextureVertices___tail_leftBrace_Leavecase_TVertexListtail_rightBrace_Leave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<TextureVertices> ::= "{" <TVertexList> "}";
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_TextureVertices;
            result.NodeValue.NodeName = EnumVTypeDTM.case_TextureVertices.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_rightBrace_Leave);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_TVertexList);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_leftBrace_Leave);
            // generate syntax tree
            var tail_leftBrace_LeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_leftBrace_LeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_leftBrace_LeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_leftBrace_LeaveTree0.Parent = result;
            //tail_leftBrace_LeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_leftBrace_Leave);
            result.Children.Add(tail_leftBrace_LeaveTree0);
            var case_TVertexListTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_TVertexListTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_TVertexListTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_TVertexListTree1.Parent = result;
            //case_TVertexListTree1.Value = new ProductionNode(EnumVTypeDTM.case_TVertexList);
            result.Children.Add(case_TVertexListTree1);
            var tail_rightBrace_LeaveTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_rightBrace_LeaveTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_rightBrace_LeaveTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_rightBrace_LeaveTree2.Parent = result;
            //tail_rightBrace_LeaveTree2.Value = new ProductionNode(EnumVTypeDTM.tail_rightBrace_Leave);
            result.Children.Add(tail_rightBrace_LeaveTree2);
            return tail_leftBrace_LeaveTree0;
        }//<TextureVertices> ::= "{" <TVertexList> "}";
        /// <summary>
        /// &lt;TVertexList&gt; ::= &lt;TVertex&gt; &lt;TVertexList&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_TVertexList___case_TVertexcase_TVertexList(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<TVertexList> ::= <TVertex> <TVertexList>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_TVertexList;
            result.NodeValue.NodeName = EnumVTypeDTM.case_TVertexList.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_TVertexList);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_TVertex);
            // generate syntax tree
            var case_TVertexTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_TVertexTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_TVertexTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_TVertexTree0.Parent = result;
            //case_TVertexTree0.Value = new ProductionNode(EnumVTypeDTM.case_TVertex);
            result.Children.Add(case_TVertexTree0);
            var case_TVertexListTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_TVertexListTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_TVertexListTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_TVertexListTree1.Parent = result;
            //case_TVertexListTree1.Value = new ProductionNode(EnumVTypeDTM.case_TVertexList);
            result.Children.Add(case_TVertexListTree1);
            return case_TVertexTree0;
        }//<TVertexList> ::= <TVertex> <TVertexList>;
        /// <summary>
        /// &lt;TVertexList&gt; ::= null;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_TVertexList___epsilonLeave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<TVertexList> ::= null;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_TVertexList;
            result.NodeValue.NodeName = EnumVTypeDTM.case_TVertexList.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_epsilonLeave);
            // generate syntax tree
            var epsilonLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            epsilonLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            epsilonLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            epsilonLeaveTree0.Parent = result;
            //epsilonLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.epsilonLeave);
            result.Children.Add(epsilonLeaveTree0);
            return epsilonLeaveTree0;
        }//<TVertexList> ::= null;
        /// <summary>
        /// &lt;TVertex&gt; ::= &quot;TVertex&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_TVertex___tail_tVertexLeavecase_SignedNumbercase_SignedNumbercase_SignedNumbercase_SignedNumber(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<TVertex> ::= "TVertex" <SignedNumber> <SignedNumber> <SignedNumber> <SignedNumber>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_TVertex;
            result.NodeValue.NodeName = EnumVTypeDTM.case_TVertex.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_tVertexLeave);
            // generate syntax tree
            var tail_tVertexLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_tVertexLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_tVertexLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_tVertexLeaveTree0.Parent = result;
            //tail_tVertexLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_tVertexLeave);
            result.Children.Add(tail_tVertexLeaveTree0);
            var case_SignedNumberTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree1.Parent = result;
            //case_SignedNumberTree1.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree1);
            var case_SignedNumberTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree2.Parent = result;
            //case_SignedNumberTree2.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree2);
            var case_SignedNumberTree3 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree3.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree3.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree3.Parent = result;
            //case_SignedNumberTree3.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree3);
            var case_SignedNumberTree4 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree4.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree4.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree4.Parent = result;
            //case_SignedNumberTree4.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree4);
            return tail_tVertexLeaveTree0;
        }//<TVertex> ::= "TVertex" <SignedNumber> <SignedNumber> <SignedNumber> <SignedNumber>;
        /// <summary>
        /// &lt;TextureFaces&gt; ::= &quot;{&quot; &lt;TFaceList&gt; &quot;}&quot;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_TextureFaces___tail_leftBrace_Leavecase_TFaceListtail_rightBrace_Leave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<TextureFaces> ::= "{" <TFaceList> "}";
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_TextureFaces;
            result.NodeValue.NodeName = EnumVTypeDTM.case_TextureFaces.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_rightBrace_Leave);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_TFaceList);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_leftBrace_Leave);
            // generate syntax tree
            var tail_leftBrace_LeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_leftBrace_LeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_leftBrace_LeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_leftBrace_LeaveTree0.Parent = result;
            //tail_leftBrace_LeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_leftBrace_Leave);
            result.Children.Add(tail_leftBrace_LeaveTree0);
            var case_TFaceListTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_TFaceListTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_TFaceListTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_TFaceListTree1.Parent = result;
            //case_TFaceListTree1.Value = new ProductionNode(EnumVTypeDTM.case_TFaceList);
            result.Children.Add(case_TFaceListTree1);
            var tail_rightBrace_LeaveTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_rightBrace_LeaveTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_rightBrace_LeaveTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_rightBrace_LeaveTree2.Parent = result;
            //tail_rightBrace_LeaveTree2.Value = new ProductionNode(EnumVTypeDTM.tail_rightBrace_Leave);
            result.Children.Add(tail_rightBrace_LeaveTree2);
            return tail_leftBrace_LeaveTree0;
        }//<TextureFaces> ::= "{" <TFaceList> "}";
        /// <summary>
        /// &lt;TFaceList&gt; ::= &lt;TFace&gt; &lt;TFaceList&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_TFaceList___case_TFacecase_TFaceList(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<TFaceList> ::= <TFace> <TFaceList>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_TFaceList;
            result.NodeValue.NodeName = EnumVTypeDTM.case_TFaceList.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_TFaceList);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_TFace);
            // generate syntax tree
            var case_TFaceTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_TFaceTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_TFaceTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_TFaceTree0.Parent = result;
            //case_TFaceTree0.Value = new ProductionNode(EnumVTypeDTM.case_TFace);
            result.Children.Add(case_TFaceTree0);
            var case_TFaceListTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_TFaceListTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_TFaceListTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_TFaceListTree1.Parent = result;
            //case_TFaceListTree1.Value = new ProductionNode(EnumVTypeDTM.case_TFaceList);
            result.Children.Add(case_TFaceListTree1);
            return case_TFaceTree0;
        }//<TFaceList> ::= <TFace> <TFaceList>;
        /// <summary>
        /// &lt;TFaceList&gt; ::= null;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_TFaceList___epsilonLeave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<TFaceList> ::= null;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_TFaceList;
            result.NodeValue.NodeName = EnumVTypeDTM.case_TFaceList.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_epsilonLeave);
            // generate syntax tree
            var epsilonLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            epsilonLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            epsilonLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            epsilonLeaveTree0.Parent = result;
            //epsilonLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.epsilonLeave);
            result.Children.Add(epsilonLeaveTree0);
            return epsilonLeaveTree0;
        }//<TFaceList> ::= null;
        /// <summary>
        /// &lt;TFace&gt; ::= &quot;TFace&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_TFace___tail_tFaceLeavecase_SignedNumbercase_SignedNumbercase_SignedNumbercase_SignedNumber(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<TFace> ::= "TFace" <SignedNumber> <SignedNumber> <SignedNumber> <SignedNumber>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_TFace;
            result.NodeValue.NodeName = EnumVTypeDTM.case_TFace.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_tFaceLeave);
            // generate syntax tree
            var tail_tFaceLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_tFaceLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_tFaceLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_tFaceLeaveTree0.Parent = result;
            //tail_tFaceLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_tFaceLeave);
            result.Children.Add(tail_tFaceLeaveTree0);
            var case_SignedNumberTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree1.Parent = result;
            //case_SignedNumberTree1.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree1);
            var case_SignedNumberTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree2.Parent = result;
            //case_SignedNumberTree2.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree2);
            var case_SignedNumberTree3 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree3.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree3.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree3.Parent = result;
            //case_SignedNumberTree3.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree3);
            var case_SignedNumberTree4 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree4.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree4.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree4.Parent = result;
            //case_SignedNumberTree4.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree4);
            return tail_tFaceLeaveTree0;
        }//<TFace> ::= "TFace" <SignedNumber> <SignedNumber> <SignedNumber> <SignedNumber>;
        /// <summary>
        /// &lt;Frame&gt; ::= &quot;{&quot; &lt;FrameContentItemList&gt; &quot;}&quot;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_Frame___tail_leftBrace_Leavecase_FrameContentItemListtail_rightBrace_Leave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<Frame> ::= "{" <FrameContentItemList> "}";
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_Frame;
            result.NodeValue.NodeName = EnumVTypeDTM.case_Frame.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_rightBrace_Leave);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_FrameContentItemList);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_leftBrace_Leave);
            // generate syntax tree
            var tail_leftBrace_LeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_leftBrace_LeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_leftBrace_LeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_leftBrace_LeaveTree0.Parent = result;
            //tail_leftBrace_LeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_leftBrace_Leave);
            result.Children.Add(tail_leftBrace_LeaveTree0);
            var case_FrameContentItemListTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_FrameContentItemListTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_FrameContentItemListTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_FrameContentItemListTree1.Parent = result;
            //case_FrameContentItemListTree1.Value = new ProductionNode(EnumVTypeDTM.case_FrameContentItemList);
            result.Children.Add(case_FrameContentItemListTree1);
            var tail_rightBrace_LeaveTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_rightBrace_LeaveTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_rightBrace_LeaveTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_rightBrace_LeaveTree2.Parent = result;
            //tail_rightBrace_LeaveTree2.Value = new ProductionNode(EnumVTypeDTM.tail_rightBrace_Leave);
            result.Children.Add(tail_rightBrace_LeaveTree2);
            return tail_leftBrace_LeaveTree0;
        }//<Frame> ::= "{" <FrameContentItemList> "}";
        /// <summary>
        /// &lt;FrameContentItemList&gt; ::= &lt;FrameContentItem&gt; &lt;FrameContentItemList&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_FrameContentItemList___case_FrameContentItemcase_FrameContentItemList(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<FrameContentItemList> ::= <FrameContentItem> <FrameContentItemList>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_FrameContentItemList;
            result.NodeValue.NodeName = EnumVTypeDTM.case_FrameContentItemList.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_FrameContentItemList);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_FrameContentItem);
            // generate syntax tree
            var case_FrameContentItemTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_FrameContentItemTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_FrameContentItemTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_FrameContentItemTree0.Parent = result;
            //case_FrameContentItemTree0.Value = new ProductionNode(EnumVTypeDTM.case_FrameContentItem);
            result.Children.Add(case_FrameContentItemTree0);
            var case_FrameContentItemListTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_FrameContentItemListTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_FrameContentItemListTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_FrameContentItemListTree1.Parent = result;
            //case_FrameContentItemListTree1.Value = new ProductionNode(EnumVTypeDTM.case_FrameContentItemList);
            result.Children.Add(case_FrameContentItemListTree1);
            return case_FrameContentItemTree0;
        }//<FrameContentItemList> ::= <FrameContentItem> <FrameContentItemList>;
        /// <summary>
        /// &lt;FrameContentItemList&gt; ::= null;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_FrameContentItemList___epsilonLeave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<FrameContentItemList> ::= null;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_FrameContentItemList;
            result.NodeValue.NodeName = EnumVTypeDTM.case_FrameContentItemList.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_epsilonLeave);
            // generate syntax tree
            var epsilonLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            epsilonLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            epsilonLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            epsilonLeaveTree0.Parent = result;
            //epsilonLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.epsilonLeave);
            result.Children.Add(epsilonLeaveTree0);
            return epsilonLeaveTree0;
        }//<FrameContentItemList> ::= null;
        /// <summary>
        /// &lt;FrameContentItem&gt; ::= &quot;Vertices&quot; &quot;{&quot; &lt;Vertices&gt; &quot;}&quot;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_FrameContentItem___tail_verticesLeavetail_leftBrace_Leavecase_Verticestail_rightBrace_Leave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<FrameContentItem> ::= "Vertices" "{" <Vertices> "}";
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_FrameContentItem;
            result.NodeValue.NodeName = EnumVTypeDTM.case_FrameContentItem.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_rightBrace_Leave);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_Vertices);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_leftBrace_Leave);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_verticesLeave);
            // generate syntax tree
            var tail_verticesLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_verticesLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_verticesLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_verticesLeaveTree0.Parent = result;
            //tail_verticesLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_verticesLeave);
            result.Children.Add(tail_verticesLeaveTree0);
            var tail_leftBrace_LeaveTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_leftBrace_LeaveTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_leftBrace_LeaveTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_leftBrace_LeaveTree1.Parent = result;
            //tail_leftBrace_LeaveTree1.Value = new ProductionNode(EnumVTypeDTM.tail_leftBrace_Leave);
            result.Children.Add(tail_leftBrace_LeaveTree1);
            var case_VerticesTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_VerticesTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_VerticesTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_VerticesTree2.Parent = result;
            //case_VerticesTree2.Value = new ProductionNode(EnumVTypeDTM.case_Vertices);
            result.Children.Add(case_VerticesTree2);
            var tail_rightBrace_LeaveTree3 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_rightBrace_LeaveTree3.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_rightBrace_LeaveTree3.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_rightBrace_LeaveTree3.Parent = result;
            //tail_rightBrace_LeaveTree3.Value = new ProductionNode(EnumVTypeDTM.tail_rightBrace_Leave);
            result.Children.Add(tail_rightBrace_LeaveTree3);
            return tail_verticesLeaveTree0;
        }//<FrameContentItem> ::= "Vertices" "{" <Vertices> "}";
        /// <summary>
        /// &lt;Vertices&gt; ::= &lt;Vertex&gt; &lt;Vertices&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_Vertices___case_Vertexcase_Vertices(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<Vertices> ::= <Vertex> <Vertices>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_Vertices;
            result.NodeValue.NodeName = EnumVTypeDTM.case_Vertices.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_Vertices);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_Vertex);
            // generate syntax tree
            var case_VertexTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_VertexTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_VertexTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_VertexTree0.Parent = result;
            //case_VertexTree0.Value = new ProductionNode(EnumVTypeDTM.case_Vertex);
            result.Children.Add(case_VertexTree0);
            var case_VerticesTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_VerticesTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_VerticesTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_VerticesTree1.Parent = result;
            //case_VerticesTree1.Value = new ProductionNode(EnumVTypeDTM.case_Vertices);
            result.Children.Add(case_VerticesTree1);
            return case_VertexTree0;
        }//<Vertices> ::= <Vertex> <Vertices>;
        /// <summary>
        /// &lt;Vertices&gt; ::= null;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_Vertices___epsilonLeave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<Vertices> ::= null;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_Vertices;
            result.NodeValue.NodeName = EnumVTypeDTM.case_Vertices.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_epsilonLeave);
            // generate syntax tree
            var epsilonLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            epsilonLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            epsilonLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            epsilonLeaveTree0.Parent = result;
            //epsilonLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.epsilonLeave);
            result.Children.Add(epsilonLeaveTree0);
            return epsilonLeaveTree0;
        }//<Vertices> ::= null;
        /// <summary>
        /// &lt;Vertex&gt; ::= &quot;Vertex&quot; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt; &lt;SignedNumber&gt;;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_Vertex___tail_vertexLeavecase_SignedNumbercase_SignedNumbercase_SignedNumbercase_SignedNumber(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<Vertex> ::= "Vertex" <SignedNumber> <SignedNumber> <SignedNumber> <SignedNumber>;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_Vertex;
            result.NodeValue.NodeName = EnumVTypeDTM.case_Vertex.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_case_SignedNumber);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_vertexLeave);
            // generate syntax tree
            var tail_vertexLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_vertexLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_vertexLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_vertexLeaveTree0.Parent = result;
            //tail_vertexLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_vertexLeave);
            result.Children.Add(tail_vertexLeaveTree0);
            var case_SignedNumberTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree1.Parent = result;
            //case_SignedNumberTree1.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree1);
            var case_SignedNumberTree2 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree2.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree2.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree2.Parent = result;
            //case_SignedNumberTree2.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree2);
            var case_SignedNumberTree3 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree3.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree3.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree3.Parent = result;
            //case_SignedNumberTree3.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree3);
            var case_SignedNumberTree4 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            case_SignedNumberTree4.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            case_SignedNumberTree4.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            case_SignedNumberTree4.Parent = result;
            //case_SignedNumberTree4.Value = new ProductionNode(EnumVTypeDTM.case_SignedNumber);
            result.Children.Add(case_SignedNumberTree4);
            return tail_vertexLeaveTree0;
        }//<Vertex> ::= "Vertex" <SignedNumber> <SignedNumber> <SignedNumber> <SignedNumber>;
        /// <summary>
        /// &lt;SignedNumber&gt; ::= &quot;+&quot; number;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_SignedNumber___tail_plus_LeavenumberLeave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<SignedNumber> ::= "+" number;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_SignedNumber;
            result.NodeValue.NodeName = EnumVTypeDTM.case_SignedNumber.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_numberLeave);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_plus_Leave);
            // generate syntax tree
            var tail_plus_LeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_plus_LeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_plus_LeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_plus_LeaveTree0.Parent = result;
            //tail_plus_LeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_plus_Leave);
            result.Children.Add(tail_plus_LeaveTree0);
            var numberLeaveTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            numberLeaveTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            numberLeaveTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            numberLeaveTree1.Parent = result;
            //numberLeaveTree1.Value = new ProductionNode(EnumVTypeDTM.numberLeave);
            result.Children.Add(numberLeaveTree1);
            return tail_plus_LeaveTree0;
        }//<SignedNumber> ::= "+" number;
        /// <summary>
        /// &lt;SignedNumber&gt; ::= &quot;-&quot; number;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_SignedNumber___tail_minus_LeavenumberLeave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<SignedNumber> ::= "-" number;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_SignedNumber;
            result.NodeValue.NodeName = EnumVTypeDTM.case_SignedNumber.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_numberLeave);
            parserArmadaTanksModel.m_ParserStack.Push(m_tail_minus_Leave);
            // generate syntax tree
            var tail_minus_LeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            tail_minus_LeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            tail_minus_LeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            tail_minus_LeaveTree0.Parent = result;
            //tail_minus_LeaveTree0.Value = new ProductionNode(EnumVTypeDTM.tail_minus_Leave);
            result.Children.Add(tail_minus_LeaveTree0);
            var numberLeaveTree1 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            numberLeaveTree1.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            numberLeaveTree1.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            numberLeaveTree1.Parent = result;
            //numberLeaveTree1.Value = new ProductionNode(EnumVTypeDTM.numberLeave);
            result.Children.Add(numberLeaveTree1);
            return tail_minus_LeaveTree0;
        }//<SignedNumber> ::= "-" number;
        /// <summary>
        /// &lt;SignedNumber&gt; ::= number;
        /// <summary>
        /// <param name="result">需要扩展的结点</param>
        /// <param name="parser">使用的分析器对象</param>
        /// <returns>下一个要扩展的结点</returns>
        private static SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>
            Derivationcase_SignedNumber___numberLeave(
            SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> result,
            ISyntaxParser<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> parser)
        {//<SignedNumber> ::= number;
            var parserArmadaTanksModel = parser as LL1SyntaxParserDTM;
            result.NodeValue.NodeType = EnumVTypeDTM.case_SignedNumber;
            result.NodeValue.NodeName = EnumVTypeDTM.case_SignedNumber.ToString();
            //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
            result.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            result.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            parserArmadaTanksModel.m_ParserStack.Pop();
            // right-to-left push
            parserArmadaTanksModel.m_ParserStack.Push(m_numberLeave);
            // generate syntax tree
            var numberLeaveTree0 = new SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>();
            numberLeaveTree0.MappedTotalTokenList = parserArmadaTanksModel.m_TokenListSource;
            numberLeaveTree0.MappedTokenStartIndex = parserArmadaTanksModel.m_ptNextToken;
            numberLeaveTree0.Parent = result;
            //numberLeaveTree0.Value = new ProductionNode(EnumVTypeDTM.numberLeave);
            result.Children.Add(numberLeaveTree0);
            return numberLeaveTree0;
        }//<SignedNumber> ::= number;
        
        #endregion 所有推导式的推导动作函数
        #region FillMapCells()
        
        private void FillMapCells()
        {
            m_Map.SetCell(EnumVTypeDTM.case_ArmadaTanksModel, EnumTokenTypeDTM.token_File, FuncParsecase_ArmadaTanksModel___tail_fileLeave);
            m_Map.SetCell(EnumVTypeDTM.case_FileContent, EnumTokenTypeDTM.token_LeftBrace_, FuncParsecase_FileContent___tail_leftBrace_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_BlockList, EnumTokenTypeDTM.token_RightBrace_, FuncParsecase_BlockList___tail_rightBrace_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_BlockList, EnumTokenTypeDTM.token_FileDesc, FuncParsecase_BlockList___tail_fileDescLeave);
            m_Map.SetCell(EnumVTypeDTM.case_BlockList, EnumTokenTypeDTM.token_Faces, FuncParsecase_BlockList___tail_facesLeave);
            m_Map.SetCell(EnumVTypeDTM.case_BlockList, EnumTokenTypeDTM.token_MapChannel, FuncParsecase_BlockList___tail_mapChannelLeave);
            m_Map.SetCell(EnumVTypeDTM.case_BlockList, EnumTokenTypeDTM.token_Frame, FuncParsecase_BlockList___tail_frameLeave);
            m_Map.SetCell(EnumVTypeDTM.case_Block, EnumTokenTypeDTM.token_FileDesc, FuncParsecase_Block___tail_fileDescLeave);
            m_Map.SetCell(EnumVTypeDTM.case_Block, EnumTokenTypeDTM.token_Faces, FuncParsecase_Block___tail_facesLeave);
            m_Map.SetCell(EnumVTypeDTM.case_Block, EnumTokenTypeDTM.token_MapChannel, FuncParsecase_Block___tail_mapChannelLeave);
            m_Map.SetCell(EnumVTypeDTM.case_Block, EnumTokenTypeDTM.token_Frame, FuncParsecase_Block___tail_frameLeave);
            m_Map.SetCell(EnumVTypeDTM.case_FileDesc, EnumTokenTypeDTM.token_LeftBrace_, FuncParsecase_FileDesc___tail_leftBrace_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_FileDescItemList, EnumTokenTypeDTM.token_RightBrace_, FuncParsecase_FileDescItemList___tail_rightBrace_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_FileDescItemList, EnumTokenTypeDTM.token_Faces, FuncParsecase_FileDescItemList___tail_facesLeave);
            m_Map.SetCell(EnumVTypeDTM.case_FileDescItemList, EnumTokenTypeDTM.token_Frames, FuncParsecase_FileDescItemList___tail_framesLeave);
            m_Map.SetCell(EnumVTypeDTM.case_FileDescItemList, EnumTokenTypeDTM.token_Vertices, FuncParsecase_FileDescItemList___tail_verticesLeave);
            m_Map.SetCell(EnumVTypeDTM.case_FileDescItemList, EnumTokenTypeDTM.token_Map, FuncParsecase_FileDescItemList___tail_mapLeave);
            m_Map.SetCell(EnumVTypeDTM.case_FileDescItem, EnumTokenTypeDTM.token_Faces, FuncParsecase_FileDescItem___tail_facesLeave);
            m_Map.SetCell(EnumVTypeDTM.case_FileDescItem, EnumTokenTypeDTM.token_Frames, FuncParsecase_FileDescItem___tail_framesLeave);
            m_Map.SetCell(EnumVTypeDTM.case_FileDescItem, EnumTokenTypeDTM.token_Vertices, FuncParsecase_FileDescItem___tail_verticesLeave);
            m_Map.SetCell(EnumVTypeDTM.case_FileDescItem, EnumTokenTypeDTM.token_Map, FuncParsecase_FileDescItem___tail_mapLeave);
            m_Map.SetCell(EnumVTypeDTM.case_Faces, EnumTokenTypeDTM.token_LeftBrace_, FuncParsecase_Faces___tail_leftBrace_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_FaceList, EnumTokenTypeDTM.token_RightBrace_, FuncParsecase_FaceList___tail_rightBrace_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_FaceList, EnumTokenTypeDTM.token_Face, FuncParsecase_FaceList___tail_faceLeave);
            m_Map.SetCell(EnumVTypeDTM.case_Face, EnumTokenTypeDTM.token_Face, FuncParsecase_Face___tail_faceLeave);
            m_Map.SetCell(EnumVTypeDTM.case_MapChannel, EnumTokenTypeDTM.token_LeftBrace_, FuncParsecase_MapChannel___tail_leftBrace_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_TextureList, EnumTokenTypeDTM.token_RightBrace_, FuncParsecase_TextureList___tail_rightBrace_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_TextureList, EnumTokenTypeDTM.token_TextureVertices, FuncParsecase_TextureList___tail_textureVerticesLeave);
            m_Map.SetCell(EnumVTypeDTM.case_TextureList, EnumTokenTypeDTM.token_TextureFaces, FuncParsecase_TextureList___tail_textureFacesLeave);
            m_Map.SetCell(EnumVTypeDTM.case_Texture, EnumTokenTypeDTM.token_TextureVertices, FuncParsecase_Texture___tail_textureVerticesLeave);
            m_Map.SetCell(EnumVTypeDTM.case_Texture, EnumTokenTypeDTM.token_TextureFaces, FuncParsecase_Texture___tail_textureFacesLeave);
            m_Map.SetCell(EnumVTypeDTM.case_TextureVertices, EnumTokenTypeDTM.token_LeftBrace_, FuncParsecase_TextureVertices___tail_leftBrace_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_TVertexList, EnumTokenTypeDTM.token_RightBrace_, FuncParsecase_TVertexList___tail_rightBrace_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_TVertexList, EnumTokenTypeDTM.token_TVertex, FuncParsecase_TVertexList___tail_tVertexLeave);
            m_Map.SetCell(EnumVTypeDTM.case_TVertex, EnumTokenTypeDTM.token_TVertex, FuncParsecase_TVertex___tail_tVertexLeave);
            m_Map.SetCell(EnumVTypeDTM.case_TextureFaces, EnumTokenTypeDTM.token_LeftBrace_, FuncParsecase_TextureFaces___tail_leftBrace_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_TFaceList, EnumTokenTypeDTM.token_RightBrace_, FuncParsecase_TFaceList___tail_rightBrace_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_TFaceList, EnumTokenTypeDTM.token_TFace, FuncParsecase_TFaceList___tail_tFaceLeave);
            m_Map.SetCell(EnumVTypeDTM.case_TFace, EnumTokenTypeDTM.token_TFace, FuncParsecase_TFace___tail_tFaceLeave);
            m_Map.SetCell(EnumVTypeDTM.case_Frame, EnumTokenTypeDTM.token_LeftBrace_, FuncParsecase_Frame___tail_leftBrace_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_FrameContentItemList, EnumTokenTypeDTM.token_RightBrace_, FuncParsecase_FrameContentItemList___tail_rightBrace_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_FrameContentItemList, EnumTokenTypeDTM.token_Vertices, FuncParsecase_FrameContentItemList___tail_verticesLeave);
            m_Map.SetCell(EnumVTypeDTM.case_FrameContentItem, EnumTokenTypeDTM.token_Vertices, FuncParsecase_FrameContentItem___tail_verticesLeave);
            m_Map.SetCell(EnumVTypeDTM.case_Vertices, EnumTokenTypeDTM.token_RightBrace_, FuncParsecase_Vertices___tail_rightBrace_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_Vertices, EnumTokenTypeDTM.token_Vertex, FuncParsecase_Vertices___tail_vertexLeave);
            m_Map.SetCell(EnumVTypeDTM.case_Vertex, EnumTokenTypeDTM.token_Vertex, FuncParsecase_Vertex___tail_vertexLeave);
            m_Map.SetCell(EnumVTypeDTM.case_SignedNumber, EnumTokenTypeDTM.token_Plus_, FuncParsecase_SignedNumber___tail_plus_Leave);
            m_Map.SetCell(EnumVTypeDTM.case_SignedNumber, EnumTokenTypeDTM.number, FuncParsecase_SignedNumber___numberLeave);
            m_Map.SetCell(EnumVTypeDTM.case_SignedNumber, EnumTokenTypeDTM.token_Minus_, FuncParsecase_SignedNumber___tail_minus_Leave);
            
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_File, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.number, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_fileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_fileLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_File, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.number, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_endfileLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfileLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_endfileLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_File, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_endfile, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.epsilon, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_Faces, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_Frame, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_endframe, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_Frames, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_Map, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_Face, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_MatID, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_TFace, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.number, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_leftBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_leftBrace_Leave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_leftBrace_Leave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_File, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_endfile, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.epsilon, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_Faces, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_Frame, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_endframe, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_Frames, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_Map, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_Face, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_MatID, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_TFace, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.number, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_rightBrace_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_rightBrace_Leave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_rightBrace_Leave_);
            
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_File, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_endfile, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.epsilon, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_FileDesc, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_Faces, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_MapChannel, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_Frame, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_endframe, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_Frames, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_Vertices, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_Map, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_TVertices, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_Face, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_MatID, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_TVertex, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_TFace, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_Vertex, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_Plus_, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.number, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_Minus_, FuncParseepsilonLeave_);
            m_Map.SetCell(EnumVTypeDTM.epsilonLeave, EnumTokenTypeDTM.token_startEnd, FuncParseepsilonLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_File, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.number, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_fileDescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_fileDescLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_fileDescLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_File, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.number, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_endfiledescLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endfiledescLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_endfiledescLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_File, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.number, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_facesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_facesLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_facesLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_File, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.number, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_mapChannelLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapChannelLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_mapChannelLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_File, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.number, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_frameLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_frameLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_frameLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_File, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.number, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_endframeLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_endframeLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_endframeLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_File, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.number, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_framesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_framesLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_framesLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_File, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.number, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_verticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_verticesLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_verticesLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_File, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.number, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_mapLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_mapLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_mapLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_File, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.number, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_tVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVerticesLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_tVerticesLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_File, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.number, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_faceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_faceLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_faceLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_File, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.number, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_matIDLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_matIDLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_matIDLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_File, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.number, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_textureVerticesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureVerticesLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_textureVerticesLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_File, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.number, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_textureFacesLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_textureFacesLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_textureFacesLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_File, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.number, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_tVertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tVertexLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_tVertexLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_File, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.number, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_tFaceLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_tFaceLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_tFaceLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_File, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.number, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_vertexLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_vertexLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_vertexLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_File, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_endfile, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.epsilon, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_Faces, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_Frame, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_endframe, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_Frames, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_Map, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_Face, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_MatID, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_TFace, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.number, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_plus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_plus_Leave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_plus_Leave_);
            
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_File, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_endfile, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.epsilon, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_Faces, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_Frame, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_endframe, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_Frames, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_Vertices, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_Map, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_TVertices, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_Face, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_MatID, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_TVertex, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_TFace, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_Vertex, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_Plus_, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.number, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_Minus_, FuncParsenumberLeave_);
            m_Map.SetCell(EnumVTypeDTM.numberLeave, EnumTokenTypeDTM.token_startEnd, FuncParsenumberLeave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_File, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_endfile, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.epsilon, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_Faces, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_Frame, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_endframe, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_Frames, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_Map, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_Face, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_MatID, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_TFace, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.number, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_minus_Leave_);
            m_Map.SetCell(EnumVTypeDTM.tail_minus_Leave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_minus_Leave_);
            
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_File, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_endfile, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_LeftBrace_, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_RightBrace_, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.epsilon, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_FileDesc, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_endfiledesc, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_Faces, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_MapChannel, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_Frame, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_endframe, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_Frames, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_Vertices, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_Map, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_TVertices, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_Face, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_MatID, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_TextureVertices, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_TextureFaces, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_TVertex, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_TFace, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_Vertex, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_Plus_, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.number, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_Minus_, FuncParsetail_startEndLeave_);
            m_Map.SetCell(EnumVTypeDTM.tail_startEndLeave, EnumTokenTypeDTM.token_startEnd, FuncParsetail_startEndLeave_);
        }
        
        #endregion FillMapCells()
        #region 为分析表中的元素配置分析函数
        
        private void InitFunc()
        {
            FuncParsecase_ArmadaTanksModel___tail_fileLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_ArmadaTanksModel___tail_fileLeave);
            FuncParsecase_FileContent___tail_leftBrace_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FileContent___tail_leftBrace_Leave);
            FuncParsecase_BlockList___tail_rightBrace_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_BlockList___tail_rightBrace_Leave);
            FuncParsecase_BlockList___tail_fileDescLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_BlockList___tail_fileDescLeave);
            FuncParsecase_BlockList___tail_facesLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_BlockList___tail_facesLeave);
            FuncParsecase_BlockList___tail_mapChannelLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_BlockList___tail_mapChannelLeave);
            FuncParsecase_BlockList___tail_frameLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_BlockList___tail_frameLeave);
            FuncParsecase_Block___tail_fileDescLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_Block___tail_fileDescLeave);
            FuncParsecase_Block___tail_facesLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_Block___tail_facesLeave);
            FuncParsecase_Block___tail_mapChannelLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_Block___tail_mapChannelLeave);
            FuncParsecase_Block___tail_frameLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_Block___tail_frameLeave);
            FuncParsecase_FileDesc___tail_leftBrace_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FileDesc___tail_leftBrace_Leave);
            FuncParsecase_FileDescItemList___tail_rightBrace_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FileDescItemList___tail_rightBrace_Leave);
            FuncParsecase_FileDescItemList___tail_facesLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FileDescItemList___tail_facesLeave);
            FuncParsecase_FileDescItemList___tail_framesLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FileDescItemList___tail_framesLeave);
            FuncParsecase_FileDescItemList___tail_verticesLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FileDescItemList___tail_verticesLeave);
            FuncParsecase_FileDescItemList___tail_mapLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FileDescItemList___tail_mapLeave);
            FuncParsecase_FileDescItem___tail_facesLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FileDescItem___tail_facesLeave);
            FuncParsecase_FileDescItem___tail_framesLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FileDescItem___tail_framesLeave);
            FuncParsecase_FileDescItem___tail_verticesLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FileDescItem___tail_verticesLeave);
            FuncParsecase_FileDescItem___tail_mapLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FileDescItem___tail_mapLeave);
            FuncParsecase_Faces___tail_leftBrace_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_Faces___tail_leftBrace_Leave);
            FuncParsecase_FaceList___tail_rightBrace_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FaceList___tail_rightBrace_Leave);
            FuncParsecase_FaceList___tail_faceLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FaceList___tail_faceLeave);
            FuncParsecase_Face___tail_faceLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_Face___tail_faceLeave);
            FuncParsecase_MapChannel___tail_leftBrace_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_MapChannel___tail_leftBrace_Leave);
            FuncParsecase_TextureList___tail_rightBrace_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_TextureList___tail_rightBrace_Leave);
            FuncParsecase_TextureList___tail_textureVerticesLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_TextureList___tail_textureVerticesLeave);
            FuncParsecase_TextureList___tail_textureFacesLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_TextureList___tail_textureFacesLeave);
            FuncParsecase_Texture___tail_textureVerticesLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_Texture___tail_textureVerticesLeave);
            FuncParsecase_Texture___tail_textureFacesLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_Texture___tail_textureFacesLeave);
            FuncParsecase_TextureVertices___tail_leftBrace_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_TextureVertices___tail_leftBrace_Leave);
            FuncParsecase_TVertexList___tail_rightBrace_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_TVertexList___tail_rightBrace_Leave);
            FuncParsecase_TVertexList___tail_tVertexLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_TVertexList___tail_tVertexLeave);
            FuncParsecase_TVertex___tail_tVertexLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_TVertex___tail_tVertexLeave);
            FuncParsecase_TextureFaces___tail_leftBrace_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_TextureFaces___tail_leftBrace_Leave);
            FuncParsecase_TFaceList___tail_rightBrace_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_TFaceList___tail_rightBrace_Leave);
            FuncParsecase_TFaceList___tail_tFaceLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_TFaceList___tail_tFaceLeave);
            FuncParsecase_TFace___tail_tFaceLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_TFace___tail_tFaceLeave);
            FuncParsecase_Frame___tail_leftBrace_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_Frame___tail_leftBrace_Leave);
            FuncParsecase_FrameContentItemList___tail_rightBrace_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FrameContentItemList___tail_rightBrace_Leave);
            FuncParsecase_FrameContentItemList___tail_verticesLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FrameContentItemList___tail_verticesLeave);
            FuncParsecase_FrameContentItem___tail_verticesLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_FrameContentItem___tail_verticesLeave);
            FuncParsecase_Vertices___tail_rightBrace_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_Vertices___tail_rightBrace_Leave);
            FuncParsecase_Vertices___tail_vertexLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_Vertices___tail_vertexLeave);
            FuncParsecase_Vertex___tail_vertexLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_Vertex___tail_vertexLeave);
            FuncParsecase_SignedNumber___tail_plus_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_SignedNumber___tail_plus_Leave);
            FuncParsecase_SignedNumber___numberLeave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_SignedNumber___numberLeave);
            FuncParsecase_SignedNumber___tail_minus_Leave = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsecase_SignedNumber___tail_minus_Leave);
            
            FuncParsetail_fileLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_fileLeave_);
            FuncParsetail_endfileLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_endfileLeave_);
            FuncParsetail_leftBrace_Leave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_leftBrace_Leave_);
            FuncParsetail_rightBrace_Leave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_rightBrace_Leave_);
            FuncParseepsilonLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(ParseepsilonLeave_);
            FuncParsetail_fileDescLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_fileDescLeave_);
            FuncParsetail_endfiledescLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_endfiledescLeave_);
            FuncParsetail_facesLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_facesLeave_);
            FuncParsetail_mapChannelLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_mapChannelLeave_);
            FuncParsetail_frameLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_frameLeave_);
            FuncParsetail_endframeLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_endframeLeave_);
            FuncParsetail_framesLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_framesLeave_);
            FuncParsetail_verticesLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_verticesLeave_);
            FuncParsetail_mapLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_mapLeave_);
            FuncParsetail_tVerticesLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_tVerticesLeave_);
            FuncParsetail_faceLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_faceLeave_);
            FuncParsetail_matIDLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_matIDLeave_);
            FuncParsetail_textureVerticesLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_textureVerticesLeave_);
            FuncParsetail_textureFacesLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_textureFacesLeave_);
            FuncParsetail_tVertexLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_tVertexLeave_);
            FuncParsetail_tFaceLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_tFaceLeave_);
            FuncParsetail_vertexLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_vertexLeave_);
            FuncParsetail_plus_Leave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_plus_Leave_);
            FuncParsenumberLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(ParsenumberLeave_);
            FuncParsetail_minus_Leave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_minus_Leave_);
            FuncParsetail_startEndLeave_ = 
                new CandidateFunction<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM>(Parsetail_startEndLeave_);
        }
        
        #endregion 为分析表中的元素配置分析函数
        /// <summary>
        /// 初始化LL(1)分析表
        /// </summary>
        public override void InitMap()
        {
            InitFunc();
            // init parser map
            SetMapLinesAndColumns();
            FillMapCells();
        }
        /// <summary>
        /// LL1SyntaxParserArmadaTanksModel的语法分析器
        /// </summary>
        public LL1SyntaxParserDTM()
            : base(51, 26) { }
        /// LL1SyntaxParserArmadaTanksModel的语法分析器
        /// </summary>
        /// <param name="tokens">要分析的单词列表</param>
        public LL1SyntaxParserDTM(TokenList<EnumTokenTypeDTM> tokens)
            : base(51, 26)
        {
            m_TokenListSource = tokens;
        }
        #region 重置语法分析器到初始状态，这样就可以重新对上次分析过的单词列表进行分析
        
        /// <summary>
        /// 重置语法分析器到初始状态，这样就可以重新对上次分析过的单词列表进行分析
        /// </summary>
        public override void Reset()
        {
            m_ptNextToken = 0;
            m_ParserStack.Clear();
            m_ParserStack.Push(m_tail_startEndLeave);
            m_ParserStack.Push(m_case_ArmadaTanksModel);
            if (m_TokenListSource.Count == 0)
            {
                var newToken = new Token<EnumTokenTypeDTM>()
                {
                    Detail = "#",
                    Line = 0,
                    Column = 0,
                    IndexOfSourceCode = 0,
                    Length = 1,
                    LexicalError = false,
                    TokenType = EnumTokenTypeDTM.token_startEnd
                };
                m_TokenListSource.Add(newToken);
            }
            else
            {
                var token = m_TokenListSource[m_TokenListSource.Count - 1];
                {
                    var newToken = new Token<EnumTokenTypeDTM>()
                    {
                        Detail = "#",
                        Line = token.Line,
                        Column = token.Column + token.Length + 1,
                        IndexOfSourceCode = token.IndexOfSourceCode + token.Length + 1,
                        Length = 1,
                        LexicalError = false,
                        TokenType = EnumTokenTypeDTM.token_startEnd
                    };
                    m_TokenListSource.Add(newToken);
                }
            }
        }
        
        #endregion 重置语法分析器到初始状态，这样就可以重新对上次分析过的单词列表进行分析
        #region SetMapLinesAndColumns()
        
        private void SetMapLinesAndColumns()
        {
            m_Map.SetLine(0, EnumVTypeDTM.case_ArmadaTanksModel);
            m_Map.SetLine(1, EnumVTypeDTM.case_FileContent);
            m_Map.SetLine(2, EnumVTypeDTM.case_BlockList);
            m_Map.SetLine(3, EnumVTypeDTM.case_Block);
            m_Map.SetLine(4, EnumVTypeDTM.case_FileDesc);
            m_Map.SetLine(5, EnumVTypeDTM.case_FileDescItemList);
            m_Map.SetLine(6, EnumVTypeDTM.case_FileDescItem);
            m_Map.SetLine(7, EnumVTypeDTM.case_Faces);
            m_Map.SetLine(8, EnumVTypeDTM.case_FaceList);
            m_Map.SetLine(9, EnumVTypeDTM.case_Face);
            m_Map.SetLine(10, EnumVTypeDTM.case_MapChannel);
            m_Map.SetLine(11, EnumVTypeDTM.case_TextureList);
            m_Map.SetLine(12, EnumVTypeDTM.case_Texture);
            m_Map.SetLine(13, EnumVTypeDTM.case_TextureVertices);
            m_Map.SetLine(14, EnumVTypeDTM.case_TVertexList);
            m_Map.SetLine(15, EnumVTypeDTM.case_TVertex);
            m_Map.SetLine(16, EnumVTypeDTM.case_TextureFaces);
            m_Map.SetLine(17, EnumVTypeDTM.case_TFaceList);
            m_Map.SetLine(18, EnumVTypeDTM.case_TFace);
            m_Map.SetLine(19, EnumVTypeDTM.case_Frame);
            m_Map.SetLine(20, EnumVTypeDTM.case_FrameContentItemList);
            m_Map.SetLine(21, EnumVTypeDTM.case_FrameContentItem);
            m_Map.SetLine(22, EnumVTypeDTM.case_Vertices);
            m_Map.SetLine(23, EnumVTypeDTM.case_Vertex);
            m_Map.SetLine(24, EnumVTypeDTM.case_SignedNumber);
            
            m_Map.SetLine(25, EnumVTypeDTM.tail_fileLeave);
            m_Map.SetLine(26, EnumVTypeDTM.tail_endfileLeave);
            m_Map.SetLine(27, EnumVTypeDTM.tail_leftBrace_Leave);
            m_Map.SetLine(28, EnumVTypeDTM.tail_rightBrace_Leave);
            m_Map.SetLine(29, EnumVTypeDTM.epsilonLeave);
            m_Map.SetLine(30, EnumVTypeDTM.tail_fileDescLeave);
            m_Map.SetLine(31, EnumVTypeDTM.tail_endfiledescLeave);
            m_Map.SetLine(32, EnumVTypeDTM.tail_facesLeave);
            m_Map.SetLine(33, EnumVTypeDTM.tail_mapChannelLeave);
            m_Map.SetLine(34, EnumVTypeDTM.tail_frameLeave);
            m_Map.SetLine(35, EnumVTypeDTM.tail_endframeLeave);
            m_Map.SetLine(36, EnumVTypeDTM.tail_framesLeave);
            m_Map.SetLine(37, EnumVTypeDTM.tail_verticesLeave);
            m_Map.SetLine(38, EnumVTypeDTM.tail_mapLeave);
            m_Map.SetLine(39, EnumVTypeDTM.tail_tVerticesLeave);
            m_Map.SetLine(40, EnumVTypeDTM.tail_faceLeave);
            m_Map.SetLine(41, EnumVTypeDTM.tail_matIDLeave);
            m_Map.SetLine(42, EnumVTypeDTM.tail_textureVerticesLeave);
            m_Map.SetLine(43, EnumVTypeDTM.tail_textureFacesLeave);
            m_Map.SetLine(44, EnumVTypeDTM.tail_tVertexLeave);
            m_Map.SetLine(45, EnumVTypeDTM.tail_tFaceLeave);
            m_Map.SetLine(46, EnumVTypeDTM.tail_vertexLeave);
            m_Map.SetLine(47, EnumVTypeDTM.tail_plus_Leave);
            m_Map.SetLine(48, EnumVTypeDTM.numberLeave);
            m_Map.SetLine(49, EnumVTypeDTM.tail_minus_Leave);
            m_Map.SetLine(50, EnumVTypeDTM.tail_startEndLeave);
            
            
            m_Map.SetColumn(0, EnumTokenTypeDTM.token_File);
            m_Map.SetColumn(1, EnumTokenTypeDTM.token_endfile);
            m_Map.SetColumn(2, EnumTokenTypeDTM.token_LeftBrace_);
            m_Map.SetColumn(3, EnumTokenTypeDTM.token_RightBrace_);
            m_Map.SetColumn(4, EnumTokenTypeDTM.epsilon);
            m_Map.SetColumn(5, EnumTokenTypeDTM.token_FileDesc);
            m_Map.SetColumn(6, EnumTokenTypeDTM.token_endfiledesc);
            m_Map.SetColumn(7, EnumTokenTypeDTM.token_Faces);
            m_Map.SetColumn(8, EnumTokenTypeDTM.token_MapChannel);
            m_Map.SetColumn(9, EnumTokenTypeDTM.token_Frame);
            m_Map.SetColumn(10, EnumTokenTypeDTM.token_endframe);
            m_Map.SetColumn(11, EnumTokenTypeDTM.token_Frames);
            m_Map.SetColumn(12, EnumTokenTypeDTM.token_Vertices);
            m_Map.SetColumn(13, EnumTokenTypeDTM.token_Map);
            m_Map.SetColumn(14, EnumTokenTypeDTM.token_TVertices);
            m_Map.SetColumn(15, EnumTokenTypeDTM.token_Face);
            m_Map.SetColumn(16, EnumTokenTypeDTM.token_MatID);
            m_Map.SetColumn(17, EnumTokenTypeDTM.token_TextureVertices);
            m_Map.SetColumn(18, EnumTokenTypeDTM.token_TextureFaces);
            m_Map.SetColumn(19, EnumTokenTypeDTM.token_TVertex);
            m_Map.SetColumn(20, EnumTokenTypeDTM.token_TFace);
            m_Map.SetColumn(21, EnumTokenTypeDTM.token_Vertex);
            m_Map.SetColumn(22, EnumTokenTypeDTM.token_Plus_);
            m_Map.SetColumn(23, EnumTokenTypeDTM.number);
            m_Map.SetColumn(24, EnumTokenTypeDTM.token_Minus_);
            m_Map.SetColumn(25, EnumTokenTypeDTM.token_startEnd);
        }
        
        #endregion SetMapLinesAndColumns()
    }

}

