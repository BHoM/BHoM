using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Global;
using BHoM.Base;
using System.Reflection;

namespace BHoM.Geometry
{
    public abstract class GeometryBase
    {
        public Guid Id { get; set; }
        
        internal GeometryBase() { Id = new Guid(); }

        public abstract BoundingBox Bounds();
        public abstract void Transform(Transform t);
        public abstract void Translate(Vector v);
        public abstract void Mirror(Plane p);
        public abstract void Project(Plane p);
        public abstract void Update();
        public abstract GeometryBase Duplicate();

        /// <summary>Create a shallow copy of the object</summary>
        public GeometryBase ShallowClone()
        {
            return (GeometryBase)this.MemberwiseClone();
        }

        public abstract string ToJSON();
        
        /// <summary>
        /// Creates a geometry object from a json format string
        /// </summary>
        /// <param name="json"></param>
        /// <returns>Geometry object</returns>
        public static GeometryBase FromJSON(string json, Project project = null)
        {
            if (project == null)
                project = Global.Project.ActiveProject;

            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);
            string typeString = null;
            if (!definition.TryGetValue("__Type__", out typeString))
                definition.TryGetValue("Primitive", out typeString);
            if (typeString == null)
                return null;
            typeString = typeString.Replace("\"", "").Replace("{", "").Replace("}", "");
            
            Type type = Type.GetType(typeString);
            if (type == null)
                type = Type.GetType("BHoM.Geometry." + typeString);

            MethodInfo methodInfo = type.GetMethod("FromJSON", System.Reflection.BindingFlags.Static | BindingFlags.Public);
            return methodInfo.Invoke(null, new object[] { json, project }) as GeometryBase;           
        }
    }
}
