namespace BaseLibrary.Network
{
    partial class NetworkControl
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
            this.groupboxNIC = new System.Windows.Forms.GroupBox();
            this.comboBoxNIC = new System.Windows.Forms.ComboBox();
            this.dgvNIC = new System.Windows.Forms.DataGridView();
            this.buttonSetNIC = new System.Windows.Forms.Button();
            this.groupboxNIC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNIC)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxNIC
            // 
            this.groupboxNIC.Controls.Add(this.buttonSetNIC);
            this.groupboxNIC.Controls.Add(this.dgvNIC);
            this.groupboxNIC.Controls.Add(this.comboBoxNIC);
            this.groupboxNIC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupboxNIC.Location = new System.Drawing.Point(0, 0);
            this.groupboxNIC.Name = "groupboxNIC";
            this.groupboxNIC.Size = new System.Drawing.Size(366, 322);
            this.groupboxNIC.TabIndex = 0;
            this.groupboxNIC.TabStop = false;
            this.groupboxNIC.Text = "NIC";
            // 
            // comboBoxNIC
            // 
            this.comboBoxNIC.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxNIC.FormattingEnabled = true;
            this.comboBoxNIC.Location = new System.Drawing.Point(3, 17);
            this.comboBoxNIC.Name = "comboBoxNIC";
            this.comboBoxNIC.Size = new System.Drawing.Size(360, 20);
            this.comboBoxNIC.TabIndex = 0;
            this.comboBoxNIC.SelectedIndexChanged += new System.EventHandler(this.comboBoxNIC_SelectedIndexChanged);
            // 
            // dgvNIC
            // 
            this.dgvNIC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNIC.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvNIC.Location = new System.Drawing.Point(3, 37);
            this.dgvNIC.Name = "dgvNIC";
            this.dgvNIC.RowTemplate.Height = 23;
            this.dgvNIC.Size = new System.Drawing.Size(360, 243);
            this.dgvNIC.TabIndex = 1;
            // 
            // buttonSetNIC
            // 
            this.buttonSetNIC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetNIC.Location = new System.Drawing.Point(3, 280);
            this.buttonSetNIC.Name = "buttonSetNIC";
            this.buttonSetNIC.Size = new System.Drawing.Size(360, 39);
            this.buttonSetNIC.TabIndex = 2;
            this.buttonSetNIC.Text = "设置";
            this.buttonSetNIC.UseVisualStyleBackColor = true;
            this.buttonSetNIC.Click += new System.EventHandler(this.buttonSetNIC_Click);
            // 
            // NetworkControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupboxNIC);
            this.Name = "NetworkControl";
            this.Size = new System.Drawing.Size(366, 322);
            this.Load += new System.EventHandler(this.NetworkControl_Load);
            this.groupboxNIC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNIC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupboxNIC;
        private System.Windows.Forms.Button buttonSetNIC;
        private System.Windows.Forms.DataGridView dgvNIC;
        private System.Windows.Forms.ComboBox comboBoxNIC;
    }
}
