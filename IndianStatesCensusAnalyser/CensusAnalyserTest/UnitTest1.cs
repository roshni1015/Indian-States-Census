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
        string IndianStateCensusHeaders2 = "StaTe,populaTion,areaInSqKm,densiTyPerSqKm";
        string IndiaStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        string IndiaStateCodeHeaders2 = "Srno,StaTe name,Tin,staTeCode";



        string IndianStateCensusFilePath = @"C:\Users\Admin\source\c#\Indian-States-Census\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCensusData.csv";
        string wrongHeaderIndianCensusFilePath = @"C:\Users\Admin\source\c#\Indian-States-Census\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaState.csv";
        string IncorrectTxtFilePath = @"C:\Users\Admin\source\c#\Indian-States-Census\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\Incorrect.txt";
        string DelimiterIndiaStateCensusDataFilePath = @"C:\Users\Admin\source\c#\Indian-States-Census\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\DelimiterIndiaStateCensusData.csv";

        string IndiaStateCodeFilePath = @"C:\Users\Admin\source\c#\Indian-States-Census\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCode.csv";
        string IndiaStateCodeWrongFilePath = @"C:\Users\Admin\source\c#\Indian-States-Census\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaState.csv";
        string StateIncorrectTxtFilePath = @"C:\Users\Admin\source\c#\Indian-States-Census\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\StateCode.txt";
        string DelimiterIndiaStateDataFilePath = @"C:\Users\Admin\source\c#\Indian-States-Census\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\DelimiterIndiaStateCode.csv";





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

        //Sad Test Case 1.3 : if the type is incorrect then exception is raised.
        [Test]
        public void GivenIncorrectTxtFile_For_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IncorrectTxtFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }

        //Sad Test Case 1.4 : if the file delimiter is incorrect then exception is raised.
        [Test]
        public void GivenIncorrectDelimiter_For_ShouldThrowCustomException()
        {
            try
            {
                IndianCensusAdapter a1 = new IndianCensusAdapter();
                totalRecord = a1.LoadCensusData(DelimiterIndiaStateCensusDataFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
        //Sad Test Case 1.5 : if the header is incorrect then exception is raised.

        [Test]
        public void GivenWrongHeader_For_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCensusFilePath, IndianStateCensusHeaders2);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }

        //Use case - 2
        //Happy Test Case 2.1 : the records are checked
        [Test]
        public void GivenIndiaStateCodeFile_For_ReturnDataFile()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndiaStateCodeFilePath, IndiaStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }

        //Sad Test Case 2.2 : to verify if the exception is raised.
        [Test]
        public void GivenIndiaStateWrongFilePath_For_ReturnException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndiaStateCodeWrongFilePath, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }

        //Sad Test Case 2.3 : if the type is incorrect then exception is raised.
        [Test]
        public void GivenStateIncorrectTxtFile_For_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, StateIncorrectTxtFilePath, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }

        //Sad Test Case 2.4 : if the file delimiter is incorrect then exception is raised.
        [Test]
        public void GivenIncorrectDelimiterStateCode_For_ShouldThrowCustomException()
        {
            try
            {
                IndianCensusAdapter a1 = new IndianCensusAdapter();
                stateRecord = a1.LoadCensusData(DelimiterIndiaStateDataFilePath, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
        //Sad Test Case 2.5 : if the header is incorrect then exception is raised.
        [Test]
        public void GivenIndianStateWrongHeader_For_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndiaStateCodeFilePath, IndiaStateCodeHeaders2);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
    }
}