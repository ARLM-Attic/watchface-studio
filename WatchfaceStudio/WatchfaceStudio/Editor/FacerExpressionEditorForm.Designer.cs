namespace WatchfaceStudio.Editor
{
    partial class FacerExpressionEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewTags = new System.Windows.Forms.ListView();
            this.columnHeaderTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderExample = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelExpression = new System.Windows.Forms.Label();
            this.textBoxExpression = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonInsertCondition = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonEvaluate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewTags
            // 
            this.listViewTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewTags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTag,
            this.columnHeaderDescription,
            this.columnHeaderExample});
            this.listViewTags.FullRowSelect = true;
            this.listViewTags.GridLines = true;
            this.listViewTags.Location = new System.Drawing.Point(12, 67);
            this.listViewTags.Name = "listViewTags";
            this.listViewTags.Size = new System.Drawing.Size(584, 226);
            this.listViewTags.TabIndex = 1;
            this.listViewTags.UseCompatibleStateImageBehavior = false;
            this.listViewTags.View = System.Windows.Forms.View.Details;
            this.listViewTags.ItemActivate += new System.EventHandler(this.listViewTags_ItemActivate);
            // 
            // columnHeaderTag
            // 
            this.columnHeaderTag.Text = "Tag";
            // 
            // columnHeaderDescription
            // 
            this.columnHeaderDescription.Text = "Description";
            this.columnHeaderDescription.Width = 103;
            // 
            // columnHeaderExample
            // 
            this.columnHeaderExample.Text = "Example";
            // 
            // labelExpression
            // 
            this.labelExpression.AutoSize = true;
            this.labelExpression.Location = new System.Drawing.Point(12, 15);
            this.labelExpression.Name = "labelExpression";
            this.labelExpression.Size = new System.Drawing.Size(61, 13);
            this.labelExpression.TabIndex = 2;
            this.labelExpression.Text = "Expression:";
            // 
            // textBoxExpression
            // 
            this.textBoxExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExpression.Location = new System.Drawing.Point(79, 12);
            this.textBoxExpression.Name = "textBoxExpression";
            this.textBoxExpression.Size = new System.Drawing.Size(517, 20);
            this.textBoxExpression.TabIndex = 3;
            this.textBoxExpression.TextChanged += new System.EventHandler(this.textBoxExpression_TextChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(521, 38);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(440, 38);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonInsertCondition
            // 
            this.buttonInsertCondition.Location = new System.Drawing.Point(12, 38);
            this.buttonInsertCondition.Name = "buttonInsertCondition";
            this.buttonInsertCondition.Size = new System.Drawing.Size(90, 23);
            this.buttonInsertCondition.TabIndex = 6;
            this.buttonInsertCondition.Text = "Insert Condition";
            this.buttonInsertCondition.UseVisualStyleBackColor = true;
            this.buttonInsertCondition.Click += new System.EventHandler(this.buttonInsertCondition_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(108, 38);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(58, 23);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelResult
            // 
            this.labelResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelResult.Location = new System.Drawing.Point(260, 38);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(174, 23);
            this.labelResult.TabIndex = 9;
            // 
            // buttonEvaluate
            // 
            this.buttonEvaluate.Location = new System.Drawing.Point(172, 38);
            this.buttonEvaluate.Name = "buttonEvaluate";
            this.buttonEvaluate.Size = new System.Drawing.Size(82, 23);
            this.buttonEvaluate.TabIndex = 10;
            this.buttonEvaluate.Text = "Try Evaluate";
            this.buttonEvaluate.UseVisualStyleBackColor = true;
            this.buttonEvaluate.Click += new System.EventHandler(this.buttonEvaluate_Click);
            // 
            // FacerExpressionEditorForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(608, 305);
            this.Controls.Add(this.buttonEvaluate);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonInsertCondition);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxExpression);
            this.Controls.Add(this.labelExpression);
            this.Controls.Add(this.listViewTags);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FacerExpressionEditorForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Expression Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewTags;
        private System.Windows.Forms.ColumnHeader columnHeaderTag;
        private System.Windows.Forms.ColumnHeader columnHeaderDescription;
        private System.Windows.Forms.Label labelExpression;
        private System.Windows.Forms.TextBox textBoxExpression;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonInsertCondition;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ColumnHeader columnHeaderExample;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonEvaluate;
    }
}