using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chytré_nástroje.Code
{
    internal class WingetUpdateInfo
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string CurrentVersion { get; set; }
        public string NewVersion { get; set; }

        // Tohle určí, co uvidíš v ListBoxu
        public override string ToString() => $"{Name} ({Id}) | {CurrentVersion} -> {NewVersion}";
    }
}
