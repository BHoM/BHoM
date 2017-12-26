namespace BH.oM.Structural.Properties
{
    public class Waffle : Property2D
    {
        public double TotalDepthX { get; set; }
        public double TotalDepthY { get; set; }
        public double StemWidthX { get; set; }
        public double StemWidthY { get; set; }
        public double SpacingX { get; set; }
        public double SpacingY { get; set; }

        internal Waffle() { }

        public Waffle(string name) : base (name) { Type = PanelType.Slab; }

        public Waffle(string name, double slabDepth, double depthX, double depthY, double stemWidthX, double stemWidthY, double spacingX, double spacingY) : this(name)
        {
            Thickness = slabDepth;
            TotalDepthX = depthX;
            TotalDepthY = depthY;
            StemWidthX = stemWidthX;
            StemWidthY = stemWidthY;
            SpacingX = spacingX;
            SpacingY = spacingY;
        }
    }   
}
