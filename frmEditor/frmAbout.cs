using Microsoft.Win32;
using System.Windows.Forms;

namespace frmEditor
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\P9");

            this.CenterToParent();

            if (key != null)
            {
                lblCounter.Text = key.GetValue("Uses").ToString();
                key.Close();
            }
        }

        private void frmAbout_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmTextEditor.Open = false;
        }
    }
}
