using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management.Common
{
    public class MessageDialog 
    {
        public static void Info(string _Title, string _Message)
        {
            MessageBox.Show($"{_Message}",
                _Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk
            );
        }

        public static void Warning(string _Title, string _Message)
        {
            MessageBox.Show($"{_Message}",
                _Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        } 

        public static void Error(string _Message)
        {
            MessageBox.Show($"{_Message}\nエラーログを確認してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        } 
    }
}
