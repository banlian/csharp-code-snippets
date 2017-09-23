namespace BaseLibrary.View
{
    partial class MultiResultDetailUserControl
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
            this.groupBoxResultDetail = new System.Windows.Forms.GroupBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.groupBoxResultDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxResultDetail
            // 
            this.groupBoxResultDetail.Controls.Add(this.dgvDetails);
            this.groupBoxResultDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxResultDetail.Location = new System.Drawing.Point(0, 0);
            this.groupBoxResultDetail.Name = "groupBoxResultDetail";
            this.groupBoxResultDetail.Size = new System.Drawing.Size(411, 417);
            this.groupBoxResultDetail.TabIndex = 0;
            this.groupBoxResultDetail.TabStop = false;
            this.groupBoxResultDetail.Text = "ResultDetail";
            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(3, 17);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowTemplate.Height = 23;
            this.dgvDetails.Size = new System.Drawing.Size(405, 397);
            this.dgvDetails.TabIndex = 0;
            // 
            // MultiResultDetailUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxResultDetail);
            this.Name = "MultiResultDetailUserControl";
            this.Size = new System.Drawing.Size(411, 417);
            this.Load += new System.EventHandler(this.MultiResultDetailUserControl_Load);
            this.groupBoxResultDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxResultDetail;
        private System.Windows.Forms.DataGridView dgvDetails;
    }
}
