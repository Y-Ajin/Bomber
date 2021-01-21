using System.Windows.Forms;

namespace Bomber
{


    partial class Main
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Phone = new System.Windows.Forms.Label();
            this.PhoneValue = new System.Windows.Forms.TextBox();
            this.TimesValue = new System.Windows.Forms.TextBox();
            this.Times = new System.Windows.Forms.Label();
            this.DelayValue = new System.Windows.Forms.TextBox();
            this.Delay = new System.Windows.Forms.Label();
            this.Data = new System.Windows.Forms.Panel();
            this.Stop = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.Proxy = new System.Windows.Forms.Label();
            this.ProxyValue = new System.Windows.Forms.RichTextBox();
            this.Output = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Bullets = new System.Windows.Forms.CheckedListBox();
            this.AllSelect = new System.Windows.Forms.Button();
            this.ReverseSelect = new System.Windows.Forms.Button();
            this.TestProxy = new System.Windows.Forms.Button();
            this.ProxyEnabled = new System.Windows.Forms.CheckBox();
            this.RefreshBullets = new System.Windows.Forms.Button();
            this.Data.SuspendLayout();
            this.SuspendLayout();
            // 
            // Phone
            // 
            this.Phone.AutoSize = true;
            this.Phone.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Phone.Location = new System.Drawing.Point(12, 16);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(69, 20);
            this.Phone.TabIndex = 0;
            this.Phone.Text = "手机号码";
            // 
            // PhoneValue
            // 
            this.PhoneValue.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PhoneValue.Location = new System.Drawing.Point(87, 9);
            this.PhoneValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PhoneValue.Name = "PhoneValue";
            this.PhoneValue.Size = new System.Drawing.Size(121, 27);
            this.PhoneValue.TabIndex = 1;
            // 
            // TimesValue
            // 
            this.TimesValue.Location = new System.Drawing.Point(87, 42);
            this.TimesValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TimesValue.Name = "TimesValue";
            this.TimesValue.Size = new System.Drawing.Size(121, 25);
            this.TimesValue.TabIndex = 3;
            this.TimesValue.Text = "3";
            // 
            // Times
            // 
            this.Times.AutoSize = true;
            this.Times.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Times.Location = new System.Drawing.Point(12, 48);
            this.Times.Name = "Times";
            this.Times.Size = new System.Drawing.Size(69, 20);
            this.Times.TabIndex = 2;
            this.Times.Text = "循环次数";
            // 
            // DelayValue
            // 
            this.DelayValue.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DelayValue.Location = new System.Drawing.Point(87, 76);
            this.DelayValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DelayValue.Name = "DelayValue";
            this.DelayValue.Size = new System.Drawing.Size(121, 27);
            this.DelayValue.TabIndex = 5;
            this.DelayValue.Text = "0";
            // 
            // Delay
            // 
            this.Delay.AutoSize = true;
            this.Delay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Delay.Location = new System.Drawing.Point(12, 81);
            this.Delay.Name = "Delay";
            this.Delay.Size = new System.Drawing.Size(69, 20);
            this.Delay.TabIndex = 4;
            this.Delay.Text = "延迟时间";
            // 
            // Data
            // 
            this.Data.Controls.Add(this.Stop);
            this.Data.Controls.Add(this.Start);
            this.Data.Controls.Add(this.Phone);
            this.Data.Controls.Add(this.DelayValue);
            this.Data.Controls.Add(this.PhoneValue);
            this.Data.Controls.Add(this.Delay);
            this.Data.Controls.Add(this.Times);
            this.Data.Controls.Add(this.TimesValue);
            this.Data.Location = new System.Drawing.Point(12, 12);
            this.Data.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(241, 148);
            this.Data.TabIndex = 6;
            // 
            // Stop
            // 
            this.Stop.BackColor = System.Drawing.Color.DarkRed;
            this.Stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Stop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Stop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.Stop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Stop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Stop.Location = new System.Drawing.Point(157, 109);
            this.Stop.Margin = new System.Windows.Forms.Padding(4);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(67, 29);
            this.Stop.TabIndex = 7;
            this.Stop.Text = "停止";
            this.Stop.UseVisualStyleBackColor = false;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.SystemColors.Highlight;
            this.Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.Start.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Start.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Start.Location = new System.Drawing.Point(85, 109);
            this.Start.Margin = new System.Windows.Forms.Padding(4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(67, 29);
            this.Start.TabIndex = 6;
            this.Start.Text = "开始";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Proxy
            // 
            this.Proxy.AutoSize = true;
            this.Proxy.BackColor = System.Drawing.Color.DarkCyan;
            this.Proxy.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Proxy.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Proxy.Location = new System.Drawing.Point(95, 174);
            this.Proxy.Name = "Proxy";
            this.Proxy.Size = new System.Drawing.Size(69, 20);
            this.Proxy.TabIndex = 8;
            this.Proxy.Text = "代理服务";
            // 
            // ProxyValue
            // 
            this.ProxyValue.Location = new System.Drawing.Point(12, 199);
            this.ProxyValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProxyValue.Name = "ProxyValue";
            this.ProxyValue.Size = new System.Drawing.Size(240, 205);
            this.ProxyValue.TabIndex = 9;
            this.ProxyValue.Text = "";
            // 
            // Output
            // 
            this.Output.BackColor = System.Drawing.Color.DarkCyan;
            this.Output.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Output.ForeColor = System.Drawing.Color.LightGreen;
            this.Output.Location = new System.Drawing.Point(260, 14);
            this.Output.Margin = new System.Windows.Forms.Padding(4);
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(386, 389);
            this.Output.TabIndex = 10;
            this.Output.Text = "";
            // 
            // Bullets
            // 
            this.Bullets.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Bullets.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bullets.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Bullets.FormattingEnabled = true;
            this.Bullets.Location = new System.Drawing.Point(653, 13);
            this.Bullets.Name = "Bullets";
            this.Bullets.Size = new System.Drawing.Size(135, 312);
            this.Bullets.TabIndex = 11;
            // 
            // AllSelect
            // 
            this.AllSelect.BackColor = System.Drawing.Color.SandyBrown;
            this.AllSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AllSelect.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.AllSelect.Location = new System.Drawing.Point(653, 341);
            this.AllSelect.Name = "AllSelect";
            this.AllSelect.Size = new System.Drawing.Size(58, 28);
            this.AllSelect.TabIndex = 12;
            this.AllSelect.Text = "全选";
            this.AllSelect.UseVisualStyleBackColor = false;
            this.AllSelect.Click += new System.EventHandler(this.AllSelect_Click);
            // 
            // ReverseSelect
            // 
            this.ReverseSelect.BackColor = System.Drawing.Color.SandyBrown;
            this.ReverseSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReverseSelect.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ReverseSelect.Location = new System.Drawing.Point(653, 375);
            this.ReverseSelect.Name = "ReverseSelect";
            this.ReverseSelect.Size = new System.Drawing.Size(58, 28);
            this.ReverseSelect.TabIndex = 13;
            this.ReverseSelect.Text = "反选";
            this.ReverseSelect.UseVisualStyleBackColor = false;
            this.ReverseSelect.Click += new System.EventHandler(this.ReverseSelect_Click);
            // 
            // TestProxy
            // 
            this.TestProxy.BackColor = System.Drawing.SystemColors.GrayText;
            this.TestProxy.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestProxy.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TestProxy.Location = new System.Drawing.Point(12, 165);
            this.TestProxy.Name = "TestProxy";
            this.TestProxy.Size = new System.Drawing.Size(61, 29);
            this.TestProxy.TabIndex = 14;
            this.TestProxy.Text = "测试";
            this.TestProxy.UseVisualStyleBackColor = false;
            this.TestProxy.Click += new System.EventHandler(this.TestProxy_Click);
            // 
            // ProxyEnabled
            // 
            this.ProxyEnabled.AutoSize = true;
            this.ProxyEnabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProxyEnabled.Location = new System.Drawing.Point(192, 380);
            this.ProxyEnabled.Name = "ProxyEnabled";
            this.ProxyEnabled.Size = new System.Drawing.Size(61, 24);
            this.ProxyEnabled.TabIndex = 15;
            this.ProxyEnabled.Text = "使用";
            this.ProxyEnabled.UseVisualStyleBackColor = true;
            // 
            // RefreshBullets
            // 
            this.RefreshBullets.BackColor = System.Drawing.Color.SandyBrown;
            this.RefreshBullets.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RefreshBullets.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.RefreshBullets.Location = new System.Drawing.Point(717, 341);
            this.RefreshBullets.Name = "RefreshBullets";
            this.RefreshBullets.Size = new System.Drawing.Size(58, 28);
            this.RefreshBullets.TabIndex = 16;
            this.RefreshBullets.Text = "刷新";
            this.RefreshBullets.UseVisualStyleBackColor = false;
            this.RefreshBullets.Click += new System.EventHandler(this.RefreshBullets_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 419);
            this.Controls.Add(this.RefreshBullets);
            this.Controls.Add(this.ProxyEnabled);
            this.Controls.Add(this.TestProxy);
            this.Controls.Add(this.ReverseSelect);
            this.Controls.Add(this.AllSelect);
            this.Controls.Add(this.Bullets);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.ProxyValue);
            this.Controls.Add(this.Proxy);
            this.Controls.Add(this.Data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Bomber.Properties.Resources.Icon;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "小小轰炸姬 v 1.0";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Data.ResumeLayout(false);
            this.Data.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Phone;
        private TextBox PhoneValue;
        private TextBox TimesValue;
        private Label Times;
        private TextBox DelayValue;
        private Label Delay;
        private Panel Data;
        private Label Proxy;
        private RichTextBox ProxyValue;
        private RichTextBox Output;
        private Button Start;
        private ToolTip toolTip1;
        private CheckedListBox Bullets;
        private Button AllSelect;
        private Button ReverseSelect;
        private Button Stop;
        private Button TestProxy;
        private CheckBox ProxyEnabled;
        private Button RefreshBullets;
    }
}

