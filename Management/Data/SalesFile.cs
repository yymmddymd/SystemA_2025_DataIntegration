using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Batch.Data
{
    /// <summary>
    /// 店舗売上データファイル
    /// </summary>
    public class SalesFile
    {
        /// <summary>店舗コード</summary>
        public string ShopCode { get; set; }

        /// <summary>集計年月</summary>
        public string SummaryTarget { get; set; }

        /// <summary>商品コード</summary>
        public string ItemCode { get; set; }

        /// <summary>販売単価</summary>
        public int SaleUnit { get; set; }

        /// <summary>売上総数量</summary>
        public int TotalQuantity { get; set; }

        /// <summary>割引適用総額</summary>
        public int TotalDiscount { get; set; }

        /// <summary>予約領域</summary>
        public int Padding { get; set; } = 0;

        public DateTime SaleDate { get; set; }

        public int TotalAmount => (SaleUnit * TotalQuantity) - TotalDiscount;

        /// <summary>分類名の取得</summary>
        public string CategoryName
        {
            get
            {
                if (string.IsNullOrEmpty(ItemCode) || ItemCode.Length < 3) return "不明";
                // 商品コードの先頭3桁で判定
                switch (ItemCode.Substring(0, 3))
                {
                    case "001": return "食料品";
                    case "002": return "電化製品";
                    case "003": return "日用品";
                    case "004": return "その他";
                    default: return "不明";
                }
            }
        }

        public string ItemName
        {
            get
            {
                // 本来はDBの商品マスタから取得すべきですが、
                // DBUtilを変更できないため、ここではコードから推測される名称を返します。
                return $"商品({ItemCode})";
            }
        }

        /// <summary>
        ///     コンストラクタ
        /// </summary>
        public SalesFile(string _ShopCode, string _SummaryTarget, string _ItemCode, int _SaleUnit, int _TotalPurchase, int _TotalDiscount)
        {
            try
            {
                ShopCode = _ShopCode;
                SummaryTarget = _SummaryTarget;
                ItemCode = _ItemCode;
                SaleUnit = _SaleUnit;
                TotalQuantity = _TotalPurchase;
                TotalDiscount = _TotalDiscount;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}