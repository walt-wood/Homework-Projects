
namespace ProductPagesV2
{
    partial class Form1
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
            this.mainFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.bikesButton = new System.Windows.Forms.Button();
            this.clothingButton = new System.Windows.Forms.Button();
            this.compButton = new System.Windows.Forms.Button();
            this.accessButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainFlowLayoutPanel
            // 
            this.mainFlowLayoutPanel.Location = new System.Drawing.Point(14, 14);
            this.mainFlowLayoutPanel.Name = "mainFlowLayoutPanel";
            this.mainFlowLayoutPanel.Size = new System.Drawing.Size(727, 474);
            this.mainFlowLayoutPanel.TabIndex = 0;
            // 
            // bikesButton
            // 
            this.bikesButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bikesButton.FlatAppearance.BorderSize = 0;
            this.bikesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bikesButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bikesButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.bikesButton.Location = new System.Drawing.Point(795, 55);
            this.bikesButton.Name = "bikesButton";
            this.bikesButton.Size = new System.Drawing.Size(87, 27);
            this.bikesButton.TabIndex = 1;
            this.bikesButton.Text = "Bikes";
            this.bikesButton.UseVisualStyleBackColor = false;
            this.bikesButton.Click += new System.EventHandler(this.bikesButton_Click);
            // 
            // clothingButton
            // 
            this.clothingButton.FlatAppearance.BorderSize = 0;
            this.clothingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clothingButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clothingButton.Location = new System.Drawing.Point(795, 143);
            this.clothingButton.Name = "clothingButton";
            this.clothingButton.Size = new System.Drawing.Size(87, 27);
            this.clothingButton.TabIndex = 2;
            this.clothingButton.Text = "Clothing";
            this.clothingButton.UseVisualStyleBackColor = true;
            this.clothingButton.Click += new System.EventHandler(this.clothingButton_Click);
            // 
            // compButton
            // 
            this.compButton.FlatAppearance.BorderSize = 0;
            this.compButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.compButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compButton.Location = new System.Drawing.Point(795, 99);
            this.compButton.Margin = new System.Windows.Forms.Padding(0);
            this.compButton.Name = "compButton";
            this.compButton.Size = new System.Drawing.Size(87, 27);
            this.compButton.TabIndex = 3;
            this.compButton.Text = "Components";
            this.compButton.UseVisualStyleBackColor = true;
            this.compButton.Click += new System.EventHandler(this.compButton_Click);
            // 
            // accessButton
            // 
            this.accessButton.FlatAppearance.BorderSize = 0;
            this.accessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accessButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accessButton.Location = new System.Drawing.Point(795, 193);
            this.accessButton.Name = "accessButton";
            this.accessButton.Size = new System.Drawing.Size(87, 27);
            this.accessButton.TabIndex = 4;
            this.accessButton.Text = "Accessories";
            this.accessButton.UseVisualStyleBackColor = true;
            this.accessButton.Click += new System.EventHandler(this.accessButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.accessButton);
            this.Controls.Add(this.compButton);
            this.Controls.Add(this.clothingButton);
            this.Controls.Add(this.bikesButton);
            this.Controls.Add(this.mainFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "Form1";
            this.Text = "Adventure Works Products";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel mainFlowLayoutPanel;
        private System.Windows.Forms.Button bikesButton;
        private System.Windows.Forms.Button clothingButton;
        private System.Windows.Forms.Button compButton;
        private System.Windows.Forms.Button accessButton;
    }
}

