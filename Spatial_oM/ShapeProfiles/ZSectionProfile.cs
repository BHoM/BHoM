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

using BH.oM.Base;
using BH.oM.Geometry;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Spatial.ShapeProfiles
{
    public class ZSectionProfile : BHoMObject, IProfile, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual ShapeType Shape { get; } = ShapeType.Zed;

        public virtual double Height { get; }

        public virtual double FlangeWidth { get; }

        public virtual double WebThickness { get; }

        public virtual double FlangeThickness { get; }

        public virtual double RootRadius { get; }

        public virtual double ToeRadius { get; }

        public virtual bool MirrorAboutLocalZ { get; }

        public virtual ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public ZSectionProfile(double height, double flangeWidth, double webthickness, double flangeThickness, double rootRadius, double toeRadius, bool mirrorAboutLocalZ, IEnumerable<ICurve> edges)
        {
            Height = height;
            FlangeWidth = flangeWidth;
            WebThickness = webthickness;
            FlangeThickness = flangeThickness;
            RootRadius = rootRadius;
            ToeRadius = toeRadius;
            MirrorAboutLocalZ = mirrorAboutLocalZ;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }


        /***************************************************/
    }
}



