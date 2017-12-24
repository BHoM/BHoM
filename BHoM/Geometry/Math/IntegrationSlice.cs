namespace BH.oM.Geometry
{
    public struct IntegrationSlice
    {
        public double Width;
        public double Length;
        public double Centre;
        public double[] Placement;

        public IntegrationSlice(double width, double length, double centre, double[] placement)
        {
            Width = width;
            Length = length;
            Centre = centre;
            Placement = placement;
        }
    }
}
