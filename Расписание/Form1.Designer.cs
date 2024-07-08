namespace Расписание
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FlowLayoutPanel flowLayoutPanel1;
            GroupBox groupBox1;
            FlowLayoutPanel flowLayoutPanel2;
            GroupBox groupBox2;
            Label label2;
            Label label1;
            rbtnGroup = new RadioButton();
            rbtnTeacher = new RadioButton();
            rbtnRoom = new RadioButton();
            flowLayoutPanel3 = new FlowLayoutPanel();
            radioButton1 = new RadioButton();
            dateOneDay = new DateTimePicker();
            radioButton2 = new RadioButton();
            datePeriodFrom = new DateTimePicker();
            datePeriodUntill = new DateTimePicker();
            grGroups = new GroupBox();
            flowLayoutPanel4 = new FlowLayoutPanel();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            listGroups = new CheckedListBox();
            grTeachers = new GroupBox();
            flowLayoutPanel5 = new FlowLayoutPanel();
            radioButton5 = new RadioButton();
            radioButton6 = new RadioButton();
            listTeachers = new CheckedListBox();
            grRooms = new GroupBox();
            flowLayoutPanel6 = new FlowLayoutPanel();
            radioButton7 = new RadioButton();
            radioButton8 = new RadioButton();
            listRooms = new CheckedListBox();
            btnResult = new Button();
            label3 = new Label();
            menuStrip1 = new MenuStrip();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            groupBox2 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            flowLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            grGroups.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            grTeachers.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            grRooms.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = SystemColors.ControlLightLight;
            flowLayoutPanel1.Controls.Add(groupBox1);
            flowLayoutPanel1.Controls.Add(groupBox2);
            flowLayoutPanel1.Controls.Add(grGroups);
            flowLayoutPanel1.Controls.Add(grTeachers);
            flowLayoutPanel1.Controls.Add(grRooms);
            flowLayoutPanel1.Controls.Add(btnResult);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 37);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(20);
            flowLayoutPanel1.Size = new Size(1116, 772);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ControlLightLight;
            groupBox1.Controls.Add(flowLayoutPanel2);
            groupBox1.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(23, 23);
            groupBox1.Margin = new Padding(3, 3, 20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(331, 189);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Выгрузить расписание по:";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Controls.Add(rbtnGroup);
            flowLayoutPanel2.Controls.Add(rbtnTeacher);
            flowLayoutPanel2.Controls.Add(rbtnRoom);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(3, 26);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(10);
            flowLayoutPanel2.Size = new Size(325, 160);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // rbtnGroup
            // 
            rbtnGroup.AutoSize = true;
            rbtnGroup.Location = new Point(13, 13);
            rbtnGroup.Margin = new Padding(3, 3, 3, 10);
            rbtnGroup.Name = "rbtnGroup";
            rbtnGroup.Size = new Size(106, 27);
            rbtnGroup.TabIndex = 0;
            rbtnGroup.Text = "группам";
            rbtnGroup.UseVisualStyleBackColor = true;
            rbtnGroup.CheckedChanged += rbtnGroup_CheckedChanged;
            // 
            // rbtnTeacher
            // 
            rbtnTeacher.AutoSize = true;
            rbtnTeacher.Location = new Point(13, 53);
            rbtnTeacher.Margin = new Padding(3, 3, 3, 10);
            rbtnTeacher.Name = "rbtnTeacher";
            rbtnTeacher.Size = new Size(181, 27);
            rbtnTeacher.TabIndex = 1;
            rbtnTeacher.Text = "преподавателям";
            rbtnTeacher.UseVisualStyleBackColor = true;
            rbtnTeacher.CheckedChanged += rbtnTeacher_CheckedChanged;
            // 
            // rbtnRoom
            // 
            rbtnRoom.AutoSize = true;
            rbtnRoom.Location = new Point(13, 93);
            rbtnRoom.Name = "rbtnRoom";
            rbtnRoom.Size = new Size(138, 27);
            rbtnRoom.TabIndex = 2;
            rbtnRoom.Text = "аудиториям";
            rbtnRoom.UseVisualStyleBackColor = true;
            rbtnRoom.CheckedChanged += rbtnRoom_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.ControlLightLight;
            groupBox2.Controls.Add(flowLayoutPanel3);
            groupBox2.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox2.Location = new Point(377, 23);
            groupBox2.Margin = new Padding(3, 3, 3, 20);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(510, 189);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.Controls.Add(radioButton1);
            flowLayoutPanel3.Controls.Add(dateOneDay);
            flowLayoutPanel3.Controls.Add(radioButton2);
            flowLayoutPanel3.Controls.Add(label2);
            flowLayoutPanel3.Controls.Add(datePeriodFrom);
            flowLayoutPanel3.Controls.Add(label1);
            flowLayoutPanel3.Controls.Add(datePeriodUntill);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(3, 26);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Padding = new Padding(10);
            flowLayoutPanel3.Size = new Size(504, 160);
            flowLayoutPanel3.TabIndex = 0;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(13, 13);
            radioButton1.Margin = new Padding(3, 3, 10, 20);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(79, 27);
            radioButton1.TabIndex = 0;
            radioButton1.Text = "Дата:";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // dateOneDay
            // 
            dateOneDay.Enabled = false;
            dateOneDay.Location = new Point(105, 13);
            dateOneDay.Margin = new Padding(3, 3, 100, 3);
            dateOneDay.Name = "dateOneDay";
            dateOneDay.Size = new Size(200, 30);
            dateOneDay.TabIndex = 0;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(13, 63);
            radioButton2.Margin = new Padding(3, 3, 360, 20);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(118, 27);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "В период:";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 116);
            label2.Margin = new Padding(3, 6, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(18, 23);
            label2.TabIndex = 5;
            label2.Text = "с";
            // 
            // datePeriodFrom
            // 
            datePeriodFrom.Enabled = false;
            datePeriodFrom.Location = new Point(37, 113);
            datePeriodFrom.Name = "datePeriodFrom";
            datePeriodFrom.Size = new Size(200, 30);
            datePeriodFrom.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(243, 116);
            label1.Margin = new Padding(3, 6, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(32, 23);
            label1.TabIndex = 4;
            label1.Text = "по";
            // 
            // datePeriodUntill
            // 
            datePeriodUntill.Enabled = false;
            datePeriodUntill.Location = new Point(281, 113);
            datePeriodUntill.Name = "datePeriodUntill";
            datePeriodUntill.Size = new Size(200, 30);
            datePeriodUntill.TabIndex = 3;
            // 
            // grGroups
            // 
            grGroups.BackColor = Color.Transparent;
            grGroups.Controls.Add(flowLayoutPanel4);
            grGroups.Enabled = false;
            grGroups.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            grGroups.Location = new Point(23, 235);
            grGroups.Margin = new Padding(3, 3, 20, 10);
            grGroups.Name = "grGroups";
            grGroups.Size = new Size(250, 465);
            grGroups.TabIndex = 2;
            grGroups.TabStop = false;
            grGroups.Text = "Группы:";
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.AutoSize = true;
            flowLayoutPanel4.Controls.Add(radioButton3);
            flowLayoutPanel4.Controls.Add(radioButton4);
            flowLayoutPanel4.Controls.Add(listGroups);
            flowLayoutPanel4.Dock = DockStyle.Fill;
            flowLayoutPanel4.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel4.Location = new Point(3, 26);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Padding = new Padding(10);
            flowLayoutPanel4.Size = new Size(244, 436);
            flowLayoutPanel4.TabIndex = 0;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(13, 13);
            radioButton3.Margin = new Padding(3, 3, 3, 10);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(56, 27);
            radioButton3.TabIndex = 0;
            radioButton3.TabStop = true;
            radioButton3.Text = "все";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(13, 53);
            radioButton4.Margin = new Padding(3, 3, 3, 10);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(103, 27);
            radioButton4.TabIndex = 1;
            radioButton4.TabStop = true;
            radioButton4.Text = "выбрать";
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.CheckedChanged += radioButton4_CheckedChanged;
            // 
            // listGroups
            // 
            listGroups.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listGroups.Enabled = false;
            listGroups.FormattingEnabled = true;
            listGroups.Location = new Point(13, 93);
            listGroups.Name = "listGroups";
            listGroups.Size = new Size(218, 329);
            listGroups.TabIndex = 3;
            // 
            // grTeachers
            // 
            grTeachers.BackColor = Color.Transparent;
            grTeachers.Controls.Add(flowLayoutPanel5);
            grTeachers.Enabled = false;
            grTeachers.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            grTeachers.Location = new Point(296, 235);
            grTeachers.Margin = new Padding(3, 3, 20, 10);
            grTeachers.Name = "grTeachers";
            grTeachers.Size = new Size(500, 465);
            grTeachers.TabIndex = 3;
            grTeachers.TabStop = false;
            grTeachers.Text = "Преподаватели:";
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.AutoSize = true;
            flowLayoutPanel5.Controls.Add(radioButton5);
            flowLayoutPanel5.Controls.Add(radioButton6);
            flowLayoutPanel5.Controls.Add(listTeachers);
            flowLayoutPanel5.Dock = DockStyle.Fill;
            flowLayoutPanel5.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel5.Location = new Point(3, 26);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Padding = new Padding(10);
            flowLayoutPanel5.Size = new Size(494, 436);
            flowLayoutPanel5.TabIndex = 0;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(13, 13);
            radioButton5.Margin = new Padding(3, 3, 3, 10);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(56, 27);
            radioButton5.TabIndex = 0;
            radioButton5.TabStop = true;
            radioButton5.Text = "все";
            radioButton5.UseVisualStyleBackColor = true;
            radioButton5.CheckedChanged += radioButton5_CheckedChanged;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(13, 53);
            radioButton6.Margin = new Padding(3, 3, 3, 10);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(103, 27);
            radioButton6.TabIndex = 1;
            radioButton6.TabStop = true;
            radioButton6.Text = "выбрать";
            radioButton6.UseVisualStyleBackColor = true;
            radioButton6.CheckedChanged += radioButton6_CheckedChanged;
            // 
            // listTeachers
            // 
            listTeachers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listTeachers.Enabled = false;
            listTeachers.FormattingEnabled = true;
            listTeachers.Location = new Point(13, 93);
            listTeachers.Name = "listTeachers";
            listTeachers.Size = new Size(469, 329);
            listTeachers.TabIndex = 3;
            // 
            // grRooms
            // 
            grRooms.BackColor = Color.Transparent;
            grRooms.Controls.Add(flowLayoutPanel6);
            grRooms.Enabled = false;
            grRooms.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            grRooms.Location = new Point(819, 235);
            grRooms.Margin = new Padding(3, 3, 0, 10);
            grRooms.Name = "grRooms";
            grRooms.Size = new Size(250, 465);
            grRooms.TabIndex = 4;
            grRooms.TabStop = false;
            grRooms.Text = "Аудитории:";
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.AutoSize = true;
            flowLayoutPanel6.Controls.Add(radioButton7);
            flowLayoutPanel6.Controls.Add(radioButton8);
            flowLayoutPanel6.Controls.Add(listRooms);
            flowLayoutPanel6.Dock = DockStyle.Fill;
            flowLayoutPanel6.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel6.Location = new Point(3, 26);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Padding = new Padding(10);
            flowLayoutPanel6.Size = new Size(244, 436);
            flowLayoutPanel6.TabIndex = 0;
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.Location = new Point(13, 13);
            radioButton7.Margin = new Padding(3, 3, 3, 10);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new Size(56, 27);
            radioButton7.TabIndex = 0;
            radioButton7.TabStop = true;
            radioButton7.Text = "все";
            radioButton7.UseVisualStyleBackColor = true;
            radioButton7.CheckedChanged += radioButton7_CheckedChanged;
            // 
            // radioButton8
            // 
            radioButton8.AutoSize = true;
            radioButton8.Location = new Point(13, 53);
            radioButton8.Margin = new Padding(3, 3, 3, 10);
            radioButton8.Name = "radioButton8";
            radioButton8.Size = new Size(103, 27);
            radioButton8.TabIndex = 1;
            radioButton8.TabStop = true;
            radioButton8.Text = "выбрать";
            radioButton8.UseVisualStyleBackColor = true;
            radioButton8.CheckedChanged += radioButton8_CheckedChanged;
            // 
            // listRooms
            // 
            listRooms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listRooms.Enabled = false;
            listRooms.FormattingEnabled = true;
            listRooms.Location = new Point(13, 93);
            listRooms.Name = "listRooms";
            listRooms.Size = new Size(217, 329);
            listRooms.TabIndex = 3;
            // 
            // btnResult
            // 
            btnResult.AutoSize = true;
            btnResult.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnResult.Location = new Point(23, 720);
            btnResult.Margin = new Padding(3, 10, 3, 3);
            btnResult.Name = "btnResult";
            btnResult.Size = new Size(118, 33);
            btnResult.TabIndex = 3;
            btnResult.Text = "Выгрузить";
            btnResult.UseVisualStyleBackColor = true;
            btnResult.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(147, 718);
            label3.Margin = new Padding(3, 8, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 23);
            label3.TabIndex = 6;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(234, 234, 234);
            menuStrip1.Items.AddRange(new ToolStripItem[] { оПрограммеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5);
            menuStrip1.Size = new Size(1116, 37);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(142, 27);
            оПрограммеToolStripMenuItem.Text = "О программе";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 809);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form1_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            grGroups.ResumeLayout(false);
            grGroups.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            grTeachers.ResumeLayout(false);
            grTeachers.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            grRooms.ResumeLayout(false);
            grRooms.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private RadioButton rbtnGroup;
        private RadioButton rbtnTeacher;
        private RadioButton rbtnRoom;
        private FlowLayoutPanel flowLayoutPanel3;
        private DateTimePicker dateOneDay;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private DateTimePicker datePeriodFrom;
        private DateTimePicker datePeriodUntill;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private GroupBox grGroups;
        private CheckedListBox listGroups;
        private Button btnResult;
        private GroupBox grTeachers;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private CheckedListBox listTeachers;
        private GroupBox grRooms;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private CheckedListBox listRooms;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel5;
        private FlowLayoutPanel flowLayoutPanel6;
        private Label label3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
    }
}
