using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using System.Drawing;
using System.Xml.Linq;

namespace bitzhuwei._3DS
{
    public enum ChunkType
    {
        MainChunk = 0x4D4D,
        _3DEditorChunk = 0x3D3D,
        CVersion = 0x0002,
        KeyFramerChunk = 0xB000,
        MaterialBlock = 0xAFFF,
        MaterialName = 0xA000,
        AmbientColor = 0xA010,
        DiffuseColor = 0xA020,
        SpecularColor = 0xA030,
        C_MATSHININESS = 0xA040,
        TextureMap = 0xA200,
        MappingFilename = 0xA300,
        ObjectBlock = 0x4000,
        TriangularMesh = 0x4100,
        VerticesList = 0x4110,
        FacesDescription = 0x4120,
        FacesMaterial = 0x4130,
        /// <summary>
        /// UV
        /// </summary>
        MappingCoordinatesList = 0x4140
    }
    public class ThreeDSFile
    {
 
        class ThreeDSChunk
        {
            public ushort ID;
            public uint Length;
            public int BytesRead;

            public ThreeDSChunk(BinaryReader reader)
            {
                // 2 byte ID
                ID = reader.ReadUInt16();
                // 4 byte length
                Length = reader.ReadUInt32();
                // = 6
                BytesRead = 6;
            }

            public override string ToString()
            {
                return string.Format("{0}, {1}, {2}", (ChunkType)ID, Length, BytesRead);
                //return base.ToString();
            }
        }

        BinaryReader reader;

        Model model = new Model();
        public Model ThreeDSModel
        {
            get
            {
                return model;
            }
        }

        Dictionary<string, MaterialD3S> materials = new Dictionary<string, MaterialD3S>();

        string base_dir;

        public ThreeDSFile(string file_name, XElement root = null)
        {
            base_dir = new FileInfo(file_name).DirectoryName + "/";

            FileStream file;
            file = new FileStream(file_name, FileMode.Open, FileAccess.Read);

            reader = new BinaryReader(file);
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            ThreeDSChunk chunk = new ThreeDSChunk(reader);
            if (chunk.ID != (short)ChunkType.MainChunk)
                throw new Exception("Not a proper 3DS file.");

            if (root != null)
            {
                root.Name = "_" + ((ChunkType)(chunk.ID)).ToString();
                root.Add(new XAttribute("Length", chunk.Length));
            }

            ProcessChunk(chunk, root);

            reader.Close();
            file.Close();

        }

        void ProcessChunk(ThreeDSChunk chunk, XElement chunkXml = null)
        {
            while (chunk.BytesRead < chunk.Length)
            {
                ThreeDSChunk child = new ThreeDSChunk(reader);
                XElement childXml = null;
                if (chunkXml != null)
                {
                    childXml = new XElement("_" + ((ChunkType)child.ID).ToString(),
                        new XAttribute("Length", child.Length));
                }
                switch ((ChunkType)child.ID)
                {
                    case ChunkType.CVersion:

                        int version = reader.ReadInt32();
                        child.BytesRead += 4;

                        if (chunkXml != null)
                        {
                            childXml.Value = version.ToString();
                        }
                        break;

                    case ChunkType._3DEditorChunk:

                        Process3DEditorChunk(child, childXml);
                        break;

                    case ChunkType.MaterialBlock:

                        ProcessMaterialChunk(child, childXml);
                        break;

                    case ChunkType.ObjectBlock:

                        string name = ProcessString(child, childXml);
                        Entity e = ProcessObjectChunk(child, childXml);
                        e.CalculateNormals();
                        model.Entities.Add(e);

                        break;

                    default:

                        SkipChunk(child, childXml);
                        break;

                }
                if (chunkXml != null)
                {
                    chunkXml.Add(childXml);
                }
                chunk.BytesRead += child.BytesRead;
            }
        }

        private void Process3DEditorChunk(ThreeDSChunk chunk, XElement chunkXml)
        {
            while (chunk.BytesRead < chunk.Length)
            {
                ThreeDSChunk child = new ThreeDSChunk(reader);
                XElement childXml = null;
                if (chunkXml != null)
                {
                    childXml = new XElement("_" + ((ChunkType)child.ID).ToString(),
                        new XAttribute("Length", child.Length));
                }
                switch ((ChunkType)child.ID)
                {
                    case ChunkType.ObjectBlock:

                        string name = ProcessString(child, childXml);
                        Entity e = ProcessObjectChunk(child, childXml);
                        e.CalculateNormals();
                        model.Entities.Add(e);

                        break;

                    default:

                        SkipChunk(child, childXml);
                        break;

                }
                if (chunkXml != null)
                {
                    chunkXml.Add(childXml);
                }
                chunk.BytesRead += child.BytesRead;
            }
        }


