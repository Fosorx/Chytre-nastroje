using System.Windows.Forms;
using Chytré_nástroje.Forms;
namespace Chytré_nástroje
{
    internal static class Program
    {
        [STAThread]
        
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Hlavni());
        }
    }
}