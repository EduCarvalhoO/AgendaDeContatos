
namespace TesteAgenda
{
    partial class formAgenda
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Contatos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(246, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agenda de Contatos";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_Contatos
            // 
            this.btn_Contatos.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btn_Contatos.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Contatos.Location = new System.Drawing.Point(322, 232);
            this.btn_Contatos.Name = "btn_Contatos";
            this.btn_Contatos.Size = new System.Drawing.Size(165, 70);
            this.btn_Contatos.TabIndex = 1;
            this.btn_Contatos.Text = "Gerenciar Contatos";
            this.btn_Contatos.UseVisualStyleBackColor = false;
            this.btn_Contatos.Click += new System.EventHandler(this.btn_Contatos_Click);
            // 
            // formAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btn_Contatos);
            this.Controls.Add(this.label1);
            this.Name = "formAgenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AGENDA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Contatos;
    }
}

