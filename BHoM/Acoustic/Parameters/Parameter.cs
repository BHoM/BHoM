using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Acoustic
{
    public abstract class Parameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>
        /// Acoustic parameter objective of the analysis
        /// </summary>
        public virtual ParameterTypes Name { get; set; } = ParameterTypes.SPL;

        /// <summary>
        /// Result value as a double
        /// </summary>
        public virtual double Value { get; set; } = 0;

        /// <summary>
        /// Receiver that owns the calculated result value
        /// </summary>
        public virtual int ReceiverID { get; set; } = 0;

        /// <summary>
        /// Speaker that generates the calculated result value
        /// </summary>
        public virtual int SpeakerID { get; set; } = 0;

        /// <summary>
        /// Frequency address of the calculated value
        /// </summary>
        public virtual Frequency Octave { get; set; } = Octaves.Hz1000;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Parameter() { }
    }
}
