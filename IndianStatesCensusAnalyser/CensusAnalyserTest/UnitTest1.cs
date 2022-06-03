using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStatesCensusAnalyser.CensusAnalyser;
namespace CensusAnalyserTest
{
    public class Tests
    {
        string csvPath = @"C:\Users\Admin\source\c#\Indian-States-Census\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCensusData.csv";

        string IndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();

        }

        [Test]
        public void Test1()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
    }
}