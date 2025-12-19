using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MyWinFormsApp.Data;

namespace MyWinFormsApp
{
    public partial class SaleForm : Form
    {
        public decimal SalePrice { get; private set; }
        public decimal AdCost { get; private set; }
        public decimal ViewsCost { get; private set; }
        public decimal PlatformFeePercent { get; private set; }
        public int PlatformId { get; private set; }

        public SaleForm()
        {
            InitializeComponent();

            btnConfirm.Click -= btnConfirm_Click;
            btnConfirm.Click += btnConfirm_Click;

            // Цена продажи
            numSalePrice.Minimum = 1;
            numSalePrice.Maximum = 1_000_000_000;
            numSalePrice.DecimalPlaces = 2;
            numSalePrice.Increment = 100;

            // Реклама
            numAdCost.Minimum = 0;
            numAdCost.Maximum = 1_000_000;
            numAdCost.DecimalPlaces = 2;
            numAdCost.Increment = 50;

            // Просмотры
            numViewsCost.Minimum = 0;
            numViewsCost.Maximum = 1_000_000;
            numViewsCost.DecimalPlaces = 2;
            numViewsCost.Increment = 10;

            // Комиссия %
            numPlatformFee.Minimum = 0;
            numPlatformFee.Maximum = 100;
            numPlatformFee.DecimalPlaces = 2;
            numPlatformFee.Increment = 0.5m;

            LoadPlatforms();
        }

        private void LoadPlatforms()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            using var db = new AppDbContext();
            cbPlatform.DataSource = db.Platforms.ToList();
            cbPlatform.DisplayMember = "Name";
            cbPlatform.ValueMember = "Id";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (numSalePrice.Value <= 0)
            {
                MessageBox.Show("Введите цену продажи больше 0");
                return;
            }

            if (cbPlatform.SelectedValue == null)
            {
                MessageBox.Show("Выберите платформу");
                return;
            }

            SalePrice = numSalePrice.Value;
            AdCost = numAdCost.Value;
            ViewsCost = numViewsCost.Value;
            PlatformFeePercent = numPlatformFee.Value;
            PlatformId = (int)cbPlatform.SelectedValue;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
