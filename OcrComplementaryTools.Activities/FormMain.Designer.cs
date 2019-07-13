namespace OcrComplementaryTools
{
    partial class FormMain
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
            this.buttonGo = new System.Windows.Forms.Button();
            this.buttonUnreadable = new System.Windows.Forms.Button();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.pictureBoxReviewImage = new System.Windows.Forms.PictureBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.comboBoxForCandidate = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReviewImage)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(473, 405);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(80, 32);
            this.buttonGo.TabIndex = 0;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // buttonUnreadable
            // 
            this.buttonUnreadable.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonUnreadable.Location = new System.Drawing.Point(572, 405);
            this.buttonUnreadable.Name = "buttonUnreadable";
            this.buttonUnreadable.Size = new System.Drawing.Size(80, 32);
            this.buttonUnreadable.TabIndex = 1;
            this.buttonUnreadable.Text = "Unreadable";
            this.buttonUnreadable.UseVisualStyleBackColor = true;
            this.buttonUnreadable.Click += new System.EventHandler(this.buttonUnreadble_Click);
            // 
            // textBoxText
            // 
            this.textBoxText.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxText.Location = new System.Drawing.Point(12, 267);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(680, 124);
            this.textBoxText.TabIndex = 2;
            this.textBoxText.Visible = false;
            // 
            // pictureBoxReviewImage
            // 
            this.pictureBoxReviewImage.Location = new System.Drawing.Point(12, 20);
            this.pictureBoxReviewImage.Name = "pictureBoxReviewImage";
            this.pictureBoxReviewImage.Size = new System.Drawing.Size(680, 228);
            this.pictureBoxReviewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxReviewImage.TabIndex = 3;
            this.pictureBoxReviewImage.TabStop = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 405);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(80, 32);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(110, 405);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(80, 32);
            this.buttonRestore.TabIndex = 5;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // comboBoxForCandidate
            // 
            this.comboBoxForCandidate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBoxForCandidate.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxForCandidate.FormattingEnabled = true;
            this.comboBoxForCandidate.ItemHeight = 19;
            this.comboBoxForCandidate.Location = new System.Drawing.Point(12, 267);
            this.comboBoxForCandidate.Name = "comboBoxForCandidate";
            this.comboBoxForCandidate.Size = new System.Drawing.Size(640, 126);
            this.comboBoxForCandidate.TabIndex = 9;
            this.comboBoxForCandidate.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonUnreadable;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.comboBoxForCandidate);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.pictureBoxReviewImage);
            this.Controls.Add(this.textBoxText);
            this.Controls.Add(this.buttonUnreadable);
            this.Controls.Add(this.buttonGo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Review Dialog";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReviewImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Button buttonUnreadable;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.PictureBox pictureBoxReviewImage;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.ComboBox comboBoxForCandidate;
    }
}