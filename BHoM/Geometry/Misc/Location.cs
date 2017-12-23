using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: We should get rid of this!!!
namespace BH.oM.Geometry
{
    [Serializable] public class Location
    {
       Plane Plane { get; set; }
       Line Line { get; set; }
    }
}
