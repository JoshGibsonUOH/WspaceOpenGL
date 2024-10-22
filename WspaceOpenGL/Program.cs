using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace WspaceOpenGL
{
    class Program
    {
        static void Main(string[] args)
        {
            using (GameWindow game = new GameWindow(800, 600, GraphicsMode.Default, "WspaceOpenGL"))
            {
                game.Load += (sender, e) =>
                {
                    // Initialize OpenGL settings
                    GL.ClearColor(Color4.CornflowerBlue);
                    GL.Enable(EnableCap.DepthTest);
                };

                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);
                    Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, game.Width / (float)game.Height, 1.0f, 64.0f);
                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadMatrix(ref projection);
                };

                game.UpdateFrame += (sender, e) =>
                {
                    // Handle input
                    KeyboardState input = Keyboard.GetState();
                    if (input.IsKeyDown(Key.Escape))
                    {
                        game.Exit();
                    }

                    // Update game logic
                    // TODO: Implement sphere movement and level logic
                };

                game.RenderFrame += (sender, e) =>
                {
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    // Render 3D sphere and level
                    // TODO: Implement rendering logic

                    game.SwapBuffers();
                };

                game.Run(60.0);
            }
        }
    }
}
