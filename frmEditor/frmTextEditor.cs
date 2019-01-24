/*
 * EXERCISE............: Exercise 9.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms III. Text Editor 
 * DATE................: 24 Jan 2019
 */


using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;


namespace frmEditor
{
    public partial class frmTextEditor : Form
    {
        private string directoryPath = "";
        private bool isBold = false;
        private bool isItalic = false;
        private bool isUnderline = false;
        private static bool open;      

        public frmTextEditor()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            InitializeComponent();
            Text = "Documento";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\P9", RegistryKeyPermissionCheck.ReadWriteSubTree);

            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\P9", RegistryKeyPermissionCheck.ReadWriteSubTree);
                key.SetValue("Uses", 1);
                key.Close();
            }
            else
            {
                int counter = int.Parse(key.GetValue("Uses").ToString());
                counter++;
                key.SetValue("Uses", counter);
                key.Close();
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea guardar los cambios a Documento?",
                      "Alerta", MessageBoxButtons.YesNoCancel);

            if(result == DialogResult.Yes)
            {
                SaveFileDialog saveFile1 = new SaveFileDialog();

                saveFile1.DefaultExt = "*.rtf";
                saveFile1.Filter = "RTF Files|*.rtf";
                saveFile1.FileName = Text;

                if (saveFile1.ShowDialog() == DialogResult.OK &&
                   saveFile1.FileName.Length > 0)
                {
                    rtbEditor.SaveFile(saveFile1.FileName);
                }

                Text = Text + "1";
                rtbEditor.Text = "";
                directoryPath = "";
            }
            else if (result == DialogResult.No)
            {
                rtbEditor.Text = "";
            }
        }
      
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();

            openFile1.DefaultExt = "*.rtf";
            openFile1.Filter = "RTF Files|*.rtf";

            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                directoryPath = Path.GetDirectoryName(openFile1.FileName) + "/" + Path.GetFileName(openFile1.FileName);
                rtbEditor.LoadFile(openFile1.FileName);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.rtf)|*.rtf|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbEditor.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbEditor.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject clip = Clipboard.GetDataObject();
            List<DataFormats.Format> formats;
            formats = new List<DataFormats.Format>();

            formats.Add(DataFormats.GetFormat(DataFormats.Rtf));    
            formats.Add(DataFormats.GetFormat(DataFormats.Tiff));
            formats.Add(DataFormats.GetFormat(DataFormats.SymbolicLink));
            formats.Add(DataFormats.GetFormat(DataFormats.Palette));
            formats.Add(DataFormats.GetFormat(DataFormats.Bitmap));
            formats.Add(DataFormats.GetFormat(DataFormats.CommaSeparatedValue));
            formats.Add(DataFormats.GetFormat(DataFormats.EnhancedMetafile));
            formats.Add(DataFormats.GetFormat(DataFormats.FileDrop));
            formats.Add(DataFormats.GetFormat(DataFormats.Html));

           try
            {
                StringCollection strcollect = Clipboard.GetFileDropList();
                Image image = Image.FromFile(strcollect[0]);
                Clipboard.SetImage(image);

                if (Clipboard.ContainsImage())
                {
                    if (rtbEditor.CanPaste(formats[10]))
                    {
                        rtbEditor.Paste(formats[10]);
                        Clipboard.SetDataObject(clip);
                    }
                    else
                    {
                        MessageBox.Show("El formato del archivo no está permitido.");
                    }
                }
            } catch(ArgumentOutOfRangeException)
            {

                for (int i = 0; i < formats.Count; i++)
                {
                    if (rtbEditor.CanPaste(formats[i]))
                    {
                        rtbEditor.Paste(formats[i]);
                    }
                    else
                    {
                       // MessageBox.Show("El formato del archivo no está permitido.");
                    }
                }
            }            
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tspOptions.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void frmTextEditor_SizeChanged(object sender, EventArgs e)
        {
            rtbEditor.Width = this.Width;
            rtbEditor.Height = this.Height - 112;
        }

        private void tscbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbEditor.SelectionFont = new Font(tscbFont.Text, rtbEditor.SelectionFont.Size);
        }

        private void tscbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int number;
            if(int.TryParse(tscbFontSize.Text, out number))
            {
                rtbEditor.SelectionFont = new Font(rtbEditor.SelectionFont.Name.ToString(), int.Parse(tscbFontSize.Text));
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbEditor.CanRedo == true)
            {
                rtbEditor.Redo();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbEditor.CanUndo == true)
            {
                rtbEditor.Undo();
            }
        }

        private void ChangeFontStyle(ref bool isBold, ref bool isItalic, ref bool isUnderlined,
            FontStyle bold, FontStyle italic, FontStyle underline, ToolStripButton tsbBold)
        {
            if (!isBold)
            {
                tsbBold.BackColor = Color.LightBlue;
                isBold = !isBold;
                if (!isItalic && !isUnderlined)
                {
                    rtbEditor.SelectionFont = new Font(rtbEditor.SelectionFont.FontFamily, rtbEditor.SelectionFont.Size, bold);
                }
                else if (!isItalic && isUnderlined)
                {
                    rtbEditor.SelectionFont = new Font(rtbEditor.SelectionFont.FontFamily, rtbEditor.SelectionFont.Size, bold | underline);
                }
                else if (isItalic && !isUnderlined)
                {
                    rtbEditor.SelectionFont = new Font(rtbEditor.SelectionFont.FontFamily, rtbEditor.SelectionFont.Size, bold | italic);
                }
                else
                {
                    rtbEditor.SelectionFont = new Font(rtbEditor.SelectionFont.FontFamily, rtbEditor.SelectionFont.Size, bold | italic | underline);
                }
            }
            else
            {
                tsbBold.BackColor = Color.Transparent;
                isBold = !isBold;

                if (!isItalic && !isUnderlined)
                {
                    rtbEditor.SelectionFont = new Font(rtbEditor.SelectionFont.FontFamily, rtbEditor.SelectionFont.Size, FontStyle.Regular);
                }
                else if (!isItalic && isUnderlined)
                {
                    rtbEditor.SelectionFont = new Font(rtbEditor.SelectionFont.FontFamily, rtbEditor.SelectionFont.Size, FontStyle.Regular | underline);
                }
                else if (isItalic && !isUnderlined)
                {
                    rtbEditor.SelectionFont = new Font(rtbEditor.SelectionFont.FontFamily, rtbEditor.SelectionFont.Size, FontStyle.Regular | italic);
                }
                else
                {
                    rtbEditor.SelectionFont = new Font(rtbEditor.SelectionFont.FontFamily, rtbEditor.SelectionFont.Size, FontStyle.Regular | italic | underline);
                }
            }
        }
        private void tsbBold_Click_1(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            ChangeFontStyle(ref isBold, ref isItalic, ref isUnderline, FontStyle.Bold, FontStyle.Italic,
                FontStyle.Underline, btn);
        }

        private void tsbItalic_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            ChangeFontStyle(ref isItalic, ref isBold, ref isUnderline, FontStyle.Italic, FontStyle.Bold,
                FontStyle.Underline, btn);
        }

        private void tsbUnderline_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            ChangeFontStyle(ref isUnderline, ref isBold, ref isItalic, FontStyle.Underline, FontStyle.Bold,
                FontStyle.Italic, btn);
        }

        private void tsbAlignleft_Click(object sender, EventArgs e)
        {
            rtbEditor.SelectionAlignment = HorizontalAlignment.Left;
            tsbAlignleft.BackColor = Color.LightBlue;
            tsbAlingright.BackColor = Color.Transparent;
            tsbAligncenter.BackColor = Color.Transparent;
        }

        private void tsbAligncenter_Click(object sender, EventArgs e)
        {
            rtbEditor.SelectionAlignment = HorizontalAlignment.Center;
            tsbAligncenter.BackColor = Color.LightBlue;
            tsbAlignleft.BackColor = Color.Transparent;
            tsbAlingright.BackColor = Color.Transparent;
        }

        private void tsbAlingright_Click(object sender, EventArgs e)
        {
            rtbEditor.SelectionAlignment = HorizontalAlignment.Right;
            tsbAlingright.BackColor = Color.LightBlue;
            tsbAlignleft.BackColor = Color.Transparent;
            tsbAligncenter.BackColor = Color.Transparent;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbEditor.SelectAll();
        }

        private void tsbForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = true;

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                rtbEditor.SelectionColor = MyDialog.Color;
            }
        }

        private void tsbBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = true;

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                rtbEditor.SelectionBackColor = MyDialog.Color;
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if(directoryPath.Equals(""))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.Filter = "RTF Files|*.rtf";

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string FileName = saveFileDialog.FileName;
                    directoryPath = Path.GetDirectoryName(saveFileDialog.FileName) + "/" + Path.GetFileName(saveFileDialog.FileName);
                }
            }
            else
            {
                try
                {
                    rtbEditor.SaveFile(directoryPath);
                    System.Windows.Forms.MessageBox.Show("Documento guardado correctamente");
                } 
                catch (UnauthorizedAccessException)
                {
                    System.Windows.Forms.MessageBox.Show("Acceso Denegado");
                }
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            PrintDialog print = new PrintDialog();
            PrintDocument docToPrint = new PrintDocument();
            print.AllowSomePages = true;

            print.Document = docToPrint;

            DialogResult result = print.ShowDialog();

            if (result == DialogResult.OK)
            {
                docToPrint.PrintPage += new PrintPageEventHandler(document_PrintPage);
                docToPrint.Print();
            }
        }

        private void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            string text = rtbEditor.Text;
            Font printFont = rtbEditor.Font;
            e.Graphics.DrawString(text, printFont,
                Brushes.Black, 10, 10);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = new frmAbout();

            if (open == false)
            {
                openForm.Show();
                open = true;
            }
            else
            {
                openForm = Application.OpenForms[0];
                openForm.BringToFront();
            }
        }

        public static bool Open { get => open; set => open = value; }
    }
}
