/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2018, the respective contributors. All rights reserved.
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

using System.Collections.Generic;
using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Theatron_oM.Parameters
{
    public class AvalueSettings : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        //all coords in mm
        public double[] StaticConeX { get; set; } =  new double[] { -0.008136, 7.548412, 16.997918, 27.217361, 34.548925, 41.88076, 48.213106, 52.435109, 56.213162, 57.770071, 56.994269, 54.996491, 51.221881, 46.225199, 40.895078, 34.232081, 27.34661, 19.461345, 9.576501, 3.936608, 0.013036 };

        public double[] StaticConeY { get; set; } =  new double[] { 50.301575, 50.037897, 48.088549, 44.424773, 40.427291, 34.763692, 27.989191, 20.770042, 11.440409, -3.433e-11, -10.552197, -20.104918, -31.879422, -42.099083, -50.985901, -59.984016, -66.982826, -73.204279, -77.982093, -79.265102, -79.476365 };

        public double[] DynamicConeX { get; set; } =  new double[] { 0, 63.19951, 84.72067, 105.844444, 125.471906, 142.374011, 155.985056, 166.052471, 171.920272, 171.582365, 162.540237, 146.857892, 127.820782, 106.97819, 85.478666, 64.005213, 0 };

        public double[] DynamicConeY { get; set; } =  new double[] { -79.476365, -92.800481, -92.786387, -88.734578, -79.98072, -66.695225, -50.040009, -31.026623, -10.346131, 11.084337, 30.438085, 45.089297, 55.073263, 60.348579, 61.347173, 59.641446, 50.511209 };

        public double[] SpecY { get; set; } =  new double[] { -120.0, -117.685699, -107.690268, -94.640677, -69.096798, -38.832854, -5.636713, 20.60068, 44.29897, 71.805914, 98.889675, 124.2807, 145.863071, 164.671238, 177.210016, 184.524303, 192.361039, 212.214104, 236.769211, 269.161054, 317.226369, 375.740666, 437.912107, 512.622325, 595.169279, 676.148887, 756.606045, 851.169328, 922.222403, 921.55777 };

        public double[] SpecX { get; set; } =  new double[] { 0.0, -25.176012, -52.108146, -68.211896, -84.315646, -94.033426, -97.353852, -96.507485, -91.852464, -82.542421, -71.962827, -66.884622, -75.771481, -96.669444, -129.061287, -163.542926, -189.66538, -210.563343, -221.534774, -230.416408, -238.775594, -242.432737, -243.477635, -241.910288, -236.163348, -229.893959, -219.967427, -210.040894, -200.114362, 0.0, };
        
        public double ViewFrameX { get; set; } =  57.77;//for fov 41.41 use 37.6085;prop should parameterise the fov angle

        public double ViewFrameY { get; set; } =  57.77;//for fov 41.41 use 24.05695;

        public double EyeFrameDist { get; set; } =  100;

        public double StaticConeArea { get; set; } =  11402;//948.5768;

        public double DynamicConeArea { get; set; } =  45292;//2320.0909;

        public double ViewFrameArea { get; set; } =  3337;//;3618.9832;

        public double ForeheadSize { get; set; } =  120;

        public double NearHeadRange { get; set; } =  100;//dist from viewplane centre for nearest heads

        public int ClipType { get; set; } =  0;

        public bool Occlusion { get; set; } =  false;

        public bool ShowPPCurves { get; set; } =  false;

        public bool ShowCPCurves { get; set; } =  false;

        public bool ShowHCurves { get; set; } =  false;

        public bool ShowViewCones { get; set; } =  false;

        public bool ShowOutlines { get; set; } =  false;

        double Scale { get; set; } =  0.001;

        /***************************************************/
    }
}
