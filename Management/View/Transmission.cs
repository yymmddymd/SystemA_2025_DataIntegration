using Batch.Common;
using Management.Common;
using System;
using System.Windows.Forms;

namespace Management
{
    public partial class Transmission : Form
    {
        DateTime SaveFrom;
        DateTime SaveTo;
        List<int> SaveCategory = new List<int>();
        List<int> SaveStatus = new List<int>();

        public Transmission()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime from = default;
            DateTime to = default;
            List<int> category = new List<int>();
            List<int> status = new List<int>();

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

                    //分類
                    if (cbxReceive.Checked) category.Add(0); 
                    if (cbxSend.Checked) category.Add(1);

                    //ステータス
                    if (cbxProceed.Checked) status.Add(0);
                    if (cbxRetry.Checked) status.Add(1);
                    if (cbxError.Checked) status.Add(2);

                    //検索条件を保存
                    SaveFrom = from;
                    SaveTo = to;
                    SaveCategory = category.ToList();
                    SaveStatus = status.ToList();
                }
                else
                {
                    //保存してる検索条件をセット
                    from = SaveFrom;
                    to = SaveTo;
                    category = SaveCategory;
                    status = SaveStatus;
                }

                //送受信データ取得
                DBUtil db = new DBUtil();
                List<List<string>> data = db.Select_Transmission(from, to, category, status);

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
            foreach (CheckBox cbx in new CheckBox[] { cbxReceive, cbxSend, cbxProceed, cbxRetry, cbxError })
            {
                cbx.Checked = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //検索ボタンの処理を呼ぶ
            btnSearch_Click(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //画面を閉じる
            this.Close();
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

            //分類:未選択チェック
            checkFlg = false;
            foreach (CheckBox cbx in new CheckBox[] { cbxProceed, cbxRetry, cbxError })
            {
                if (cbx.Checked == true)
                {
                    checkFlg = true;
                    break;
                }
            }
            if (checkFlg  == false)
            {
                return "分類が未選択です。";
            }

            //ステータス:未選択チェック
            checkFlg = false;
            foreach (CheckBox cbx in new CheckBox[] { cbxReceive, cbxSend })
            {
                if (cbx.Checked == true)
                {
                    checkFlg = true;
                    break;
                }
            }
            if (checkFlg == false)
            {
                return "ステータスが未選択です。";
            }

            return string.Empty;
        }
    }
}
