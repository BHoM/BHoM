namespace BH.oM.Structural.Properties
{
    public class Ribbed : Property2D
    {
        public PanelDirection Direction { get; set; }
        public double TotalDepth { get; set; }
        public double StemWidth { get; set; }
        public double Spacing { get; set; }

        internal Ribbed() { }
        public Ribbed(string name) : base(name) { Type = PanelType.Slab; }

        public Ribbed(string name, double slabDepth, double totalDepth, double stemWidth, double spacing, PanelDirection direction) : this(name)
        {
            Thickness = slabDepth;
            TotalDepth = totalDepth;
            StemWidth = stemWidth;
            Spacing = spacing;
            Direction = direction;
        }
    }
}
