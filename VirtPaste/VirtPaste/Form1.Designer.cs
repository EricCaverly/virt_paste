namespace VirtPaste {
    partial class Form1 {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.UI_GB_Compat = new System.Windows.Forms.GroupBox();
            this.UI_LBL_Delay = new System.Windows.Forms.Label();
            this.UI_LBL_DelayMax = new System.Windows.Forms.Label();
            this.UI_LBL_DelayMin = new System.Windows.Forms.Label();
            this.UI_TRB_Delay = new System.Windows.Forms.TrackBar();
            this.UI_CB_SendBackspaces = new System.Windows.Forms.CheckBox();
            this.UI_CB_RemoveCapslock = new System.Windows.Forms.CheckBox();
            this.UI_CB_RemoveReturn = new System.Windows.Forms.CheckBox();
            this.UI_PB_Progress = new System.Windows.Forms.ProgressBar();
            this.UI_BTN_Stop = new System.Windows.Forms.Button();
            this.UI_BTN_Hide = new System.Windows.Forms.Button();
            this.UI_CB_Active = new System.Windows.Forms.CheckBox();
            this.UI_GB_Hotkey = new System.Windows.Forms.GroupBox();
            this.UI_TB_Hotkey = new System.Windows.Forms.TextBox();
            this.UI_CB_MOD_Win = new System.Windows.Forms.CheckBox();
            this.UI_CB_MOD_Shift = new System.Windows.Forms.CheckBox();
            this.UI_CB_MOD_Alt = new System.Windows.Forms.CheckBox();
            this.UI_CB_MOD_Ctrl = new System.Windows.Forms.CheckBox();
            this.UI_CB_SlowType = new System.Windows.Forms.CheckBox();
            this.UI_NI_SysTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.UI_CMS_NI_SysTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UI_CMSBTN_ShowSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.UI_CMSBTN_Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.UI_GB_Compat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_TRB_Delay)).BeginInit();
            this.UI_GB_Hotkey.SuspendLayout();
            this.UI_CMS_NI_SysTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_GB_Compat
            // 
            this.UI_GB_Compat.Controls.Add(this.UI_CB_SlowType);
            this.UI_GB_Compat.Controls.Add(this.UI_LBL_Delay);
            this.UI_GB_Compat.Controls.Add(this.UI_LBL_DelayMax);
            this.UI_GB_Compat.Controls.Add(this.UI_LBL_DelayMin);
            this.UI_GB_Compat.Controls.Add(this.UI_TRB_Delay);
            this.UI_GB_Compat.Controls.Add(this.UI_CB_SendBackspaces);
            this.UI_GB_Compat.Controls.Add(this.UI_CB_RemoveCapslock);
            this.UI_GB_Compat.Controls.Add(this.UI_CB_RemoveReturn);
            this.UI_GB_Compat.Location = new System.Drawing.Point(12, 67);
            this.UI_GB_Compat.Name = "UI_GB_Compat";
            this.UI_GB_Compat.Size = new System.Drawing.Size(347, 97);
            this.UI_GB_Compat.TabIndex = 0;
            this.UI_GB_Compat.TabStop = false;
            this.UI_GB_Compat.Text = "Compatibility Options";
            // 
            // UI_LBL_Delay
            // 
            this.UI_LBL_Delay.Location = new System.Drawing.Point(114, 74);
            this.UI_LBL_Delay.Name = "UI_LBL_Delay";
            this.UI_LBL_Delay.Size = new System.Drawing.Size(189, 13);
            this.UI_LBL_Delay.TabIndex = 6;
            this.UI_LBL_Delay.Text = "Delay";
            this.UI_LBL_Delay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_LBL_DelayMax
            // 
            this.UI_LBL_DelayMax.AutoSize = true;
            this.UI_LBL_DelayMax.Location = new System.Drawing.Point(309, 74);
            this.UI_LBL_DelayMax.Name = "UI_LBL_DelayMax";
            this.UI_LBL_DelayMax.Size = new System.Drawing.Size(38, 13);
            this.UI_LBL_DelayMax.TabIndex = 5;
            this.UI_LBL_DelayMax.Text = "200ms";
            // 
            // UI_LBL_DelayMin
            // 
            this.UI_LBL_DelayMin.AutoSize = true;
            this.UI_LBL_DelayMin.Location = new System.Drawing.Point(86, 74);
            this.UI_LBL_DelayMin.Name = "UI_LBL_DelayMin";
            this.UI_LBL_DelayMin.Size = new System.Drawing.Size(32, 13);
            this.UI_LBL_DelayMin.TabIndex = 4;
            this.UI_LBL_DelayMin.Text = "30ms";
            // 
            // UI_TRB_Delay
            // 
            this.UI_TRB_Delay.LargeChange = 10;
            this.UI_TRB_Delay.Location = new System.Drawing.Point(89, 42);
            this.UI_TRB_Delay.Maximum = 200;
            this.UI_TRB_Delay.Minimum = 30;
            this.UI_TRB_Delay.Name = "UI_TRB_Delay";
            this.UI_TRB_Delay.Size = new System.Drawing.Size(252, 45);
            this.UI_TRB_Delay.SmallChange = 5;
            this.UI_TRB_Delay.TabIndex = 3;
            this.UI_TRB_Delay.TickFrequency = 10;
            this.UI_TRB_Delay.Value = 30;
            // 
            // UI_CB_SendBackspaces
            // 
            this.UI_CB_SendBackspaces.AutoSize = true;
            this.UI_CB_SendBackspaces.Location = new System.Drawing.Point(208, 19);
            this.UI_CB_SendBackspaces.Name = "UI_CB_SendBackspaces";
            this.UI_CB_SendBackspaces.Size = new System.Drawing.Size(113, 17);
            this.UI_CB_SendBackspaces.TabIndex = 2;
            this.UI_CB_SendBackspaces.Text = "Send Backspaces";
            this.UI_CB_SendBackspaces.UseVisualStyleBackColor = true;
            // 
            // UI_CB_RemoveCapslock
            // 
            this.UI_CB_RemoveCapslock.AutoSize = true;
            this.UI_CB_RemoveCapslock.Location = new System.Drawing.Point(89, 19);
            this.UI_CB_RemoveCapslock.Name = "UI_CB_RemoveCapslock";
            this.UI_CB_RemoveCapslock.Size = new System.Drawing.Size(113, 17);
            this.UI_CB_RemoveCapslock.TabIndex = 1;
            this.UI_CB_RemoveCapslock.Text = "Override Capslock";
            this.UI_CB_RemoveCapslock.UseVisualStyleBackColor = true;
            // 
            // UI_CB_RemoveReturn
            // 
            this.UI_CB_RemoveReturn.AutoSize = true;
            this.UI_CB_RemoveReturn.Location = new System.Drawing.Point(6, 19);
            this.UI_CB_RemoveReturn.Name = "UI_CB_RemoveReturn";
            this.UI_CB_RemoveReturn.Size = new System.Drawing.Size(77, 17);
            this.UI_CB_RemoveReturn.TabIndex = 0;
            this.UI_CB_RemoveReturn.Text = "Remove \\r";
            this.UI_CB_RemoveReturn.UseVisualStyleBackColor = true;
            // 
            // UI_PB_Progress
            // 
            this.UI_PB_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_PB_Progress.Location = new System.Drawing.Point(12, 181);
            this.UI_PB_Progress.Name = "UI_PB_Progress";
            this.UI_PB_Progress.Size = new System.Drawing.Size(347, 23);
            this.UI_PB_Progress.TabIndex = 1;
            // 
            // UI_BTN_Stop
            // 
            this.UI_BTN_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_BTN_Stop.Enabled = false;
            this.UI_BTN_Stop.Location = new System.Drawing.Point(203, 210);
            this.UI_BTN_Stop.Name = "UI_BTN_Stop";
            this.UI_BTN_Stop.Size = new System.Drawing.Size(75, 23);
            this.UI_BTN_Stop.TabIndex = 2;
            this.UI_BTN_Stop.Text = "Stop";
            this.UI_BTN_Stop.UseVisualStyleBackColor = true;
            // 
            // UI_BTN_Hide
            // 
            this.UI_BTN_Hide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_BTN_Hide.Location = new System.Drawing.Point(284, 210);
            this.UI_BTN_Hide.Name = "UI_BTN_Hide";
            this.UI_BTN_Hide.Size = new System.Drawing.Size(75, 23);
            this.UI_BTN_Hide.TabIndex = 3;
            this.UI_BTN_Hide.Text = "Hide";
            this.UI_BTN_Hide.UseVisualStyleBackColor = true;
            // 
            // UI_CB_Active
            // 
            this.UI_CB_Active.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UI_CB_Active.AutoSize = true;
            this.UI_CB_Active.Location = new System.Drawing.Point(12, 214);
            this.UI_CB_Active.Name = "UI_CB_Active";
            this.UI_CB_Active.Size = new System.Drawing.Size(56, 17);
            this.UI_CB_Active.TabIndex = 4;
            this.UI_CB_Active.Text = "Active";
            this.UI_CB_Active.UseVisualStyleBackColor = true;
            // 
            // UI_GB_Hotkey
            // 
            this.UI_GB_Hotkey.Controls.Add(this.UI_TB_Hotkey);
            this.UI_GB_Hotkey.Controls.Add(this.UI_CB_MOD_Win);
            this.UI_GB_Hotkey.Controls.Add(this.UI_CB_MOD_Shift);
            this.UI_GB_Hotkey.Controls.Add(this.UI_CB_MOD_Alt);
            this.UI_GB_Hotkey.Controls.Add(this.UI_CB_MOD_Ctrl);
            this.UI_GB_Hotkey.Location = new System.Drawing.Point(12, 12);
            this.UI_GB_Hotkey.Name = "UI_GB_Hotkey";
            this.UI_GB_Hotkey.Size = new System.Drawing.Size(347, 49);
            this.UI_GB_Hotkey.TabIndex = 5;
            this.UI_GB_Hotkey.TabStop = false;
            this.UI_GB_Hotkey.Text = "Hotkey";
            // 
            // UI_TB_Hotkey
            // 
            this.UI_TB_Hotkey.Location = new System.Drawing.Point(238, 17);
            this.UI_TB_Hotkey.MaxLength = 1;
            this.UI_TB_Hotkey.Name = "UI_TB_Hotkey";
            this.UI_TB_Hotkey.Size = new System.Drawing.Size(28, 20);
            this.UI_TB_Hotkey.TabIndex = 4;
            // 
            // UI_CB_MOD_Win
            // 
            this.UI_CB_MOD_Win.AutoSize = true;
            this.UI_CB_MOD_Win.Location = new System.Drawing.Point(184, 19);
            this.UI_CB_MOD_Win.Name = "UI_CB_MOD_Win";
            this.UI_CB_MOD_Win.Size = new System.Drawing.Size(48, 17);
            this.UI_CB_MOD_Win.TabIndex = 3;
            this.UI_CB_MOD_Win.Text = "WIN";
            this.UI_CB_MOD_Win.UseVisualStyleBackColor = true;
            // 
            // UI_CB_MOD_Shift
            // 
            this.UI_CB_MOD_Shift.AutoSize = true;
            this.UI_CB_MOD_Shift.Location = new System.Drawing.Point(121, 19);
            this.UI_CB_MOD_Shift.Name = "UI_CB_MOD_Shift";
            this.UI_CB_MOD_Shift.Size = new System.Drawing.Size(57, 17);
            this.UI_CB_MOD_Shift.TabIndex = 2;
            this.UI_CB_MOD_Shift.Text = "SHIFT";
            this.UI_CB_MOD_Shift.UseVisualStyleBackColor = true;
            // 
            // UI_CB_MOD_Alt
            // 
            this.UI_CB_MOD_Alt.AutoSize = true;
            this.UI_CB_MOD_Alt.Location = new System.Drawing.Point(69, 19);
            this.UI_CB_MOD_Alt.Name = "UI_CB_MOD_Alt";
            this.UI_CB_MOD_Alt.Size = new System.Drawing.Size(46, 17);
            this.UI_CB_MOD_Alt.TabIndex = 1;
            this.UI_CB_MOD_Alt.Text = "ALT";
            this.UI_CB_MOD_Alt.UseVisualStyleBackColor = true;
            // 
            // UI_CB_MOD_Ctrl
            // 
            this.UI_CB_MOD_Ctrl.AutoSize = true;
            this.UI_CB_MOD_Ctrl.Location = new System.Drawing.Point(9, 19);
            this.UI_CB_MOD_Ctrl.Name = "UI_CB_MOD_Ctrl";
            this.UI_CB_MOD_Ctrl.Size = new System.Drawing.Size(54, 17);
            this.UI_CB_MOD_Ctrl.TabIndex = 0;
            this.UI_CB_MOD_Ctrl.Text = "CTRL";
            this.UI_CB_MOD_Ctrl.UseVisualStyleBackColor = true;
            // 
            // UI_CB_SlowType
            // 
            this.UI_CB_SlowType.AutoSize = true;
            this.UI_CB_SlowType.Location = new System.Drawing.Point(6, 43);
            this.UI_CB_SlowType.Name = "UI_CB_SlowType";
            this.UI_CB_SlowType.Size = new System.Drawing.Size(84, 17);
            this.UI_CB_SlowType.TabIndex = 7;
            this.UI_CB_SlowType.Text = "Slow Typing";
            this.UI_CB_SlowType.UseVisualStyleBackColor = true;
            // 
            // UI_NI_SysTray
            // 
            this.UI_NI_SysTray.ContextMenuStrip = this.UI_CMS_NI_SysTray;
            this.UI_NI_SysTray.Icon = ((System.Drawing.Icon)(resources.GetObject("UI_NI_SysTray.Icon")));
            this.UI_NI_SysTray.Text = "VirtPaste";
            this.UI_NI_SysTray.Visible = true;
            // 
            // UI_CMS_NI_SysTray
            // 
            this.UI_CMS_NI_SysTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UI_CMSBTN_ShowSettings,
            this.UI_CMSBTN_Quit});
            this.UI_CMS_NI_SysTray.Name = "UI_CMS_NI_SysTray";
            this.UI_CMS_NI_SysTray.Size = new System.Drawing.Size(181, 70);
            // 
            // UI_CMSBTN_ShowSettings
            // 
            this.UI_CMSBTN_ShowSettings.Name = "UI_CMSBTN_ShowSettings";
            this.UI_CMSBTN_ShowSettings.Size = new System.Drawing.Size(180, 22);
            this.UI_CMSBTN_ShowSettings.Text = "Show Settings";
            // 
            // UI_CMSBTN_Quit
            // 
            this.UI_CMSBTN_Quit.Name = "UI_CMSBTN_Quit";
            this.UI_CMSBTN_Quit.Size = new System.Drawing.Size(180, 22);
            this.UI_CMSBTN_Quit.Text = "Quit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(371, 245);
            this.Controls.Add(this.UI_GB_Hotkey);
            this.Controls.Add(this.UI_CB_Active);
            this.Controls.Add(this.UI_BTN_Hide);
            this.Controls.Add(this.UI_BTN_Stop);
            this.Controls.Add(this.UI_PB_Progress);
            this.Controls.Add(this.UI_GB_Compat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Virtual Paste";
            this.UI_GB_Compat.ResumeLayout(false);
            this.UI_GB_Compat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_TRB_Delay)).EndInit();
            this.UI_GB_Hotkey.ResumeLayout(false);
            this.UI_GB_Hotkey.PerformLayout();
            this.UI_CMS_NI_SysTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox UI_GB_Compat;
        private System.Windows.Forms.CheckBox UI_CB_SendBackspaces;
        private System.Windows.Forms.CheckBox UI_CB_RemoveCapslock;
        private System.Windows.Forms.CheckBox UI_CB_RemoveReturn;
        private System.Windows.Forms.ProgressBar UI_PB_Progress;
        private System.Windows.Forms.Button UI_BTN_Stop;
        private System.Windows.Forms.Button UI_BTN_Hide;
        private System.Windows.Forms.TrackBar UI_TRB_Delay;
        private System.Windows.Forms.Label UI_LBL_DelayMin;
        private System.Windows.Forms.Label UI_LBL_Delay;
        private System.Windows.Forms.Label UI_LBL_DelayMax;
        private System.Windows.Forms.CheckBox UI_CB_Active;
        private System.Windows.Forms.GroupBox UI_GB_Hotkey;
        private System.Windows.Forms.CheckBox UI_CB_MOD_Win;
        private System.Windows.Forms.CheckBox UI_CB_MOD_Shift;
        private System.Windows.Forms.CheckBox UI_CB_MOD_Alt;
        private System.Windows.Forms.CheckBox UI_CB_MOD_Ctrl;
        private System.Windows.Forms.TextBox UI_TB_Hotkey;
        private System.Windows.Forms.CheckBox UI_CB_SlowType;
        private System.Windows.Forms.NotifyIcon UI_NI_SysTray;
        private System.Windows.Forms.ContextMenuStrip UI_CMS_NI_SysTray;
        private System.Windows.Forms.ToolStripMenuItem UI_CMSBTN_ShowSettings;
        private System.Windows.Forms.ToolStripMenuItem UI_CMSBTN_Quit;
    }
}

