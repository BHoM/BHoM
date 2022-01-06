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
using BH.oM.Humans.BodyParts;

namespace BH.oM.Humans
{    public class Skeleton : BHoMObject, IHumanRole
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual Head Head { get; set; } = new Head();

        public virtual RightHand RightHand { get; set; } = new RightHand();

        public virtual LeftHand LeftHand { get; set; } = new LeftHand();

        public virtual RightThumb RightThumb { get; set; } = new RightThumb();

        public virtual LeftThumb LeftThumb { get; set; } = new LeftThumb();

        public virtual Neck Neck { get; set; } = new Neck();

        public virtual RightShoulder RightShoulder { get; set; } = new RightShoulder();

        public virtual LeftShoulder LeftShoulder { get; set; } = new LeftShoulder();

        public virtual Spine Spine { get; set; } = new Spine();

        public virtual RightHip RightHip { get; set; } = new RightHip();

        public virtual LeftHip LeftHip { get; set; } = new LeftHip();

        public virtual RightUpperArm RightUpperArm { get; set; } = new RightUpperArm();

        public virtual LeftUpperArm LeftUpperArm { get; set; } = new LeftUpperArm();

        public virtual RightLowerArm RightLowerArm { get; set; } = new RightLowerArm();

        public virtual LeftLowerArm LeftLowerArm { get; set; } = new LeftLowerArm();

        public virtual RightUpperLeg RightUpperLeg { get; set; } = new RightUpperLeg();

        public virtual LeftUpperLeg LeftUpperLeg { get; set; } = new LeftUpperLeg();

        public virtual RightLowerLeg RightLowerLeg { get; set; } = new RightLowerLeg();

        public virtual LeftLowerLeg LeftLowerLeg { get; set; } = new LeftLowerLeg();

        public virtual RightFoot RightFoot { get; set; } = new RightFoot();

        public virtual LeftFoot LeftFoot { get; set; } = new LeftFoot();


        /***************************************************/
    }

}



