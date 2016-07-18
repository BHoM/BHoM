﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Global;

namespace BHoM.Geometry
{
    public class Group : Group<GeometryBase> { }

    public class Group<T> : GeometryBase, IEnumerable<T> where T : GeometryBase 
    {
        private List<T> m_Geometry;
        private BoundingBox m_Bounds;

        public Group()
        {
            m_Geometry = new List<T>();
        }

        public Group(List<T> geometry)
        {
            m_Geometry = geometry;
        }

        public void Add(T geometry)
        {
            m_Geometry.Add(geometry);
        }

        public void AddRange(IEnumerable<T> geometry)
        {
            m_Geometry.AddRange(geometry);
        }

        internal List<T> Geometry()
        {
            return m_Geometry;
        }

        internal List<T> GeometryData { set { m_Geometry = value; } }

        public T this[int i]
        {
            get
            {
                return m_Geometry.Count > i ? m_Geometry[i] : default(T);
            }
        }

        public int Count
        {
            get
            {
                return m_Geometry.Count;
            }
        }

        public override BoundingBox Bounds()
        {
            if (m_Bounds == null)
            {
                m_Bounds = m_Geometry[0].Bounds();
                for (int i = 1; i < m_Geometry.Count; i++)
                {
                    m_Bounds = BoundingBox.Merge(m_Bounds, m_Geometry[i].Bounds());
                }
            }
            return m_Bounds;           
        }

        public Group<T> DuplicateGroup()
        {
            Group<T> group = new Group<T>();
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                group.m_Geometry.Add((T)m_Geometry[i].Duplicate());
            }
            return group;
        }

        public override GeometryBase Duplicate()
        {
            return DuplicateGroup();
        }

        public override void Mirror(Plane p)
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Mirror(p);
            }
            Update();
        }

        public override void Project(Plane p)
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Project(p);
            }
            Update();
        }

        public override void Transform(Transform t)
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Transform(t);
            }
            Update();
        }

        public override void Translate(Vector v)
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Translate(v);
            }
            Update();
        }

        public override void Update()
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Update();
            }
            m_Bounds = null;
        }

        public override string ToJSON()
        {
            return "{\"Primitive\": \"group\", \"groupType\": \""+ typeof(T).FullName + "\"," + BHoMJSON.WriteProperty("group", m_Geometry) + "}";
        }

        public static new GeometryBase FromJSON(string json, Project project)
        {
            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);
            if (!definition.ContainsKey("Primitive")) return null;
            var typeString = definition["Primitive"].Replace("\"", "").Replace("{", "").Replace("}", "");
            Type groupDataType = Type.GetType(definition["groupType"].Trim('\"', '\"'));
            var groupType = typeof(Group<>);
            var dataType = typeof(List<>);
            var data = dataType.MakeGenericType(groupDataType);
            var groupofType = groupType.MakeGenericType(groupDataType);
            var group = Activator.CreateInstance(groupofType);
            System.Reflection.MethodInfo jsonMethod = groupofType.GetMethod("AddRange");
            if (jsonMethod != null)
            {
                object result = jsonMethod.Invoke(group, new object[] { BHoMJSON.ReadValue(data, definition["group"], project) });
            }      
            return group as GeometryBase;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return m_Geometry.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_Geometry.GetEnumerator();
        }
    }
}
