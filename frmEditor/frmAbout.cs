/*
 * EXERCISE............: Exercise 9.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms III. Text Editor 
 * DATE................: 24 Jan 2019
 */


using Microsoft.Win32;
using System.Windows.Forms;

namespace frmEditor
{
    public partial class frmAbout : Form
    {
        #region constructor
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
        #endregion
        #region events
        private void frmAbout_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmTextEditor.Open = false;
        }
        #endregion
    }
}
