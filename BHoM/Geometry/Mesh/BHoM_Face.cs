﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Meshface object
    /// </summary>
    [Serializable]
    public class Face
    {
        private int[] m_Indices;

        public int A
        {
            get { return m_Indices[0]; }
        }
        public int B
        {
            get { return m_Indices[1]; }
        }
        public int C
        {
            get { return m_Indices[2]; }
        }
        public int D
        {
            get { return m_Indices.Length > 3 ? m_Indices[3] : -1; }
        }

        internal Face(int[] indices)
        {
            m_Indices = indices;
        }

        public bool IsQuad
        {
            get
            {
                return m_Indices.Length == 4;
            }
        }

        public bool IsTriangle
        {
            get
            {
                return m_Indices.Length == 3;
            }
        }
    }
}
