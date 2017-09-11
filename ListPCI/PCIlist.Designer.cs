namespace ListPCI
{
    partial class Pcilist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pcilist));
            this.ID_List = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ID_List
            // 
            this.ID_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ID_List.FormattingEnabled = true;
            this.ID_List.HorizontalScrollbar = true;
            this.ID_List.ItemHeight = 16;
            this.ID_List.Location = new System.Drawing.Point(0, 0);
            this.ID_List.Name = "ID_List";
            this.ID_List.Size = new System.Drawing.Size(1116, 389);
            this.ID_List.TabIndex = 2;
            // 
            // Pcilist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 389);
            this.Controls.Add(this.ID_List);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pcilist";
            this.Text = "PCI devices list";
            this.Load += new System.EventHandler(this.Pcilist_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ID_List;
    }
}

