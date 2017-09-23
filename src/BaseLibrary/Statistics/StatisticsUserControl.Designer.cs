
namespace BaseLibrary.Statistics
{
    partial class StatisticsUserControl
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
            this.groupBoxStatistics = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.labelTOTAL = new System.Windows.Forms.Label();
            this.labelTOTALCOUNT = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.labelPASS = new System.Windows.Forms.Label();
            this.labelPASSCOUNT = new System.Windows.Forms.Label();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.labelFAIL = new System.Windows.Forms.Label();
            this.labelFAILCOUNT = new System.Windows.Forms.Label();
            this.groupBoxStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxStatistics
            // 
            this.groupBoxStatistics.Controls.Add(this.splitContainer1);
            this.groupBoxStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStatistics.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStatistics.Name = "groupBoxStatistics";
            this.groupBoxStatistics.Size = new System.Drawing.Size(394, 42);
            this.groupBoxStatistics.TabIndex = 0;
            this.groupBoxStatistics.TabStop = false;
            this.groupBoxStatistics.Text = "Statistics";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(388, 22);
            this.splitContainer1.SplitterDistance = 129;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.labelTOTAL);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.labelTOTALCOUNT);
            this.splitContainer3.Size = new System.Drawing.Size(129, 22);
            this.splitContainer3.SplitterDistance = 45;
            this.splitContainer3.TabIndex = 0;
            // 
            // labelTOTAL
            // 
            this.labelTOTAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTOTAL.Location = new System.Drawing.Point(0, 0);
            this.labelTOTAL.Name = "labelTOTAL";
            this.labelTOTAL.Size = new System.Drawing.Size(45, 22);
            this.labelTOTAL.TabIndex = 0;
            this.labelTOTAL.Text = "TOTAL:";
            this.labelTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTOTAL.DoubleClick += new System.EventHandler(this.labelTOTAL_DoubleClick);
            // 
            // labelTOTALCOUNT
            // 
            this.labelTOTALCOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTOTALCOUNT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTOTALCOUNT.Location = new System.Drawing.Point(0, 0);
            this.labelTOTALCOUNT.Name = "labelTOTALCOUNT";
            this.labelTOTALCOUNT.Size = new System.Drawing.Size(80, 22);
            this.labelTOTALCOUNT.TabIndex = 1;
            this.labelTOTALCOUNT.Text = "0";
            this.labelTOTALCOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer2.Size = new System.Drawing.Size(255, 22);
            this.splitContainer2.SplitterDistance = 116;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.labelPASS);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.labelPASSCOUNT);
            this.splitContainer4.Size = new System.Drawing.Size(116, 22);
            this.splitContainer4.SplitterDistance = 41;
            this.splitContainer4.TabIndex = 0;
            // 
            // labelPASS
            // 
            this.labelPASS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPASS.Location = new System.Drawing.Point(0, 0);
            this.labelPASS.Name = "labelPASS";
            this.labelPASS.Size = new System.Drawing.Size(41, 22);
            this.labelPASS.TabIndex = 1;
            this.labelPASS.Text = "PASS:";
            this.labelPASS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPASS.DoubleClick += new System.EventHandler(this.labelStat_DoubleClick);
            // 
            // labelPASSCOUNT
            // 
            this.labelPASSCOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPASSCOUNT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPASSCOUNT.Location = new System.Drawing.Point(0, 0);
            this.labelPASSCOUNT.Name = "labelPASSCOUNT";
            this.labelPASSCOUNT.Size = new System.Drawing.Size(71, 22);
            this.labelPASSCOUNT.TabIndex = 1;
            this.labelPASSCOUNT.Text = "0";
            this.labelPASSCOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.labelFAIL);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.labelFAILCOUNT);
            this.splitContainer5.Size = new System.Drawing.Size(135, 22);
            this.splitContainer5.SplitterDistance = 45;
            this.splitContainer5.TabIndex = 0;
            // 
            // labelFAIL
            // 
            this.labelFAIL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFAIL.Location = new System.Drawing.Point(0, 0);
            this.labelFAIL.Name = "labelFAIL";
            this.labelFAIL.Size = new System.Drawing.Size(45, 22);
            this.labelFAIL.TabIndex = 1;
            this.labelFAIL.Text = "FAIL:";
            this.labelFAIL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelFAIL.DoubleClick += new System.EventHandler(this.labelStat_DoubleClick);
            // 
            // labelFAILCOUNT
            // 
            this.labelFAILCOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFAILCOUNT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFAILCOUNT.Location = new System.Drawing.Point(0, 0);
            this.labelFAILCOUNT.Name = "labelFAILCOUNT";
            this.labelFAILCOUNT.Size = new System.Drawing.Size(86, 22);
            this.labelFAILCOUNT.TabIndex = 1;
            this.labelFAILCOUNT.Text = "0";
            this.labelFAILCOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatisticsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxStatistics);
            this.Name = "StatisticsUserControl";
            this.Size = new System.Drawing.Size(394, 42);
            this.Load += new System.EventHandler(this.StatisticsUserControl_Load);
            this.groupBoxStatistics.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxStatistics;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Label labelTOTAL;
        private System.Windows.Forms.Label labelTOTALCOUNT;
        private System.Windows.Forms.Label labelPASS;
        private System.Windows.Forms.Label labelPASSCOUNT;
        private System.Windows.Forms.Label labelFAIL;
        private System.Windows.Forms.Label labelFAILCOUNT;
    }
}
