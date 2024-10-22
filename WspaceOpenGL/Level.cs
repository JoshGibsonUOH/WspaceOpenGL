using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace WspaceOpenGL
{
    public class Level
    {
        private Vector3 startPosition;
        private Vector3 goalPosition;
        private Vector3[] platforms;

        public Level()
        {
            // Define the level with platforms, a start, and a goal
            startPosition = new Vector3(0, 0, 0);
            goalPosition = new Vector3(10, 0, 10);
            platforms = new Vector3[]
            {
                new Vector3(0, 0, 0),
                new Vector3(2, 0, 0),
                new Vector3(4, 0, 0),
                new Vector3(6, 0, 0),
                new Vector3(8, 0, 0),
                new Vector3(10, 0, 0),
                new Vector3(10, 0, 2),
                new Vector3(10, 0, 4),
                new Vector3(10, 0, 6),
                new Vector3(10, 0, 8),
                new Vector3(10, 0, 10)
            };
        }

        public void Render()
        {
            // Render the platforms
            foreach (var platform in platforms)
            {
                GL.PushMatrix();
                GL.Translate(platform);
                GL.Begin(PrimitiveType.Quads);
                GL.Vertex3(-1, 0, -1);
                GL.Vertex3(1, 0, -1);
                GL.Vertex3(1, 0, 1);
                GL.Vertex3(-1, 0, 1);
                GL.End();
                GL.PopMatrix();
            }

            // Render the goal
            GL.PushMatrix();
            GL.Translate(goalPosition);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(1.0, 0.0, 0.0); // Red color for the goal
            GL.Vertex3(-1, 0, -1);
            GL.Vertex3(1, 0, -1);
            GL.Vertex3(1, 0, 1);
            GL.Vertex3(-1, 0, 1);
            GL.End();
            GL.PopMatrix();
        }

        public Vector3 GetStartPosition()
        {
            return startPosition;
        }

        public bool CheckGoal(Vector3 position)
        {
            return position == goalPosition;
        }

        public bool CheckFall(Vector3 position)
        {
            foreach (var platform in platforms)
            {
                if (position == platform)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
