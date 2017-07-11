using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project
{
    class UtilityImage
    {
        private UtilityImage() { }
        private static  List<String> imageSupported = new List<String>(new string[] {"jpg","png","PNG"});
        public static string findFileCheckImage()
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                string value = open.FileName;
                if(imageSupported.Contains(value.Split('.')[1]))
                {
                    return value;
                } else
                {

                    throw new ArgumentException();
                }
            } else
            {
                return "";
            }
            
        }
    }
}
