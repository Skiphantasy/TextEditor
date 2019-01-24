/*
 * EXERCISE............: Exercise 9.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms III. Text Editor 
 * DATE................: 24 Jan 2019
 */


using System;
using System.Windows.Forms;

namespace frmEditor
{
    static class MainClass
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        #region main
        static void Main()
        {
            frmSplashScreen splash;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            splash = new frmSplashScreen();
            
            if(splash.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmTextEditor());
            }
        }
        #endregion
    }
}
