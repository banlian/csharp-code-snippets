namespace BaseLibrary.View
{
    partial class UserStartControl
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
            this.groupBoxUserStart = new System.Windows.Forms.GroupBox();
            this.buttonUserStart = new System.Windows.Forms.Button();
            this.groupBoxUserStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUserStart
            // 
            this.groupBoxUserStart.Controls.Add(this.buttonUserStart);
            this.groupBoxUserStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxUserStart.Location = new System.Drawing.Point(0, 0);
            this.groupBoxUserStart.Name = "groupBoxUserStart";
            this.groupBoxUserStart.Size = new System.Drawing.Size(250, 120);
            this.groupBoxUserStart.TabIndex = 0;
            this.groupBoxUserStart.TabStop = false;
            this.groupBoxUserStart.Text = "Operation";
            // 
            // buttonUserStart
            // 
            this.buttonUserStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUserStart.Location = new System.Drawing.Point(18, 32);
            this.buttonUserStart.Margin = new System.Windows.Forms.Padding(15);
            this.buttonUserStart.Name = "buttonUserStart";
            this.buttonUserStart.Size = new System.Drawing.Size(214, 70);
            this.buttonUserStart.TabIndex = 0;
            this.buttonUserStart.Text = "启动";
            this.buttonUserStart.UseVisualStyleBackColor = true;
            this.buttonUserStart.Click += new System.EventHandler(this.buttonUserStart_Click);
            // 
            // UserStartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxUserStart);
            this.Name = "UserStartControl";
            this.Size = new System.Drawing.Size(250, 120);
            this.groupBoxUserStart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUserStart;
        private System.Windows.Forms.Button buttonUserStart;
    }
}
