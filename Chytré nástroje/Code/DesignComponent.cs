using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chytré_nástroje.Code
{
    public static class DesignComponent
    {
        public static Panel CreatePanel(int x, int y, int width, int height, string name)
        {
            Panel panel = new Panel();
            panel.Name = name;
            panel.Location = new Point(x, y);
            panel.Size = new Size(width, height);
            return panel;
        }

    }
}
