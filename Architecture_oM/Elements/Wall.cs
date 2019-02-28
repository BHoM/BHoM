/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
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
using BH.oM.Common.Properties;
using BH.oM.Common.Interface;

namespace BH.oM.Architecture.Elements
{
    public class Wall : BHoMObject, IObject2D
    {
        public Object2DProperties Properties { get; set; } = new Object2DProperties();
        public ISurface Surface { get; set; } = new NurbsSurface();

        /*
        Methods to implement in BHoM_Engine

        //Create

        public static Wall Wall(PolyCurve profile, Material material, double thickness)
        {
            //Add checks

            Wall aWall = new Wall();
            aWall.Surface = Create.NurbsSurface(Query.IControlPoints(profile));
            aWall.Properties.AddCompoundLayer(material, thickness);

            return aWall
        }

        public static Wall Wall(PolyCurve profile, Object2DProperties properties)
        {
            //Add checks

            Wall aWall = new Wall()
            {
                Profile = profile,
                Properties = properties
            };

            return aWall
        }

        public static Wall Wall(ICurve location, double height, Object2DProperties properties)
        {
            //Add checks

            //To implement GetProfile method from Location curve and height
            ISurface aSurface = GetSurface(location, height)

            Wall aWall = new Wall()
            {
                Surface = aSurface,
                Properties = properties
            };

            return aWall
        }

        */
    }
}
