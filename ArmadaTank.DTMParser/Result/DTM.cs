using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ArmadaTank.DTMParser.Result
{
    public class DTM
    {
        public FileContent fileContentObj { get; set; }

        public override string ToString()
        {
            return string.Format("{0} frame, {1} vertices, {2} faces.",
                frame, vertices, faces);
            //return base.ToString();
        }
        private int frame;
        private int vertices;
        private int faces;

        public List<Vertices> GetFrameList()
        {
            var result = new List<Vertices>();

            foreach (var item in fileContentObj.blockListObj)
            {
                var frameBlock = item as Frame;
                if (frameBlock != null)
                {
                    frame = frameBlock.frameContentItemListObj.Count;
                    foreach (var frameContentItemList in frameBlock.frameContentItemListObj)
                    {
                        var verticesObj = frameContentItemList.verticesObj;
                        vertices = verticesObj.Count;
                        result.Add(verticesObj);
                    }
                }
            }

            return result;
        }

        public List<Face> GetModelFaces()
        {
            var result = new List<Face>();

            foreach (var item in fileContentObj.blockListObj)
            {
                var facesBlock = item as Faces;
                if (facesBlock != null)
                {
                    faces = facesBlock.faceListObj.Count;
                    foreach (var face in facesBlock.faceListObj)
                    {
                        result.Add(face);
                    }
                }
            }

            return result;
        }

        public List<TVertex> GetTextureVertices()
        {
            var result = new List<TVertex>();

            foreach (var item in fileContentObj.blockListObj)
            {
                var mapChannelBlock = item as MapChannel;
                if (mapChannelBlock != null)
                {
                    foreach (var texture in mapChannelBlock.textureListObj)
                    {
                        //var textureFaces = texture as TextureFaces;
                        //if (textureFaces != null)
                        //{

                        //}
                        var textureVertices = texture as TextureVertices;
                        if (textureVertices != null)
                        {
                            foreach (var tvertex in textureVertices.tVertexListObj)
                            {
                                result.Add(tvertex);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public List<TFace> GetTextureFaces()
        {
            var result = new List<TFace>();

            foreach (var item in fileContentObj.blockListObj)
            {
                var mapChannelBlock = item as MapChannel;
                if (mapChannelBlock != null)
                {
                    foreach (var texture in mapChannelBlock.textureListObj)
                    {
                        var textureFaces = texture as TextureFaces;
                        if (textureFaces != null)
                        {
                            foreach (var tface in textureFaces.tFaceListObj)
                            {
                                result.Add(tface);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public Bitmap GenerateBitmap(int width, int height)
        {
            var textureFaces = GetTextureFaces();
            var textureVertices = GetTextureVertices();

            foreach (var vertex in textureVertices)
            {
                vertex.X *= width;
                vertex.Y *= height;
                //vertex.Z *= ?; // all z indexes of vertex are 0.
            }

            var bitmap = new Bitmap(width, height);
            var canvas = Graphics.FromImage(bitmap);
            canvas.Clear(Color.White);
            var redPen = new Pen(Color.Red);
            var greenPen = new Pen(Color.Green);
            var bluePen = new Pen(Color.Blue);

            foreach (var face in textureFaces)
            {
                var tvertexA = textureVertices[face.VertexIndexes[0]];
                var tvertexB = textureVertices[face.VertexIndexes[1]];
                var tvertexC = textureVertices[face.VertexIndexes[2]];
                var pointA = new PointF((float)tvertexA.X, (float)tvertexA.Y);
                var pointB = new PointF((float)tvertexB.X, (float)tvertexB.Y);
                var pointC = new PointF((float)tvertexC.X, (float)tvertexC.Y);
                canvas.DrawLine(redPen, pointA, pointB);
                canvas.DrawLine(greenPen, pointB, pointC);
                canvas.DrawLine(bluePen, pointC, pointA);
            }

            canvas.Flush();
            canvas.Dispose();

            return bitmap;
        }
    }
}
