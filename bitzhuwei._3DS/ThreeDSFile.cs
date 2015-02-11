using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using System.Drawing;

namespace bitzhuwei._3DS
{
    public class ThreeDSFile
    {
        enum ChunkType
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

        public ThreeDSFile(string file_name)
        {
            base_dir = new FileInfo(file_name).DirectoryName + "/";

            FileStream file;
            file = new FileStream(file_name, FileMode.Open, FileAccess.Read);

            reader = new BinaryReader(file);
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            ThreeDSChunk chunk = new ThreeDSChunk(reader);
            if (chunk.ID != (short)ChunkType.MainChunk)
                throw new Exception("Not a proper 3DS file.");

            ProcessChunk(chunk);

            reader.Close();
            file.Close();
        }
        void ProcessChunk(ThreeDSChunk chunk)
        {
            while (chunk.BytesRead < chunk.Length)
            {
                ThreeDSChunk child = new ThreeDSChunk(reader);

                switch ((ChunkType)child.ID)
                {
                    case ChunkType.CVersion:

                        int version = reader.ReadInt32();
                        child.BytesRead += 4;

                        break;

                    case ChunkType._3DEditorChunk:

                        ThreeDSChunk obj_chunk = new ThreeDSChunk(reader);

                        // not sure whats up with this chunk
                        SkipChunk(obj_chunk);
                        child.BytesRead += obj_chunk.BytesRead;

                        ProcessChunk(child);

                        break;

                    case ChunkType.MaterialBlock:

                        ProcessMaterialChunk(child);
                        break;

                    case ChunkType.ObjectBlock:

                        string name = ProcessString(child);
                        Entity e = ProcessObjectChunk(child);
                        e.CalculateNormals();
                        model.Entities.Add(e);

                        break;

                    default:

                        SkipChunk(child);
                        break;

                }

                chunk.BytesRead += child.BytesRead;
            }
        }

        void ProcessMaterialChunk(ThreeDSChunk chunk)
        {
            string name = string.Empty;
            MaterialD3S m = new MaterialD3S();

            while (chunk.BytesRead < chunk.Length)
            {
                ThreeDSChunk child = new ThreeDSChunk(reader);

                switch ((ChunkType)child.ID)
                {
                    case ChunkType.MaterialName:

                        name = ProcessString(child);
                        break;

                    case ChunkType.AmbientColor:

                        m.Ambient = ProcessColorChunk(child);
                        break;

                    case ChunkType.DiffuseColor:

                        m.Diffuse = ProcessColorChunk(child);
                        break;

                    case ChunkType.SpecularColor:

                        m.Specular = ProcessColorChunk(child);
                        break;

                    case ChunkType.C_MATSHININESS:

                        m.Shininess = ProcessPercentageChunk(child);
                        //Console.WriteLine ( "SHININESS: {0}", m.Shininess );
                        break;

                    case ChunkType.TextureMap:

                        ProcessPercentageChunk(child);

                        //SkipChunk ( child );
                        ProcessTexMapChunk(child, m);

                        break;

                    default:

                        SkipChunk(child);
                        break;
                }
                chunk.BytesRead += child.BytesRead;
            }
            materials.Add(name, m);
        }

        void ProcessTexMapChunk(ThreeDSChunk chunk, MaterialD3S m)
        {
            while (chunk.BytesRead < chunk.Length)
            {
                ThreeDSChunk child = new ThreeDSChunk(reader);
                switch ((ChunkType)child.ID)
                {
                    case ChunkType.MappingFilename:

                        string name = ProcessString(child);

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

                        SkipChunk(child, (int)(chunk.Length - chunk.BytesRead - child.BytesRead));
                        break;

                }
                chunk.BytesRead += child.BytesRead;
            }
        }

        float[] ProcessColorChunk(ThreeDSChunk chunk)
        {
            ThreeDSChunk child = new ThreeDSChunk(reader);
            float[] c = new float[] { (float)reader.ReadByte() / 256, (float)reader.ReadByte() / 256, (float)reader.ReadByte() / 256 };
            chunk.BytesRead += (int)child.Length;
            return c;
        }

        int ProcessPercentageChunk(ThreeDSChunk chunk)
        {
            ThreeDSChunk child = new ThreeDSChunk(reader);
            int per = reader.ReadUInt16();
            child.BytesRead += 2;
            chunk.BytesRead += child.BytesRead;
            return per;
        }

        Entity ProcessObjectChunk(ThreeDSChunk chunk)
        {
            return ProcessObjectChunk(chunk, new Entity());
        }

        Entity ProcessObjectChunk(ThreeDSChunk chunk, Entity e)
        {
            while (chunk.BytesRead < chunk.Length)
            {
                ThreeDSChunk child = new ThreeDSChunk(reader);

                switch ((ChunkType)child.ID)
                {
                    case ChunkType.TriangularMesh:

                        ProcessObjectChunk(child, e);
                        break;

                    case ChunkType.VerticesList:

                        e.vertices = ReadVertices(child);
                        break;

                    case ChunkType.FacesDescription:

                        e.indices = ReadIndices(child);

                        if (child.BytesRead < child.Length)
                            ProcessObjectChunk(child, e);
                        break;

                    case ChunkType.FacesMaterial:

                        string name2 = ProcessString(child);

                        MaterialD3S mat;
                        if (materials.TryGetValue(name2, out mat))
                            e.material = mat;

                        SkipChunk(child);
                        break;

                    case ChunkType.MappingCoordinatesList:

                        int cnt = reader.ReadUInt16();
                        child.BytesRead += 2;

                        e.texcoords = new TexCoord[cnt];
                        for (int ii = 0; ii < cnt; ii++)
                            e.texcoords[ii] = new TexCoord(reader.ReadSingle(), reader.ReadSingle());

                        child.BytesRead += (cnt * (4 * 2));

                        break;

                    default:

                        SkipChunk(child);
                        break;

                }
                chunk.BytesRead += child.BytesRead;
            }
            return e;
        }

        void SkipChunk(ThreeDSChunk chunk, int maxSkip=-1)
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
            chunk.BytesRead += length;
        }

        string ProcessString(ThreeDSChunk chunk)
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

            return sb.ToString();
        }

        Vector[] ReadVertices(ThreeDSChunk chunk)
        {
            ushort numVerts = reader.ReadUInt16();
            chunk.BytesRead += 2;
            Vector[] verts = new Vector[numVerts];

            for (int ii = 0; ii < verts.Length; ii++)
            {
                float f1 = reader.ReadSingle();
                float f2 = reader.ReadSingle();
                float f3 = reader.ReadSingle();

                verts[ii] = new Vector(f1, f3, -f2);
            }

            chunk.BytesRead += verts.Length * (3 * 4);

            return verts;
        }

        Triangle[] ReadIndices(ThreeDSChunk chunk)
        {
            ushort numIdcs = reader.ReadUInt16();
            chunk.BytesRead += 2;
            Triangle[] idcs = new Triangle[numIdcs];

            for (int ii = 0; ii < idcs.Length; ii++)
            {
                idcs[ii] = new Triangle(reader.ReadUInt16(), reader.ReadUInt16(), reader.ReadUInt16());
                reader.ReadUInt16();
            }
            chunk.BytesRead += (2 * 4) * idcs.Length;
            return idcs;
        }

    }
}
