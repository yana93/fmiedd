using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BookManager
{
    class ViewLabel : Label
    {
        private FontFamily font = new FontFamily("Microsoft Sans Serif");

        public override Font Font
        {
            get
            {
                return new Font(font, 9);
            }
        }

        public override bool AutoSize
        {
            get
            {
                return true;
            }
        }

        public override Size MinimumSize
        {
            get
            {
                return new Size(100, 10);
            }
        }
    }
}
