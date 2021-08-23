using Foster.Framework;
using Foster.GLFW;
using Foster.OpenGL;

class Program
{
    static void Main(string[] args)
    {
        // our System Module (this is Mandatory)
        App.Modules.Register<GLFW_System>();

        // our Graphics Module (not Mandatory but required for drawing anything)
        App.Modules.Register<GL_Graphics>();

        // our custom module
        App.Modules.Register<Wew.Wew>();

        // start the Application with a single 1280x720 Window
        App.Start("Wew", Wew.Wew.WINDOW_WIDTH, Wew.Wew.WINDOW_HEIGHT);
    }
}
