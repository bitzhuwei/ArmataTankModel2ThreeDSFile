using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bitzhuwei._3DS;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Linq;

namespace bitzhuwei._3DSViewer
{
    public partial class FormMain : Form
    {
        private float rotation;
        private float horizontal = 0;
        private float vertical = 0;
        private float zoom = 1;
        private List<ThreeDSFile> _3dsFileList = new List<ThreeDSFile>();
        //private ThreeDSFile _3dsFile;
        private List<Bitmap> textureImageList = new List<Bitmap>();
        //private Bitmap textureImage;
        //private bool textureAdded = false;
        private List<SharpGL.SceneGraph.Assets.Texture> textureList = new List<SharpGL.SceneGraph.Assets.Texture>();
        //private SharpGL.SceneGraph.Assets.Texture texture;

        public FormMain()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.open3DSDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //try
                {
                    XElement root = new XElement("threedDS");
                    var _3dsFile = new ThreeDSFile(this.open3DSDlg.FileName, root);
                    if (_3dsFile != null)
                    {
                        this._3dsFileList.Clear();
                        this._3dsFileList.Add(_3dsFile);
                        var fileInfo = new FileInfo(this.open3DSDlg.FileName);
                        root.Save(Path.Combine(fileInfo.DirectoryName, fileInfo.Name + ".xml"));
                    }
                    else
                    { MessageBox.Show("Failed to load " + this.open3DSDlg.FileName); }
                    //this._3dsFile = _3dsFile;
                }
                //catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            var gl = openGLControl1.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.Translate(horizontal, vertical, 0);
            gl.Rotate(rotation, 0, 1, 0);
            gl.Scale(zoom, zoom, zoom);
            //if (_3dsFile == null) { return; }

            int i = 0;
            foreach (var _3dsFile in this._3dsFileList)
            {
                foreach (var entity in _3dsFile.ThreeDSModel.Entities)
                {
                    if (entity.vertices == null) { continue; }
                    if (entity.indices == null) { continue; }

                    if (entity.texcoords != null && i<this.textureList.Count)
                    {
                        //gl.Disable(OpenGL.GL_LIGHTING);
                        gl.Enable(OpenGL.GL_TEXTURE_2D);
                        gl.BindTexture(OpenGL.GL_TEXTURE_2D, this.textureList[i++].TextureName);
                        //gl.BindTexture(OpenGL.GL_TEXTURE_2D, this.texture.TextureName);
                        //gl.ShadeModel(OpenGL.GL_SMOOTH);// Enables Smooth Shading
                        gl.Begin(SharpGL.Enumerations.BeginMode.Triangles);
                        foreach (var triangle in entity.indices)
                        {
                            var point1 = entity.vertices[triangle.vertex1];
                            var uv1 = entity.texcoords[triangle.vertex1];
                            gl.TexCoord(uv1.U, uv1.V);
                            gl.Vertex(point1.X, point1.Y, point1.Z);
                            var point2 = entity.vertices[triangle.vertex2];
                            var uv2 = entity.texcoords[triangle.vertex2];
                            gl.TexCoord(uv2.U, uv2.V);
                            gl.Vertex(point2.X, point2.Y, point2.Z);
                            var point3 = entity.vertices[triangle.vertex3];
                            var uv3 = entity.texcoords[triangle.vertex3];
                            gl.TexCoord(uv3.U, uv3.V);
                            gl.Vertex(point3.X, point3.Y, point3.Z);
                        }
                        gl.End();
                    }
                    else
                    {
                        gl.Begin(SharpGL.Enumerations.BeginMode.Triangles);
                        foreach (var triangle in entity.indices)
                        {
                            var point1 = entity.vertices[triangle.vertex1];
                            gl.Vertex(point1.X, point1.Y, point1.Z);
                            var point2 = entity.vertices[triangle.vertex2];
                            gl.Vertex(point2.X, point2.Y, point2.Z);
                            var point3 = entity.vertices[triangle.vertex3];
                            gl.Vertex(point3.X, point3.Y, point3.Z);
                        }
                        gl.End();
                    }
                }
            }
            
            rotation += 3;
        }
        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            var gl = openGLControl1.OpenGL;
            gl.ClearColor(0, 0, 0, 0);
        }

        private void openGLControl1_Resized(object sender, EventArgs e)
        {
            var gl = openGLControl1.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Perspective(60, (double)openGLControl1.Width / (double)openGLControl1.Height, 0.01, 1000);
            gl.LookAt(0, 5, -5, 0, 0, 0, 0, 1, 0);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            var zoomSpeed = 0.5f;
            var horizontalMoveSpeed = 0.2f;
            var verticalMoveSpeed = 0.2f;
            if (e.KeyCode == Keys.Q)
            {
                zoom *= (1 + zoomSpeed);
            }
            else if (e.KeyCode == Keys.E)
            {
                zoom *= (1 - 0.5f);
            }
            else if (e.KeyCode == Keys.A)
            {
                horizontal += horizontalMoveSpeed;
            }
            else if (e.KeyCode == Keys.D)
            {
                horizontal -= horizontalMoveSpeed;
            }
            else if (e.KeyCode == Keys.W)
            {
                vertical += verticalMoveSpeed;
            }
            else if (e.KeyCode == Keys.S)
            {
                vertical -= verticalMoveSpeed;
            }
        }

        private void toolStripItemOpenTexture_Click(object sender, EventArgs e)
        {
            if (openTextureDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //this.textureAdded = false;
                try
                {
                    var texture = new SharpGL.SceneGraph.Assets.Texture();
                    var textureImage = new Bitmap(openTextureDlg.FileName);
                    texture.Create(this.openGLControl1.OpenGL, textureImage);
                    this.textureList.Clear();
                    this.textureImageList.Clear();
                    this.textureImageList.Add(textureImage);
                    this.textureList.Add(texture);

                    //this.textureAdded = true;
                }
                catch (Exception ex)
                {
                    //this.textureAdded = false;
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void toolStripMenuItemAdd3DS_Click(object sender, EventArgs e)
        {
            if (this.open3DSDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    var _3dsFile = new ThreeDSFile(this.open3DSDlg.FileName);
                    if (_3dsFile != null)
                    { this._3dsFileList.Add(_3dsFile); }
                    else
                    { MessageBox.Show("Failed to load " + this.open3DSDlg.FileName); }
                    //this._3dsFile = _3dsFile;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void toolStripMenuItemAddTexture_Click(object sender, EventArgs e)
        {
            if (openTextureDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //this.textureAdded = false;
                try
                {
                    var texture = new SharpGL.SceneGraph.Assets.Texture();
                    var textureImage = new Bitmap(openTextureDlg.FileName);
                    texture.Create(this.openGLControl1.OpenGL, textureImage);
                    this.textureImageList.Add(textureImage);
                    this.textureList.Add(texture); 

                    //this.textureAdded = true;
                }
                catch (Exception ex)
                {
                    //this.textureAdded = false;
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
