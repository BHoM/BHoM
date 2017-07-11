using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Results
{
    public abstract class Envelope
    {
        public double[] Values { get; set; }
        public string[] Cases { get; set; }
        public string[] Keys { get; set; }
        public string[] Names { get; set; }
        public Envelope(List<string> valueNames)
        {
            Names = valueNames.ToArray();
            Values = new double[Names.Length];
            Cases = new string[Names.Length];
            Keys = new string[Names.Length];
        }

        public abstract Envelope Merge(Envelope e2);
    }

    public class MaxEnvelope : Envelope
    {
        public MaxEnvelope(List<string> valueNames) : base(valueNames)
        {
            for (int i = 0; i < Values.Length; i++)
            {
                Values[i] = double.MinValue;
            }
        }

        public override Envelope Merge(Envelope e2)
        {
            if (Values.Length == e2.Values.Length)
            {
                for (int i = 0; i < Values.Length; i++)
                {
                    if (Values[i] < e2.Values[i])
                    {
                        Values[i] = e2.Values[i];
                        Cases[i] = e2.Cases[i];
                        Keys[i] = e2.Keys[i];
                    }
                }
            }
            return this;
        }
    }

    public class MinEnvelope : Envelope
    {
        public MinEnvelope(List<string> valueNames) : base(valueNames)
        {
            for (int i = 0; i < Values.Length; i++)
            {
                Values[i] = double.MaxValue;
            }
        }
        public override Envelope Merge(Envelope e2)
        {
            if (Values.Length == e2.Values.Length)
            {
                for (int i = 0; i < Values.Length; i++)
                {
                    if (Values[i] > e2.Values[i])
                    {
                        Values[i] = e2.Values[i];
                        Cases[i] = e2.Cases[i];
                        Keys[i] = e2.Keys[i];
                    }
                }
            }
            return this;
        }
    }
}
