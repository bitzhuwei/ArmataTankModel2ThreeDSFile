using System;

namespace bitzhuwei._3DS
{
    public struct TexCoord
    {
        public float U;
        public float V;

        public TexCoord(float u, float v)
        {
            U = u;
            V = v;
        }
    }

    public class Entity
    {
        public MaterialD3S material = new MaterialD3S();
        public Vector[] vertices;
        public Vector[] normals;
        public Triangle[] indices;
        public TexCoord[] texcoords;
        bool normalized = false;

        public void CalculateNormals()
        {
            if (indices == null) return;

            normals = new Vector[vertices.Length];

            Vector[] temps = new Vector[indices.Length];

            for (int ii = 0; ii < indices.Length; ii++)
            {
                Triangle tr = indices[ii];

                Vector v1 = vertices[tr.vertex1] - vertices[tr.vertex2];
                Vector v2 = vertices[tr.vertex2] - vertices[tr.vertex3];

                temps[ii] = v1.CrossProduct(v2);
            }

            for (int ii = 0; ii < vertices.Length; ii++)
            {
                Vector v = new Vector();
                int shared = 0;

                for (int jj = 0; jj < indices.Length; jj++)
                {
                    Triangle tr = indices[jj];
                    if (tr.vertex1 == ii || tr.vertex2 == ii || tr.vertex3 == ii)
                    {
                        v += temps[jj];
                        shared++;
                    }
                }

                normals[ii] = (v / shared).Normalize();
            }
            normalized = true;
        }
    }
}
