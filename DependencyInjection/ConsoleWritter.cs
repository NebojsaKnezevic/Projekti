using System.Diagnostics;

namespace AspNetCoreWithReact.DependencyInjection
{
    public class ConsoleWritter : IConsoleWritter
    {
        public void Write()
        {
            Debug.WriteLine("testing Dependency injection");
        }
    }
}
