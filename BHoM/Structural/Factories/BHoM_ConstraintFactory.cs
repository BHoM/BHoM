using BHoM.Global;
using System.Collections.Generic;

namespace BHoM.Structural
{
    /// <summary>
    /// 
    /// </summary>
    public class ConstraintFactory : ObjectFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public ConstraintFactory(Project p) : base(p) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="constraint"></param>
        public ConstraintFactory(Project p, List<BHoM.Global.BHoMObject> constraint) : base(p, constraint) { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Constraint Create()
        {
            return new Constraint();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="xx"></param>
        /// <param name="yy"></param>
        /// <param name="zz"></param>
        /// <returns></returns>
        public Constraint Create(string name, double x, double y, double z, double xx, double yy, double zz)
        {
            if (this.ContainsName(name))
            {
                return this[name] as Constraint;
            }
            else
            {
                return new Constraint(name, new double[] { 0, 0, 0, 0, 0, 0 });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="xx"></param>
        /// <param name="yy"></param>
        /// <param name="zz"></param>
        /// <returns></returns>
        public Constraint Create(string name, bool x, bool y, bool z, bool xx, bool yy, bool zz)
        {
            if (this.ContainsName(name))
            {
                return this[name] as Constraint;
            }
            else
            {
                Constraint c = new Constraint(name, new bool[] { x, y, z, xx, yy, zz }, new double[6]);
                this.Add(c);
                return c;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fixity"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public Constraint Create(string name, bool[] fixity, double[] values)
        {
            if (this.ContainsName(name))
            {
                return this[name] as Constraint;
            }
            else
            {
                Constraint c = new Constraint(name, fixity, values);
                this.Add(c);
                return c;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fixity">Constraint string x indicates fixity and f indices freedom must be 6 characters long or nothing will be returned</param>
        /// <returns></returns>
        public Constraint Create(string name, string fixity)
        {
            if (this.ContainsName(name))
            {
                return this[name] as Constraint;
            }
            else
            {
                if (fixity.Length == 6)
                {
                    bool[] f = new bool[6];
                    for (int i = 0; i < 6; i++)
                    {
                        f[i] = fixity[i] == 'x';
                    }
                    return new Constraint(name, f, new double[6]);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}