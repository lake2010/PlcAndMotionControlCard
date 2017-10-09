namespace WinFormsApp6480
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
            this.components = new System.ComponentModel.Container();
            this.LinkEth = new System.Windows.Forms.Button();
            this.PMovePlus = new System.Windows.Forms.Button();
            this.PMoveReverse = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.POSX = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LinkCom = new System.Windows.Forms.Button();
            this.CloseConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LinkEth
            // 
            this.LinkEth.Location = new System.Drawing.Point(16, 14);
            this.LinkEth.Name = "LinkEth";
            this.LinkEth.Size = new System.Drawing.Size(71, 38);
            this.LinkEth.TabIndex = 0;
            this.LinkEth.Text = "连接网络";
            this.LinkEth.UseVisualStyleBackColor = true;
            this.LinkEth.Click += new System.EventHandler(this.OnLink);
            // 
            // PMovePlus
            // 
            this.PMovePlus.Location = new System.Drawing.Point(187, 12);
            this.PMovePlus.Name = "PMovePlus";
            this.PMovePlus.Size = new System.Drawing.Size(60, 38);
            this.PMovePlus.TabIndex = 1;
            this.PMovePlus.Text = "PMove+";
            this.PMovePlus.UseVisualStyleBackColor = true;
            this.PMovePlus.Click += new System.EventHandler(this.PMove_Click);
            // 
            // PMoveReverse
            // 
            this.PMoveReverse.Location = new System.Drawing.Point(187, 70);
            this.PMoveReverse.Name = "PMoveReverse";
            this.PMoveReverse.Size = new System.Drawing.Size(60, 38);
            this.PMoveReverse.TabIndex = 1;
            this.PMoveReverse.Text = "PMove-";
            this.PMoveReverse.UseVisualStyleBackColor = true;
            this.PMoveReverse.Click += new System.EventHandler(this.PMove_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(187, 130);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(60, 38);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "停止";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.OnTick);
            // 
            // POSX
            // 
            this.POSX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.POSX.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.POSX.Location = new System.Drawing.Point(115, 201);
            this.POSX.Name = "POSX";
            this.POSX.Size = new System.Drawing.Size(64, 23);
            this.POSX.TabIndex = 3;
            this.POSX.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "X轴当前脉冲位置";
            // 
            // LinkCom
            // 
            this.LinkCom.Location = new System.Drawing.Point(16, 64);
            this.LinkCom.Name = "LinkCom";
            this.LinkCom.Size = new System.Drawing.Size(71, 38);
            this.LinkCom.TabIndex = 0;
            this.LinkCom.Text = "连接串口";
            this.LinkCom.UseVisualStyleBackColor = true;
            this.LinkCom.Click += new System.EventHandler(this.OnLink);
            // 
            // CloseConnect
            // 
            this.CloseConnect.Location = new System.Drawing.Point(16, 121);
            this.CloseConnect.Name = "CloseConnect";
            this.CloseConnect.Size = new System.Drawing.Size(71, 38);
            this.CloseConnect.TabIndex = 5;
            this.CloseConnect.Text = "关闭连接";
            this.CloseConnect.UseVisualStyleBackColor = true;
            this.CloseConnect.Click += new System.EventHandler(this.CloseConnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 266);
            this.Controls.Add(this.CloseConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.POSX);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.PMoveReverse);
            this.Controls.Add(this.PMovePlus);
            this.Controls.Add(this.LinkCom);
            this.Controls.Add(this.LinkEth);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LinkEth;
        private System.Windows.Forms.Button PMovePlus;
        private System.Windows.Forms.Button PMoveReverse;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label POSX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LinkCom;
        private System.Windows.Forms.Button CloseConnect;
    }
}

