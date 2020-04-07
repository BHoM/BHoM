/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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

namespace BH.oM.Geometry.ShapeProfiles
{
    public class FabricatedBoxProfile : BHoMObject, IProfile, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual ShapeType Shape { get; } = ShapeType.Box;

        public virtual double Height { get; }

        public virtual double Width { get; }

        public virtual double WebThickness { get; }

        public virtual double TopFlangeThickness { get; }

        public virtual double BotFlangeThickness { get; }

        public virtual double WeldSize { get; }

        public virtual ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public FabricatedBoxProfile(double height, double width, double webThickness, double topFlangeThickness, double botFlangeThickness, double weldSize, IEnumerable<ICurve> edges)
        {
            Height = height;
            Width = width;
            WebThickness = webThickness;
            BotFlangeThickness = botFlangeThickness;
            TopFlangeThickness = topFlangeThickness;
            WeldSize = weldSize;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }


        /***************************************************/
    }
}

