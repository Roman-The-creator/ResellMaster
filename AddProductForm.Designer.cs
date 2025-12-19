namespace MyWinFormsApp
{
    public partial class AddProductForm : Form
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
            numUnitPrice = new NumericUpDown();
            cbBrand = new ComboBox();
            cbCategory = new ComboBox();
            btnSave = new Button();
            numQuantity = new NumericUpDown();
            txtSize = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numUnitPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(346, 291);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(110, 23);
            txtName.TabIndex = 0;
            // 
            // numUnitPrice
            // 
            numUnitPrice.DecimalPlaces = 2;
            numUnitPrice.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numUnitPrice.Location = new Point(604, 292);
            numUnitPrice.Margin = new Padding(3, 2, 3, 2);
            numUnitPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numUnitPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numUnitPrice.Name = "numUnitPrice";
            numUnitPrice.Size = new Size(131, 23);
            numUnitPrice.TabIndex = 1;
            numUnitPrice.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cbBrand
            // 
            cbBrand.FormattingEnabled = true;
            cbBrand.Location = new Point(367, 369);
            cbBrand.Margin = new Padding(3, 2, 3, 2);
            cbBrand.Name = "cbBrand";
            cbBrand.Size = new Size(133, 23);
            cbBrand.TabIndex = 2;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(647, 363);
            cbCategory.Margin = new Padding(3, 2, 3, 2);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(133, 23);
            cbCategory.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(542, 463);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 22);
            btnSave.TabIndex = 4;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(142, 290);
            numQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(120, 23);
            numQuantity.TabIndex = 5;
            numQuantity.TextAlign = HorizontalAlignment.Center;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtSize
            // 
            txtSize.Location = new Point(283, 214);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(71, 23);
            txtSize.TabIndex = 6;
            txtSize.Click += btnSave_Click;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1212, 590);
            Controls.Add(txtSize);
            Controls.Add(numQuantity);
            Controls.Add(btnSave);
            Controls.Add(cbCategory);
            Controls.Add(cbBrand);
            Controls.Add(numUnitPrice);
            Controls.Add(txtName);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddProductForm";
            Text = "AddProductForm";
            ((System.ComponentModel.ISupportInitialize)numUnitPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private NumericUpDown numUnitPrice;
        private ComboBox cbBrand;
        private ComboBox cbCategory;
        private Button btnSave;
        private NumericUpDown numQuantity;
        private TextBox txtSize;
    }
}