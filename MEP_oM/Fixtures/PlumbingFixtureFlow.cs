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
using BH.oM.Quantities.Attributes;

namespace BH.oM.MEP.Fixtures
{
    [Description("Flow properties of a plumbing fixture")]
    public class PlumbingFixtureFlow : BHoMObject, IFixtureFlow
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Volume]
        [Description("Volume of fluid supplied to a clothes washer per use through the plumbing fixture.")]
        public virtual double ClothesWasherVolumePerUse { get; set; } = 0;

        [Volume]
        [Description("Volume of fluid supplied to a dish washer per use through the plumbing fixture.")]
        public virtual double DishWasherVolumePerUse { get; set; } = 0;

        [Time]
        [Description("Duration of use measured in seconds.")]
        public virtual double KitchenFaucetAssumedUse { get; set; } = 0;

        [Volume]
        [Description("Volume of fluid supplied to a kitchen faucet per use through the plumbing fixture.")]
        public virtual double KitchenFaucetVolumePerUse { get; set; } = 0;

        [Time]
        [Description("Duration of use measured in seconds.")]
        public virtual double LavatoryAssumedUse { get; set; } = 0;

        [Volume]
        [Description("Volume of fluid supplied to a lavatory per use through the plumbing fixture.")]
        public virtual double LavatoryVolumePerUse { get; set; } = 0;

        [Volume]
        [Description("Volume of fluid supplied to a people washer per use through the plumbing fixture.")]
        public virtual double ShowerVolumePerUse { get; set; } = 0;

        [Time]
        [Description("Duration of use measured in seconds.")]
        public virtual double ShowerAssumedUse { get; set; } = 0;

        [Volume]
        [Description("Volume of fluid supplied to a toilet per use through the plumbing fixture.")]
        public virtual double ToiletVolumePerUse { get; set; } = 0;

        [Volume]
        [Description("Volume of fluid supplied to a urinal per use through the plumbing fixture.")]
        public virtual double UrinalVolumePerUse { get; set; } = 0;
        /***************************************************/
    }
}


