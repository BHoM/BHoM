using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural
{
    [Serializable]
    public class Bar
    {

        public int Number { get; private set; }
        public int Group { get; private set; }
        public string Name { get; private set; }
        
        ////// LENGTH AND EFFECTIVE LENGTHS //////
        public double Length { get; set; }
        public double Ley { get; set; }
        public double Lez { get; set; }
        public double Let { get; set; }

        public double SlackLength { get; set; }
        
        ////// SECTION PROPERTIES //////
        private int _sectionPropertyIndex;
        public string SectionPropertyName { get; private set; }
            
        public Node StartNode { get; private set; }
        public Node EndNode { get; private set; }
        public int StartNodeNumber { get; private set; }
        public int EndNodeNumber { get; private set; }
      
        public double OrientationAngle { get; set; }
     
        ////// CAPACITIES //////
        public double Lambda { get; set; } // non-dimensional slenderness
        
        public double NybRd { get; set; } //Design buckling resistance of a compression member (buckling about the y-y axis)
        public double NzbRd { get; set; } //Design buckling resistance of a compression member (buckling about the z-z axis)
        public double MybRd { get; set; } //Design buckling resistance about y-y axis (simplified interaction criterion - NCCI)
        public double MzcbRd { get; set; } //Design buckling resistance about z-z axis (simplified interaction criterion - NCCI)

        //American capacities
        public double phiPnt { get; set; } // tensile capacity

        public double phiPncx { get; set; } // compressive buckling about y-y axis
        public double phiPncy { get; set; } // compressive bckling about z-z axis
        public double phiPnct { get; set; } // lateral torional bucklng

        public double phiPnc { get; set; } // dominant compression capacity
        
        public double phiVnx { get; set; } // shear capacity
        public double phiVny { get; set; } // shear capacity

        ////// VIRTUAL WORK VARIABLES ////// Create subclass for this?
        public double n { get; set; } //Force in element under unit loadcase
        public double F { get; set; } //Force in element under loadcase
        public double Delta { get; private set; }
        public double changeR { get; set; } //Change ration for each element area
        public List<int> SymmetryIndices { get; set; } //Indices for symmetrical elements

        ////// OPTIMISATION //////
        public bool Change { get; set; } //Boolen to indicate wheter to change an element or not
        public bool Overutilised { get; set; } //Boolean to indicate wether an element is failing / overutilised under any loadcase
        public bool Underutilised { get; set; } //Boolean to indicate whether an element is utilised less than it should
        public bool Changed { get; set; } //Boolean to track wheter an element has been changed during an iteration
        public List<bool> UpsizeHistory { get; set; } //List to track upsizing
        public List<bool> DownsizeHistory { get; set; } //List to track downsizing
        public double MaxUtilisation { get; set; } //Maximum utilisation for upsizing decision NS 20141003
        public bool IsInLimbo { get; set; } 


        ////// LEGACY //////
        public double RatioInSuperBeam { get; set; }

        public SectionProperty SectionProperty;
        public Materials.Material Material;
        public string ReleaseName;
        public Release StartRelease;
        public Release EndRelease;
        public string TypeName;
        public string MaterialName;
        public BarStructuralUsage StructuralUsage;

        public string OffsetName;
        

        public Bar()
        {
            StartNodeNumber = -1;
            EndNodeNumber = -1;
            Number = -1;
            Name = "";
            SectionProperty = new SectionProperty(); 
            StartRelease = new Release();
            EndRelease = new Release();
            OrientationAngle = 0;
        }

        public Bar(Node startNode, Node endNode)
            : this()
        {
            SetStartNode(startNode);
            SetEndNode(endNode);
        }

        public Bar(Node startNode, Node endNode, int barNumber) 
            : this(startNode, endNode)
        {
            Number = barNumber;
        }

       public void SetStartNodeNumber(int startNodeNumber)
        {
            StartNodeNumber = startNodeNumber;
        }

        public void SetEndNodeNumber(int endNodeNumber)
        {
            EndNodeNumber = endNodeNumber;
        }

        public void SetStartNode(Node node)
        {
            StartNode = node;
            StartNodeNumber = node.Number;
        }

        public void SetEndNode(Node node)
        {
            EndNode = node;
            EndNodeNumber = node.Number;
        }

        public Node GetStartNode()
        {
            return StartNode;
        }

        public Node GetEndNode()
        {
            return EndNode;
        }

        public Node GetOtherEnd(Node node)
        {
            if (EndNode.Number == node.Number)
                return StartNode;
            else
                return EndNode;
        }

        public bool HasValidNumber()
        {
            return Number > 0;
        }

        public void SetNumber(int i)
        {
            this.Number = i;
        }

        public void  SetSectionPropertyName(string sectionPropertyName)
        {
            this.SectionPropertyName = sectionPropertyName;
        }
      
    }
}
