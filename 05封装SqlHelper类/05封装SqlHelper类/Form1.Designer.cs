namespace _05封装SqlHelper类
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textusername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textuserpwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.M_Singin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textusername
            // 
            this.textusername.Location = new System.Drawing.Point(109, 50);
            this.textusername.Name = "textusername";
            this.textusername.Size = new System.Drawing.Size(100, 21);
            this.textusername.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名";
            // 
            // textuserpwd
            // 
            this.textuserpwd.Location = new System.Drawing.Point(109, 119);
            this.textuserpwd.Name = "textuserpwd";
            this.textuserpwd.Size = new System.Drawing.Size(100, 21);
            this.textuserpwd.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // M_Singin
            // 
            this.M_Singin.Location = new System.Drawing.Point(134, 197);
            this.M_Singin.Name = "M_Singin";
            this.M_Singin.Size = new System.Drawing.Size(75, 23);
            this.M_Singin.TabIndex = 2;
            this.M_Singin.Text = "登录";
            this.M_Singin.UseVisualStyleBackColor = true;
            this.M_Singin.Click += new System.EventHandler(this.M_Singin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 275);
            this.Controls.Add(this.M_Singin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textuserpwd);
            this.Controls.Add(this.textusername);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textusername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textuserpwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button M_Singin;
    }
}

