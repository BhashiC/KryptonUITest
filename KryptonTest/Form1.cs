using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KryptonTest
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
            toolStripComboBox1.ComboBox.DataSource = Enum.GetValues(typeof(PaletteMode));
            toolStripComboBox1.ComboBox.SelectionChangeCommitted += new EventHandler(toolStripComboBox1_ChangePalette);
        }

        PaletteMode _palette;
        PaletteModeManager _globalPalette;

        void toolStripComboBox1_ChangePalette(object sender, EventArgs e)
        {
            if(PaletteMode.TryParse((sender as ComboBox).SelectedValue.ToString(), out _palette))
            {
                this.PaletteMode = _palette;
                kryptonPalette1.BasePaletteMode = _palette;
            }

            if (PaletteModeManager.TryParse((sender as ComboBox).SelectedValue.ToString(), out _globalPalette))
            {
                kryptonManager1.GlobalPaletteMode = _globalPalette;
            }
            toolStrip1.Select();
        }
    }
}
