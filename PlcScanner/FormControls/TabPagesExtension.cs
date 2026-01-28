using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlcScanner.FormControls
{
    internal class TabPagesExtension
    {
        
    }
    public class TabPageProgrammedRoutine : TabPage
    {
        public TabPageProgrammedRoutine() : base ()
        {
            this.Text = "Programmed Routine";
            this.Controls.Add(new tabRecordedRoutineEditor());
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.Controls[0].Size = this.Size;
        }
    }
}
