namespace BaseLibrary.View
{
    partial class IniUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxIni = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richTextBoxIni = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.buttonLoadIni = new System.Windows.Forms.Button();
            this.buttonSaveIni = new System.Windows.Forms.Button();
            this.groupBoxIni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxIni
            // 
            this.groupBoxIni.Controls.Add(this.splitContainer1);
            this.groupBoxIni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxIni.Location = new System.Drawing.Point(0, 0);
            this.groupBoxIni.Name = "groupBoxIni";
            this.groupBoxIni.Size = new System.Drawing.Size(600, 400);
            this.groupBoxIni.TabIndex = 0;
            this.groupBoxIni.TabStop = false;
            this.groupBoxIni.Text = "INI CONFIG";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richTextBoxIni);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(594, 380);
            this.splitContainer1.SplitterDistance = 324;
            this.splitContainer1.TabIndex = 1;
            // 
            // richTextBoxIni
            // 
            this.richTextBoxIni.BackColor = System.Drawing.Color.LightGray;
            this.richTextBoxIni.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxIni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxIni.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxIni.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxIni.Name = "richTextBoxIni";
            this.richTextBoxIni.Size = new System.Drawing.Size(594, 324);
            this.richTextBoxIni.TabIndex = 0;
            this.richTextBoxIni.Text = "";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.buttonLoadIni);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.buttonSaveIni);
            this.splitContainer2.Size = new System.Drawing.Size(594, 52);
            this.splitContainer2.SplitterDistance = 285;
            this.splitContainer2.TabIndex = 0;
            // 
            // buttonLoadIni
            // 
            this.buttonLoadIni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoadIni.Location = new System.Drawing.Point(0, 0);
            this.buttonLoadIni.Name = "buttonLoadIni";
            this.buttonLoadIni.Size = new System.Drawing.Size(285, 52);
            this.buttonLoadIni.TabIndex = 0;
            this.buttonLoadIni.Text = "加载";
            this.buttonLoadIni.UseVisualStyleBackColor = true;
            this.buttonLoadIni.Click += new System.EventHandler(this.buttonLoadIni_Click);
            // 
            // buttonSaveIni
            // 
            this.buttonSaveIni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveIni.Location = new System.Drawing.Point(0, 0);
            this.buttonSaveIni.Name = "buttonSaveIni";
            this.buttonSaveIni.Size = new System.Drawing.Size(305, 52);
            this.buttonSaveIni.TabIndex = 1;
            this.buttonSaveIni.Text = "保存";
            this.buttonSaveIni.UseVisualStyleBackColor = true;
            this.buttonSaveIni.Click += new System.EventHandler(this.buttonSaveIni_Click);
            // 
            // IniUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxIni);
            this.Name = "IniUserControl";
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.IniUserControl_Load);
            this.groupBoxIni.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxIni;
        private System.Windows.Forms.RichTextBox richTextBoxIni;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonLoadIni;
        private System.Windows.Forms.Button buttonSaveIni;
    }
}
