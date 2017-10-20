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
        protected virtual ParameterTypes Name { get; set; } = ParameterTypes.SPL;

        /// <summary>
        /// Result value as a double
        /// </summary>
        protected virtual double Value { get; set; } = 0;

        /// <summary>
        /// Receiver that owns the calculated result value
        /// </summary>
        protected virtual int ReceiverID { get; set; } = 0;

        /// <summary>
        /// Frequency address of the calculated value
        /// </summary>
        protected virtual Frequency Octave { get; set; } = Octaves.Hz1000;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        protected Parameter() { }
    }
}
