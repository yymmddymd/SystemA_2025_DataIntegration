using Batch.Common;
using Management.Common;
using System.Diagnostics;
using System.Text;

namespace Management
{
    public partial class frmSalesData : Form
    {
        DateTime SaveFrom;
        DateTime SaveTo;
        List<string> SaveCategory = new List<string>();
        string SaveNumber;
        string SaveName;

        public frmSalesData()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime from = default;
            DateTime to = default;
            List<string> category = new List<string>();
            string number;
            string name;

            try
            {
                //入力チェック
                string message = checkInput();
                if (string.IsNullOrEmpty(message) == false)
                {
                    MessageDialog.Warning("検索条件エラー", message);
                    return;
                }

                //検索ボタン押下時
                if (sender == btnSearch)
                {
                    //開始年月
                    from = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, 1);

                    //終了年月
                    to = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, 1).AddMonths(1);

                    //商品分類
                    if (cbxFood.Checked) category.Add("001");
                    if (cbxEquipment.Checked) category.Add("002");
                    if (cbxLiving.Checked) category.Add("003");
                    if (cbxOther.Checked) category.Add("004");

                    //商品番号
                    number = string.IsNullOrEmpty(txtNumber.Text) ? null : txtNumber.Text;

                    //商品名
                    name = string.IsNullOrEmpty(txtName.Text) ? null : txtName.Text;

                    //検索条件を保存
                    SaveFrom = from;
                    SaveTo = to;
                    SaveCategory = category.ToList();
                    SaveNumber = number;
                    SaveName = name;
                }
                else
                {
                    //保存してる検索条件をセット
                    from = SaveFrom;
                    to = SaveTo;
                    category = SaveCategory;
                    number = SaveNumber;
                    name = SaveName;
                }

                //売上データ取得
                DBUtil db = new DBUtil();
                List<List<string>> data = db.Select_Sales(from, to, category, number, name);

                //データグリッドビューに適用
                dgvResult.Rows.Clear();
                foreach (List<string> record in data)
                {
                    dgvResult.Rows.Add(record.ToArray());
                }

                //更新ボタンを有効化
                btnUpdate.Enabled = true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.ToString());
                MessageDialog.Error("検索処理が失敗しました。");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //初期表示の状態に戻す
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
            foreach (CheckBox cbx in new CheckBox[] { cbxFood, cbxEquipment, cbxLiving, cbxOther })
            {
                cbx.Checked = true;
            }
            txtNumber.Text = string.Empty;
            txtName.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 0〜9、バックスペース以外の入力を無効化
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 入力値チェック
        /// </summary>
        private string checkInput()
        {
            bool checkFlg;

            //期間:相関チェック
            DateTime start = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, 1);
            DateTime end = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, 1);
            if (start > end)
            {
                return "開始年月が終了年月を過ぎてます。";
            }

            //商品分類:未選択チェック
            checkFlg = false;
            foreach (CheckBox cbx in new CheckBox[] { cbxFood, cbxEquipment, cbxLiving, cbxOther })
            {
                if (cbx.Checked == true)
                {
                    checkFlg = true;
                    break;
                }
            }
            if (checkFlg == false)
            {
                return "商品分類が未選択です。";
            }

            return string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //検索ボタンの処理を呼ぶ
            btnSearch_Click(sender, e);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //バッチファイルパス
            string batchPath = Path.Combine(Directory.GetCurrentDirectory(), "Transmission.bat");

            //期間:相関チェック
            DateTime start = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, 1);
            DateTime end = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, 1);
            if (start > end)
            {
                MessageDialog.Warning("入力値エラー", "開始年月が終了年月を過ぎてます。");
                return;
            }

            //確認メッセージ
            StringBuilder confirm = new StringBuilder();
            confirm.Append("売上データの送信を開始します。\n");
            confirm.Append("期間以外の検索条件は送信データに反映されません。\n");
            confirm.Append("よろしいですか?");

            //メッセージ表示
            DialogResult result = MessageBox.Show(confirm.ToString(), "実行確認",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            //[いいえ]が押されたら処理を中断
            if (result != DialogResult.Yes)
            {
                return;
            }

            //バッチ実行情報の構築
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            //引数設定
            startInfo.ArgumentList.Add("/c");
            startInfo.ArgumentList.Add(batchPath);
            startInfo.ArgumentList.Add("1");
            startInfo.ArgumentList.Add(start.ToString("yyyyMM"));
            startInfo.ArgumentList.Add(end.ToString("yyyyMM"));

            try
            {
                // マウスポインタを砂時計にする
                this.Cursor = Cursors.WaitCursor;
       
                using (Process process = Process.Start(startInfo))
                { 
                    if (process != null)
                    {
                        //プロセスが終了するまで待機
                        process.WaitForExit();

                        //リターンコードで判定 
                        if (process.ExitCode == 0)
                        {
                            MessageDialog.Info("送信成功", "売上データ送信が成功しました。");
                        }
                        else
                        {
                            MessageDialog.Error("売上データ送信が異常終了しました。");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.ToString());
                MessageDialog.Error("バッチ起動が異常終了しました。");
            }
            finally
            {
                //マウスポインタを元に戻す
                this.Cursor = Cursors.Default;
            }
        }
    }
}
