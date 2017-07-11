using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.graphicsUtility
{
    public static class TooltipFactory
    {
        public static ToolTip createBasicTooltip(string title)
        {
            ToolTip tip = new ToolTip();
            tip.UseFading = true;
            tip.UseAnimation = true;

            tip.ShowAlways = true;
            tip.ToolTipTitle = title;
            tip.AutoPopDelay = 20000;
            tip.InitialDelay = 200;
            tip.ReshowDelay = 500;
            return tip;
        }
    }
}
