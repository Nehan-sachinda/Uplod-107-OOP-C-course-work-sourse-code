namespace POSsystem
{
    partial class Bill
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAddToBill;
        private System.Windows.Forms.DataGridView dgvBill;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnClearBill;
        private System.Windows.Forms.Button btnPrintBill;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAddToBill = new System.Windows.Forms.Button();
            this.dgvBill = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnClearBill = new System.Windows.Forms.Button();
            this.btnPrintBill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            this.SuspendLayout();

            // 
            // cmbProducts
            // 
            this.cmbProducts.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Location = new System.Drawing.Point(30, 30);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(200, 25);
            this.cmbProducts.TabIndex = 0;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtQuantity.Location = new System.Drawing.Point(250, 30);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 25);
            this.txtQuantity.TabIndex = 1;
            // 
            // btnAddToBill
            // 
            this.btnAddToBill.BackColor = System.Drawing.Color.DarkGreen;
            this.btnAddToBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToBill.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddToBill.ForeColor = System.Drawing.Color.White;
            this.btnAddToBill.Location = new System.Drawing.Point(370, 30);
            this.btnAddToBill.Name = "btnAddToBill";
            this.btnAddToBill.Size = new System.Drawing.Size(100, 30);
            this.btnAddToBill.TabIndex = 2;
            this.btnAddToBill.Text = "Add to Bill";
            this.btnAddToBill.UseVisualStyleBackColor = false;
            this.btnAddToBill.Click += new System.EventHandler(this.btnAddToBill_Click);
            // 
            // dgvBill
            // 
            this.dgvBill.AllowUserToAddRows = false;
            this.dgvBill.AllowUserToDeleteRows = false;
            this.dgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Product", Name = "Product", ReadOnly = true },
            new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Quantity", Name = "Quantity", ReadOnly = true },
            new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Price", Name = "Price", ReadOnly = true },
            new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Line Total", Name = "LineTotal", ReadOnly = true }
            });
            this.dgvBill.Location = new System.Drawing.Point(30, 80);
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.ReadOnly = true;
            this.dgvBill.Size = new System.Drawing.Size(500, 200);
            this.dgvBill.TabIndex = 3;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(30, 300);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(84, 21);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total: $0.00";
            // 
            // btnClearBill
            // 
            this.btnClearBill.BackColor = System.Drawing.Color.DarkOrange;
            this.btnClearBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearBill.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearBill.ForeColor = System.Drawing.Color.White;
            this.btnClearBill.Location = new System.Drawing.Point(370, 300);
            this.btnClearBill.Name = "btnClearBill";
            this.btnClearBill.Size = new System.Drawing.Size(100, 30);
            this.btnClearBill.TabIndex = 5;
            this.btnClearBill.Text = "Clear Bill";
            this.btnClearBill.UseVisualStyleBackColor = false;
            this.btnClearBill.Click += new System.EventHandler(this.btnClearBill_Click);
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.BackColor = System.Drawing.Color.Maroon;
            this.btnPrintBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBill.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrintBill.ForeColor = System.Drawing.Color.White;
            this.btnPrintBill.Location = new System.Drawing.Point(480, 300);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(100, 30);
            this.btnPrintBill.TabIndex = 6;
            this.btnPrintBill.Text = "Print Bill";
            this.btnPrintBill.UseVisualStyleBackColor = false;
            this.btnPrintBill.Click += new System.EventHandler(this.btnPrintBill_Click);
            // 
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.btnPrintBill);
            this.Controls.Add(this.btnClearBill);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvBill);
            this.Controls.Add(this.btnAddToBill);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.cmbProducts);
            this.Name = "BillForm";
            this.Text = "Billing";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
