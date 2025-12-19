using System;
using System.Linq;
using System.Windows.Forms;
using MyWinFormsApp.Models;
using MyWinFormsApp.Services;

namespace MyWinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly InventoryService _service;

        public MainForm()
        {
            InitializeComponent();

            _service = new InventoryService();

            btnAdd.Click += btnAdd_Click;
            btnSell.Click += btnSell_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnExport.Click += btnExport_Click;

            dgvProducts.RowPrePaint += dgvProducts_RowPrePaint;

            _service.SeedData();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var rows = _service.GetProductRows();

                dgvProducts.AutoGenerateColumns = true;
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = rows;

                dgvProducts.RowHeadersVisible = false;
                dgvProducts.AllowUserToAddRows = false;
                dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProducts.MultiSelect = false;
                dgvProducts.ReadOnly = true;

                if (dgvProducts.Columns["Id"] != null)
                    dgvProducts.Columns["Id"].Visible = false;

                dgvProducts.Columns["Name"].HeaderText = "Название";
                dgvProducts.Columns["Size"].HeaderText = "Размер";
                dgvProducts.Columns["Quantity"].HeaderText = "Кол-во";
                dgvProducts.Columns["UnitPurchasePrice"].HeaderText = "Цена закуп / шт";
                dgvProducts.Columns["PurchasePrice"].HeaderText = "Закуп итого";
                dgvProducts.Columns["SalePrice"].HeaderText = "Цена продажи (чистая)";
                dgvProducts.Columns["Brand"].HeaderText = "Бренд";
                dgvProducts.Columns["Category"].HeaderText = "Категория";
                dgvProducts.Columns["Status"].HeaderText = "Статус";

                dgvProducts.Columns["UnitPurchasePrice"].DefaultCellStyle.Format = "N2";
                dgvProducts.Columns["PurchasePrice"].DefaultCellStyle.Format = "N2";
                dgvProducts.Columns["SalePrice"].DefaultCellStyle.Format = "N2";
                if (dgvProducts.Columns["PurchaseDate"] != null)
                    dgvProducts.Columns["PurchaseDate"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";

                // ✅ ПРИБЫЛЬ = чистая продажа - закуп
                var totalProfit = rows
                    .Where(r => r.SalePrice.HasValue)
                    .Sum(r => r.SalePrice.Value - r.PurchasePrice);

                // ✅ В НАЛИЧИИ
                var inStockCount = rows.Count(r => r.Status == ItemStatus.InStock.ToString());

                // ✅ СТОИМОСТЬ ТОВАРА В НАЛИЧИИ (вложенные деньги)
                var inventoryValue = rows
                    .Where(r => r.Status == ItemStatus.InStock.ToString())
                    .Sum(r => r.PurchasePrice);

                // ✅ ДЕНЬГИ ОТ ПРОДАЖ (чистыми)
                var cashFromSales = rows
                    .Where(r => r.Status == ItemStatus.Sold.ToString() && r.SalePrice.HasValue)
                    .Sum(r => r.SalePrice.Value);

                // ✅ КАПИТАЛ = деньги + товар на складе
                var capital = cashFromSales + inventoryValue;

                lblTotalProfit.Text = $"Прибыль: {totalProfit:N2} ₽";
                lblInStock.Text = $"В наличии: {inStockCount} шт.";
                lblInventoryValue.Text = $"Капитал: {capital:N2} ₽";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Product? GetSelectedProduct()
        {
            if (dgvProducts.SelectedRows.Count == 0) return null;

            var row = dgvProducts.SelectedRows[0].DataBoundItem as ProductRow;
            if (row == null) return null;

            return _service.GetProductById(row.Id);
        }

        private void dgvProducts_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvProducts.Rows[e.RowIndex];
            if (row?.DataBoundItem is not ProductRow r) return;

            if (r.Status == ItemStatus.Sold.ToString())
            {
                row.DefaultCellStyle.BackColor = System.Drawing.Color.Honeydew;
                row.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkGreen;
            }
            else
            {
                row.DefaultCellStyle.BackColor = dgvProducts.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dgvProducts.DefaultCellStyle.ForeColor;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var addForm = new AddProductForm();
            if (addForm.ShowDialog() != DialogResult.OK) return;

            if (addForm.NewProduct == null)
            {
                MessageBox.Show("Товар не создан.");
                return;
            }

            _service.AddProduct(addForm.NewProduct);
            LoadData();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("Выберите товар в таблице!");
                return;
            }

            if (product.Status == ItemStatus.Sold)
            {
                MessageBox.Show("Этот товар уже продан!");
                return;
            }

            try
            {
                using var saleForm = new SaleForm();
                if (saleForm.ShowDialog() != DialogResult.OK) return;

                _service.SellProduct(
                    product.Id,
                    saleForm.SalePrice,
                    saleForm.PlatformId,
                    "Клиент",
                    saleForm.AdCost,
                    saleForm.ViewsCost,
                    saleForm.PlatformFeePercent
                );

                LoadData();
                MessageBox.Show("Сделка оформлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            var product = GetSelectedProduct();
            if (product == null) return;

            if (MessageBox.Show(
                $"Удалить товар \"{product.Name}\"?",
                "Подтверждение",
                MessageBoxButtons.YesNo
            ) != DialogResult.Yes) return;

            if (product.Status == ItemStatus.Sold)
            {
                var confirm = MessageBox.Show(
                    "Товар продан. Удалить его вместе с историей продажи?",
                    "Внимание",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm != DialogResult.Yes)
                    return;

                _service.DeleteProduct(product.Id, allowDeleteSold: true);
            }
            else
            {
                _service.DeleteProduct(product.Id);
            }

            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "CSV файлы (*.csv)|*.csv",
                FileName = $"Inventory_{DateTime.Now:yyyyMMdd}.csv"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            _service.ExportProductsToCsv(sfd.FileName);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
