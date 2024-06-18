namespace AgainCalc
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.expressionLbl = new System.Windows.Forms.Label();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.zeroBtn = new System.Windows.Forms.Button();
            this.oneBtn = new System.Windows.Forms.Button();
            this.twoBtn = new System.Windows.Forms.Button();
            this.threeBtn = new System.Windows.Forms.Button();
            this.fourBtn = new System.Windows.Forms.Button();
            this.sevenBtn = new System.Windows.Forms.Button();
            this.fiveBtn = new System.Windows.Forms.Button();
            this.eightBtn = new System.Windows.Forms.Button();
            this.nineBtn = new System.Windows.Forms.Button();
            this.sixBtn = new System.Windows.Forms.Button();
            this.minusBtn = new System.Windows.Forms.Button();
            this.plusBtn = new System.Windows.Forms.Button();
            this.multBtn = new System.Windows.Forms.Button();
            this.divBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(601, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(601, 625);
            this.splitContainer1.SplitterDistance = 137;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.expressionLbl, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.inputBox, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.48148F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.51852F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(599, 135);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // expressionLbl
            // 
            this.expressionLbl.AutoSize = true;
            this.expressionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expressionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expressionLbl.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.expressionLbl.Location = new System.Drawing.Point(3, 0);
            this.expressionLbl.Name = "expressionLbl";
            this.expressionLbl.Size = new System.Drawing.Size(593, 28);
            this.expressionLbl.TabIndex = 0;
            this.expressionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // inputBox
            // 
            this.inputBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.inputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputBox.Location = new System.Drawing.Point(3, 31);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(593, 64);
            this.inputBox.TabIndex = 1;
            this.inputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inputBox.WordWrap = false;
            this.inputBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.zeroBtn, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.oneBtn, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.twoBtn, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.threeBtn, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.fourBtn, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.sevenBtn, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.fiveBtn, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.eightBtn, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.nineBtn, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.sixBtn, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.minusBtn, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.plusBtn, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.multBtn, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.divBtn, 4, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(599, 482);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // zeroBtn
            // 
            this.zeroBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.zeroBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zeroBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zeroBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zeroBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.zeroBtn.Location = new System.Drawing.Point(241, 411);
            this.zeroBtn.Name = "zeroBtn";
            this.zeroBtn.Size = new System.Drawing.Size(113, 68);
            this.zeroBtn.TabIndex = 0;
            this.zeroBtn.Text = "0";
            this.zeroBtn.UseVisualStyleBackColor = false;
            // 
            // oneBtn
            // 
            this.oneBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.oneBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oneBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.oneBtn.Location = new System.Drawing.Point(122, 343);
            this.oneBtn.Name = "oneBtn";
            this.oneBtn.Size = new System.Drawing.Size(113, 62);
            this.oneBtn.TabIndex = 1;
            this.oneBtn.Text = "1";
            this.oneBtn.UseVisualStyleBackColor = false;
            // 
            // twoBtn
            // 
            this.twoBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.twoBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.twoBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.twoBtn.Location = new System.Drawing.Point(241, 343);
            this.twoBtn.Name = "twoBtn";
            this.twoBtn.Size = new System.Drawing.Size(113, 62);
            this.twoBtn.TabIndex = 2;
            this.twoBtn.Text = "2";
            this.twoBtn.UseVisualStyleBackColor = false;
            // 
            // threeBtn
            // 
            this.threeBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.threeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.threeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.threeBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.threeBtn.Location = new System.Drawing.Point(360, 343);
            this.threeBtn.Name = "threeBtn";
            this.threeBtn.Size = new System.Drawing.Size(113, 62);
            this.threeBtn.TabIndex = 3;
            this.threeBtn.Text = "3";
            this.threeBtn.UseVisualStyleBackColor = false;
            // 
            // fourBtn
            // 
            this.fourBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.fourBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fourBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fourBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fourBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fourBtn.Location = new System.Drawing.Point(122, 275);
            this.fourBtn.Name = "fourBtn";
            this.fourBtn.Size = new System.Drawing.Size(113, 62);
            this.fourBtn.TabIndex = 4;
            this.fourBtn.Text = "4";
            this.fourBtn.UseVisualStyleBackColor = false;
            // 
            // sevenBtn
            // 
            this.sevenBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sevenBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sevenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sevenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sevenBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.sevenBtn.Location = new System.Drawing.Point(122, 207);
            this.sevenBtn.Name = "sevenBtn";
            this.sevenBtn.Size = new System.Drawing.Size(113, 62);
            this.sevenBtn.TabIndex = 5;
            this.sevenBtn.Text = "7";
            this.sevenBtn.UseVisualStyleBackColor = false;
            // 
            // fiveBtn
            // 
            this.fiveBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.fiveBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fiveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fiveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fiveBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fiveBtn.Location = new System.Drawing.Point(241, 275);
            this.fiveBtn.Name = "fiveBtn";
            this.fiveBtn.Size = new System.Drawing.Size(113, 62);
            this.fiveBtn.TabIndex = 6;
            this.fiveBtn.Text = "5";
            this.fiveBtn.UseVisualStyleBackColor = false;
            // 
            // eightBtn
            // 
            this.eightBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.eightBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eightBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eightBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eightBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.eightBtn.Location = new System.Drawing.Point(241, 207);
            this.eightBtn.Name = "eightBtn";
            this.eightBtn.Size = new System.Drawing.Size(113, 62);
            this.eightBtn.TabIndex = 7;
            this.eightBtn.Text = "8";
            this.eightBtn.UseVisualStyleBackColor = false;
            // 
            // nineBtn
            // 
            this.nineBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.nineBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nineBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.nineBtn.Location = new System.Drawing.Point(360, 207);
            this.nineBtn.Name = "nineBtn";
            this.nineBtn.Size = new System.Drawing.Size(113, 62);
            this.nineBtn.TabIndex = 8;
            this.nineBtn.Text = "9";
            this.nineBtn.UseVisualStyleBackColor = false;
            // 
            // sixBtn
            // 
            this.sixBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sixBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sixBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sixBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sixBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.sixBtn.Location = new System.Drawing.Point(360, 275);
            this.sixBtn.Name = "sixBtn";
            this.sixBtn.Size = new System.Drawing.Size(113, 62);
            this.sixBtn.TabIndex = 9;
            this.sixBtn.Text = "6";
            this.sixBtn.UseVisualStyleBackColor = false;
            // 
            // minusBtn
            // 
            this.minusBtn.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.minusBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minusBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.minusBtn.Location = new System.Drawing.Point(479, 275);
            this.minusBtn.Name = "minusBtn";
            this.minusBtn.Size = new System.Drawing.Size(117, 62);
            this.minusBtn.TabIndex = 10;
            this.minusBtn.Text = "-";
            this.minusBtn.UseVisualStyleBackColor = false;
            // 
            // plusBtn
            // 
            this.plusBtn.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.plusBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plusBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plusBtn.Location = new System.Drawing.Point(479, 343);
            this.plusBtn.Name = "plusBtn";
            this.plusBtn.Size = new System.Drawing.Size(117, 62);
            this.plusBtn.TabIndex = 11;
            this.plusBtn.Text = "+";
            this.plusBtn.UseVisualStyleBackColor = false;
            // 
            // multBtn
            // 
            this.multBtn.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.multBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.multBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.multBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.multBtn.Location = new System.Drawing.Point(479, 207);
            this.multBtn.Name = "multBtn";
            this.multBtn.Size = new System.Drawing.Size(117, 62);
            this.multBtn.TabIndex = 12;
            this.multBtn.Text = "*";
            this.multBtn.UseVisualStyleBackColor = false;
            // 
            // divBtn
            // 
            this.divBtn.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.divBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.divBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.divBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.divBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.divBtn.Location = new System.Drawing.Point(479, 139);
            this.divBtn.Name = "divBtn";
            this.divBtn.Size = new System.Drawing.Size(117, 62);
            this.divBtn.TabIndex = 13;
            this.divBtn.Text = "/";
            this.divBtn.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 649);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Калькулятор";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label expressionLbl;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button zeroBtn;
        private System.Windows.Forms.Button oneBtn;
        private System.Windows.Forms.Button twoBtn;
        private System.Windows.Forms.Button threeBtn;
        private System.Windows.Forms.Button fourBtn;
        private System.Windows.Forms.Button sevenBtn;
        private System.Windows.Forms.Button fiveBtn;
        private System.Windows.Forms.Button eightBtn;
        private System.Windows.Forms.Button nineBtn;
        private System.Windows.Forms.Button sixBtn;
        private System.Windows.Forms.Button minusBtn;
        private System.Windows.Forms.Button plusBtn;
        private System.Windows.Forms.Button multBtn;
        private System.Windows.Forms.Button divBtn;
    }
}