        void ProcessMaterialChunk(ThreeDSChunk chunk, XElement chunkXml)
        {
            string name = string.Empty;
            MaterialD3S m = new MaterialD3S();

            while (chunk.BytesRead < chunk.Length)
            {
                ThreeDSChunk child = new ThreeDSChunk(reader);
                XElement childXml = null;
                if (chunkXml != null)
                {
                    childXml = new XElement(
                        "_" + ((ChunkType)child.ID).ToString(),
                        new XAttribute("Length", child.Length)
                        );
                }
                switch ((ChunkType)child.ID)
                {
                    case ChunkType.MaterialName:

                        name = ProcessString(child, childXml);
                        break;

                    case ChunkType.AmbientColor:

                        m.Ambient = ProcessColorChunk(child, childXml);
                        break;

                    case ChunkType.DiffuseColor:

                        m.Diffuse = ProcessColorChunk(child, childXml);
                        break;

                    case ChunkType.SpecularColor:

                        m.Specular = ProcessColorChunk(child, childXml);
                        break;

                    case ChunkType.C_MATSHININESS:

                        m.Shininess = ProcessPercentageChunk(child, childXml);
                        //Console.WriteLine ( "SHININESS: {0}", m.Shininess );
                        break;

                    case ChunkType.TextureMap:

                        ProcessPercentageChunk(child, childXml);

                        //SkipChunk ( child );
                        ProcessTexMapChunk(child, m, childXml);

                        break;

                    default:

                        SkipChunk(child, childXml);
                        break;
                }
                if (chunkXml != null)
                { chunkXml.Add(childXml); }
                chunk.BytesRead += child.BytesRead;
            }
            materials.Add(name, m);
        }

