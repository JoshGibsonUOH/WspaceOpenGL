using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace WspaceOpenGL
{
    public class Sphere
    {
        private Vector3 position;
        private float speed = 0.1f;

        public Sphere(Vector3 startPosition)
        {
            position = startPosition;
        }

        public void Update(KeyboardState input)
        {
            if (input.IsKeyDown(Key.Left))
            {
                position.X -= speed;
            }
            if (input.IsKeyDown(Key.Right))
            {
                position.X += speed;
            }
            if (input.IsKeyDown(Key.Up))
            {
                position.Z -= speed;
            }
            if (input.IsKeyDown(Key.Down))
            {
                position.Z += speed;
            }
        }

        public void Render()
        {
            GL.PushMatrix();
            GL.Translate(position);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(0.0, 1.0, 0.0); // Green color for the sphere
            GL.Vertex3(-0.5, -0.5, -0.5);
            GL.Vertex3(0.5, -0.5, -0.5);
            GL.Vertex3(0.5, 0.5, -0.5);
            GL.Vertex3(-0.5, 0.5, -0.5);
            GL.End();
            GL.PopMatrix();
        }

        public Vector3 GetPosition()
        {
            return position;
        }
    }
}
