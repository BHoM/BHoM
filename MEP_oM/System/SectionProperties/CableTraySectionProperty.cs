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

using BH.oM.Base;
using BH.oM.MEP.System.MaterialFragments;
using BH.oM.Physical.Materials;

namespace BH.oM.MEP.System.SectionProperties
{
    public class CableTraySectionProperty : BHoMObject, IImmutable
    {
        /***************************************************/
        /****                 Properties                ****/
        /***************************************************/

        [Description("The cable tray material is the primary material that the it is composed of.")]
        public virtual Material Material { get; set; }     

        [Description("The section profile of the object that will determine its use within a System.")]
        public virtual SectionProfile SectionProfile { get; }

        [Description("This area takes the element's thickness into account to determine the actual area of the 'solid' portion of the ShapeProfile.")]
        public virtual double ElementSolidArea { get; }

        [Description("The interior area within the element's shapeProfile. This corresponds to the actual open area less any material thickness.")]
        public virtual double ElementVoidArea { get; }

        /***************************************************/
        /****                 Constructor               ****/
        /***************************************************/
        
        public CableTraySectionProperty(Material material,SectionProfile sectionProfile, double elementSolidArea, double elementVoidArea)
        {
            Material = material;
            SectionProfile = sectionProfile;
            ElementSolidArea = elementSolidArea;
            ElementVoidArea = elementVoidArea;            
        }

        /***************************************************/
    }
}


