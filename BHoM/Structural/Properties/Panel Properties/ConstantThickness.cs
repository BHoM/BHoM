namespace BH.oM.Structural.Properties
{
    [Serializable]
    public class ConstantThickness : Property2D
    {
        public ConstantThickness() { }
        public ConstantThickness(string name) : base(name) { Type = PanelType.Undefined; }
        public ConstantThickness(string name, double thickness, PanelType type) : this(name)
        {
            Thickness = thickness;
            Type = type;
        }
    }
}
