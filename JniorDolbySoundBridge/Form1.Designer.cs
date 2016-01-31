namespace JniorDolbySoundBridge
{
	partial class Form1
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.jniorConnectionLabel = new System.Windows.Forms.Label();
			this.jniorStatus = new System.Windows.Forms.Label();
			this.increaseVolumeButton = new System.Windows.Forms.Button();
			this.decreaseVolumeButton = new System.Windows.Forms.Button();
			this.titleLabel = new System.Windows.Forms.Label();
			this.trayIcon_ = new System.Windows.Forms.NotifyIcon(this.components);
			this.trayMenu_ = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.inputsLabel = new System.Windows.Forms.Label();
			this.jniorInputs = new System.Windows.Forms.Label();
			this.outputsLabel = new System.Windows.Forms.Label();
			this.jniorOutputs = new System.Windows.Forms.Label();
			this.lastUpdatedLabel = new System.Windows.Forms.Label();
			this.lastUpdated = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.logoBox = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.dolbyConnectionLabel = new System.Windows.Forms.Label();
			this.dolbyStatus = new System.Windows.Forms.Label();
			this.logLabel = new System.Windows.Forms.Label();
			this.lights_0 = new System.Windows.Forms.Button();
			this.lights_33 = new System.Windows.Forms.Button();
			this.lights_66 = new System.Windows.Forms.Button();
			this.lights_100 = new System.Windows.Forms.Button();
			this.lightsLabel = new System.Windows.Forms.Label();
			this.trayMenu_.SuspendLayout();
			this.mainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
			this.SuspendLayout();
			// 
			// jniorConnectionLabel
			// 
			this.jniorConnectionLabel.AutoSize = true;
			this.jniorConnectionLabel.Location = new System.Drawing.Point(9, 107);
			this.jniorConnectionLabel.Name = "jniorConnectionLabel";
			this.jniorConnectionLabel.Size = new System.Drawing.Size(89, 13);
			this.jniorConnectionLabel.TabIndex = 1;
			this.jniorConnectionLabel.Text = "Jnior Connection:";
			// 
			// jniorStatus
			// 
			this.jniorStatus.AutoSize = true;
			this.jniorStatus.Location = new System.Drawing.Point(10, 120);
			this.jniorStatus.Name = "jniorStatus";
			this.jniorStatus.Size = new System.Drawing.Size(73, 13);
			this.jniorStatus.TabIndex = 2;
			this.jniorStatus.Text = "Disconnected";
			// 
			// increaseVolumeButton
			// 
			this.increaseVolumeButton.Location = new System.Drawing.Point(283, 248);
			this.increaseVolumeButton.Name = "increaseVolumeButton";
			this.increaseVolumeButton.Size = new System.Drawing.Size(110, 23);
			this.increaseVolumeButton.TabIndex = 3;
			this.increaseVolumeButton.Text = "Increase Volume";
			this.increaseVolumeButton.UseVisualStyleBackColor = true;
			this.increaseVolumeButton.Click += new System.EventHandler(this.increaseVolumeButton_Click);
			// 
			// decreaseVolumeButton
			// 
			this.decreaseVolumeButton.Location = new System.Drawing.Point(9, 248);
			this.decreaseVolumeButton.Name = "decreaseVolumeButton";
			this.decreaseVolumeButton.Size = new System.Drawing.Size(110, 23);
			this.decreaseVolumeButton.TabIndex = 4;
			this.decreaseVolumeButton.Text = "Decrease Volume";
			this.decreaseVolumeButton.UseVisualStyleBackColor = true;
			this.decreaseVolumeButton.Click += new System.EventHandler(this.decreaseVolumeButton_Click);
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.Location = new System.Drawing.Point(75, 67);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(253, 20);
			this.titleLabel.TabIndex = 5;
			this.titleLabel.Text = "Jnior to Dolby CP750 Fader Bridge";
			// 
			// trayIcon_
			// 
			this.trayIcon_.ContextMenuStrip = this.trayMenu_;
			this.trayIcon_.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon_.Icon")));
			this.trayIcon_.Text = "Jnior to Dolby Fader Bridge";
			this.trayIcon_.Visible = true;
			this.trayIcon_.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon__MouseDoubleClick);
			// 
			// trayMenu_
			// 
			this.trayMenu_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.trayMenu_.Name = "trayMenu_";
			this.trayMenu_.Size = new System.Drawing.Size(104, 48);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// mainMenu
			// 
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(400, 24);
			this.mainMenu.TabIndex = 7;
			this.mainMenu.Text = "Main Menu";
			// 
			// menuToolStripMenuItem
			// 
			this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem1});
			this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
			this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.menuToolStripMenuItem.Text = "Menu";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem1
			// 
			this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
			this.exitToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem1.Text = "Exit";
			this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
			// 
			// inputsLabel
			// 
			this.inputsLabel.AutoSize = true;
			this.inputsLabel.Location = new System.Drawing.Point(10, 184);
			this.inputsLabel.Name = "inputsLabel";
			this.inputsLabel.Size = new System.Drawing.Size(39, 13);
			this.inputsLabel.TabIndex = 8;
			this.inputsLabel.Text = "Inputs:";
			// 
			// jniorInputs
			// 
			this.jniorInputs.AutoSize = true;
			this.jniorInputs.Location = new System.Drawing.Point(63, 184);
			this.jniorInputs.Name = "jniorInputs";
			this.jniorInputs.Size = new System.Drawing.Size(55, 13);
			this.jniorInputs.TabIndex = 9;
			this.jniorInputs.Text = "00000000";
			// 
			// outputsLabel
			// 
			this.outputsLabel.AutoSize = true;
			this.outputsLabel.Location = new System.Drawing.Point(10, 201);
			this.outputsLabel.Name = "outputsLabel";
			this.outputsLabel.Size = new System.Drawing.Size(47, 13);
			this.outputsLabel.TabIndex = 10;
			this.outputsLabel.Text = "Outputs:";
			// 
			// jniorOutputs
			// 
			this.jniorOutputs.AutoSize = true;
			this.jniorOutputs.Location = new System.Drawing.Point(63, 201);
			this.jniorOutputs.Name = "jniorOutputs";
			this.jniorOutputs.Size = new System.Drawing.Size(55, 13);
			this.jniorOutputs.TabIndex = 11;
			this.jniorOutputs.Text = "00000000";
			// 
			// lastUpdatedLabel
			// 
			this.lastUpdatedLabel.AutoSize = true;
			this.lastUpdatedLabel.Location = new System.Drawing.Point(10, 218);
			this.lastUpdatedLabel.Name = "lastUpdatedLabel";
			this.lastUpdatedLabel.Size = new System.Drawing.Size(74, 13);
			this.lastUpdatedLabel.TabIndex = 12;
			this.lastUpdatedLabel.Text = "Last Updated:";
			// 
			// lastUpdated
			// 
			this.lastUpdated.AutoSize = true;
			this.lastUpdated.Location = new System.Drawing.Point(93, 218);
			this.lastUpdated.Name = "lastUpdated";
			this.lastUpdated.Size = new System.Drawing.Size(34, 13);
			this.lastUpdated.TabIndex = 13;
			this.lastUpdated.Text = "never";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::JniorDolbySoundBridge.Properties.Resources.schunterkino;
			this.pictureBox1.Location = new System.Drawing.Point(96, 39);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(220, 25);
			this.pictureBox1.TabIndex = 15;
			this.pictureBox1.TabStop = false;
			// 
			// logoBox
			// 
			this.logoBox.Image = global::JniorDolbySoundBridge.Properties.Resources.dolby_jnior_128;
			this.logoBox.Location = new System.Drawing.Point(265, 107);
			this.logoBox.Name = "logoBox";
			this.logoBox.Size = new System.Drawing.Size(128, 128);
			this.logoBox.TabIndex = 14;
			this.logoBox.TabStop = false;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(9, 357);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(384, 172);
			this.textBox1.TabIndex = 16;
			// 
			// dolbyConnectionLabel
			// 
			this.dolbyConnectionLabel.AutoSize = true;
			this.dolbyConnectionLabel.Location = new System.Drawing.Point(9, 144);
			this.dolbyConnectionLabel.Name = "dolbyConnectionLabel";
			this.dolbyConnectionLabel.Size = new System.Drawing.Size(94, 13);
			this.dolbyConnectionLabel.TabIndex = 17;
			this.dolbyConnectionLabel.Text = "Dolby Connection:";
			// 
			// dolbyStatus
			// 
			this.dolbyStatus.AutoSize = true;
			this.dolbyStatus.Location = new System.Drawing.Point(10, 157);
			this.dolbyStatus.Name = "dolbyStatus";
			this.dolbyStatus.Size = new System.Drawing.Size(73, 13);
			this.dolbyStatus.TabIndex = 18;
			this.dolbyStatus.Text = "Disconnected";
			// 
			// logLabel
			// 
			this.logLabel.AutoSize = true;
			this.logLabel.Location = new System.Drawing.Point(9, 338);
			this.logLabel.Name = "logLabel";
			this.logLabel.Size = new System.Drawing.Size(28, 13);
			this.logLabel.TabIndex = 19;
			this.logLabel.Text = "Log:";
			// 
			// lights_0
			// 
			this.lights_0.Location = new System.Drawing.Point(9, 312);
			this.lights_0.Name = "lights_0";
			this.lights_0.Size = new System.Drawing.Size(75, 23);
			this.lights_0.TabIndex = 20;
			this.lights_0.Text = "0%";
			this.lights_0.UseVisualStyleBackColor = true;
			this.lights_0.Click += new System.EventHandler(this.lights_0_Click);
			// 
			// lights_33
			// 
			this.lights_33.Location = new System.Drawing.Point(114, 312);
			this.lights_33.Name = "lights_33";
			this.lights_33.Size = new System.Drawing.Size(75, 23);
			this.lights_33.TabIndex = 21;
			this.lights_33.Text = "33%";
			this.lights_33.UseVisualStyleBackColor = true;
			this.lights_33.Click += new System.EventHandler(this.lights_33_Click);
			// 
			// lights_66
			// 
			this.lights_66.Location = new System.Drawing.Point(215, 312);
			this.lights_66.Name = "lights_66";
			this.lights_66.Size = new System.Drawing.Size(75, 23);
			this.lights_66.TabIndex = 22;
			this.lights_66.Text = "66%";
			this.lights_66.UseVisualStyleBackColor = true;
			this.lights_66.Click += new System.EventHandler(this.lights_66_Click);
			// 
			// lights_100
			// 
			this.lights_100.Location = new System.Drawing.Point(318, 312);
			this.lights_100.Name = "lights_100";
			this.lights_100.Size = new System.Drawing.Size(75, 23);
			this.lights_100.TabIndex = 23;
			this.lights_100.Text = "100%";
			this.lights_100.UseVisualStyleBackColor = true;
			this.lights_100.Click += new System.EventHandler(this.lights_100_Click);
			// 
			// lightsLabel
			// 
			this.lightsLabel.AutoSize = true;
			this.lightsLabel.Location = new System.Drawing.Point(9, 293);
			this.lightsLabel.Name = "lightsLabel";
			this.lightsLabel.Size = new System.Drawing.Size(35, 13);
			this.lightsLabel.TabIndex = 24;
			this.lightsLabel.Text = "Lights";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 536);
			this.Controls.Add(this.lightsLabel);
			this.Controls.Add(this.lights_100);
			this.Controls.Add(this.lights_66);
			this.Controls.Add(this.lights_33);
			this.Controls.Add(this.lights_0);
			this.Controls.Add(this.logLabel);
			this.Controls.Add(this.dolbyStatus);
			this.Controls.Add(this.dolbyConnectionLabel);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lastUpdated);
			this.Controls.Add(this.lastUpdatedLabel);
			this.Controls.Add(this.jniorOutputs);
			this.Controls.Add(this.outputsLabel);
			this.Controls.Add(this.jniorInputs);
			this.Controls.Add(this.inputsLabel);
			this.Controls.Add(this.mainMenu);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.decreaseVolumeButton);
			this.Controls.Add(this.increaseVolumeButton);
			this.Controls.Add(this.jniorStatus);
			this.Controls.Add(this.jniorConnectionLabel);
			this.Controls.Add(this.logoBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mainMenu;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Jnior to Dolby Fader Bridge";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.trayMenu_.ResumeLayout(false);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label jniorConnectionLabel;
		private System.Windows.Forms.Label jniorStatus;
		private System.Windows.Forms.Button increaseVolumeButton;
		private System.Windows.Forms.Button decreaseVolumeButton;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.NotifyIcon trayIcon_;
		private System.Windows.Forms.ContextMenuStrip trayMenu_;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
		private System.Windows.Forms.Label inputsLabel;
		private System.Windows.Forms.Label jniorInputs;
		private System.Windows.Forms.Label outputsLabel;
		private System.Windows.Forms.Label jniorOutputs;
		private System.Windows.Forms.Label lastUpdatedLabel;
		private System.Windows.Forms.Label lastUpdated;
		private System.Windows.Forms.PictureBox logoBox;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label dolbyConnectionLabel;
		private System.Windows.Forms.Label dolbyStatus;
		private System.Windows.Forms.Label logLabel;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.Button lights_0;
		private System.Windows.Forms.Button lights_33;
		private System.Windows.Forms.Button lights_66;
		private System.Windows.Forms.Button lights_100;
		private System.Windows.Forms.Label lightsLabel;
	}
}

