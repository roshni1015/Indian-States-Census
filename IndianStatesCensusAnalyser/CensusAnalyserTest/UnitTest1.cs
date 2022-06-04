using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStatesCensusAnalyser.CensusAnalyser;
namespace CensusAnalyserTest
{
    public class Tests
    {
        
        string IndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        string IndianStateCensusFilePath = @"C:\Users\Admin\source\c#\Indian-States-Census\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCensusData.csv";
        string wrongHeaderIndianCensusFilePath = @"C:\Users\Admin\source\c#\Indian-States-Census\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaState.csv";


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

        //Use case - 1
        //Happy Test Case 1.1 : the records are checked
        [Test]
        public void GivenIndianCensusDataFile_For_ReturnDataFile()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCensusFilePath, IndianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        //Sad Test Case 1.2 : to verify if the exception is raised.
        [Test]
        public void GivenWrongFilePath_For_ReturnException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
    }
}