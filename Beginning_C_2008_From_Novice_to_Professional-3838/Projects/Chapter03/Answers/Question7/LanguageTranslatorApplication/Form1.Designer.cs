namespace LanguageTranslatorApplication {
    partial class FormMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.butTranslate = new System.Windows.Forms.Button();
            this.txtToTranslate = new System.Windows.Forms.TextBox();
            this.txtTranslated = new System.Windows.Forms.TextBox();
            this.optEnglishToGerman = new System.Windows.Forms.RadioButton();
            this.optFrenchToGerman = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // butTranslate
            // 
            this.butTranslate.Location = new System.Drawing.Point(12, 12);
            this.butTranslate.Name = "butTranslate";
            this.butTranslate.Size = new System.Drawing.Size(97, 26);
            this.butTranslate.TabIndex = 0;
            this.butTranslate.Text = "Translate";
            this.butTranslate.UseVisualStyleBackColor = true;
            this.butTranslate.Click += new System.EventHandler(this.butTranslate_Click);
            // 
            // txtToTranslate
            // 
            this.txtToTranslate.Location = new System.Drawing.Point(12, 105);
            this.txtToTranslate.Name = "txtToTranslate";
            this.txtToTranslate.Size = new System.Drawing.Size(209, 20);
            this.txtToTranslate.TabIndex = 1;
            // 
            // txtTranslated
            // 
            this.txtTranslated.Location = new System.Drawing.Point(12, 146);
            this.txtTranslated.Name = "txtTranslated";
            this.txtTranslated.ReadOnly = true;
            this.txtTranslated.Size = new System.Drawing.Size(209, 20);
            this.txtTranslated.TabIndex = 2;
            // 
            // optEnglishToGerman
            // 
            this.optEnglishToGerman.AutoSize = true;
            this.optEnglishToGerman.Checked = true;
            this.optEnglishToGerman.Location = new System.Drawing.Point(20, 47);
            this.optEnglishToGerman.Name = "optEnglishToGerman";
            this.optEnglishToGerman.Size = new System.Drawing.Size(115, 17);
            this.optEnglishToGerman.TabIndex = 3;
            this.optEnglishToGerman.TabStop = true;
            this.optEnglishToGerman.Text = "English To German";
            this.optEnglishToGerman.UseVisualStyleBackColor = true;
            // 
            // optFrenchToGerman
            // 
            this.optFrenchToGerman.AutoSize = true;
            this.optFrenchToGerman.Location = new System.Drawing.Point(20, 74);
            this.optFrenchToGerman.Name = "optFrenchToGerman";
            this.optFrenchToGerman.Size = new System.Drawing.Size(114, 17);
            this.optFrenchToGerman.TabIndex = 4;
            this.optFrenchToGerman.TabStop = true;
            this.optFrenchToGerman.Text = "French To German";
            this.optFrenchToGerman.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 185);
            this.Controls.Add(this.optFrenchToGerman);
            this.Controls.Add(this.optEnglishToGerman);
            this.Controls.Add(this.txtTranslated);
            this.Controls.Add(this.txtToTranslate);
            this.Controls.Add(this.butTranslate);
            this.Name = "FormMain";
            this.Text = "Form Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butTranslate;
        private System.Windows.Forms.TextBox txtToTranslate;
        private System.Windows.Forms.TextBox txtTranslated;
        private System.Windows.Forms.RadioButton optEnglishToGerman;
        private System.Windows.Forms.RadioButton optFrenchToGerman;
    }
}

