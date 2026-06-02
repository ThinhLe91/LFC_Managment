namespace LFC_Management.WinForm
{
    partial class FormAddMember
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            numBirth = new NumericUpDown();
            chkIsDead = new CheckBox();
            numDeath = new NumericUpDown();
            txtNationality = new TextBox();
            txtRole = new TextBox();
            txtPosition = new TextBox();
            txtFoot = new TextBox();
            numFrom = new NumericUpDown();
            numTo = new NumericUpDown();
            btnSave = new Button();
            chkInOutContract = new CheckBox();
            label1 = new Label();
            labBirth = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)numBirth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDeath).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTo).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(99, 68);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 0;
            // 
            // numBirth
            // 
            numBirth.Location = new Point(293, 72);
            numBirth.Maximum = new decimal(new int[] { 2026, 0, 0, 0 });
            numBirth.Minimum = new decimal(new int[] { 1800, 0, 0, 0 });
            numBirth.Name = "numBirth";
            numBirth.Size = new Size(120, 23);
            numBirth.TabIndex = 1;
            numBirth.Value = new decimal(new int[] { 1800, 0, 0, 0 });
            // 
            // chkIsDead
            // 
            chkIsDead.AutoSize = true;
            chkIsDead.Location = new Point(455, 72);
            chkIsDead.Name = "chkIsDead";
            chkIsDead.Size = new Size(62, 19);
            chkIsDead.TabIndex = 2;
            chkIsDead.Text = "Death?";
            chkIsDead.UseVisualStyleBackColor = true;
            // 
            // numDeath
            // 
            numDeath.Location = new Point(637, 70);
            numDeath.Maximum = new decimal(new int[] { 2026, 0, 0, 0 });
            numDeath.Minimum = new decimal(new int[] { 1800, 0, 0, 0 });
            numDeath.Name = "numDeath";
            numDeath.Size = new Size(120, 23);
            numDeath.TabIndex = 3;
            numDeath.Value = new decimal(new int[] { 1800, 0, 0, 0 });
            // 
            // txtNationality
            // 
            txtNationality.Location = new Point(99, 131);
            txtNationality.Name = "txtNationality";
            txtNationality.Size = new Size(100, 23);
            txtNationality.TabIndex = 4;
            // 
            // txtRole
            // 
            txtRole.Location = new Point(293, 131);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(100, 23);
            txtRole.TabIndex = 5;
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(455, 131);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(100, 23);
            txtPosition.TabIndex = 6;
            // 
            // txtFoot
            // 
            txtFoot.Location = new Point(683, 128);
            txtFoot.Name = "txtFoot";
            txtFoot.Size = new Size(100, 23);
            txtFoot.TabIndex = 7;
            // 
            // numFrom
            // 
            numFrom.Location = new Point(293, 197);
            numFrom.Maximum = new decimal(new int[] { 2026, 0, 0, 0 });
            numFrom.Minimum = new decimal(new int[] { 1800, 0, 0, 0 });
            numFrom.Name = "numFrom";
            numFrom.Size = new Size(120, 23);
            numFrom.TabIndex = 8;
            numFrom.Value = new decimal(new int[] { 1800, 0, 0, 0 });
            // 
            // numTo
            // 
            numTo.Location = new Point(637, 197);
            numTo.Maximum = new decimal(new int[] { 2026, 0, 0, 0 });
            numTo.Minimum = new decimal(new int[] { 1800, 0, 0, 0 });
            numTo.Name = "numTo";
            numTo.Size = new Size(120, 23);
            numTo.TabIndex = 9;
            numTo.Value = new decimal(new int[] { 1800, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.Location = new Point(371, 301);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // chkInOutContract
            // 
            chkInOutContract.AutoSize = true;
            chkInOutContract.Location = new Point(455, 201);
            chkInOutContract.Name = "chkInOutContract";
            chkInOutContract.Size = new Size(90, 19);
            chkInOutContract.TabIndex = 11;
            chkInOutContract.Text = "In Contract?";
            chkInOutContract.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 72);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 12;
            label1.Text = "Name";
            // 
            // labBirth
            // 
            labBirth.AutoSize = true;
            labBirth.Location = new Point(248, 74);
            labBirth.Name = "labBirth";
            labBirth.Size = new Size(32, 15);
            labBirth.TabIndex = 13;
            labBirth.Text = "Birth";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(599, 72);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 14;
            label2.Text = "Death";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 134);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 15;
            label3.Text = "Nationality";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(248, 134);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 16;
            label4.Text = "Role";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(410, 134);
            label5.Name = "label5";
            label5.Size = new Size(26, 15);
            label5.TabIndex = 17;
            label5.Text = "Pos";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(592, 131);
            label6.Name = "label6";
            label6.Size = new Size(85, 15);
            label6.TabIndex = 18;
            label6.Text = "Favorable Foot";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(248, 202);
            label7.Name = "label7";
            label7.Size = new Size(35, 15);
            label7.TabIndex = 19;
            label7.Text = "From";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(592, 201);
            label8.Name = "label8";
            label8.Size = new Size(19, 15);
            label8.TabIndex = 20;
            label8.Text = "To";
            // 
            // FormAddMember
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(labBirth);
            Controls.Add(label1);
            Controls.Add(chkInOutContract);
            Controls.Add(btnSave);
            Controls.Add(numTo);
            Controls.Add(numFrom);
            Controls.Add(txtFoot);
            Controls.Add(txtPosition);
            Controls.Add(txtRole);
            Controls.Add(txtNationality);
            Controls.Add(numDeath);
            Controls.Add(chkIsDead);
            Controls.Add(numBirth);
            Controls.Add(txtName);
            Name = "FormAddMember";
            Text = "FormAddMember";
            ((System.ComponentModel.ISupportInitialize)numBirth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDeath).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private NumericUpDown numBirth;
        private CheckBox chkIsDead;
        private NumericUpDown numDeath;
        private TextBox txtNationality;
        private TextBox txtRole;
        private TextBox txtPosition;
        private TextBox txtFoot;
        private NumericUpDown numFrom;
        private NumericUpDown numTo;
        private Button btnSave;
        private CheckBox chkInOutContract;
        private Label label1;
        private Label labBirth;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}