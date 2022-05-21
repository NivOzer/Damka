
namespace Damka
{
    partial class Damka
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
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.gameLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveButton.AutoSize = true;
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.FlatAppearance.BorderSize = 10;
            this.saveButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saveButton.Location = new System.Drawing.Point(538, 766);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(313, 52);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadButton.AutoSize = true;
            this.loadButton.BackColor = System.Drawing.Color.Transparent;
            this.loadButton.FlatAppearance.BorderSize = 10;
            this.loadButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.loadButton.Location = new System.Drawing.Point(855, 766);
            this.loadButton.Margin = new System.Windows.Forms.Padding(2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(313, 52);
            this.loadButton.TabIndex = 14;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // gameLabel
            // 
            this.gameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameLabel.AutoSize = true;
            this.gameLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gameLabel.Font = new System.Drawing.Font("Perpetua Titling MT", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gameLabel.ForeColor = System.Drawing.Color.Snow;
            this.gameLabel.Location = new System.Drawing.Point(696, -80);
            this.gameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.gameLabel.Name = "gameLabel";
            this.gameLabel.Size = new System.Drawing.Size(306, 79);
            this.gameLabel.TabIndex = 1;
            this.gameLabel.Text = "Damka";
            this.gameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gameLabel.UseMnemonic = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 10;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(538, 821);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(630, 52);
            this.button1.TabIndex = 15;
            this.button1.Text = "Back To Menu";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Damka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::Damka.Properties.Resources.wood;
            this.ClientSize = new System.Drawing.Size(1684, 791);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.gameLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Damka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "~ Damka ~";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label gameLabel;
        private System.Windows.Forms.Button button1;
    }
}