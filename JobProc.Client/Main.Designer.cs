
namespace JobProc.Client
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainGroupBox = new System.Windows.Forms.GroupBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.fillTimesButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.countPeople = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.countImages = new System.Windows.Forms.MaskedTextBox();
            this.dataGridTimes = new System.Windows.Forms.DataGridView();
            this.MainGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainGroupBox.Controls.Add(this.resetButton);
            this.MainGroupBox.Controls.Add(this.startButton);
            this.MainGroupBox.Controls.Add(this.fillTimesButton);
            this.MainGroupBox.Controls.Add(this.label2);
            this.MainGroupBox.Controls.Add(this.countPeople);
            this.MainGroupBox.Controls.Add(this.label1);
            this.MainGroupBox.Controls.Add(this.countImages);
            this.MainGroupBox.Location = new System.Drawing.Point(12, 12);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(776, 57);
            this.MainGroupBox.TabIndex = 0;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "Choose count images and people";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(617, 22);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 6;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(698, 22);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // fillTimesButton
            // 
            this.fillTimesButton.Location = new System.Drawing.Point(536, 22);
            this.fillTimesButton.Name = "fillTimesButton";
            this.fillTimesButton.Size = new System.Drawing.Size(75, 23);
            this.fillTimesButton.TabIndex = 4;
            this.fillTimesButton.Text = "Fill time";
            this.fillTimesButton.UseVisualStyleBackColor = true;
            this.fillTimesButton.Click += new System.EventHandler(this.FillTimesButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "choose count of people";
            // 
            // countPeople
            // 
            this.countPeople.HidePromptOnLeave = true;
            this.countPeople.Location = new System.Drawing.Point(430, 22);
            this.countPeople.Mask = "00000";
            this.countPeople.Name = "countPeople";
            this.countPeople.Size = new System.Drawing.Size(100, 23);
            this.countPeople.TabIndex = 2;
            this.countPeople.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "choose count of images";
            // 
            // countImages
            // 
            this.countImages.HidePromptOnLeave = true;
            this.countImages.Location = new System.Drawing.Point(146, 22);
            this.countImages.Mask = "00000000";
            this.countImages.Name = "countImages";
            this.countImages.Size = new System.Drawing.Size(100, 23);
            this.countImages.TabIndex = 0;
            this.countImages.ValidatingType = typeof(int);
            // 
            // dataGridTimes
            // 
            this.dataGridTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTimes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTimes.Location = new System.Drawing.Point(12, 75);
            this.dataGridTimes.Name = "dataGridTimes";
            this.dataGridTimes.RowTemplate.Height = 25;
            this.dataGridTimes.Size = new System.Drawing.Size(776, 363);
            this.dataGridTimes.TabIndex = 1;
            this.dataGridTimes.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridTimes_DataError);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridTimes);
            this.Controls.Add(this.MainGroupBox);
            this.Name = "Main";
            this.Text = "Form1";
            this.MainGroupBox.ResumeLayout(false);
            this.MainGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTimes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MainGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox countImages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox countPeople;
        private System.Windows.Forms.Button fillTimesButton;
        private System.Windows.Forms.DataGridView dataGridTimes;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button resetButton;
    }
}