        void ProcessTexMapChunk(ThreeDSChunk chunk, MaterialD3S m, XElement chunkXml)
        {
            while (chunk.BytesRead < chunk.Length)
            {
                ThreeDSChunk child = new ThreeDSChunk(reader);
                XElement childXml = null;
                if (chunkXml != null)
                {
                    childXml = new XElement(
                        "_" + ((ChunkType)child.ID).ToString(),
                        new XAttribute("Length", child.Length));
                }
                switch ((ChunkType)child.ID)
                {
                    case ChunkType.MappingFilename:

                        string name = ProcessString(child, childXml);

                        Bitmap bmp;
                        try
                        {
                            bmp = new Bitmap(base_dir + name);
                        }
                        catch (Exception e)
                        {
                            break;
                        }

                        bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        System.Drawing.Imaging.BitmapData imgData = bmp.LockBits(new Rectangle(new Point(0, 0), bmp.Size),
                                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        //m.BindTexture(imgData.Width, imgData.Height, imgData.Scan0);
                        bmp.UnlockBits(imgData);
                        bmp.Dispose();

                        break;

                    default:

                        SkipChunk(child, childXml, (int)(chunk.Length - chunk.BytesRead - child.BytesRead));
                        break;

                }
                if (chunkXml != null)
                { chunkXml.Add(childXml); }
                chunk.BytesRead += child.BytesRead;
            }
        }

        float[] ProcessColorChunk(ThreeDSChunk chunk, XElement chunkXml)
        {
            ThreeDSChunk child = new ThreeDSChunk(reader);
            float[] c = new float[] { (float)reader.ReadByte() / 256, (float)reader.ReadByte() / 256, (float)reader.ReadByte() / 256 };
            chunk.BytesRead += (int)child.Length;
            if (chunkXml != null)
            {
                chunkXml.Add(new XAttribute("r", c[0]),
                    new XAttribute("g", c[1]),
                    new XAttribute("b", c[2]));
            }
            return c;
        }

        int ProcessPercentageChunk(ThreeDSChunk chunk, XElement chunkXml)
        {
            ThreeDSChunk child = new ThreeDSChunk(reader);
            int per = reader.ReadUInt16();
            child.BytesRead += 2;
            chunk.BytesRead += child.BytesRead;

            if (chunkXml != null)
            { chunkXml.Add(new XAttribute("per", per)); }
            return per;
        }

        Entity ProcessObjectChunk(ThreeDSChunk chunk, XElement chunkXml)
        {
            return ProcessObjectChunk(chunk, new Entity(), chunkXml);
        }

        Entity ProcessObjectChunk(ThreeDSChunk chunk, Entity e, XElement chunkXml)
        {
            while (chunk.BytesRead < chunk.Length)
            {
                ThreeDSChunk child = new ThreeDSChunk(reader);
                XElement childXml = null;
                if (chunkXml != null)
                {
                    childXml = new XElement(
                        "_" + ((ChunkType)child.ID).ToString(),
                        new XAttribute("Length", child.Length));
                }
                switch ((ChunkType)child.ID)
                {
                    case ChunkType.TriangularMesh:
                        ProcessObjectChunk(child, e, childXml);

                        break;

                    case ChunkType.VerticesList:

                        e.vertices = ReadVertices(child, childXml);
                        break;

                    case ChunkType.FacesDescription:

                        e.indices = ReadIndices(child, childXml);

                        if (child.BytesRead < child.Length)
                            ProcessObjectChunk(child, e, childXml);
                        break;

                    case ChunkType.FacesMaterial:

                        string name2 = ProcessString(child, childXml);

                        MaterialD3S mat;
                        if (materials.TryGetValue(name2, out mat))
                            e.material = mat;

                        SkipChunk(child, childXml);
                        break;

                    case ChunkType.MappingCoordinatesList:

                        ReadTexCoord(child, e, childXml);

                        break;

                    default:

                        SkipChunk(child, childXml);
                        break;

                }
                if (chunkXml != null)
                {
                    chunkXml.Add(childXml);
                }
                chunk.BytesRead += child.BytesRead;
            }
            return e;
        }

        private void ReadTexCoord(ThreeDSChunk chunk, Entity e, XElement chunkXml)
        {
            int cnt = reader.ReadUInt16();
            chunk.BytesRead += 2;

            e.texcoords = new TexCoord[cnt];
            if (chunkXml != null) { chunkXml.Add(new XElement("TexCoordCount", cnt, new XAttribute("Length", 2))); }
            for (int ii = 0; ii < cnt; ii++)
            {
                e.texcoords[ii] = new TexCoord(reader.ReadSingle(), reader.ReadSingle());
                if (chunkXml != null)
                {
                    chunkXml.Add(new XElement("TexCoord",
                      new XAttribute("Length", "8"),
                      e.texcoords[ii].ToString()));
                }
            }

            chunk.BytesRead += (cnt * (4 * 2));
        }

        void SkipChunk(ThreeDSChunk chunk, XElement chunkXml, int maxSkip = -1)
        {
            int length = (int)chunk.Length - chunk.BytesRead;
            if (maxSkip != -1)
            {
                if (length > maxSkip)//Something wrong about 3ds file may happen here.
                {
                    length = maxSkip;
                }
            }
            reader.ReadBytes(length);
            if (chunkXml != null)
            {
                chunkXml.Add(new XAttribute("Skip", length));
            }
            chunk.BytesRead += length;
        }

        string ProcessString(ThreeDSChunk chunk, XElement chunkXml)
        {
            StringBuilder sb = new StringBuilder();
            byte b = reader.ReadByte();
            int idx = 0;
            while (b != 0)
            {
                sb.Append((char)b);
                b = reader.ReadByte();
                idx++;
            }
            chunk.BytesRead += idx + 1;

            var str = sb.ToString();
            if (chunkXml != null)
            {
                chunkXml.Add(new XElement("String", str, new XAttribute("Length", idx + 1)));
            }
            return str;
        }

        Vector[] ReadVertices(ThreeDSChunk chunk, XElement chunkXml)
        {
            ushort numVerts = reader.ReadUInt16();
            chunk.BytesRead += 2;
            Vector[] verts = new Vector[numVerts];
            if (chunkXml != null) { chunkXml.Add(new XElement("numVerts", numVerts, new XAttribute("Length", 2))); }
            for (int ii = 0; ii < verts.Length; ii++)
            {
                float f1 = reader.ReadSingle();
                float f2 = reader.ReadSingle();
                float f3 = reader.ReadSingle();

                verts[ii] = new Vector(f1, f3, -f2);
                if (chunkXml != null)
                {
                    chunkXml.Add(
                        new XElement("Vector", verts[ii].ToString(),
                            new XAttribute("Length", "12"))
                        );
                }
            }

            chunk.BytesRead += verts.Length * (3 * 4);

            return verts;
        }

        Triangle[] ReadIndices(ThreeDSChunk chunk, XElement chunkXml)
        {
            ushort numIdcs = reader.ReadUInt16();
            if (chunkXml != null) { chunkXml.Add(new XElement("numIndices", numIdcs, new XAttribute("Length", 2))); }
            chunk.BytesRead += 2;
            Triangle[] idcs = new Triangle[numIdcs];

            for (int ii = 0; ii < idcs.Length; ii++)
            {
                idcs[ii] = new Triangle(reader.ReadUInt16(), reader.ReadUInt16(), reader.ReadUInt16());
                reader.ReadUInt16();
                if (chunkXml != null)
                {
                    chunkXml.Add(new XElement(
                      "triIndex", idcs[ii].ToString(),
                      new XAttribute("Length", "8")));
                }
            }
            chunk.BytesRead += (2 * 4) * idcs.Length;
            return idcs;
        }


    }
}
