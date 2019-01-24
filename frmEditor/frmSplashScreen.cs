/*
 * EXERCISE............: Exercise 9.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms III. Text Editor 
 * DATE................: 24 Jan 2019
 */


using System;
using System.Drawing;
using System.Windows.Forms;

namespace frmEditor
{
    public partial class frmSplashScreen : Form
    {
        #region attributes
        int time;
        #endregion
        #region constructor
        public frmSplashScreen()
        {            
            InitializeComponent();
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            cbarSplash.Value = 10;
            time = 0;
            cbarSplash2.Value = 10;
            this.tmrBar.Start();
        }
        #endregion
        #region event voids
        private void tmrBar_Tick(object sender, EventArgs e)
        {
            time++;

            if (time < 200)
            {
                this.cbarSplash.StartAngle += 5;
                this.cbarSplash2.StartAngle += 5;
            }   
            else
            {
                DialogResult = DialogResult.OK;                      
                Close();
            }
        }
        #endregion
    }
}
