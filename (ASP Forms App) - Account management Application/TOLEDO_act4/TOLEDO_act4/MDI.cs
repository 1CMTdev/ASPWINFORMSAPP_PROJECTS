using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOLEDO_act4
{
    class MDI
    {
        public static void checkMdi(Form form)
        {
            foreach (Form frm in TOLEDO_ACT4.ActiveForm.MdiChildren)
            {
                if (frm.GetType() == form.GetType())
                {
                    frm.Focus();
                    return;
                }
            }
            form.MdiParent = TOLEDO_ACT4.ActiveForm;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }






    }
}
