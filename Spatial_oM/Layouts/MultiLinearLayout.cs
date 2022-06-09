/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */


using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Quantities.Attributes;


namespace BH.oM.Spatial.Layouts
{
    [Description("Linear distribution of points along multiple linear parallel axes, defined along a vector from one side of the perimeter of the host object to the other. \n" +
                 "Starts by fitting in as many points as possible in the first layer, then generates a new one and repeats.")]
    public class MultiLinearLayout : BHoMObject, ILayout2D, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Number of points along the axis.")]
        public virtual int NumberOfPoints { get; set; }

        [Length]
        [Description("Minimum distance between any two points in the layout along the axis layers.")]
        public virtual double ParallelMinimumSpacing { get; set; }

        [Length]
        [Description("Minimum distance between any two layers.")]
        public virtual double PerpendicularMinimumSpacing { get; set; }

        [Description("Direction of the axis. Vector should lie in the XY-plane, i.e. have a Z-coordinate equal to 0.")]
        public virtual Vector Direction { get; }

        [Length]
        [Description("Offset of the linear layout in relation to the reference point, perpendicular to the Direction vector in the XY plane.\n" + 
                     "A positive value will mean an offset towards the centre of the boundingbox of the host objects.")]
        public virtual double Offset { get; }

        [Description("Controls which point on the host element that should be used for the layout.")]
        public virtual ReferencePoint ReferencePoint { get; set; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MultiLinearLayout(int numberOfPoints, double parallelMinimumSpacing, double perpendicularMinimumSpacing, Vector direction, double offset, ReferencePoint referencePoint)
        {
            NumberOfPoints = numberOfPoints;
            ParallelMinimumSpacing = parallelMinimumSpacing;
            PerpendicularMinimumSpacing = perpendicularMinimumSpacing;
            Direction = direction;
            Offset = offset;
            ReferencePoint = referencePoint;
        }

        /***************************************************/
    }
}


