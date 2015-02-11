using System;


namespace bitzhuwei._3DS
{
    public class MaterialD3S
    {
        public float[] Ambient = new float[] { 0.5f, 0.5f, 0.5f };
        public float[] Diffuse = new float[] { 0.5f, 0.5f, 0.5f };
        public float[] Specular = new float[] { 0.5f, 0.5f, 0.5f };
        public int Shininess = 50;

        int textureid = -1;
        public int TextureId
        {
            get
            {
                return textureid;
            }
        }

    }
}
