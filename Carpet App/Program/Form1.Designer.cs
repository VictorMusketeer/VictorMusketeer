namespace Program
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
            this.label1 = new System.Windows.Forms.Label();
            this.grpRoomDetails = new System.Windows.Forms.GroupBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCarpetCost = new System.Windows.Forms.TextBox();
            this.grpCalculations = new System.Windows.Forms.GroupBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblPerimeter = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.grpRoomDetails.SuspendLayout();
            this.grpCalculations.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(321, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carpet Quote";
            // 
            // grpRoomDetails
            // 
            this.grpRoomDetails.Controls.Add(this.txtWidth);
            this.grpRoomDetails.Controls.Add(this.txtLength);
            this.grpRoomDetails.Controls.Add(this.lblWidth);
            this.grpRoomDetails.Controls.Add(this.lblLength);
            this.grpRoomDetails.Location = new System.Drawing.Point(222, 67);
            this.grpRoomDetails.Name = "grpRoomDetails";
            this.grpRoomDetails.Size = new System.Drawing.Size(351, 115);
            this.grpRoomDetails.TabIndex = 1;
            this.grpRoomDetails.TabStop = false;
            this.grpRoomDetails.Text = "Room Details";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(21, 36);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(40, 13);
            this.lblLength.TabIndex = 0;
            this.lblLength.Text = "Length";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(26, 66);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 1;
            this.lblWidth.Text = "Width";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(164, 29);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(141, 20);
            this.txtLength.TabIndex = 2;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(164, 66);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(141, 20);
            this.txtWidth.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Carpet Cost per sq m";
            // 
            // txtCarpetCost
            // 
            this.txtCarpetCost.Location = new System.Drawing.Point(386, 204);
            this.txtCarpetCost.Name = "txtCarpetCost";
            this.txtCarpetCost.Size = new System.Drawing.Size(141, 20);
            this.txtCarpetCost.TabIndex = 3;
            // 
            // grpCalculations
            // 
            this.grpCalculations.Controls.Add(this.txtTotalCost);
            this.grpCalculations.Controls.Add(this.lblTotalCost);
            this.grpCalculations.Controls.Add(this.lblPerimeter);
            this.grpCalculations.Controls.Add(this.lblArea);
            this.grpCalculations.Controls.Add(this.label4);
            this.grpCalculations.Controls.Add(this.label3);
            this.grpCalculations.Location = new System.Drawing.Point(225, 257);
            this.grpCalculations.Name = "grpCalculations";
            this.grpCalculations.Size = new System.Drawing.Size(348, 151);
            this.grpCalculations.TabIndex = 4;
            this.grpCalculations.TabStop = false;
            this.grpCalculations.Text = "Totals";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(363, 427);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 5;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Area";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Perimeter";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(158, 35);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(35, 13);
            this.lblArea.TabIndex = 2;
            this.lblArea.Text = "label5";
            // 
            // lblPerimeter
            // 
            this.lblPerimeter.AutoSize = true;
            this.lblPerimeter.Location = new System.Drawing.Point(158, 68);
            this.lblPerimeter.Name = "lblPerimeter";
            this.lblPerimeter.Size = new System.Drawing.Size(35, 13);
            this.lblPerimeter.TabIndex = 3;
            this.lblPerimeter.Text = "label5";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(18, 104);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(55, 13);
            this.lblTotalCost.TabIndex = 4;
            this.lblTotalCost.Text = "Total Cost";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(161, 104);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.Size = new System.Drawing.Size(141, 20);
            this.txtTotalCost.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 466);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.grpCalculations);
            this.Controls.Add(this.txtCarpetCost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpRoomDetails);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpRoomDetails.ResumeLayout(false);
            this.grpRoomDetails.PerformLayout();
            this.grpCalculations.ResumeLayout(false);
            this.grpCalculations.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpRoomDetails;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCarpetCost;
        private System.Windows.Forms.GroupBox grpCalculations;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblPerimeter;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCalculate;
    }
}

