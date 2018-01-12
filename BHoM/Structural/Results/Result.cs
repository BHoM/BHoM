using BH.oM.Structural.Interface;
using System;

namespace BH.oM.Structural.Results
{
    public abstract class Result<TName, TLoadcase, TTimeStep>
        where TName : IComparable
        where TLoadcase : IComparable
        where TTimeStep : IComparable
    {

        public string Id { get; set; }
        public TName Name { get; set; }
        public TLoadcase Loadcase { get; set; }
        public TTimeStep TimeStep { get; set; }

        public virtual IResult Duplicate()
        {
            return (IResult)this.MemberwiseClone();
        }

        public Result() { }      

        //public virtual int CompareTo(object obj)
        //{
        //    var r2 = obj as Result<TName, TLoadcase, TTimeStep>;
        //    if (r2 != null)
        //    {
        //        int n = this.Name.CompareTo(r2.Name);
        //        if (n == 0)
        //        {
        //            int l = this.Loadcase.CompareTo(r2.Loadcase);
        //            return l == 0 ? this.TimeStep.CompareTo(r2.TimeStep) : l;
        //        }
        //        else
        //        {
        //            return n;
        //        }
        //    }
        //    return 1;
        //}
    }
}
