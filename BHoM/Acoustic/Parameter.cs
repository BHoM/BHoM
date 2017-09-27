using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Acoustic
{
    /// <summary>
    /// BHom Acoustic parameters class
    /// </summary>
    public abstract class Parameter
    {
        #region Fields

        private double _Value;
        private int _ReceiverID;
        private List<double> _Octaves;

        #endregion

        #region Properties

        public double Value
        {
            get { return _Value; }
            set { _Value = Value; }
        }

        public int ReceiverID
        {
            get { return _ReceiverID; }
            set { _ReceiverID = ReceiverID; }
        }

        public List<double> Octaves
        {
            get { return _Octaves; }
            set { _Octaves = Octaves; }
        }

        /************** Additional Properties *****************/

        public List<double> Frequencies { get; set; }           // Ask Matthew H. why both Frequencies and Octaves?
        public List<double> Gains { get; set; }

        #endregion

    }
}
