﻿using System.Windows.Forms;

namespace AdaptiveHuffmanTree
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
            this.letterToEncodeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.averageCodewordLengthTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.entropyTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lettersListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.encodedTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.enteredTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addLetterButton = new System.Windows.Forms.Button();
            this.treePictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // letterToEncodeTextBox
            // 
            this.letterToEncodeTextBox.Location = new System.Drawing.Point(7, 40);
            this.letterToEncodeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.letterToEncodeTextBox.MaxLength = 1;
            this.letterToEncodeTextBox.Name = "letterToEncodeTextBox";
            this.letterToEncodeTextBox.Size = new System.Drawing.Size(203, 28);
            this.letterToEncodeTextBox.TabIndex = 0;
            this.letterToEncodeTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.letterToEncodeTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Letter to send";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.addLetterButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.letterToEncodeTextBox);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(13, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1540, 188);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.averageCodewordLengthTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.entropyTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lettersListView);
            this.groupBox1.Controls.Add(this.encodedTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.enteredTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(240, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1283, 166);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // averageCodewordLengthTextBox
            // 
            this.averageCodewordLengthTextBox.Enabled = false;
            this.averageCodewordLengthTextBox.Location = new System.Drawing.Point(540, 120);
            this.averageCodewordLengthTextBox.Name = "averageCodewordLengthTextBox";
            this.averageCodewordLengthTextBox.Size = new System.Drawing.Size(192, 28);
            this.averageCodewordLengthTextBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(536, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 21);
            this.label6.TabIndex = 7;
            this.label6.Text = "Average Codeword Length";
            // 
            // entropyTextBox
            // 
            this.entropyTextBox.Enabled = false;
            this.entropyTextBox.Location = new System.Drawing.Point(540, 52);
            this.entropyTextBox.Name = "entropyTextBox";
            this.entropyTextBox.Size = new System.Drawing.Size(192, 28);
            this.entropyTextBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(536, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Entropy";
            // 
            // lettersListView
            // 
            this.lettersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lettersListView.Location = new System.Drawing.Point(756, 25);
            this.lettersListView.Name = "lettersListView";
            this.lettersListView.Size = new System.Drawing.Size(490, 123);
            this.lettersListView.TabIndex = 4;
            this.lettersListView.UseCompatibleStateImageBehavior = false;
            this.lettersListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Letter";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Binary Code";
            this.columnHeader2.Width = 102;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Letter";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Binary Code";
            this.columnHeader4.Width = 101;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Letter";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Binary Code";
            this.columnHeader6.Width = 98;
            // 
            // encodedTextBox
            // 
            this.encodedTextBox.Enabled = false;
            this.encodedTextBox.Location = new System.Drawing.Point(6, 120);
            this.encodedTextBox.Name = "encodedTextBox";
            this.encodedTextBox.Size = new System.Drawing.Size(507, 28);
            this.encodedTextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Encoded text";
            // 
            // enteredTextBox
            // 
            this.enteredTextBox.Enabled = false;
            this.enteredTextBox.Location = new System.Drawing.Point(10, 52);
            this.enteredTextBox.Name = "enteredTextBox";
            this.enteredTextBox.Size = new System.Drawing.Size(503, 28);
            this.enteredTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Entered text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // addLetterButton
            // 
            this.addLetterButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.addLetterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addLetterButton.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addLetterButton.ForeColor = System.Drawing.Color.White;
            this.addLetterButton.Location = new System.Drawing.Point(7, 105);
            this.addLetterButton.Margin = new System.Windows.Forms.Padding(4);
            this.addLetterButton.Name = "addLetterButton";
            this.addLetterButton.Size = new System.Drawing.Size(203, 73);
            this.addLetterButton.TabIndex = 3;
            this.addLetterButton.Text = "ADD LETTER";
            this.addLetterButton.UseVisualStyleBackColor = false;
            this.addLetterButton.Click += new System.EventHandler(this.addLetterButton_Click);
            // 
            // treePictureBox
            // 
            this.treePictureBox.Location = new System.Drawing.Point(12, 211);
            this.treePictureBox.Name = "treePictureBox";
            this.treePictureBox.Size = new System.Drawing.Size(1541, 840);
            this.treePictureBox.TabIndex = 3;
            this.treePictureBox.TabStop = false;
            this.treePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.treePictureBox_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1558, 1055);
            this.Controls.Add(this.treePictureBox);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Adaptive Huffman Tree";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox letterToEncodeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addLetterButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox enteredTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox encodedTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lettersListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private TextBox averageCodewordLengthTextBox;
        private Label label6;
        private TextBox entropyTextBox;
        private Label label5;
        private PictureBox treePictureBox;
    }
}

