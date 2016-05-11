using System;
using System.Collections.Generic;
using System.Linq;
using BHoM.Structural.SectionProperties;
using System.Xml;
using BHoM.Global;

namespace BHoM.Structural
{
    /// <summary>
    /// Structure class represents a collection of structural objects
    /// </summary>
    [Serializable]
    public class Structure : IStructuralObject
    {
        private Dictionary<Guid, BHoM.Global.BHoMObject> m_Objects;
        private Project m_Project;
        internal XmlDocument m_Xml;

       /// <summary>Structure number</summary>
        public int Number { get; private set; }

        /// <summary>Structure name</summary>
        public string Name { get; private set; }

        /// <summary>Dictionary of storeys</summary>
        public Dictionary<int, Storey> Storeys { get; private set; }
        
        /// <summary>Tolerance of structure for node merge etc</summary>
        public double Tolerance { get; private set; }


        /// <summary>
        /// Collection of Node objects
        /// </summary>
        public ObjectCollection<Node> NodeCollection
        {
            get
            {
                return new ObjectCollection<Node>();
            }
        }

        internal Structure(Project project, Dictionary<Guid, BHoMObject> objects)
        {
            this.m_Project = project;
            this.m_Objects = objects;
        }

        public BHoM.Global.BHoMObject GetObject(Guid id)
        {
            BHoM.Global.BHoMObject result = null;
            m_Objects.TryGetValue(id, out result);
            return result;
        }

        /// <summary>
        /// Sort nodal faces
        /// </summary>
        /// <returns></returns>
        public bool SortNodalFaces()
        {
            return false;
        }

        /// <summary>Sets the structure name</summary>
        public void SetName(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Set the structure number
        /// </summary>
        /// <param name="number"></param>
        public void SetNumber(int number)
        {
            this.Number = number;
        }

        /// <summary>
        /// Sets the internal tolerance for which structural node merging etc. will be performed
        /// </summary>
        /// <param name="tol"></param>
        public void SetTolerance(double tol)
        {
            Tolerance = tol;
        }

    }
}
