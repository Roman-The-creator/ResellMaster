namespace MyWinFormsApp;

partial class MainForm
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
        dgvProducts = new DataGridView();
        pnlControls = new Panel();
        btnDelete = new Button();
        btnExport = new Button();
        btnRefresh = new Button();
        btnSell = new Button();
        btnAdd = new Button();
        pnlTop = new Panel();
        lblTotalProfit = new Label();
        lblInventoryValue = new Label();
        lblInStock = new Label();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
        pnlControls.SuspendLayout();
        pnlTop.SuspendLayout();
        SuspendLayout();
        // 
        // dgvProducts
        // 
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvProducts.Dock = DockStyle.Fill;
        dgvProducts.Location = new Point(0, 38);
        dgvProducts.Margin = new Padding(3, 2, 3, 2);
        dgvProducts.Name = "dgvProducts";
        dgvProducts.ReadOnly = true;
        dgvProducts.RowHeadersWidth = 51;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.Size = new Size(1178, 472);
        dgvProducts.TabIndex = 0;
        // 
        // pnlControls
        // 
        pnlControls.Controls.Add(btnDelete);
        pnlControls.Controls.Add(btnExport);
        pnlControls.Controls.Add(btnRefresh);
        pnlControls.Controls.Add(btnSell);
        pnlControls.Controls.Add(btnAdd);
        pnlControls.Dock = DockStyle.Bottom;
        pnlControls.Location = new Point(0, 510);
        pnlControls.Margin = new Padding(3, 2, 3, 2);
        pnlControls.Name = "pnlControls";
        pnlControls.Size = new Size(1178, 94);
        pnlControls.TabIndex = 1;
        // 
        // btnDelete
        // 
        btnDelete.AccessibleName = "";
        btnDelete.Location = new Point(53, 29);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(126, 23);
        btnDelete.TabIndex = 4;
        btnDelete.Text = "Удалить";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        // 
        // btnExport
        // 
        btnExport.BackColor = Color.FromArgb(192, 255, 192);
        btnExport.Location = new Point(1032, 28);
        btnExport.Margin = new Padding(3, 2, 3, 2);
        btnExport.Name = "btnExport";
        btnExport.Size = new Size(112, 22);
        btnExport.TabIndex = 3;
        btnExport.Text = "Экспорт в CSV";
        btnExport.UseVisualStyleBackColor = false;
        btnExport.Click += btnExport_Click;
        // 
        // btnRefresh
        // 
        btnRefresh.Location = new Point(861, 30);
        btnRefresh.Margin = new Padding(3, 2, 3, 2);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(88, 22);
        btnRefresh.TabIndex = 2;
        btnRefresh.Text = "Обновить";
        btnRefresh.UseVisualStyleBackColor = true;
        btnRefresh.Click += btnRefresh_Click;
        // 
        // btnSell
        // 
        btnSell.Location = new Point(549, 26);
        btnSell.Margin = new Padding(3, 2, 3, 2);
        btnSell.Name = "btnSell";
        btnSell.Size = new Size(154, 22);
        btnSell.TabIndex = 1;
        btnSell.Text = "Продать выбранный";
        btnSell.UseVisualStyleBackColor = true;
        btnSell.Click += btnSell_Click;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(281, 29);
        btnAdd.Margin = new Padding(3, 2, 3, 2);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(120, 22);
        btnAdd.TabIndex = 0;
        btnAdd.Text = "Добавить товар";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // pnlTop
        // 
        pnlTop.Controls.Add(lblTotalProfit);
        pnlTop.Controls.Add(lblInventoryValue);
        pnlTop.Controls.Add(lblInStock);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Margin = new Padding(3, 2, 3, 2);
        pnlTop.Name = "pnlTop";
        pnlTop.Size = new Size(1178, 38);
        pnlTop.TabIndex = 2;
        // 
        // lblTotalProfit
        // 
        lblTotalProfit.AutoSize = true;
        lblTotalProfit.Location = new Point(821, 12);
        lblTotalProfit.Name = "lblTotalProfit";
        lblTotalProfit.Size = new Size(97, 15);
        lblTotalProfit.TabIndex = 2;
        lblTotalProfit.Text = "Прибыль: 0 руб.";
        // 
        // lblInventoryValue
        // 
        lblInventoryValue.AutoSize = true;
        lblInventoryValue.Location = new Point(455, 7);
        lblInventoryValue.Name = "lblInventoryValue";
        lblInventoryValue.Size = new Size(90, 15);
        lblInventoryValue.TabIndex = 1;
        lblInventoryValue.Text = "Капитал: 0 руб.";
        // 
        // lblInStock
        // 
        lblInStock.AutoSize = true;
        lblInStock.Location = new Point(106, 8);
        lblInStock.Name = "lblInStock";
        lblInStock.Size = new Size(99, 15);
        lblInStock.TabIndex = 0;
        lblInStock.Text = "В наличии: 0 шт.";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1178, 604);
        Controls.Add(dgvProducts);
        Controls.Add(pnlTop);
        Controls.Add(pnlControls);
        Margin = new Padding(3, 2, 3, 2);
        Name = "MainForm";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
        pnlControls.ResumeLayout(false);
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dgvProducts;
    private Panel pnlControls;
    private Button btnRefresh;
    private Button btnSell;
    private Button btnAdd;
    private Panel pnlTop;
    private Label lblTotalProfit;
    private Label lblInventoryValue;
    private Label lblInStock;
    private Button btnExport;
    private Button btnDelete;
}
