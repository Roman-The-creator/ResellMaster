using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MyWinFormsApp.Data;
using MyWinFormsApp.Models;

namespace MyWinFormsApp
{
    public partial class AddProductForm : Form
    {
        public Product? NewProduct { get; private set; }

        public AddProductForm()
        {
            InitializeComponent();
            LoadReferences();
        }

        private void LoadReferences()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            using var db = new AppDbContext();

            var brands = db.Brands.OrderBy(b => b.Name).ToList();
            cbBrand.DataSource = brands;
            cbBrand.DisplayMember = "Name";
            cbBrand.ValueMember = "Id";
            cbBrand.DropDownStyle = ComboBoxStyle.DropDown;
            cbBrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbBrand.AutoCompleteSource = AutoCompleteSource.ListItems;

            var categories = db.Categories.OrderBy(c => c.Name).ToList();
            cbCategory.DataSource = categories;
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";
            cbCategory.DropDownStyle = ComboBoxStyle.DropDown;
            cbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var name = (txtName.Text ?? "").Trim();
                var size = (txtSize.Text ?? "").Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Введите название товара");
                    return;
                }

                if (string.IsNullOrWhiteSpace(size))
                {
                    MessageBox.Show("Введите размер");
                    return;
                }

                var qty = (int)numQuantity.Value;
                if (qty <= 0)
                {
                    MessageBox.Show("Количество должно быть больше 0");
                    return;
                }

                var unit = numUnitPrice.Value;
                if (unit <= 0)
                {
                    MessageBox.Show("Цена за штуку должна быть больше 0");
                    return;
                }

                using var db = new AppDbContext();

                var brandName = (cbBrand.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(brandName))
                {
                    MessageBox.Show("Введите бренд");
                    return;
                }

                var catName = (cbCategory.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(catName))
                {
                    MessageBox.Show("Введите категорию");
                    return;
                }

                var brand = db.Brands.FirstOrDefault(b => b.Name.ToLower() == brandName.ToLower());
                if (brand == null)
                {
                    brand = new Brand { Name = brandName };
                    db.Brands.Add(brand);
                    db.SaveChanges();
                }

                var category = db.Categories.FirstOrDefault(c => c.Name.ToLower() == catName.ToLower());
                if (category == null)
                {
                    category = new Category { Name = catName };
                    db.Categories.Add(category);
                    db.SaveChanges();
                }

                NewProduct = new Product
                {
                    Name = name,
                    Size = size,
                    Quantity = qty,
                    UnitPurchasePrice = unit,
                    PurchasePrice = qty * unit,
                    BrandId = brand.Id,
                    CategoryId = category.Id,
                    Status = ItemStatus.InStock,
                    PurchaseDate = DateTime.Now
                };

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
