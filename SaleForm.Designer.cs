namespace MyWinFormsApp
{
    partial class SaleForm
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
            lblSalePrice = new Label();
            numSalePrice = new NumericUpDown();
            cbPlatform = new ComboBox();
            btnConfirm = new Button();
            numPlatformFee = new NumericUpDown();
            lblPlatformFee = new Label();
            lblDeliveryCost = new Label();
            numAdCost = new NumericUpDown();
            lblViews = new Label();
            numViewsCost = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numSalePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPlatformFee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAdCost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numViewsCost).BeginInit();
            SuspendLayout();
            // 
            // lblSalePrice
            // 
            lblSalePrice.AutoSize = true;
            lblSalePrice.Location = new Point(330, 155);
            lblSalePrice.Name = "lblSalePrice";
            lblSalePrice.Size = new Size(134, 15);
            lblSalePrice.TabIndex = 0;
            lblSalePrice.Text = "Введите цену продажи:";
            // 
            // numSalePrice
            // 
            numSalePrice.DecimalPlaces = 2;
            numSalePrice.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numSalePrice.Location = new Point(362, 215);
            numSalePrice.Margin = new Padding(3, 2, 3, 2);
            numSalePrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numSalePrice.Name = "numSalePrice";
            numSalePrice.Size = new Size(131, 23);
            numSalePrice.TabIndex = 1;
            // 
            // cbPlatform
            // 
            cbPlatform.FormattingEnabled = true;
            cbPlatform.Location = new Point(616, 167);
            cbPlatform.Margin = new Padding(3, 2, 3, 2);
            cbPlatform.Name = "cbPlatform";
            cbPlatform.Size = new Size(133, 23);
            cbPlatform.TabIndex = 2;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(660, 208);
            btnConfirm.Margin = new Padding(3, 2, 3, 2);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(103, 22);
            btnConfirm.TabIndex = 3;
            btnConfirm.Text = "Подтвердить";
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // numPlatformFee
            // 
            numPlatformFee.DecimalPlaces = 2;
            numPlatformFee.Location = new Point(922, 144);
            numPlatformFee.Name = "numPlatformFee";
            numPlatformFee.Size = new Size(98, 23);
            numPlatformFee.TabIndex = 4;
            // 
            // lblPlatformFee
            // 
            lblPlatformFee.AutoSize = true;
            lblPlatformFee.Location = new Point(931, 99);
            lblPlatformFee.Name = "lblPlatformFee";
            lblPlatformFee.Size = new Size(78, 15);
            lblPlatformFee.TabIndex = 5;
            lblPlatformFee.Text = "Комиссия, %";
            // 
            // lblDeliveryCost
            // 
            lblDeliveryCost.AutoSize = true;
            lblDeliveryCost.Location = new Point(330, 51);
            lblDeliveryCost.Name = "lblDeliveryCost";
            lblDeliveryCost.Size = new Size(66, 15);
            lblDeliveryCost.TabIndex = 6;
            lblDeliveryCost.Text = "Реклама, ₽";
            // 
            // numAdCost
            // 
            numAdCost.DecimalPlaces = 2;
            numAdCost.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            numAdCost.Location = new Point(325, 85);
            numAdCost.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numAdCost.Name = "numAdCost";
            numAdCost.Size = new Size(84, 23);
            numAdCost.TabIndex = 7;
            // 
            // lblViews
            // 
            lblViews.AutoSize = true;
            lblViews.Location = new Point(631, 42);
            lblViews.Name = "lblViews";
            lblViews.Size = new Size(85, 15);
            lblViews.TabIndex = 8;
            lblViews.Text = "Просмотры, ₽";
            // 
            // numViewsCost
            // 
            numViewsCost.DecimalPlaces = 2;
            numViewsCost.Location = new Point(632, 71);
            numViewsCost.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numViewsCost.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numViewsCost.Name = "numViewsCost";
            numViewsCost.Size = new Size(94, 23);
            numViewsCost.TabIndex = 9;
            numViewsCost.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // SaleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1220, 421);
            Controls.Add(numViewsCost);
            Controls.Add(lblViews);
            Controls.Add(numAdCost);
            Controls.Add(lblDeliveryCost);
            Controls.Add(lblPlatformFee);
            Controls.Add(numPlatformFee);
            Controls.Add(btnConfirm);
            Controls.Add(cbPlatform);
            Controls.Add(numSalePrice);
            Controls.Add(lblSalePrice);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SaleForm";
            Text = "SaleForm";
            ((System.ComponentModel.ISupportInitialize)numSalePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPlatformFee).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAdCost).EndInit();
            ((System.ComponentModel.ISupportInitialize)numViewsCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSalePrice;
        private NumericUpDown numSalePrice;
        private ComboBox cbPlatform;
        private Button btnConfirm;
        private NumericUpDown numPlatformFee;
        private Label lblPlatformFee;
        private Label lblDeliveryCost;
        private NumericUpDown numAdCost;
        private Label lblViews;
        private NumericUpDown numViewsCost;
    }
}