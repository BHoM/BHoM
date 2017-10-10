using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Acoustic
{
    public abstract class Result
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>
        /// Acoustic parameter objective of the analysis
        /// </summary>
        protected virtual Parameter Parameter { get; set; } = Parameter.SPL;

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
        protected virtual int Octaves { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        protected Result() { }
    }
}
