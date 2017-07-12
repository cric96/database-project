using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.graphicsUtility
{
    class labelFactory
    {
        public static Font getGeneralFont()
        {
            return new Font("Colibrì", 10);
        }
        public static Label createBasicLabel(String text)
        {
            Label label = new Label();
            label.Text = text;
            return label;
        }

        public static Label createAdvanceLabel(String text, Font font, Size size, Color color,ContentAlignment align)
        {
            Label label = createBasicLabel(text);
            label.BackColor = System.Drawing.Color.Transparent;
            label.TextAlign = align;
            label.Font = font;
            label.Size = size;
            label.ForeColor = color;
            return label;
   
        }
    }
}
