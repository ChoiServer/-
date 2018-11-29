namespace servermonitoring
{
    partial class TotalsubControl2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pingIMG = new DevExpress.XtraEditors.PictureEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mysqlIMG = new DevExpress.XtraEditors.PictureEdit();
            this.mssqlIMG = new DevExpress.XtraEditors.PictureEdit();
            this.mailIMG = new DevExpress.XtraEditors.PictureEdit();
            this.greenColor = new DevExpress.XtraEditors.PictureEdit();
            this.redColor = new DevExpress.XtraEditors.PictureEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pingIMG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mysqlIMG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssqlIMG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mailIMG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redColor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::DXWindowsApplication2.Properties.Resources.ppt1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pingIMG);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.mysqlIMG);
            this.panel1.Controls.Add(this.mssqlIMG);
            this.panel1.Controls.Add(this.mailIMG);
            this.panel1.Controls.Add(this.greenColor);
            this.panel1.Controls.Add(this.redColor);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 200);
            this.panel1.TabIndex = 0;
            // 
            // pingIMG
            // 
            this.pingIMG.EditValue = global::DXWindowsApplication2.Properties.Resources.ping;
            this.pingIMG.Location = new System.Drawing.Point(6, 82);
            this.pingIMG.Name = "pingIMG";
            this.pingIMG.Properties.AllowFocused = false;
            this.pingIMG.Properties.AllowScrollViaMouseDrag = false;
            this.pingIMG.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pingIMG.Properties.Appearance.Options.UseBackColor = true;
            this.pingIMG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pingIMG.Properties.ReadOnly = true;
            this.pingIMG.Properties.ShowMenu = false;
            this.pingIMG.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pingIMG.Size = new System.Drawing.Size(133, 98);
            this.pingIMG.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("새굴림", 13F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(181, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 18);
            this.label4.TabIndex = 32;
            this.label4.Text = "time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("새굴림", 13F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(181, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 27;
            this.label3.Text = "status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("새굴림", 13F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(277, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 26;
            this.label1.Text = "상 태";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("새굴림", 18F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(5, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 24);
            this.label5.TabIndex = 25;
            this.label5.Text = "IP?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("새굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 27);
            this.label2.TabIndex = 22;
            this.label2.Text = "SERVER";
            // 
            // mysqlIMG
            // 
            this.mysqlIMG.EditValue = global::DXWindowsApplication2.Properties.Resources.MySQL;
            this.mysqlIMG.Location = new System.Drawing.Point(6, 82);
            this.mysqlIMG.Name = "mysqlIMG";
            this.mysqlIMG.Properties.AllowFocused = false;
            this.mysqlIMG.Properties.AllowScrollViaMouseDrag = false;
            this.mysqlIMG.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.mysqlIMG.Properties.Appearance.Options.UseBackColor = true;
            this.mysqlIMG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.mysqlIMG.Properties.ReadOnly = true;
            this.mysqlIMG.Properties.ShowMenu = false;
            this.mysqlIMG.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.mysqlIMG.Size = new System.Drawing.Size(133, 98);
            this.mysqlIMG.TabIndex = 31;
            // 
            // mssqlIMG
            // 
            this.mssqlIMG.EditValue = global::DXWindowsApplication2.Properties.Resources.MsSQL;
            this.mssqlIMG.Location = new System.Drawing.Point(6, 82);
            this.mssqlIMG.Name = "mssqlIMG";
            this.mssqlIMG.Properties.AllowFocused = false;
            this.mssqlIMG.Properties.AllowScrollViaMouseDrag = false;
            this.mssqlIMG.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.mssqlIMG.Properties.Appearance.Options.UseBackColor = true;
            this.mssqlIMG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.mssqlIMG.Properties.ReadOnly = true;
            this.mssqlIMG.Properties.ShowMenu = false;
            this.mssqlIMG.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.mssqlIMG.Size = new System.Drawing.Size(133, 98);
            this.mssqlIMG.TabIndex = 30;
            // 
            // mailIMG
            // 
            this.mailIMG.EditValue = global::DXWindowsApplication2.Properties.Resources.mail;
            this.mailIMG.Location = new System.Drawing.Point(6, 82);
            this.mailIMG.Name = "mailIMG";
            this.mailIMG.Properties.AllowFocused = false;
            this.mailIMG.Properties.AllowScrollViaMouseDrag = false;
            this.mailIMG.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.mailIMG.Properties.Appearance.Options.UseBackColor = true;
            this.mailIMG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.mailIMG.Properties.ReadOnly = true;
            this.mailIMG.Properties.ShowMenu = false;
            this.mailIMG.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.mailIMG.Size = new System.Drawing.Size(133, 98);
            this.mailIMG.TabIndex = 29;
            // 
            // greenColor
            // 
            this.greenColor.EditValue = global::DXWindowsApplication2.Properties.Resources.GREEN1;
            this.greenColor.Location = new System.Drawing.Point(278, 85);
            this.greenColor.Name = "greenColor";
            this.greenColor.Properties.AllowFocused = false;
            this.greenColor.Properties.AllowScrollViaMouseDrag = false;
            this.greenColor.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.greenColor.Properties.Appearance.Options.UseBackColor = true;
            this.greenColor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.greenColor.Properties.ReadOnly = true;
            this.greenColor.Properties.ShowMenu = false;
            this.greenColor.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.greenColor.Size = new System.Drawing.Size(50, 50);
            this.greenColor.TabIndex = 35;
            // 
            // redColor
            // 
            this.redColor.EditValue = global::DXWindowsApplication2.Properties.Resources.RED1;
            this.redColor.Location = new System.Drawing.Point(278, 85);
            this.redColor.Name = "redColor";
            this.redColor.Properties.AllowFocused = false;
            this.redColor.Properties.AllowScrollViaMouseDrag = false;
            this.redColor.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.redColor.Properties.Appearance.Options.UseBackColor = true;
            this.redColor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.redColor.Properties.ReadOnly = true;
            this.redColor.Properties.ShowMenu = false;
            this.redColor.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.redColor.Size = new System.Drawing.Size(50, 50);
            this.redColor.TabIndex = 34;
            // 
            // TotalsubControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "TotalsubControl2";
            this.Size = new System.Drawing.Size(476, 206);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pingIMG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mysqlIMG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mssqlIMG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mailIMG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redColor.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.PictureEdit mysqlIMG;
        private DevExpress.XtraEditors.PictureEdit mssqlIMG;
        private DevExpress.XtraEditors.PictureEdit mailIMG;
        private DevExpress.XtraEditors.PictureEdit pingIMG;
        private DevExpress.XtraEditors.PictureEdit greenColor;
        private DevExpress.XtraEditors.PictureEdit redColor;
    }
}
