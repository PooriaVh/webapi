namespace CallApiiWithWinForm
{
    partial class Form1
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
            this.dgp_product = new System.Windows.Forms.DataGridView();
            this.Search = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgp_product)).BeginInit();
            this.SuspendLayout();
            // 
            // dgp_product
            // 
            this.dgp_product.AccessibleName = "grid_product";
            this.dgp_product.AllowUserToAddRows = false;
            this.dgp_product.AllowUserToDeleteRows = false;
            this.dgp_product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgp_product.Location = new System.Drawing.Point(12, 96);
            this.dgp_product.Name = "dgp_product";
            this.dgp_product.ReadOnly = true;
            this.dgp_product.RowHeadersWidth = 51;
            this.dgp_product.RowTemplate.Height = 24;
            this.dgp_product.Size = new System.Drawing.Size(763, 342);
            this.dgp_product.TabIndex = 0;
            // 
            // Search
            // 
            this.Search.AccessibleName = "btn_search";
            this.Search.Location = new System.Drawing.Point(641, 40);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(134, 40);
            this.Search.TabIndex = 1;
            this.Search.Text = "Seach";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(473, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "Create Factor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.dgp_product);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgp_product)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgp_product;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button button1;
    }
}

