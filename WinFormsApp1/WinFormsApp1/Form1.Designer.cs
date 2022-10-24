using System.Drawing;

namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.editGroupBox = new System.Windows.Forms.GroupBox();
            this.editLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.vertexRemoveButton = new System.Windows.Forms.CheckBox();
            this.vertexAddButton = new System.Windows.Forms.CheckBox();
            this.polygonCreateButton = new System.Windows.Forms.CheckBox();
            this.relationGroupBox = new System.Windows.Forms.GroupBox();
            this.relationLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lengthChangeButton = new System.Windows.Forms.CheckBox();
            this.lengthLimitButton = new System.Windows.Forms.CheckBox();
            this.perpendicularityButton = new System.Windows.Forms.CheckBox();
            this.viewRelationsButton = new System.Windows.Forms.CheckBox();
            this.algGroupBox = new System.Windows.Forms.GroupBox();
            this.algLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.alg1Button = new System.Windows.Forms.RadioButton();
            this.alg2Button = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuLayoutPanel.SuspendLayout();
            this.editGroupBox.SuspendLayout();
            this.editLayoutPanel.SuspendLayout();
            this.relationGroupBox.SuspendLayout();
            this.relationLayoutPanel.SuspendLayout();
            this.algGroupBox.SuspendLayout();
            this.algLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menuLayoutPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1397, 1573);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuLayoutPanel
            // 
            this.menuLayoutPanel.ColumnCount = 3;
            this.menuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.menuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.menuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.menuLayoutPanel.Controls.Add(this.editGroupBox, 0, 0);
            this.menuLayoutPanel.Controls.Add(this.relationGroupBox, 1, 0);
            this.menuLayoutPanel.Controls.Add(this.algGroupBox, 2, 0);
            this.menuLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.menuLayoutPanel.Name = "menuLayoutPanel";
            this.menuLayoutPanel.RowCount = 1;
            this.menuLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuLayoutPanel.Size = new System.Drawing.Size(1391, 229);
            this.menuLayoutPanel.TabIndex = 0;
            // 
            // editGroupBox
            // 
            this.editGroupBox.Controls.Add(this.editLayoutPanel);
            this.editGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editGroupBox.Location = new System.Drawing.Point(3, 3);
            this.editGroupBox.Name = "editGroupBox";
            this.editGroupBox.Size = new System.Drawing.Size(411, 223);
            this.editGroupBox.TabIndex = 0;
            this.editGroupBox.TabStop = false;
            this.editGroupBox.Text = "Edit tab";
            // 
            // editLayoutPanel
            // 
            this.editLayoutPanel.ColumnCount = 3;
            this.editLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.editLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.editLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.editLayoutPanel.Controls.Add(this.vertexRemoveButton, 0, 0);
            this.editLayoutPanel.Controls.Add(this.vertexAddButton, 0, 0);
            this.editLayoutPanel.Controls.Add(this.polygonCreateButton, 0, 0);
            this.editLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editLayoutPanel.Location = new System.Drawing.Point(3, 27);
            this.editLayoutPanel.Name = "editLayoutPanel";
            this.editLayoutPanel.RowCount = 1;
            this.editLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.editLayoutPanel.Size = new System.Drawing.Size(405, 193);
            this.editLayoutPanel.TabIndex = 0;
            // 
            // vertexRemoveButton
            // 
            this.vertexRemoveButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.vertexRemoveButton.AutoSize = true;
            this.vertexRemoveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vertexRemoveButton.Location = new System.Drawing.Point(273, 3);
            this.vertexRemoveButton.Name = "vertexRemoveButton";
            this.vertexRemoveButton.Size = new System.Drawing.Size(129, 187);
            this.vertexRemoveButton.TabIndex = 3;
            this.vertexRemoveButton.Text = "Remove vertex";
            this.vertexRemoveButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.vertexRemoveButton.UseVisualStyleBackColor = true;
            this.vertexRemoveButton.CheckedChanged += new System.EventHandler(this.vertexRemoveButton_CheckedChanged);
            // 
            // vertexAddButton
            // 
            this.vertexAddButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.vertexAddButton.AutoSize = true;
            this.vertexAddButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vertexAddButton.Location = new System.Drawing.Point(138, 3);
            this.vertexAddButton.Name = "vertexAddButton";
            this.vertexAddButton.Size = new System.Drawing.Size(129, 187);
            this.vertexAddButton.TabIndex = 2;
            this.vertexAddButton.Text = "Add vertex";
            this.vertexAddButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.vertexAddButton.UseVisualStyleBackColor = true;
            this.vertexAddButton.CheckedChanged += new System.EventHandler(this.vertexAddButton_CheckedChanged);
            // 
            // polygonCreateButton
            // 
            this.polygonCreateButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.polygonCreateButton.AutoSize = true;
            this.polygonCreateButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polygonCreateButton.Location = new System.Drawing.Point(3, 3);
            this.polygonCreateButton.Name = "polygonCreateButton";
            this.polygonCreateButton.Size = new System.Drawing.Size(129, 187);
            this.polygonCreateButton.TabIndex = 0;
            this.polygonCreateButton.Text = "Create polygon";
            this.polygonCreateButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.polygonCreateButton.UseVisualStyleBackColor = true;
            this.polygonCreateButton.CheckedChanged += new System.EventHandler(this.polygonCreateButton_CheckedChanged);
            // 
            // relationGroupBox
            // 
            this.relationGroupBox.Controls.Add(this.relationLayoutPanel);
            this.relationGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.relationGroupBox.Location = new System.Drawing.Point(420, 3);
            this.relationGroupBox.Name = "relationGroupBox";
            this.relationGroupBox.Size = new System.Drawing.Size(689, 223);
            this.relationGroupBox.TabIndex = 1;
            this.relationGroupBox.TabStop = false;
            this.relationGroupBox.Text = "Relations tab";
            // 
            // relationLayoutPanel
            // 
            this.relationLayoutPanel.ColumnCount = 4;
            this.relationLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.relationLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.relationLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.relationLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.relationLayoutPanel.Controls.Add(this.lengthChangeButton, 1, 0);
            this.relationLayoutPanel.Controls.Add(this.lengthLimitButton, 0, 0);
            this.relationLayoutPanel.Controls.Add(this.perpendicularityButton, 2, 0);
            this.relationLayoutPanel.Controls.Add(this.viewRelationsButton, 3, 0);
            this.relationLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.relationLayoutPanel.Location = new System.Drawing.Point(3, 27);
            this.relationLayoutPanel.Name = "relationLayoutPanel";
            this.relationLayoutPanel.RowCount = 1;
            this.relationLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.relationLayoutPanel.Size = new System.Drawing.Size(683, 193);
            this.relationLayoutPanel.TabIndex = 0;
            // 
            // lengthChangeButton
            // 
            this.lengthChangeButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.lengthChangeButton.AutoSize = true;
            this.lengthChangeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lengthChangeButton.Location = new System.Drawing.Point(173, 3);
            this.lengthChangeButton.Name = "lengthChangeButton";
            this.lengthChangeButton.Size = new System.Drawing.Size(164, 187);
            this.lengthChangeButton.TabIndex = 0;
            this.lengthChangeButton.Text = "Set const length";
            this.lengthChangeButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lengthChangeButton.UseVisualStyleBackColor = true;
            this.lengthChangeButton.CheckedChanged += new System.EventHandler(this.lengthChangeButton_CheckedChanged);
            // 
            // lengthLimitButton
            // 
            this.lengthLimitButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.lengthLimitButton.AutoSize = true;
            this.lengthLimitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lengthLimitButton.Location = new System.Drawing.Point(3, 3);
            this.lengthLimitButton.Name = "lengthLimitButton";
            this.lengthLimitButton.Size = new System.Drawing.Size(164, 187);
            this.lengthLimitButton.TabIndex = 1;
            this.lengthLimitButton.Text = "Limit length";
            this.lengthLimitButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lengthLimitButton.UseVisualStyleBackColor = true;
            this.lengthLimitButton.CheckedChanged += new System.EventHandler(this.lengthLimitButton_CheckedChanged);
            // 
            // perpendicularityButton
            // 
            this.perpendicularityButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.perpendicularityButton.AutoSize = true;
            this.perpendicularityButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.perpendicularityButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.perpendicularityButton.Location = new System.Drawing.Point(343, 3);
            this.perpendicularityButton.Name = "perpendicularityButton";
            this.perpendicularityButton.Size = new System.Drawing.Size(164, 187);
            this.perpendicularityButton.TabIndex = 2;
            this.perpendicularityButton.Text = "Set perpendicular edges";
            this.perpendicularityButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.perpendicularityButton.UseVisualStyleBackColor = true;
            this.perpendicularityButton.CheckedChanged += new System.EventHandler(this.perpendicularityButton_CheckedChanged);
            // 
            // viewRelationsButton
            // 
            this.viewRelationsButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.viewRelationsButton.AutoSize = true;
            this.viewRelationsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewRelationsButton.Location = new System.Drawing.Point(513, 3);
            this.viewRelationsButton.Name = "viewRelationsButton";
            this.viewRelationsButton.Size = new System.Drawing.Size(167, 187);
            this.viewRelationsButton.TabIndex = 3;
            this.viewRelationsButton.Text = "Inspect/Remove relations";
            this.viewRelationsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.viewRelationsButton.UseVisualStyleBackColor = true;
            this.viewRelationsButton.CheckedChanged += new System.EventHandler(this.viewRelationsButton_CheckedChanged);
            // 
            // algGroupBox
            // 
            this.algGroupBox.Controls.Add(this.algLayoutPanel);
            this.algGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.algGroupBox.Location = new System.Drawing.Point(1115, 3);
            this.algGroupBox.Name = "algGroupBox";
            this.algGroupBox.Size = new System.Drawing.Size(273, 223);
            this.algGroupBox.TabIndex = 2;
            this.algGroupBox.TabStop = false;
            this.algGroupBox.Text = "Algorithm tab";
            // 
            // algLayoutPanel
            // 
            this.algLayoutPanel.ColumnCount = 1;
            this.algLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.algLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.algLayoutPanel.Controls.Add(this.alg1Button, 0, 0);
            this.algLayoutPanel.Controls.Add(this.alg2Button, 0, 1);
            this.algLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.algLayoutPanel.Location = new System.Drawing.Point(3, 27);
            this.algLayoutPanel.Name = "algLayoutPanel";
            this.algLayoutPanel.RowCount = 2;
            this.algLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.algLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.algLayoutPanel.Size = new System.Drawing.Size(267, 193);
            this.algLayoutPanel.TabIndex = 0;
            // 
            // alg1Button
            // 
            this.alg1Button.AutoSize = true;
            this.alg1Button.Checked = true;
            this.alg1Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alg1Button.Location = new System.Drawing.Point(3, 3);
            this.alg1Button.Name = "alg1Button";
            this.alg1Button.Size = new System.Drawing.Size(261, 90);
            this.alg1Button.TabIndex = 0;
            this.alg1Button.TabStop = true;
            this.alg1Button.Text = "Library algorithm";
            this.alg1Button.UseVisualStyleBackColor = true;
            this.alg1Button.CheckedChanged += new System.EventHandler(this.alg1Button_CheckedChanged);
            // 
            // alg2Button
            // 
            this.alg2Button.AutoSize = true;
            this.alg2Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alg2Button.Location = new System.Drawing.Point(3, 99);
            this.alg2Button.Name = "alg2Button";
            this.alg2Button.Size = new System.Drawing.Size(261, 91);
            this.alg2Button.TabIndex = 1;
            this.alg2Button.Text = "Bresenham\'s algorithm";
            this.alg2Button.UseVisualStyleBackColor = true;
            this.alg2Button.CheckedChanged += new System.EventHandler(this.alg2Button_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 238);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1391, 1332);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 1573);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(1419, 1629);
            this.MinimumSize = new System.Drawing.Size(1419, 1629);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PolygonDrawer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menuLayoutPanel.ResumeLayout(false);
            this.editGroupBox.ResumeLayout(false);
            this.editLayoutPanel.ResumeLayout(false);
            this.editLayoutPanel.PerformLayout();
            this.relationGroupBox.ResumeLayout(false);
            this.relationLayoutPanel.ResumeLayout(false);
            this.relationLayoutPanel.PerformLayout();
            this.algGroupBox.ResumeLayout(false);
            this.algLayoutPanel.ResumeLayout(false);
            this.algLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bitmap drawArea;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel menuLayoutPanel;
        private System.Windows.Forms.GroupBox editGroupBox;
        private System.Windows.Forms.GroupBox relationGroupBox;
        private System.Windows.Forms.GroupBox algGroupBox;
        private System.Windows.Forms.TableLayoutPanel algLayoutPanel;
        private System.Windows.Forms.RadioButton alg1Button;
        private System.Windows.Forms.RadioButton alg2Button;
        private System.Windows.Forms.TableLayoutPanel editLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox polygonCreateButton;
        private System.Windows.Forms.CheckBox vertexRemoveButton;
        private System.Windows.Forms.CheckBox vertexAddButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TableLayoutPanel relationLayoutPanel;
        private System.Windows.Forms.CheckBox lengthChangeButton;
        private System.Windows.Forms.CheckBox lengthLimitButton;
        private System.Windows.Forms.CheckBox perpendicularityButton;
        private System.Windows.Forms.CheckBox viewRelationsButton;
    }
}
