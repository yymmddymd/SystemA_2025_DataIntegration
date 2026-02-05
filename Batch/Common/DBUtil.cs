using Batch.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Batch.Common
{
    /// <summary>
    /// DB操作クラス
    /// </summary>
    public class DBUtil
    {
        /// <summary>サーバ名</summary>
        private string DBServer;

        /// <summary>ユーザ名</summary>
        private string DBUser;

        /// <summary>パスワード</summary>
        private string DBPass;

        /// <summary>データベース名</summary>
        private string DBName;

        /// <summary>スキーマ名</summary>
        private string DBSchema;

        /// <summary>接続文字列</summary>
        private string ConnectionString;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DBUtil()
        {
            //configファイルから接続情報を読み込む
            DBServer = ConfigurationManager.AppSettings["DB_SERVER"];
            DBUser = ConfigurationManager.AppSettings["DB_USER"];
            DBPass = ConfigurationManager.AppSettings["DB_PASS"];
            DBName = ConfigurationManager.AppSettings["DB_NAME"];
            DBSchema = ConfigurationManager.AppSettings["DB_SCHEMA"];

            //接続文字列を設定
            ConnectionString = $"Data Source={DBServer};Initial Catalog={DBName};User ID={DBUser};Password={DBPass}";
        }

        /// <summary>
        ///  商品マスタ登録
        /// </summary>
        /// <param name="_RegistData">登録データ</param>
        public void Insert_product_master(List<ProductMasterFile> _RegistData)
        {
            try
            {
                DateTime now = DateTime.Now;

                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        foreach (ProductMasterFile data in _RegistData)
                        {
                            //SQL作成
                            StringBuilder sql = new StringBuilder();
                            sql.Append("INSERT INTO ");
                            sql.Append($"   {DBSchema}.product_master ");
                            sql.Append("VALUES ( ");
                            sql.Append($"   @item_code,");
                            sql.Append("    @reg_date,");
                            sql.Append($"   @category_id,");
                            sql.Append($"   @item_no,");
                            sql.Append($"   @sale_unit,");
                            sql.Append($"   @purchase_unit,");
                            sql.Append($"   @sale_flg");
                            sql.Append(")");

                            using (var command = new SqlCommand(sql.ToString(), connection, transaction))
                            {
                                //パラメータ設定
                                command.Parameters.AddWithValue("@item_code", data.ItemCode);
                                command.Parameters.AddWithValue("@reg_date", now);
                                command.Parameters.AddWithValue("@category_id", data.ItemCode.Substring(0, 3));
                                command.Parameters.AddWithValue("@item_no", data.ItemCode.Substring(3, 5));
                                command.Parameters.AddWithValue("@sale_unit", data.SaleUnit);
                                command.Parameters.AddWithValue("@purchase_unit", data.PurchaseUnit);
                                command.Parameters.AddWithValue("@sale_flg", data.SaleFlg);

                                //SQL実行
                                command.ExecuteNonQuery();
                            }
                        }

                        //トランザクションをコミット
                        transaction.Commit();
                    }
                }            
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///     店舗売上データ取得
        /// </summary>
        public List<SalesFile> Select_Sales(DateTime _Target)
        {
            List<SalesFile> rtnData = new List<SalesFile>();

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    //SQL作成
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT ");
                    sql.Append("    item_code, ");
                    sql.Append("    sale_unit, ");
                    sql.Append("    SUM(quantity) AS total_quantity, ");
                    sql.Append("    SUM(discount) AS total_discount ");
                    sql.Append("FROM ");
                    sql.Append($"   {DBSchema}.sales_detail ");
                    sql.Append("WHERE ");
                    sql.Append("    sale_date >= @start ");
                    sql.Append("AND ");
                    sql.Append("    sale_date < @end ");
                    sql.Append("GROUP BY ");
                    sql.Append("    item_code, sale_unit ");
                    sql.Append("ORDER BY ");
                    sql.Append("    item_code ASC");

                    //店舗コード
                    string shopCode = ConfigurationManager.AppSettings["SHOP_CODE"];

                    using (var command = new SqlCommand(sql.ToString(), connection))
                    {
                        //条件式の日付
                        DateTime start = new DateTime(_Target.Year, _Target.Month, 1);
                        DateTime end = start.AddMonths(1);

                        //パラメータ設定
                        command.Parameters.AddWithValue("@start", start);
                        command.Parameters.AddWithValue("@end", end);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read() != false)
                            {
                                rtnData.Add(
                                    new SalesFile(
                                            shopCode,
                                            _Target.ToString("yyyyMM"),
                                            reader["item_code"].ToString(),
                                            int.Parse(reader["sale_unit"].ToString()),
                                            int.Parse(reader["total_quantity"].ToString()),
                                            int.Parse(reader["total_discount"].ToString())
                                        )
                                );
                            }
                        }
                    }
                }

                return rtnData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///     送受信データ登録
        /// </summary>
        public void Insert_Transmission(TransmissionTable _RegistData)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    //SQL作成
                    StringBuilder sql = new StringBuilder();
                    sql.Append("INSERT INTO ");
                    sql.Append($"   {DBSchema}.transmission ");
                    sql.Append("VALUES ( ");
                    sql.Append($"   @processed_at,");
                    sql.Append("    @category,");
                    sql.Append($"   @file_name,");
                    sql.Append($"   @status,");
                    sql.Append($"   @output_message");
                    sql.Append(")");

                    using (var command = new SqlCommand(sql.ToString(), connection))
                    {
                        //パラメータ設定
                        command.Parameters.AddWithValue("@processed_at", _RegistData.ProcessedAt);
                        command.Parameters.AddWithValue("@category", _RegistData.Category);
                        command.Parameters.AddWithValue("@file_name", _RegistData.FileName);
                        command.Parameters.AddWithValue("@status", _RegistData.Status);
                        command.Parameters.AddWithValue("@output_message", _RegistData.OutputMessage);

                        //SQL実行
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///     送受信データ更新
        /// </summary>
        public void Update_Transmission(string _FileName)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    //SQL作成
                    StringBuilder sql = new StringBuilder();
                    sql.Append("UPDATE ");
                    sql.Append($"   {DBSchema}.transmission ");
                    sql.Append("SET ");
                    sql.Append($"   status　= @status,");
                    sql.Append("    output_message = @output_message ");
                    sql.Append($"WHERE ");
                    sql.Append($"   file_name = @file_name");

                    using (var command = new SqlCommand(sql.ToString(), connection))
                    {
                        //パラメータ設定
                        command.Parameters.AddWithValue("@status", Status.Processed);
                        command.Parameters.AddWithValue("@output_message", string.Empty);
                        command.Parameters.AddWithValue("@file_name", _FileName);

                        //SQL実行
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 送受信表示データ取得
        /// </summary>
        public List<List<string>> Select_Transmission(DateTime _ProcessedFrom, DateTime _ProcessedTo, List<int> _Category, List<int> _Status)
        {
            //戻り値
            List <List<string>> rtnData = new List<List<string>>();

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    //SQL作成
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT ");
                    sql.Append("    processed_at, ");
                    sql.Append("    category_view, ");
                    sql.Append("    file_name, ");
                    sql.Append("    status_view, ");
                    sql.Append("    output_message ");
                    sql.Append("FROM ");
                    sql.Append($" {DBSchema}.transmission_detail ");
                    sql.Append("WHERE ");
                    sql.Append("    processed_at >= @start ");
                    sql.Append("AND ");
                    sql.Append("    processed_at < @end ");

                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        command.Parameters.AddWithValue("@start", _ProcessedFrom);
                        command.Parameters.AddWithValue("@end", _ProcessedTo);

                        //分類の抽出条件
                        List<string> categoryParam = new List<string>();
                        for (int i = 0; i < _Category.Count; i++)
                        {
                            string param = $"@category{i}";
                            categoryParam.Add(param);
                            command.Parameters.AddWithValue(param, _Category[i]);
                        }
                        sql.Append($"AND category IN ({string.Join(",", categoryParam)}) ");

                        //ステータスの抽出条件
                        List<string> statusParam = new List<string>();
                        for (int i = 0; i < _Status.Count; i++)
                        {
                            string param = $"@status{i}";
                            statusParam.Add(param);
                            command.Parameters.AddWithValue(param, _Status[i]);
                        }
                        sql.Append($"AND status IN ({string.Join(",", statusParam)}) ");

                        command.CommandText = sql.ToString();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read() != false)
                            {
                                List<string> record = new List<string>{
                                    reader["processed_at"].ToString(),
                                    reader["category_view"].ToString(),
                                    reader["file_name"].ToString(),
                                    reader["status_view"].ToString(),
                                    reader["output_message"].ToString()
                                };

                                rtnData.Add(record);
                            }
                        }
                    }
                }

                return rtnData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 売上表示データ取得
        /// </summary>
        public List<List<string>> Select_Sales(DateTime _SaleFrom, DateTime _SaleTo, List<string> _Category, string _Number, string _Name)
        {
            //戻り値
            List<List<string>> rtnData = new List<List<string>>();

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    //SQL作成
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT ");
                    sql.Append("    sale_date, ");
                    sql.Append("    category_view, ");
                    sql.Append("    SUBSTRING(item_code, 4, 5) AS item_number, ");
                    sql.Append("    item_name, ");
                    sql.Append("    quantity, ");
                    sql.Append("    discount, ");
                    sql.Append("    total_amount ");
                    sql.Append("FROM ");
                    sql.Append($" {DBSchema}.sales_detail ");
                    sql.Append("WHERE ");
                    sql.Append("    sale_date >= @start ");
                    sql.Append("AND ");
                    sql.Append("    sale_date < @end ");

                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        command.Parameters.AddWithValue("@start", _SaleFrom);
                        command.Parameters.AddWithValue("@end", _SaleTo);

                        //商品分類の抽出条件
                        List<string> categoryParam = new List<string>();
                        for (int i = 0; i < _Category.Count; i++)
                        {
                            string param = $"@category{i}";
                            categoryParam.Add(param);
                            command.Parameters.AddWithValue(param, _Category[i]);
                        }
                        sql.Append($"AND category_id IN ({string.Join(",", categoryParam)}) ");

                        //商品番号の抽出条件
                        if (string.IsNullOrEmpty(_Number) == false)
                        {
                            sql.Append($"AND SUBSTRING(item_code, 4, 5) = @number ");
                            command.Parameters.AddWithValue("@number", _Number);
                        }
                        
                        //商品名の抽出条件(あいまい検索)
                        if (string.IsNullOrEmpty(_Name) == false)
                        {
                            sql.Append($"AND item_name LIKE @name");
                            command.Parameters.AddWithValue("@name", $"%{_Name}%");
                        }
                        
                        command.CommandText = sql.ToString();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read() != false)
                            {
                                List<string> record = new List<string>{
                                    reader["sale_date"].ToString(),
                                    reader["category_view"].ToString(),
                                    reader["item_number"].ToString(),
                                    reader["item_name"].ToString(),
                                    reader["quantity"].ToString(),
                                    reader["discount"].ToString(),
                                    reader["total_amount"].ToString()
                                };

                                rtnData.Add(record);
                            }
                        }
                    }
                }

                return rtnData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
