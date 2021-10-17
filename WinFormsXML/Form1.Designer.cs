
namespace WinFormsXML
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btGet = new System.Windows.Forms.Button();
            this.btRead = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 46);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(643, 234);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // btGet
            // 
            this.btGet.Location = new System.Drawing.Point(24, 9);
            this.btGet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(276, 22);
            this.btGet.TabIndex = 1;
            this.btGet.Text = "Получить данные из XML и записать в БД";
            this.btGet.UseVisualStyleBackColor = true;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // btRead
            // 
            this.btRead.Location = new System.Drawing.Point(305, 9);
            this.btRead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btRead.Name = "btRead";
            this.btRead.Size = new System.Drawing.Size(181, 22);
            this.btRead.TabIndex = 2;
            this.btRead.Text = "Загрузить данные из БД";
            this.btRead.UseVisualStyleBackColor = true;
            this.btRead.Click += new System.EventHandler(this.btRead_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(492, 9);
            this.btSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(175, 22);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "Сохранить в БД";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btInfo
            // 
            this.btInfo.BackColor = System.Drawing.Color.BurlyWood;
            this.btInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btInfo.ForeColor = System.Drawing.Color.Blue;
            this.btInfo.Location = new System.Drawing.Point(0, 305);
            this.btInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btInfo.Name = "btInfo";
            this.btInfo.Size = new System.Drawing.Size(700, 33);
            this.btInfo.TabIndex = 4;
            this.btInfo.Text = "info";
            this.btInfo.UseVisualStyleBackColor = false;
            this.btInfo.Click += new System.EventHandler(this.btInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.btInfo);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btRead);
            this.Controls.Add(this.btGet);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Загрузка клиентов в БД. Тестовое задание.";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.Button btRead;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btInfo;
    }
}

