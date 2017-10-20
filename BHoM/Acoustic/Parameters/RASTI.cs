using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Acoustic
{
    public class RASTI : Parameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>
        /// Rapid Speech Transmission Index
        /// </summary>
        protected override ParameterTypes Name { get; set; } = ParameterTypes.RASTI;

        /// <summary>
        /// STI result between 0 and 1
        /// </summary>
        protected override double Value { get; set; } = 0;

        /// <summary>
        /// Receiver at STI calculation
        /// </summary>
        protected override int ReceiverID { get; set; } = 0;

        /// <summary>
        /// Frequency of the analysed value
        /// </summary>
        protected override Frequency Octave { get; set; } = Octaves.Sum;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public RASTI() { }

        /***************************************************/

        public RASTI(double value, int receiverID, Frequency octave)
        {
            Value = value;
            ReceiverID = receiverID;
            Octave = octave;
        }
    }
}