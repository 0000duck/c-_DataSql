namespace _04登陆验证
{
    partial class Form2
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
            this.textoldpwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textnewpwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textnewpwd1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.moditypwd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textoldpwd
            // 
            this.textoldpwd.Location = new System.Drawing.Point(206, 57);
            this.textoldpwd.Name = "textoldpwd";
            this.textoldpwd.Size = new System.Drawing.Size(202, 21);
            this.textoldpwd.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "旧密码";
            // 
            // textnewpwd
            // 
            this.textnewpwd.Location = new System.Drawing.Point(206, 113);
            this.textnewpwd.Name = "textnewpwd";
            this.textnewpwd.Size = new System.Drawing.Size(202, 21);
            this.textnewpwd.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "新密码";
            // 
            // textnewpwd1
            // 
            this.textnewpwd1.Location = new System.Drawing.Point(206, 172);
            this.textnewpwd1.Name = "textnewpwd1";
            this.textnewpwd1.Size = new System.Drawing.Size(202, 21);
            this.textnewpwd1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "再次输入新密码";
            // 
            // moditypwd
            // 
            this.moditypwd.Location = new System.Drawing.Point(332, 252);
            this.moditypwd.Name = "moditypwd";
            this.moditypwd.Size = new System.Drawing.Size(75, 23);
            this.moditypwd.TabIndex = 2;
            this.moditypwd.Text = "修改密码";
            this.moditypwd.UseVisualStyleBackColor = true;
            this.moditypwd.Click += new System.EventHandler(this.moditypwd_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 308);
            this.Controls.Add(this.moditypwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textnewpwd1);
            this.Controls.Add(this.textnewpwd);
            this.Controls.Add(this.textoldpwd);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textoldpwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textnewpwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textnewpwd1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button moditypwd;
    }
}