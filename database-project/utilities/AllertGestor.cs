using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.utilities
{
    class AllertGestor
    {
        public static void defaultError(string error)
        {
            MessageBox.Show(error, "qualcosa è andato storto", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        public static void defaultShowOk(String text)
        {
            MessageBox.Show(text, "tutto ok!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
    }
}
