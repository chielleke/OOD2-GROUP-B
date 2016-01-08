namespace FlowSimulator
{
    partial class FlowNetworkSimulator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlowNetworkSimulator));
            this.panel1 = new System.Windows.Forms.Panel();
            this.RedoButton = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.UndoButton = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPipe = new System.Windows.Forms.Button();
            this.btnMerger = new System.Windows.Forms.Button();
            this.btnSplitter = new System.Windows.Forms.Button();
            this.btnSink = new System.Windows.Forms.Button();
            this.btnPump = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cmsEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditPipeline = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedoButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UndoButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel7.SuspendLayout();
            this.cmsEdit.SuspendLayout();
            this.cmsEditPipeline.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.RedoButton);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.UndoButton);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(812, 48);
            this.panel1.TabIndex = 0;
            // 
            // RedoButton
            // 
            this.RedoButton.Enabled = false;
            this.RedoButton.Image = global::FlowSimulator.Properties.Resources.redo;
            this.RedoButton.Location = new System.Drawing.Point(173, 12);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(35, 29);
            this.RedoButton.TabIndex = 7;
            this.RedoButton.TabStop = false;
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel6.Location = new System.Drawing.Point(0, 65);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(92, 21);
            this.panel6.TabIndex = 3;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::FlowSimulator.Properties.Resources.help;
            this.pictureBox6.Location = new System.Drawing.Point(250, 12);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(28, 29);
            this.pictureBox6.TabIndex = 6;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::FlowSimulator.Properties.Resources.delete;
            this.pictureBox5.Location = new System.Drawing.Point(214, 12);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 29);
            this.pictureBox5.TabIndex = 5;
            this.pictureBox5.TabStop = false;
            // 
            // UndoButton
            // 
            this.UndoButton.Enabled = false;
            this.UndoButton.Image = global::FlowSimulator.Properties.Resources.undo;
            this.UndoButton.Location = new System.Drawing.Point(132, 12);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(35, 29);
            this.UndoButton.TabIndex = 4;
            this.UndoButton.TabStop = false;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::FlowSimulator.Properties.Resources.save;
            this.pictureBox3.Location = new System.Drawing.Point(93, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 29);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(47, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 29);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FlowSimulator.Properties.Resources._new;
            this.pictureBox1.Location = new System.Drawing.Point(7, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 29);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.btnPipe);
            this.panel2.Controls.Add(this.btnMerger);
            this.panel2.Controls.Add(this.btnSplitter);
            this.panel2.Controls.Add(this.btnSink);
            this.panel2.Controls.Add(this.btnPump);
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(92, 439);
            this.panel2.TabIndex = 1;
            // 
            // btnPipe
            // 
            this.btnPipe.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnPipe.Image = global::FlowSimulator.Properties.Resources.pipe_icon;
            this.btnPipe.Location = new System.Drawing.Point(5, 283);
            this.btnPipe.Name = "btnPipe";
            this.btnPipe.Size = new System.Drawing.Size(80, 64);
            this.btnPipe.TabIndex = 13;
            this.btnPipe.UseVisualStyleBackColor = false;
            this.btnPipe.Click += new System.EventHandler(this.btnPipe_Click);
            // 
            // btnMerger
            // 
            this.btnMerger.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnMerger.Image = global::FlowSimulator.Properties.Resources.merger_icon;
            this.btnMerger.Location = new System.Drawing.Point(5, 215);
            this.btnMerger.Name = "btnMerger";
            this.btnMerger.Size = new System.Drawing.Size(80, 64);
            this.btnMerger.TabIndex = 12;
            this.btnMerger.UseVisualStyleBackColor = false;
            this.btnMerger.Click += new System.EventHandler(this.btnMerger_Click);
            // 
            // btnSplitter
            // 
            this.btnSplitter.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSplitter.Image = global::FlowSimulator.Properties.Resources.splitter;
            this.btnSplitter.Location = new System.Drawing.Point(5, 145);
            this.btnSplitter.Name = "btnSplitter";
            this.btnSplitter.Size = new System.Drawing.Size(80, 64);
            this.btnSplitter.TabIndex = 11;
            this.btnSplitter.UseVisualStyleBackColor = false;
            this.btnSplitter.Click += new System.EventHandler(this.btnSplitter_Click);
            // 
            // btnSink
            // 
            this.btnSink.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSink.Image = global::FlowSimulator.Properties.Resources.sink_icon;
            this.btnSink.Location = new System.Drawing.Point(5, 75);
            this.btnSink.Name = "btnSink";
            this.btnSink.Size = new System.Drawing.Size(80, 64);
            this.btnSink.TabIndex = 10;
            this.btnSink.UseVisualStyleBackColor = false;
            this.btnSink.Click += new System.EventHandler(this.btnSink_Click);
            // 
            // btnPump
            // 
            this.btnPump.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnPump.Image = global::FlowSimulator.Properties.Resources.pump_icon;
            this.btnPump.Location = new System.Drawing.Point(5, 5);
            this.btnPump.Name = "btnPump";
            this.btnPump.Size = new System.Drawing.Size(80, 64);
            this.btnPump.TabIndex = 9;
            this.btnPump.UseVisualStyleBackColor = false;
            this.btnPump.Click += new System.EventHandler(this.btnPump_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Components";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(91, 47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(721, 21);
            this.panel4.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "NetworkName";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.trackBar1);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.textBox2);
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(699, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(111, 505);
            this.panel5.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "label6";
            // 
            // trackBar1
            // 
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(3, 101);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Value = 5;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(68, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(35, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "10";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "0";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Capacity:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Flow:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Properties";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel7.Controls.Add(this.label1);
            this.panel7.Location = new System.Drawing.Point(0, 47);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(92, 21);
            this.panel7.TabIndex = 3;
            // 
            // cmsEdit
            // 
            this.cmsEdit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.propertiesToolStripMenuItem});
            this.cmsEdit.Name = "cmsEdit";
            this.cmsEdit.Size = new System.Drawing.Size(128, 70);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // cmsEditPipeline
            // 
            this.cmsEditPipeline.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsEditPipeline.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem1});
            this.cmsEditPipeline.Name = "cmsEditPipeline";
            this.cmsEditPipeline.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // flowLabel
            // 
            this.flowLabel.AutoSize = true;
            this.flowLabel.Location = new System.Drawing.Point(0, 0);
            this.flowLabel.Name = "flowLabel";
            this.flowLabel.Size = new System.Drawing.Size(35, 13);
            this.flowLabel.TabIndex = 5;
            this.flowLabel.Text = "label7";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Splitter flow";
            // 
            // FlowNetworkSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 505);
            this.Controls.Add(this.flowLabel);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FlowNetworkSimulator";
            this.Text = "Flow Simulator";
            this.Load += new System.EventHandler(this.FlowNetworkSimulator_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowNetworkSimulator_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FlowNetworkSimulator_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FlowNetworkSimulator_MouseMove);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RedoButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UndoButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.cmsEdit.ResumeLayout(false);
            this.cmsEditPipeline.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox UndoButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnPump;
        private System.Windows.Forms.Button btnPipe;
        private System.Windows.Forms.Button btnMerger;
        private System.Windows.Forms.Button btnSplitter;
        private System.Windows.Forms.Button btnSink;
        private System.Windows.Forms.PictureBox RedoButton;
        private System.Windows.Forms.ContextMenuStrip cmsEdit;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsEditPipeline;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.Label flowLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

