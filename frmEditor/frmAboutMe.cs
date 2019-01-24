/*
 * EXERCISE.............: Exercise 8.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms II. Components
 * DATE................: 21 Jan 2019
 */


using Microsoft.Win32;
using System.Windows.Forms;

namespace Exercise8
{
    public partial class frmAboutMe : Form
    {
        #region constructor
        public frmAboutMe()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\P8");
            InitializeComponent();
            this.CenterToParent();

            if (key != null)
            {
                lblCounter.Text = key.GetValue("Uses").ToString();
                key.Close();
            }
        }
        #endregion
        #region event voids
        private void frmAboutMe_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGroups.Open = false;
        }
        #endregion
    }
}
