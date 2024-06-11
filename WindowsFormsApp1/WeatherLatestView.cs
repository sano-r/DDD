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

namespace WindowsFormsApp1
{
    public partial class WeatherLatestView : Form
    {
        private readonly string ConnectionString = @"Data Source=C:\Users\81803\Desktop\DDD.db;Version=3;";
        public WeatherLatestView()
        {
            InitializeComponent();
        }

        private void LatestButton_Click(object sender, EventArgs e)
        {

            // SQLiteだと「Limit 1」が「TOP 1」と同じ意味になる。
            string sql = @"
SELECT DataDate,
       Condition,
       Temperature
FROM Weather
WHERE AreaId = @AreaId
ORDER BY DataDate desc
LIMIT 1
";
            DataTable dt = new DataTable();
            using (var connection = new SQLiteConnection(ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@AreaId", this.AreaIdTextBox.Text);
                using (var adapter = new SQLiteDataAdapter(command))
                {
                    adapter.Fill(dt);
                }

                if(dt.Rows.Count > 0)
                {
                    DataDateLabel.Text = dt.Rows[0]["DataDate"].ToString();
                    ConditionLabel.Text = dt.Rows[0]["Condition"].ToString();
                    TemperatureLabel.Text = RoundString(Convert.ToSingle(dt.Rows[0]["Temperature"]),2);
                }

            }
        }

        private string RoundString(float value, int decimalPoint)
        {
            var temp = Convert.ToSingle(Math.Round(value, decimalPoint));
            return temp.ToString("F"+ decimalPoint);
        }
    }
}
