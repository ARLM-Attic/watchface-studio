using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchfaceStudio.Entities;

namespace WatchfaceStudio.Editor
{
    public partial class FacerExpressionEditorForm : Form
    {
        public string Expression;

        public FacerExpressionEditorForm(string expression = "")
        {
            InitializeComponent();

            foreach (var kvp in FacerTags.Tags)
            {
                var itm = listViewTags.Items.Add(kvp.Key);
                itm.SubItems.Add(kvp.Value.Description);
                if (kvp.Value.Get != null)
                    itm.SubItems.Add(kvp.Value.Get(DateTime.Now));
            }
            foreach (ColumnHeader col in listViewTags.Columns)
                col.Width = -1;

            textBoxExpression.Text = expression;
        }
        
        private void buttonInsertCondition_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "$ ?100:0$";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text = string.Empty;
        }

        private void listViewTags_ItemActivate(object sender, EventArgs e)
        {
            if (listViewTags.SelectedItems.Count > 0 && listViewTags.SelectedItems[0].Text.StartsWith("#"))
                textBoxExpression.Text += listViewTags.SelectedItems[0].Text;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Expression = textBoxExpression.Text;
        }
    }
}
