using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmEditor
{
    public partial class frmTextEditor : Form
    {
        private int childFormNumber = 0;

        public frmTextEditor()
        {
            InitializeComponent();
            Text = "Documento";
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
                rtbEditor.LoadFile(openFile1.FileName);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
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
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
    }
}
