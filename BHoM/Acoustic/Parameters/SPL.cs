using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Acoustic
{
    public class SPL : Parameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>
        /// Sound Pressure level
        /// </summary>
        protected override ParameterTypes Name { get; set; } = ParameterTypes.SPL;

        /// <summary>
        /// Sound Level result value in dB
        /// </summary>
        protected override double Value { get; set; } = 0;

        /// <summary>
        /// Receiver at SPL calculation
        /// </summary>
        protected override int ReceiverID { get; set; } = 0;

        /// <summary>
        /// Frequency of the analysed value
        /// </summary>
        protected override Frequency Octave { get; set; } = Octaves.Hz1000;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SPL() { }

        /***************************************************/

        public SPL(double value, int receiverID, Frequency octave)
        {
            Value = value;
            ReceiverID = receiverID;
            Octave = octave;
        }
    }
}