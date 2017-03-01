namespace SteamChat
{
	partial class MainForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>


		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.ProcessSelectCombo = new System.Windows.Forms.ComboBox();
			this.SelectChatObjCombo = new System.Windows.Forms.ComboBox();
			this.ProcessGroupBox = new System.Windows.Forms.GroupBox();
			this.processRefreshButton = new System.Windows.Forms.Button();
			this.ProcessSelectOKButton = new System.Windows.Forms.Button();
			this.ChatObject = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ChatObjListbox = new System.Windows.Forms.ListBox();
			this.ChatListGroupButton = new System.Windows.Forms.Button();
			this.ChatListRemoveButton = new System.Windows.Forms.Button();
			this.ChatListAddButton = new System.Windows.Forms.Button();
			this.ioUserBox = new System.Windows.Forms.GroupBox();
			this.focusChatRoomLabel = new System.Windows.Forms.Label();
			this.IOUserGridView = new System.Windows.Forms.DataGridView();
			this.NNameLabel = new System.Windows.Forms.Label();
			this.NFriendLabel = new System.Windows.Forms.Label();
			this.NGroupLabel = new System.Windows.Forms.Label();
			this.nameLabel = new System.Windows.Forms.Label();
			this.friendsLabel = new System.Windows.Forms.Label();
			this.groupsLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.settingButton = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.showOfflineFriendCheck = new System.Windows.Forms.CheckBox();
			this.ProcessGroupBox.SuspendLayout();
			this.ChatObject.SuspendLayout();
			this.ioUserBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.IOUserGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// ProcessSelectCombo
			// 
			this.ProcessSelectCombo.DropDownHeight = 100;
			this.ProcessSelectCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ProcessSelectCombo.FormattingEnabled = true;
			this.ProcessSelectCombo.IntegralHeight = false;
			this.ProcessSelectCombo.Location = new System.Drawing.Point(6, 15);
			this.ProcessSelectCombo.Name = "ProcessSelectCombo";
			this.ProcessSelectCombo.Size = new System.Drawing.Size(154, 20);
			this.ProcessSelectCombo.TabIndex = 0;
			// 
			// SelectChatObjCombo
			// 
			this.SelectChatObjCombo.DropDownHeight = 100;
			this.SelectChatObjCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SelectChatObjCombo.FormattingEnabled = true;
			this.SelectChatObjCombo.IntegralHeight = false;
			this.SelectChatObjCombo.Location = new System.Drawing.Point(63, 20);
			this.SelectChatObjCombo.Name = "SelectChatObjCombo";
			this.SelectChatObjCombo.Size = new System.Drawing.Size(210, 20);
			this.SelectChatObjCombo.TabIndex = 2;
			// 
			// ProcessGroupBox
			// 
			this.ProcessGroupBox.Controls.Add(this.processRefreshButton);
			this.ProcessGroupBox.Controls.Add(this.ProcessSelectOKButton);
			this.ProcessGroupBox.Controls.Add(this.ProcessSelectCombo);
			this.ProcessGroupBox.Location = new System.Drawing.Point(12, 27);
			this.ProcessGroupBox.Name = "ProcessGroupBox";
			this.ProcessGroupBox.Size = new System.Drawing.Size(301, 43);
			this.ProcessGroupBox.TabIndex = 5;
			this.ProcessGroupBox.TabStop = false;
			this.ProcessGroupBox.Text = "Target process";
			// 
			// processRefreshButton
			// 
			this.processRefreshButton.Enabled = false;
			this.processRefreshButton.Location = new System.Drawing.Point(233, 15);
			this.processRefreshButton.Name = "processRefreshButton";
			this.processRefreshButton.Size = new System.Drawing.Size(61, 20);
			this.processRefreshButton.TabIndex = 2;
			this.processRefreshButton.Text = "Refresh";
			this.processRefreshButton.UseVisualStyleBackColor = true;
			this.processRefreshButton.Click += new System.EventHandler(this.refreshButtonClick);
			// 
			// ProcessSelectOKButton
			// 
			this.ProcessSelectOKButton.Enabled = false;
			this.ProcessSelectOKButton.Location = new System.Drawing.Point(166, 15);
			this.ProcessSelectOKButton.Name = "ProcessSelectOKButton";
			this.ProcessSelectOKButton.Size = new System.Drawing.Size(61, 20);
			this.ProcessSelectOKButton.TabIndex = 1;
			this.ProcessSelectOKButton.Text = "Apply";
			this.ProcessSelectOKButton.UseVisualStyleBackColor = true;
			this.ProcessSelectOKButton.Click += new System.EventHandler(this.processSelectOKButtonClick);
			// 
			// ChatObject
			// 
			this.ChatObject.Controls.Add(this.showOfflineFriendCheck);
			this.ChatObject.Controls.Add(this.label4);
			this.ChatObject.Controls.Add(this.ChatObjListbox);
			this.ChatObject.Controls.Add(this.ChatListGroupButton);
			this.ChatObject.Controls.Add(this.ChatListRemoveButton);
			this.ChatObject.Controls.Add(this.ChatListAddButton);
			this.ChatObject.Controls.Add(this.SelectChatObjCombo);
			this.ChatObject.Location = new System.Drawing.Point(12, 76);
			this.ChatObject.Name = "ChatObject";
			this.ChatObject.Size = new System.Drawing.Size(301, 157);
			this.ChatObject.TabIndex = 6;
			this.ChatObject.TabStop = false;
			this.ChatObject.Text = "Chatting list";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 12);
			this.label4.TabIndex = 17;
			this.label4.Text = "Friends:";
			// 
			// ChatObjListbox
			// 
			this.ChatObjListbox.FormattingEnabled = true;
			this.ChatObjListbox.ItemHeight = 12;
			this.ChatObjListbox.Location = new System.Drawing.Point(6, 49);
			this.ChatObjListbox.Name = "ChatObjListbox";
			this.ChatObjListbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.ChatObjListbox.Size = new System.Drawing.Size(221, 100);
			this.ChatObjListbox.TabIndex = 8;
			// 
			// ChatListGroupButton
			// 
			this.ChatListGroupButton.Location = new System.Drawing.Point(233, 101);
			this.ChatListGroupButton.Name = "ChatListGroupButton";
			this.ChatListGroupButton.Size = new System.Drawing.Size(61, 20);
			this.ChatListGroupButton.TabIndex = 7;
			this.ChatListGroupButton.Text = "Group..";
			this.ChatListGroupButton.UseVisualStyleBackColor = true;
			// 
			// ChatListRemoveButton
			// 
			this.ChatListRemoveButton.Enabled = false;
			this.ChatListRemoveButton.Location = new System.Drawing.Point(233, 75);
			this.ChatListRemoveButton.Name = "ChatListRemoveButton";
			this.ChatListRemoveButton.Size = new System.Drawing.Size(61, 20);
			this.ChatListRemoveButton.TabIndex = 6;
			this.ChatListRemoveButton.Text = "Remove";
			this.ChatListRemoveButton.UseVisualStyleBackColor = true;
			this.ChatListRemoveButton.Click += new System.EventHandler(this.ChatListRemoveButton_Click);
			// 
			// ChatListAddButton
			// 
			this.ChatListAddButton.Enabled = false;
			this.ChatListAddButton.Location = new System.Drawing.Point(233, 49);
			this.ChatListAddButton.Name = "ChatListAddButton";
			this.ChatListAddButton.Size = new System.Drawing.Size(61, 20);
			this.ChatListAddButton.TabIndex = 5;
			this.ChatListAddButton.Text = "Add";
			this.ChatListAddButton.UseVisualStyleBackColor = true;
			this.ChatListAddButton.Click += new System.EventHandler(this.chatListAddButtonClick);
			// 
			// ioUserBox
			// 
			this.ioUserBox.Controls.Add(this.focusChatRoomLabel);
			this.ioUserBox.Controls.Add(this.IOUserGridView);
			this.ioUserBox.Location = new System.Drawing.Point(319, 12);
			this.ioUserBox.Name = "ioUserBox";
			this.ioUserBox.Size = new System.Drawing.Size(285, 289);
			this.ioUserBox.TabIndex = 7;
			this.ioUserBox.TabStop = false;
			this.ioUserBox.Text = "Connected user";
			// 
			// focusChatRoomLabel
			// 
			this.focusChatRoomLabel.AutoSize = true;
			this.focusChatRoomLabel.Location = new System.Drawing.Point(6, 17);
			this.focusChatRoomLabel.Name = "focusChatRoomLabel";
			this.focusChatRoomLabel.Size = new System.Drawing.Size(24, 12);
			this.focusChatRoomLabel.TabIndex = 14;
			this.focusChatRoomLabel.Text = "To.";
			// 
			// IOUserGridView
			// 
			this.IOUserGridView.AllowUserToAddRows = false;
			this.IOUserGridView.AllowUserToDeleteRows = false;
			this.IOUserGridView.AllowUserToResizeColumns = false;
			this.IOUserGridView.AllowUserToResizeRows = false;
			this.IOUserGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.IOUserGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.IOUserGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.IOUserGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.IOUserGridView.ColumnHeadersVisible = false;
			this.IOUserGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.IOUserGridView.Location = new System.Drawing.Point(6, 32);
			this.IOUserGridView.Name = "IOUserGridView";
			this.IOUserGridView.ReadOnly = true;
			this.IOUserGridView.RowHeadersVisible = false;
			this.IOUserGridView.RowTemplate.Height = 23;
			this.IOUserGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.IOUserGridView.Size = new System.Drawing.Size(273, 251);
			this.IOUserGridView.TabIndex = 0;
			this.IOUserGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.IOUserGridViewCellContentDoubleClick);
			// 
			// NNameLabel
			// 
			this.NNameLabel.AutoSize = true;
			this.NNameLabel.Location = new System.Drawing.Point(12, 9);
			this.NNameLabel.Name = "NNameLabel";
			this.NNameLabel.Size = new System.Drawing.Size(43, 12);
			this.NNameLabel.TabIndex = 8;
			this.NNameLabel.Text = "Name:";
			// 
			// NFriendLabel
			// 
			this.NFriendLabel.AutoSize = true;
			this.NFriendLabel.Location = new System.Drawing.Point(157, 9);
			this.NFriendLabel.Name = "NFriendLabel";
			this.NFriendLabel.Size = new System.Drawing.Size(51, 12);
			this.NFriendLabel.TabIndex = 9;
			this.NFriendLabel.Text = "Friends:";
			// 
			// NGroupLabel
			// 
			this.NGroupLabel.AutoSize = true;
			this.NGroupLabel.Location = new System.Drawing.Point(243, 9);
			this.NGroupLabel.Name = "NGroupLabel";
			this.NGroupLabel.Size = new System.Drawing.Size(50, 12);
			this.NGroupLabel.TabIndex = 10;
			this.NGroupLabel.Text = "Groups:";
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(61, 9);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(37, 12);
			this.nameLabel.TabIndex = 11;
			this.nameLabel.Text = "name";
			// 
			// friendsLabel
			// 
			this.friendsLabel.AutoSize = true;
			this.friendsLabel.Location = new System.Drawing.Point(214, 9);
			this.friendsLabel.Name = "friendsLabel";
			this.friendsLabel.Size = new System.Drawing.Size(11, 12);
			this.friendsLabel.TabIndex = 12;
			this.friendsLabel.Text = "0";
			// 
			// groupsLabel
			// 
			this.groupsLabel.AutoSize = true;
			this.groupsLabel.Location = new System.Drawing.Point(299, 9);
			this.groupsLabel.Name = "groupsLabel";
			this.groupsLabel.Size = new System.Drawing.Size(11, 12);
			this.groupsLabel.TabIndex = 13;
			this.groupsLabel.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 236);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(297, 12);
			this.label1.TabIndex = 14;
			this.label1.Text = "베타버전, 배포: 디시 유로파 갤러리, 다음 유로파 카페";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 251);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(283, 12);
			this.label2.TabIndex = 15;
			this.label2.Text = "문의: dja12123@naver.com 혹은 스팀 CamelCase";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 266);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 12);
			this.label3.TabIndex = 16;
			this.label3.Text = "소스: ";
			// 
			// settingButton
			// 
			this.settingButton.Location = new System.Drawing.Point(12, 281);
			this.settingButton.Name = "settingButton";
			this.settingButton.Size = new System.Drawing.Size(61, 20);
			this.settingButton.TabIndex = 3;
			this.settingButton.Text = "Setting";
			this.settingButton.UseVisualStyleBackColor = true;
			this.settingButton.Click += new System.EventHandler(this.settingButtonClick);
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(39, 266);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(274, 12);
			this.linkLabel1.TabIndex = 17;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "https://github.com/dja12123/SteamchatInGame";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// showOfflineFriendCheck
			// 
			this.showOfflineFriendCheck.AutoSize = true;
			this.showOfflineFriendCheck.Location = new System.Drawing.Point(279, 23);
			this.showOfflineFriendCheck.Name = "showOfflineFriendCheck";
			this.showOfflineFriendCheck.Size = new System.Drawing.Size(15, 14);
			this.showOfflineFriendCheck.TabIndex = 18;
			this.showOfflineFriendCheck.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(613, 309);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.settingButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupsLabel);
			this.Controls.Add(this.friendsLabel);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.NGroupLabel);
			this.Controls.Add(this.NFriendLabel);
			this.Controls.Add(this.NNameLabel);
			this.Controls.Add(this.ioUserBox);
			this.Controls.Add(this.ChatObject);
			this.Controls.Add(this.ProcessGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ProcessGroupBox.ResumeLayout(false);
			this.ChatObject.ResumeLayout(false);
			this.ChatObject.PerformLayout();
			this.ioUserBox.ResumeLayout(false);
			this.ioUserBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.IOUserGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox ProcessSelectCombo;
		private System.Windows.Forms.ComboBox SelectChatObjCombo;
		private System.Windows.Forms.GroupBox ProcessGroupBox;
		private System.Windows.Forms.Button ProcessSelectOKButton;
		private System.Windows.Forms.GroupBox ChatObject;
		private System.Windows.Forms.Button ChatListAddButton;
		private System.Windows.Forms.GroupBox ioUserBox;
		private System.Windows.Forms.Label NNameLabel;
		private System.Windows.Forms.Label NFriendLabel;
		private System.Windows.Forms.Label NGroupLabel;
		private System.Windows.Forms.Button ChatListGroupButton;
		private System.Windows.Forms.Button ChatListRemoveButton;
		private System.Windows.Forms.ListBox ChatObjListbox;
		private System.Windows.Forms.DataGridView IOUserGridView;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.Label friendsLabel;
		private System.Windows.Forms.Label groupsLabel;
		private System.Windows.Forms.Button processRefreshButton;
		private System.Windows.Forms.Label focusChatRoomLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button settingButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.CheckBox showOfflineFriendCheck;
	}
}

