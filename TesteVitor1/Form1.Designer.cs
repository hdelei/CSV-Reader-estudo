namespace TesteVitor1
{
    partial class MainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt = new System.Windows.Forms.TextBox();
            this.myButton = new System.Windows.Forms.Button();
            this.labelSub = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.broupBoxSourceData = new System.Windows.Forms.GroupBox();
            this.groupBoxAverageData = new System.Windows.Forms.GroupBox();
            this.dgvAverage = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.broupBoxSourceData.SuspendLayout();
            this.groupBoxAverageData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAverage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.BackColor = System.Drawing.Color.Black;
            this.txt.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.ForeColor = System.Drawing.Color.Lime;
            this.txt.Location = new System.Drawing.Point(20, 21);
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(283, 502);
            this.txt.TabIndex = 0;
            // 
            // myButton
            // 
            this.myButton.Enabled = false;
            this.myButton.Location = new System.Drawing.Point(12, 569);
            this.myButton.Name = "myButton";
            this.myButton.Size = new System.Drawing.Size(322, 23);
            this.myButton.TabIndex = 1;
            this.myButton.Text = "Import CSV";
            this.myButton.UseVisualStyleBackColor = true;
            this.myButton.Click += new System.EventHandler(this.MyButton_Click);
            // 
            // labelSub
            // 
            this.labelSub.AutoSize = true;
            this.labelSub.Location = new System.Drawing.Point(18, 608);
            this.labelSub.Name = "labelSub";
            this.labelSub.Size = new System.Drawing.Size(107, 13);
            this.labelSub.TabIndex = 2;
            this.labelSub.Text = "Import data from CSV";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.Black;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(16, 21);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.Size = new System.Drawing.Size(416, 232);
            this.dgvData.TabIndex = 3;
            this.dgvData.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvData_DataBindingComplete);
            // 
            // broupBoxSourceData
            // 
            this.broupBoxSourceData.Controls.Add(this.dgvData);
            this.broupBoxSourceData.Location = new System.Drawing.Point(353, 12);
            this.broupBoxSourceData.Name = "broupBoxSourceData";
            this.broupBoxSourceData.Size = new System.Drawing.Size(447, 266);
            this.broupBoxSourceData.TabIndex = 4;
            this.broupBoxSourceData.TabStop = false;
            this.broupBoxSourceData.Text = "Original Data";
            // 
            // groupBoxAverageData
            // 
            this.groupBoxAverageData.Controls.Add(this.dgvAverage);
            this.groupBoxAverageData.Location = new System.Drawing.Point(353, 284);
            this.groupBoxAverageData.Name = "groupBoxAverageData";
            this.groupBoxAverageData.Size = new System.Drawing.Size(447, 266);
            this.groupBoxAverageData.TabIndex = 5;
            this.groupBoxAverageData.TabStop = false;
            this.groupBoxAverageData.Text = "Average";
            // 
            // dgvAverage
            // 
            this.dgvAverage.AllowUserToAddRows = false;
            this.dgvAverage.AllowUserToDeleteRows = false;
            this.dgvAverage.BackgroundColor = System.Drawing.Color.Black;
            this.dgvAverage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAverage.Location = new System.Drawing.Point(16, 19);
            this.dgvAverage.Name = "dgvAverage";
            this.dgvAverage.ReadOnly = true;
            this.dgvAverage.Size = new System.Drawing.Size(416, 232);
            this.dgvAverage.TabIndex = 3;
            this.dgvAverage.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAverage_DataBindingComplete);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 538);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "JSON";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(655, 569);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Select File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileBox
            // 
            this.fileBox.Location = new System.Drawing.Point(353, 571);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(296, 20);
            this.fileBox.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 646);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxAverageData);
            this.Controls.Add(this.broupBoxSourceData);
            this.Controls.Add(this.labelSub);
            this.Controls.Add(this.myButton);
            this.Name = "MainForm";
            this.Text = "My Test";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.broupBoxSourceData.ResumeLayout(false);
            this.groupBoxAverageData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAverage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.Button myButton;
        private System.Windows.Forms.Label labelSub;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox broupBoxSourceData;
        private System.Windows.Forms.GroupBox groupBoxAverageData;
        private System.Windows.Forms.DataGridView dgvAverage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox fileBox;
    }
}

