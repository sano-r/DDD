using DDD.Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using WindowsFormsApp1.ViewModel;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherLatestViewModelTest
    {
        [TestMethod]
        public void シナリオ()
        {
            // 起動時に初期値を表示
            var viewModel = new WeatherLatestViewModel(new WeatherMock());
            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);

            // AreaIdに1を入力
            viewModel.AreaIdText = "1";
            viewModel.Search();
            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("2024/06/01 12:34:56", viewModel.DataDateText);
            Assert.AreEqual("2", viewModel.ConditionText);
            Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);

        }
    }

    internal class WeatherMock : IWeatherRepository
    {
        public DataTable GetLatest(int areaId)
        {
            var dt = new DataTable();
            dt.Columns.Add("AreaId", typeof(int));
            dt.Columns.Add("DataDate", typeof(DateTime));
            dt.Columns.Add("Condition", typeof(int));
            dt.Columns.Add("Temperature", typeof(float));

            var newRow = dt.NewRow();
            newRow["Areaid"] = 1;
            newRow["DataDate"] = Convert.ToDateTime("2024/06/01 12:34:56");
            newRow["Condition"] = 2;
            newRow["Temperature"] = 12.3f;

            dt.Rows.Add(newRow);

            return dt;


        }
    }
}
