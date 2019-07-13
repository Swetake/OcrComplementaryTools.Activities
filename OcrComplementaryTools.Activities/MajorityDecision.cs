using System;
using System.Collections.Generic;
using System.Activities;
using System.ComponentModel;

namespace OcrComplementaryTools
{
    public class MajorityDecision : CodeActivity
    {

        [Category("Input")]
        [RequiredArgument]
        [Description("Candidate String List")]
        public InArgument<List<String>> CandidateStringList { get; set; }

        [Category("Output")]
        [Description("Unanimous. Return string if all are same.")]
        public OutArgument<string> Unanimous { get; set; }

        [Category("Output")]
        [Description("Majority. Return string if there are same strings more than half of the list.")]
        public OutArgument<string> Majority { get; set; }
        
        [Category("Output")]
        [Description("String Array which is sorted by RMSE for NormalizedEditDistance")]
        public OutArgument<string[]> SortedTextArray { get; set; }

        [Category("Output")]
        [Description("Array of RMSE which is related with SortedTextArray")]
        public OutArgument<double[]> RMSEArray { get; set; }



        protected override void Execute(CodeActivityContext context)
        {
            List<string> listStrSrc = CandidateStringList.Get(context);

            int intListCount = listStrSrc.Count;
            if (intListCount % 2 == 0 || intListCount < 3)
            {
                throw (new ArgumentException("Number of list item must be odd number and no less than 3"));
            }

            Dictionary<string, int> dicStringCount = new Dictionary<string, int>();
            Dictionary<string, double> dicRMSE = new Dictionary<string, double>();

            //Check CandidateStringList
            int i = 0;
            while (i < listStrSrc.Count)
            {
                if (String.IsNullOrEmpty(listStrSrc[i]))
                {
                    throw (new ArgumentException("Empty string is not allowed in CandidateStringList."));
                }
                i++;
            }

            //Main Calculation loop
            i = 0;
            double[] dblSumOfSquare = new double[intListCount * intListCount];
            while (i < intListCount)
            {
                //For check matching
                if (dicStringCount.ContainsKey(listStrSrc[i]))
                {
                    dicStringCount[listStrSrc[i]]++;
                }
                else
                {
                    dicStringCount[listStrSrc[i]] = 1;
                }

                //Calculate Edit Distance
                int j = 0;
                Fastenshtein.Levenshtein lev = new Fastenshtein.Levenshtein(listStrSrc[i]);

                while (j < intListCount)
                {
                    if (i != j)
                    {
                        double dblNormalizedEditDistance = ((double)lev.DistanceFrom(listStrSrc[j]))/ (double)Math.Max(listStrSrc[i].Length, listStrSrc[j].Length);
                        dblSumOfSquare[j + i * intListCount] = Math.Pow(dblNormalizedEditDistance, 2);
                   }
                    j++;
                }
                i++;
            }

            // Calculate RMSE
            i = 0;
            while (i < intListCount)
            {
                if (!dicRMSE.ContainsKey(listStrSrc[i]))
                {
                    dicRMSE[listStrSrc[i]] = 0;
                    int j = 0;
                    while (j < intListCount)
                    {
                        if (i != j)
                        {
                            dicRMSE[listStrSrc[i]] += dblSumOfSquare[j + i * intListCount];
                        }
                        j++;
                    }
                    dicRMSE[listStrSrc[i]] = Math.Sqrt(dicRMSE[listStrSrc[i]] / (double)(intListCount - 1));
                }
                i++;
            }



            //Check matching count

            string[] sortedKeysCount = new string[dicStringCount.Count];
            int[] sortedValuesCount = new int[dicStringCount.Count];
            dicStringCount.Keys.CopyTo(sortedKeysCount, 0);
            dicStringCount.Values.CopyTo(sortedValuesCount, 0);
            Array.Sort(sortedValuesCount, sortedKeysCount);

            Array.Reverse(sortedValuesCount);
            Array.Reverse(sortedKeysCount);

            int intCountMode = sortedValuesCount[0];
            string strCandidateFromMatching = sortedKeysCount[0];

            if (intCountMode==intListCount)
            {
                Unanimous.Set(context, strCandidateFromMatching);
            }
            else
            {
                Unanimous.Set(context, string.Empty);
            }

            if (intCountMode > (intListCount>>1))
            {
                Majority.Set(context, strCandidateFromMatching);
            }
            else
            {
                Majority.Set(context, string.Empty);
            }

            //Sort RMSE
            string[] sortedKeys = new string[dicRMSE.Count];
            double[] sortedValues = new double[dicRMSE.Count];

            dicRMSE.Keys.CopyTo(sortedKeys, 0);
            dicRMSE.Values.CopyTo(sortedValues, 0);
            Array.Sort(sortedValues, sortedKeys);

            SortedTextArray.Set(context, sortedKeys);
            RMSEArray.Set(context, sortedValues);
        }
    }
}
