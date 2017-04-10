namespace _04登陆验证
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
            this.textloginid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textloginPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.M_SIgnin = new System.Windows.Forms.Button();
            this.M_Signin1 = new System.Windows.Forms.Button();
            this.modity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textloginid
            // 
            this.textloginid.Location = new System.Drawing.Point(144, 50);
            this.textloginid.Name = "textloginid";
            this.textloginid.Size = new System.Drawing.Size(140, 21);
            this.textloginid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名";
            // 
            // textloginPwd
            // 
            this.textloginPwd.Location = new System.Drawing.Point(144, 101);
            this.textloginPwd.Name = "textloginPwd";
            this.textloginPwd.Size = new System.Drawing.Size(140, 21);
            this.textloginPwd.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // M_SIgnin
            // 
            this.M_SIgnin.Location = new System.Drawing.Point(86, 169);
            this.M_SIgnin.Name = "M_SIgnin";
            this.M_SIgnin.Size = new System.Drawing.Size(100, 23);
            this.M_SIgnin.TabIndex = 2;
            this.M_SIgnin.Text = "登录";
            this.M_SIgnin.UseVisualStyleBackColor = true;
            this.M_SIgnin.Click += new System.EventHandler(this.M_SIgnin_Click);
            // 
            // M_Signin1
            // 
            this.M_Signin1.Location = new System.Drawing.Point(209, 169);
            this.M_Signin1.Name = "M_Signin1";
            this.M_Signin1.Size = new System.Drawing.Size(75, 23);
            this.M_Signin1.TabIndex = 3;
            this.M_Signin1.Text = "登录账号";
            this.M_Signin1.UseVisualStyleBackColor = true;
            this.M_Signin1.Click += new System.EventHandler(this.M_Signin1_Click);
            // 
            // modity
            // 
            this.modity.Enabled = false;
            this.modity.Location = new System.Drawing.Point(209, 208);
            this.modity.Name = "modity";
            this.modity.Size = new System.Drawing.Size(75, 23);
            this.modity.TabIndex = 4;
            this.modity.Text = "修改密码";
            this.modity.UseVisualStyleBackColor = true;
            this.modity.Click += new System.EventHandler(this.modity_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 268);
            this.Controls.Add(this.modity);
            this.Controls.Add(this.M_Signin1);
            this.Controls.Add(this.M_SIgnin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textloginPwd);
            this.Controls.Add(this.textloginid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textloginid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textloginPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button M_SIgnin;
        private System.Windows.Forms.Button M_Signin1;
        private System.Windows.Forms.Button modity;
    }
}

