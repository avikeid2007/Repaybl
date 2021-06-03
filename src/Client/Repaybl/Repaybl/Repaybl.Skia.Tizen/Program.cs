using Tizen.Applications;

using Uno.UI.Runtime.Skia;

namespace Repaybl.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new Repaybl.App(), args);
            host.Run();
        }
    }
}
