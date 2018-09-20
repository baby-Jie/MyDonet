namespace WinformTest
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.helloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnKeyDown = new System.Windows.Forms.Button();
            this.btnTopmostForm = new System.Windows.Forms.Button();
            this.GraphicsButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helloToolStripMenuItem,
            this.hiToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 52);
            // 
            // helloToolStripMenuItem
            // 
            this.helloToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memeToolStripMenuItem});
            this.helloToolStripMenuItem.Name = "helloToolStripMenuItem";
            this.helloToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.helloToolStripMenuItem.Text = "hello";
            // 
            // memeToolStripMenuItem
            // 
            this.memeToolStripMenuItem.Name = "memeToolStripMenuItem";
            this.memeToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.memeToolStripMenuItem.Text = "meme ";
            // 
            // hiToolStripMenuItem
            // 
            this.hiToolStripMenuItem.Name = "hiToolStripMenuItem";
            this.hiToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.hiToolStripMenuItem.Text = "hi";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(73, 129);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "test button";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnKeyDown
            // 
            this.btnKeyDown.Location = new System.Drawing.Point(12, 12);
            this.btnKeyDown.Name = "btnKeyDown";
            this.btnKeyDown.Size = new System.Drawing.Size(126, 31);
            this.btnKeyDown.TabIndex = 2;
            this.btnKeyDown.Text = "KeyDownForm";
            this.btnKeyDown.UseVisualStyleBackColor = true;
            this.btnKeyDown.Click += new System.EventHandler(this.btnKeyDown_Click);
            // 
            // btnTopmostForm
            // 
            this.btnTopmostForm.Location = new System.Drawing.Point(171, 12);
            this.btnTopmostForm.Name = "btnTopmostForm";
            this.btnTopmostForm.Size = new System.Drawing.Size(126, 31);
            this.btnTopmostForm.TabIndex = 3;
            this.btnTopmostForm.Text = "TopMostForm";
            this.btnTopmostForm.UseVisualStyleBackColor = true;
            this.btnTopmostForm.Click += new System.EventHandler(this.btnTopmostForm_Click);
            // 
            // GraphicsButton
            // 
            this.GraphicsButton.Location = new System.Drawing.Point(339, 12);
            this.GraphicsButton.Name = "GraphicsButton";
            this.GraphicsButton.Size = new System.Drawing.Size(171, 31);
            this.GraphicsButton.TabIndex = 4;
            this.GraphicsButton.Text = "Graaphics";
            this.GraphicsButton.UseVisualStyleBackColor = true;
            this.GraphicsButton.Click += new System.EventHandler(this.GraphicsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.GraphicsButton);
            this.Controls.Add(this.btnTopmostForm);
            this.Controls.Add(this.btnKeyDown);
            this.Controls.Add(this.btnTest);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hiToolStripMenuItem;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnKeyDown;
        private System.Windows.Forms.Button btnTopmostForm;
        private System.Windows.Forms.Button GraphicsButton;
    }
}

