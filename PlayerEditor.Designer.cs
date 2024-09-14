namespace DZ_Players
{
    partial class PlayerEditor
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            searchPlayer = new TextBox();
            label2 = new Label();
            searchPlayerButton = new Button();
            groupBox1 = new GroupBox();
            clearDuplicatesListButton = new Button();
            searchDuplicatesButton = new Button();
            deleteCharFromDBButton = new Button();
            cleanInventoryButton = new Button();
            deleteDuplicatesButton = new Button();
            exportDuplicatesButton = new Button();
            label4 = new Label();
            label3 = new Label();
            dupeInventory = new TreeView();
            playerInventory = new TreeView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            copyAsIntArrayMenuItem1 = new ToolStripMenuItem();
            copyParentUIDMenuItem = new ToolStripMenuItem();
            playersListBox = new ListBox();
            groupBox2 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            playerDbId = new TextBox();
            label8 = new Label();
            playerUID = new TextBox();
            playerStatus = new Label();
            playerChartype = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            playerCounter = new Label();
            groupBox1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(361, 18);
            label1.TabIndex = 1;
            label1.Text = "Список игроков:";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // searchPlayer
            // 
            searchPlayer.Location = new Point(12, 732);
            searchPlayer.Name = "searchPlayer";
            searchPlayer.Size = new Size(361, 23);
            searchPlayer.TabIndex = 3;
            // 
            // label2
            // 
            label2.Location = new Point(12, 711);
            label2.Name = "label2";
            label2.Size = new Size(361, 18);
            label2.TabIndex = 4;
            label2.Text = "Поиск по UID/Steam64";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // searchPlayerButton
            // 
            searchPlayerButton.Location = new Point(12, 761);
            searchPlayerButton.Name = "searchPlayerButton";
            searchPlayerButton.Size = new Size(361, 23);
            searchPlayerButton.TabIndex = 5;
            searchPlayerButton.Text = "Поиск";
            searchPlayerButton.UseVisualStyleBackColor = true;
            searchPlayerButton.Click += Click_Button_Action;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(clearDuplicatesListButton);
            groupBox1.Controls.Add(searchDuplicatesButton);
            groupBox1.Controls.Add(deleteCharFromDBButton);
            groupBox1.Controls.Add(cleanInventoryButton);
            groupBox1.Controls.Add(deleteDuplicatesButton);
            groupBox1.Controls.Add(exportDuplicatesButton);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dupeInventory);
            groupBox1.Controls.Add(playerInventory);
            groupBox1.Location = new Point(379, 163);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1015, 621);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // clearDuplicatesListButton
            // 
            clearDuplicatesListButton.Location = new Point(519, 536);
            clearDuplicatesListButton.Name = "clearDuplicatesListButton";
            clearDuplicatesListButton.Size = new Size(490, 23);
            clearDuplicatesListButton.TabIndex = 14;
            clearDuplicatesListButton.Text = "Очистить список";
            clearDuplicatesListButton.UseVisualStyleBackColor = true;
            clearDuplicatesListButton.Click += Click_Button_Action;
            // 
            // searchDuplicatesButton
            // 
            searchDuplicatesButton.Location = new Point(6, 536);
            searchDuplicatesButton.Name = "searchDuplicatesButton";
            searchDuplicatesButton.Size = new Size(490, 23);
            searchDuplicatesButton.TabIndex = 13;
            searchDuplicatesButton.Text = "Найти дубликаты";
            searchDuplicatesButton.UseVisualStyleBackColor = true;
            searchDuplicatesButton.Click += Click_Button_Action;
            // 
            // deleteCharFromDBButton
            // 
            deleteCharFromDBButton.Anchor = AnchorStyles.Bottom;
            deleteCharFromDBButton.Location = new Point(6, 594);
            deleteCharFromDBButton.Name = "deleteCharFromDBButton";
            deleteCharFromDBButton.Size = new Size(490, 23);
            deleteCharFromDBButton.TabIndex = 12;
            deleteCharFromDBButton.Text = "Удалить персонажа из DB";
            deleteCharFromDBButton.UseVisualStyleBackColor = true;
            deleteCharFromDBButton.Click += Click_Button_Action;
            // 
            // cleanInventoryButton
            // 
            cleanInventoryButton.Anchor = AnchorStyles.Bottom;
            cleanInventoryButton.Location = new Point(6, 565);
            cleanInventoryButton.Name = "cleanInventoryButton";
            cleanInventoryButton.Size = new Size(490, 23);
            cleanInventoryButton.TabIndex = 11;
            cleanInventoryButton.Text = "Очистить инвентарь";
            cleanInventoryButton.UseVisualStyleBackColor = true;
            cleanInventoryButton.Click += Click_Button_Action;
            // 
            // deleteDuplicatesButton
            // 
            deleteDuplicatesButton.Anchor = AnchorStyles.Bottom;
            deleteDuplicatesButton.Location = new Point(519, 594);
            deleteDuplicatesButton.Name = "deleteDuplicatesButton";
            deleteDuplicatesButton.Size = new Size(490, 23);
            deleteDuplicatesButton.TabIndex = 10;
            deleteDuplicatesButton.Text = "Удалить дубликаты у игроков";
            deleteDuplicatesButton.UseVisualStyleBackColor = true;
            deleteDuplicatesButton.Click += Click_Button_Action;
            // 
            // exportDuplicatesButton
            // 
            exportDuplicatesButton.Anchor = AnchorStyles.Bottom;
            exportDuplicatesButton.Location = new Point(519, 565);
            exportDuplicatesButton.Name = "exportDuplicatesButton";
            exportDuplicatesButton.Size = new Size(490, 23);
            exportDuplicatesButton.TabIndex = 9;
            exportDuplicatesButton.Text = "Экспорт в файл";
            exportDuplicatesButton.UseVisualStyleBackColor = true;
            exportDuplicatesButton.Click += Click_Button_Action;
            // 
            // label4
            // 
            label4.Location = new Point(519, 17);
            label4.Name = "label4";
            label4.Size = new Size(490, 18);
            label4.TabIndex = 8;
            label4.Text = "Дубликаты:";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Location = new Point(6, 17);
            label3.Name = "label3";
            label3.Size = new Size(490, 18);
            label3.TabIndex = 7;
            label3.Text = "Инвентарь:";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // dupeInventory
            // 
            dupeInventory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dupeInventory.Location = new Point(519, 38);
            dupeInventory.Name = "dupeInventory";
            dupeInventory.Size = new Size(490, 492);
            dupeInventory.TabIndex = 1;
            dupeInventory.NodeMouseClick += NodeMouseClick;
            // 
            // playerInventory
            // 
            playerInventory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            playerInventory.Location = new Point(6, 38);
            playerInventory.Name = "playerInventory";
            playerInventory.Size = new Size(490, 492);
            playerInventory.TabIndex = 0;
            playerInventory.NodeMouseClick += NodeMouseClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { copyAsIntArrayMenuItem1, copyParentUIDMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(222, 48);
            // 
            // copyAsIntArrayMenuItem1
            // 
            copyAsIntArrayMenuItem1.Name = "copyAsIntArrayMenuItem1";
            copyAsIntArrayMenuItem1.Size = new Size(221, 22);
            copyAsIntArrayMenuItem1.Text = "Копировать как int[]";
            copyAsIntArrayMenuItem1.Click += copyAsIntArrayMenuItem1_Click;
            // 
            // copyParentUIDMenuItem
            // 
            copyParentUIDMenuItem.Name = "copyParentUIDMenuItem";
            copyParentUIDMenuItem.Size = new Size(221, 22);
            copyParentUIDMenuItem.Text = "Копировать UID владельца";
            copyParentUIDMenuItem.Click += copyParentUIDMenuItem_Click;
            // 
            // playersListBox
            // 
            playersListBox.FormattingEnabled = true;
            playersListBox.ItemHeight = 15;
            playersListBox.Location = new Point(12, 29);
            playersListBox.Name = "playersListBox";
            playersListBox.Size = new Size(361, 664);
            playersListBox.TabIndex = 7;
            playersListBox.SelectedIndexChanged += SelectNextPlayer;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tableLayoutPanel1);
            groupBox2.Location = new Point(379, 29);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1015, 128);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Игрок";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(playerDbId, 1, 0);
            tableLayoutPanel1.Controls.Add(label8, 0, 0);
            tableLayoutPanel1.Controls.Add(playerUID, 1, 1);
            tableLayoutPanel1.Controls.Add(playerStatus, 1, 3);
            tableLayoutPanel1.Controls.Add(playerChartype, 1, 2);
            tableLayoutPanel1.Controls.Add(label7, 0, 3);
            tableLayoutPanel1.Controls.Add(label6, 0, 2);
            tableLayoutPanel1.Controls.Add(label5, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.Size = new Size(1009, 106);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // playerDbId
            // 
            playerDbId.Dock = DockStyle.Fill;
            playerDbId.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            playerDbId.Location = new Point(183, 3);
            playerDbId.Name = "playerDbId";
            playerDbId.ReadOnly = true;
            playerDbId.Size = new Size(823, 23);
            playerDbId.TabIndex = 19;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(174, 27);
            label8.TabIndex = 18;
            label8.Text = "DB ID:";
            label8.TextAlign = ContentAlignment.TopCenter;
            // 
            // playerUID
            // 
            playerUID.Dock = DockStyle.Fill;
            playerUID.Location = new Point(183, 30);
            playerUID.Name = "playerUID";
            playerUID.ReadOnly = true;
            playerUID.Size = new Size(823, 23);
            playerUID.TabIndex = 0;
            // 
            // playerStatus
            // 
            playerStatus.Dock = DockStyle.Fill;
            playerStatus.Location = new Point(183, 84);
            playerStatus.Name = "playerStatus";
            playerStatus.Size = new Size(823, 27);
            playerStatus.TabIndex = 17;
            playerStatus.Text = "Отсуствует";
            // 
            // playerChartype
            // 
            playerChartype.Dock = DockStyle.Fill;
            playerChartype.Location = new Point(183, 57);
            playerChartype.Name = "playerChartype";
            playerChartype.ReadOnly = true;
            playerChartype.Size = new Size(823, 23);
            playerChartype.TabIndex = 15;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(3, 84);
            label7.Name = "label7";
            label7.Size = new Size(174, 27);
            label7.TabIndex = 16;
            label7.Text = "Статус:";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 54);
            label6.Name = "label6";
            label6.Size = new Size(174, 30);
            label6.TabIndex = 14;
            label6.Text = "Тип персонажа:";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 27);
            label5.Name = "label5";
            label5.Size = new Size(174, 27);
            label5.TabIndex = 13;
            label5.Text = "UID:";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // playerCounter
            // 
            playerCounter.Location = new Point(12, 693);
            playerCounter.Name = "playerCounter";
            playerCounter.Size = new Size(361, 18);
            playerCounter.TabIndex = 9;
            playerCounter.Text = "Записей:";
            // 
            // PlayerEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(playerCounter);
            Controls.Add(groupBox2);
            Controls.Add(playersListBox);
            Controls.Add(groupBox1);
            Controls.Add(searchPlayerButton);
            Controls.Add(label2);
            Controls.Add(searchPlayer);
            Controls.Add(label1);
            Name = "PlayerEditor";
            Size = new Size(1397, 798);
            groupBox1.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox searchPlayer;
        private Label label2;
        private Button searchPlayerButton;
        private GroupBox groupBox1;
        private Button exportDuplicatesButton;
        private Label label4;
        private Label label3;
        private TreeView dupeInventory;
        private TreeView playerInventory;
        private Button deleteCharFromDBButton;
        private Button cleanInventoryButton;
        private Button deleteDuplicatesButton;
        private ListBox playersListBox;
        private GroupBox groupBox2;
        private TextBox playerUID;
        private TextBox playerChartype;
        private Label label6;
        private Label label5;
        private Label playerStatus;
        private Label label7;
        private Label playerCounter;
        private Button clearDuplicatesListButton;
        private Button searchDuplicatesButton;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox playerDbId;
        private Label label8;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem copyAsIntArrayMenuItem1;
        private ToolStripMenuItem copyParentUIDMenuItem;
    }
}
