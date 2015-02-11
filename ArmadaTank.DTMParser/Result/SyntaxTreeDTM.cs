using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bitzhuwei.CompilerBase;

namespace ArmadaTank.DTMParser.Result
{
    public static class SyntaxTreeDTM
    {
        public static DTM GetModel(this SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            if (null == syntaxTree)
            {
                return null;
            }

            DTM result = new DTM();

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_ArmadaTanksModel___tail_fileLeave())
            {
                FileContent fileContent = GetFileContent(syntaxTree.Children[1]);
                result.fileContentObj = fileContent;
            }

            return result;
        }

        private static FileContent GetFileContent(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            var result = new FileContent();

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FileContent___tail_leftBrace_Leave())
            {
                BlockList blockList = GetBlockList(syntaxTree.Children[1]);
                result.blockListObj = blockList;
            }

            return result;
        }

        private static BlockList GetBlockList(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            var result = new BlockList();

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_BlockList___tail_facesLeave()
                || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_BlockList___tail_fileDescLeave()
                || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_BlockList___tail_frameLeave()
                || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_BlockList___tail_mapChannelLeave())
            {
                Block block = GetBlock(syntaxTree.Children[0]);
                result.Add(block);
                var leftList = GetBlockList(syntaxTree.Children[1]);
                result.AddRange(leftList);
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_BlockList___tail_rightBrace_Leave())
            {
                // nothing to do
            }

            return result;
        }

        private static Block GetBlock(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            Block result = null;

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_Block___tail_facesLeave())
            {
                Faces faces = GetFaces(syntaxTree.Children[1]);
                result = faces;
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_Block___tail_fileDescLeave())
            {
                FileDesc fileDesc = GetFileDesc(syntaxTree.Children[1]);
                result = fileDesc;
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_Block___tail_frameLeave())
            {
                Frame frame = GetFrame(syntaxTree.Children[2]);
                frame.Order = (int)GetSignedNumber(syntaxTree.Children[1]);
                result = frame;
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_Block___tail_mapChannelLeave())
            {
                MapChannel mapChannel = GetMapChannel(syntaxTree.Children[2]);
                mapChannel.Order = (int)GetSignedNumber(syntaxTree.Children[1]);
                result = mapChannel;
            }

            return result;
        }

        private static MapChannel GetMapChannel(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            MapChannel result = null;
            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_MapChannel___tail_leftBrace_Leave())
            {
                result = new MapChannel();
                TextureList textureList = GetTextureList(syntaxTree.Children[1]);
                result.textureListObj = textureList;
            }
            return result;
        }

        private static TextureList GetTextureList(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            var textureList = new TextureList();

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_TextureList___tail_textureFacesLeave()
                || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_TextureList___tail_textureVerticesLeave())
            {
                Texture texture = GetTexture(syntaxTree.Children[0]);
                textureList.Add(texture);
                var leftList = GetTextureList(syntaxTree.Children[1]);
                textureList.AddRange(leftList);
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_TextureList___tail_rightBrace_Leave())
            {
                // nothing to do
            }

            return textureList;
        }

        private static Texture GetTexture(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            Texture result = null;

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_Texture___tail_textureFacesLeave())
            {
                result = GetTextureFaces(syntaxTree.Children[1]);
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_Texture___tail_textureVerticesLeave())
            {
                result = GetTextureVertices(syntaxTree.Children[1]);
            }

            return result;
        }

        private static TextureVertices GetTextureVertices(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            var result = new TextureVertices();

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_TextureVertices___tail_leftBrace_Leave())
            {
                TVertexList tVertexList = GetTVertexList(syntaxTree.Children[1]);
                result.tVertexListObj = tVertexList;
            }

            return result;
        }

        private static TVertexList GetTVertexList(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            var result = new TVertexList();

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_TVertexList___tail_tVertexLeave())
            {
                TVertex tVertex = GetTVertex(syntaxTree.Children[0]);
                result.Add(tVertex);
                var leftList = GetTVertexList(syntaxTree.Children[1]);
                result.AddRange(leftList);
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_TVertexList___tail_rightBrace_Leave())
            {
                // nothing to do
            }

            return result;
        }

        private static TVertex GetTVertex(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            var result = new TVertex();

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_TVertex___tail_tVertexLeave())
            {
                result.Order = (int)GetSignedNumber(syntaxTree.Children[1]);
                result.X = GetSignedNumber(syntaxTree.Children[2]);
                result.Y = GetSignedNumber(syntaxTree.Children[3]);
                result.Z = GetSignedNumber(syntaxTree.Children[4]);
                //for (int i = 0; i < 3; i++)
                //{
                //    result.VertexIndexes[i] = (int)GetSignedNumber(syntaxTree.Children[i + 2]);
                //}
            }

            return result;
        }

        private static TextureFaces GetTextureFaces(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            var result = new TextureFaces();

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_TextureFaces___tail_leftBrace_Leave())
            {
                TFaceList tFaceList = GetTFaceList(syntaxTree.Children[1]);
                result.tFaceListObj = tFaceList;
            }

            return result;
        }

        private static TFaceList GetTFaceList(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            var result = new TFaceList();

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_TFaceList___tail_tFaceLeave())
            {
                TFace tFace = GetTFace(syntaxTree.Children[0]);
                result.Add(tFace);
                var leftList = GetTFaceList(syntaxTree.Children[1]);
                result.AddRange(leftList);
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_TFaceList___tail_rightBrace_Leave())
            {
                // nothing to do
            }

            return result;
        }

        private static TFace GetTFace(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            var result = new TFace();

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_TFace___tail_tFaceLeave())
            {
                result.Order = (int)GetSignedNumber(syntaxTree.Children[1]);
                for (int i = 0; i < 3; i++)
                {
                    result.VertexIndexes[i] = (int)GetSignedNumber(syntaxTree.Children[i + 2]);
                }
            }

            return result;
        }

        private static Frame GetFrame(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            Frame result = null;
            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_Frame___tail_leftBrace_Leave())
            {
                result = new Frame();
                FrameContentItemList frameContentItemList = GetFrameContentItemList(syntaxTree.Children[1]);
                result.frameContentItemListObj = frameContentItemList;
            }

            return result;
        }

        private static FrameContentItemList GetFrameContentItemList(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            FrameContentItemList result = new FrameContentItemList();
            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FrameContentItemList___tail_verticesLeave())
            {

                FrameContentItem frameContentItem = GetFrameContentItem(syntaxTree.Children[0]);
                result.Add(frameContentItem);
                var rest = GetFrameContentItemList(syntaxTree.Children[1]);
                result.AddRange(rest);
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FrameContentItemList___tail_rightBrace_Leave())
            {
            }

            return result;
        }

        private static FrameContentItem GetFrameContentItem(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            FrameContentItem result = new FrameContentItem();

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FrameContentItem___tail_verticesLeave())
            {
                Vertices vertices = GetVertices(syntaxTree.Children[2]);
                result.verticesObj = vertices;
            }

            return result;
        }

        private static Vertices GetVertices(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            Vertices result = new Vertices();

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_Vertices___tail_rightBrace_Leave())
            {
                // nothing to do
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_Vertices___tail_vertexLeave())
            {
                Vertex vertex = GetVertex(syntaxTree.Children[0]);
                result.Add(vertex);
                Vertices left = GetVertices(syntaxTree.Children[1]);
                result.AddRange(left);
            }

            return result;
        }

        private static Vertex GetVertex(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            Vertex result = new Vertex();

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_Vertex___tail_vertexLeave())
            {
                result.Order = (int)GetSignedNumber(syntaxTree.Children[1]);
                result.X = GetSignedNumber(syntaxTree.Children[2]);
                result.Y = GetSignedNumber(syntaxTree.Children[3]);
                result.Z = GetSignedNumber(syntaxTree.Children[4]);
            }

            return result;
        }

        private static double GetSignedNumber(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            double result = 0;
            //if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_faceLeave()
            //    || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_facesLeave()
            //    || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_framesLeave()
            //    || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_leftBrace_Leave()
            //    || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_mapLeave()
            //    || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_matIDLeave()
            //    || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_minus_Leave()
            //    || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_plus_Leave()
            //    || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_rightBrace_Leave()
            //    || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_tFaceLeave()
            //    || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_tVertexLeave()
            //    || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_tVerticesLeave()
            //    || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_vertexLeave()
            //    || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_verticesLeave()
            //    )
            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_plus_Leave())
            {
                result = double.Parse(syntaxTree.Children[1].NodeValue.NodeName);
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___tail_minus_Leave())
            {
                result = -double.Parse(syntaxTree.Children[1].NodeValue.NodeName);
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_SignedNumber___numberLeave())
            {
                result = double.Parse(syntaxTree.Children[0].NodeValue.NodeName);
            }
            //{
            //    var positiveSign = GetSign(syntaxTree.Children[0]);
            //    result = double.Parse(syntaxTree.Children[1].NodeValue.NodeName);
            //    if (!positiveSign)
            //    {
            //        result = -result;
            //    }
            //}
            else
            {
                throw new Exception("not valid SignedNumber " + syntaxTree.NodeValue.NodeName);
            }

            return result;
        }

        //private static bool GetSign(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        //{
        //    var result = true;

        //    if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_Sign___numberLeave())
        //    {
        //        result = true;
        //    }
        //    else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_Sign___tail_minus_Leave())
        //    {
        //        result = false;
        //    }
        //    else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_Sign___tail_plus_Leave())
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        throw new Exception("not valid sign " + syntaxTree.NodeValue.NodeName);
        //    }
        //    return result;
        //}

        private static FileDesc GetFileDesc(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            FileDesc result = new FileDesc();
            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FileDesc___tail_leftBrace_Leave())
            {
                FileDescItemList fileDescItem = GetFileDescItemList(syntaxTree.Children[1]);
                result.fileDescItemObj = fileDescItem;
            }
            return result;
        }

        private static FileDescItemList GetFileDescItemList(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            var result = new FileDescItemList();
            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FileDescItemList___tail_facesLeave()
                || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FileDescItemList___tail_framesLeave()
                || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FileDescItemList___tail_mapLeave()
                || syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FileDescItemList___tail_verticesLeave())
            {
                FileDescItem fileDescItem = GetFileDescItem(syntaxTree.Children[0]);
                result.Add(fileDescItem);
                var leftItems = GetFileDescItemList(syntaxTree.Children[1]);
                result.AddRange(leftItems);
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FileDescItemList___tail_rightBrace_Leave())
            {
                // nothing to do
            }
            return result;
        }

        private static FileDescItem GetFileDescItem(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            FileDescItem result = null;
            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FileDescItem___tail_facesLeave())
            {
                var facesCount = (int)GetSignedNumber(syntaxTree.Children[1]);
                var facesCountObj = new FacesCount();
                facesCountObj.facesCount = facesCount;
                result = facesCountObj;
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FileDescItem___tail_framesLeave())
            {
                var framesCount = (int)GetSignedNumber(syntaxTree.Children[1]);
                var framesCountObj = new FramesCount();
                framesCountObj.framesCount = framesCount;
                result = framesCountObj;
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FileDescItem___tail_mapLeave())
            {
                var mapCount = (int)GetSignedNumber(syntaxTree.Children[1]);
                var tVerticesCount = (int)GetSignedNumber(syntaxTree.Children[3]);
                var mapCountObj = new MapCount();
                mapCountObj.mapCount = mapCount;
                mapCountObj.tVerticesCount = tVerticesCount;
                result = mapCountObj;
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FileDescItem___tail_verticesLeave())
            {
                var verticesCount = (int)GetSignedNumber(syntaxTree.Children[1]);
                var verticesCountObj = new VerticesCount();
                verticesCountObj.verticesCount = verticesCount;
                result = verticesCountObj;
            }

            return result;
        }

        private static Faces GetFaces(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            var result = new Faces();
            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_Faces___tail_leftBrace_Leave())
            {
                FaceList faceList = GetFaceList(syntaxTree.Children[1]);
                result.faceListObj = faceList;
            }
            return result;
        }

        private static FaceList GetFaceList(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            var result = new FaceList();

            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FaceList___tail_faceLeave())
            {
                Face face = GetFace(syntaxTree.Children[0]);
                result.Add(face);
                var leftList = GetFaceList(syntaxTree.Children[1]);
                result.AddRange(leftList);
            }
            else if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_FaceList___tail_rightBrace_Leave())
            {
                // nothing to do
            }

            return result;
        }

        private static Face GetFace(SyntaxTree<EnumTokenTypeDTM, EnumVTypeDTM, TreeNodeValueDTM> syntaxTree)
        {
            var face = new Face();
            if (syntaxTree.CandidateFunc == LL1SyntaxParserDTM.GetFuncParsecase_Face___tail_faceLeave())
            {
                face.Order = (int)GetSignedNumber(syntaxTree.Children[1]);
                for (int i = 0; i < 3; i++)
                {
                    face.verticesIndex[i] = (int)GetSignedNumber(syntaxTree.Children[i + 2]);
                }
                face.MatID = (int)GetSignedNumber(syntaxTree.Children[6]);
            }
            return face;
        }
    }
}
