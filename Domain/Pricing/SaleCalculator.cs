namespace MyWinFormsApp.Domain.Pricing
{
    public static class SaleCalculator
    {
        // Расчет комиссии платформы в рублях
        public static decimal GetPlatformFee(decimal grossSalePrice, decimal platformFeePercent)
            => grossSalePrice * (platformFeePercent / 100m);

        // Чистая сумма, полученная после всех вычетов площадки и рекламы
        public static decimal GetNetSalePrice(decimal grossSalePrice, decimal adCost, decimal viewsCost, decimal platformFeePercent)
            => grossSalePrice - adCost - viewsCost - GetPlatformFee(grossSalePrice, platformFeePercent);

        // Итоговая прибыль с продажи одной единицы
        public static decimal GetProfit(decimal netSalePrice, decimal unitPurchasePrice)
            => netSalePrice - unitPurchasePrice;
    }
}