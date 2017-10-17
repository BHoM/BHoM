using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Results
{
    public class PanelForce : PanelForce<int, int, int>
    {
        public PanelForce() : base() { }
        public PanelForce(int number, int node, int loadcase, int timeStep, double fx, double fy, double fz, double mx, double my, double mz, double vx, double vy)
            : base(number, node, loadcase, timeStep, fx, fy, fz, mx, my, mz, vx, vy)
        { }
    }

    public class PanelForce<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {

        public PanelForce()
        { }

        public PanelForce(TName number, TName node, TLoadcase loadcase, TTimeStep timeStep, double nx, double ny, double nxy, double mx, double my, double mxy, double vx, double vy) : this()
        {
            Name = number;
            TimeStep = timeStep;
            Loadcase = loadcase;
            Node = node;
            Id = Name + ":" + Node + ":" + loadcase + ":" + TimeStep;
            NXX = nx;
            NYY = ny;
            NXY = nxy;
            MXX = mx;
            MYY = my;
            MXY = mxy;
            VX = vx;
            VY = vy;
        }

        public TName Node { get; set; }
        
        public double NXX { get; set; }
        
        public double NYY { get; set; }
        
        public double NXY { get; set; }
        
        public double MXX { get; set; }
        
        public double MYY { get; set; }
        
        public double MXY { get; set; }
        
        public double VX { get; set; }
        
        public double VY { get; set; }        
    }
}
