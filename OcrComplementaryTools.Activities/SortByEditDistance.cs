using System;
using System.Collections.Generic;
using System.Activities;
using System.ComponentModel;


namespace OcrComplementaryTools
{
    public class SortByEditDistance : CodeActivity
    {
        [Category("Input")]
        [Description("Target Text")]
        [RequiredArgument]
        public InArgument<String> TargetText { get; set; }

        [Category("Input")]
        [Description("Candidate String List")]
        [RequiredArgument]
        public InArgument<List<String>> CandidateStringList { get; set; }
        
        [Category("Output")]
        [Description("Text Array which is sorted by Normalized Edit Distance")]
        public OutArgument<string[]> SortedTextArray { get; set; }
       
        [Category("Output")]
        [Description("Array of Normalized Edit Distance which is related with SortedTextArray")]
        public OutArgument<double[]> SortedNormalizedEditDistanceArray { get; set; }

        [Category("Output")]
        [Description("Return true if the list contains target text.")]
        public OutArgument<bool> IsMatched { get; set; }


        

        protected override void Execute(CodeActivityContext context)
        {
            var dicString = new Dictionary<string, double>();
            var listStrSouce = CandidateStringList.Get(context);
            var strTarget = TargetText.Get(context);
            var lev = new Fastenshtein.Levenshtein(strTarget);
            var intStrLength = strTarget.Length;
            if (String.IsNullOrEmpty(strTarget))
            {
                throw (new ArgumentException("Target Text is null or empty"));
            }

            //Calculate Normalized Edit Distance
            foreach (string strItem in listStrSouce)
            {
                if (String.IsNullOrEmpty(strItem))
                {
                    throw (new ArgumentException("CandidateStringList contains null or empty"));
                }
                dicString[strItem] = ((double)lev.DistanceFrom(strItem)/(double)Math.Max(intStrLength,strItem.Length));
            }

            //Sort
            string[] sortedKeys = new string[dicString.Count];
            double[] sortedValues = new double[dicString.Count];

            dicString.Keys.CopyTo(sortedKeys, 0);
            dicString.Values.CopyTo(sortedValues, 0);
            Array.Sort( sortedValues, sortedKeys);

            //Check if matched
            if (sortedKeys[0] == strTarget)
            {
                IsMatched.Set(context, true);
            }
            else
            {
                IsMatched.Set(context, false);
            }
            
            SortedTextArray.Set(context, sortedKeys);
            SortedNormalizedEditDistanceArray.Set(context, sortedValues);

        }
    }
}
