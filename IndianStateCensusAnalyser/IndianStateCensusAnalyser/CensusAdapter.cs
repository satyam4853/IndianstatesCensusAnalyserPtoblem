﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IndianStateCensusAnalyser;
 using IndianStateCensusAnalyser.POCO;

namespace IndianStateCensusAnalyser
{
   public abstract  class CensusAdapter
    {
        protected string[] GetCensusData(string csvFilePath , string dataHeaders)
        {
            string[] censusData;
            if(!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);

            }
            if(Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Path ", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);

            
            }
            censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect header in Data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            return censusData;
        }

    }
}
