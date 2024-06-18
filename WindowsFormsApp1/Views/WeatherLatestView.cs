using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Common;
using WindowsFormsApp1.Data;

namespace WindowsFormsApp1
{
    public partial class WeatherLatestView : Form
    {
        public WeatherLatestView()
        {
            InitializeComponent();
        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            DataTable dt = WeatherSQLite.GetLatest(Convert.ToInt32(AreaIdTextBox.Text));

            if (dt.Rows.Count > 0)
            {
                DataDateLabel.Text = dt.Rows[0]["DataDate"].ToString();
                ConditionLabel.Text = dt.Rows[0]["Condition"].ToString();

                // ★下記BAD例: 温度を表示するのに「Common」「Const」を使うことをクライアントコードが知っている必要がある。
                // 複数人開発時に知識の共有が難しくなる恐れがあるので、クライアントコードは使うだけにする実装にする。
                TemperatureLabel.Text = CommonFunc.RoundString(
                    Convert.ToSingle(dt.Rows[0]["Temperature"])
                    , CommonConst.TemperatureDecimalPoint)
                    + CommonConst.TemperatureUnit;
            }

        }
    }
}
