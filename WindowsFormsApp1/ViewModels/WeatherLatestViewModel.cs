using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Common;

namespace WindowsFormsApp1.ViewModel
{
    public sealed class WeatherLatestViewModel
    {
        private IWeatherRepository _weather;

        // ↓テストコードにつながるかもしれないし、実際のSQLiteにつながるかもしれない
        public WeatherLatestViewModel(IWeatherRepository weather)
        {
            _weather = weather;
        }

        public string AreaIdText { get; set; } = string.Empty;
        public string DataDateText { get; set; } = string.Empty;
        public string ConditionText { get; set; } = string.Empty;
        public string TemperatureText { get; set; } = string.Empty;

        public void Search()
        {
            var dt = _weather.GetLatest(Convert.ToInt32(AreaIdText));
            if (dt.Rows.Count > 0)
            {
                DataDateText = dt.Rows[0]["DataDate"].ToString();
                ConditionText = dt.Rows[0]["Condition"].ToString();

                TemperatureText = CommonFunc.RoundString(
                    Convert.ToSingle(dt.Rows[0]["Temperature"])
                    , CommonConst.TemperatureDecimalPoint) + " "
                    + CommonConst.TemperatureUnit;
            }
        }
    }
}
