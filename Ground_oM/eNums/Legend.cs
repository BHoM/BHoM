/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
using BH.oM.Base.Attributes;


namespace BH.oM.Structure.Elements
{
    /***************************************************/

    [Description("Geology description expressed as a single legend code based on the AGS schema v4.1.")]
    public enum Legend
    {
        [Description("Sand Backfill from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sand backfill")]
        SandBackfill = 901,
        [Description("Gravel Backfill from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravel backfill")]
        GravelBackfill = 902,
        [Description("Bentonite from the AGS schema added on 25/05/2010.")]
        [DisplayText("Bentonite")]
        Bentonite = 903,
        [Description("Grout from the AGS schema added on 25/05/2010.")]
        [DisplayText("Grout")]
        Grout = 904,
        [Description("Arisings from the AGS schema added on 25/05/2010.")]
        [DisplayText("Arisings")]
        Arisings = 905,
        [Description("Concrete from the AGS schema added on 25/05/2010.")]
        [DisplayText("Concrete")]
        Concrete = 906,
        [Description("Asphalt from the AGS schema added on 24/12/2013.")]
        [DisplayText("Asphalt")]
        Asphalt = 907,
        [Description("Ballast from the AGS schema added on 24/12/2013.")]
        [DisplayText("Ballast")]
        Ballast = 908,
        [Description("Upstanding Cover from the AGS schema added on 24/12/2013.")]
        [DisplayText("Upstanding cover")]
        UpstandingCover = 909,
        [Description("Flush Cover from the AGS schema added on 24/12/2013.")]
        [DisplayText("Flush cover")]
        FlushCover = 910,
        [Description("Paving Slab from the AGS schema added on 09/01/2014.")]
        [DisplayText("Paving slab")]
        PavingSlab = 912,
        [Description("Timber from the AGS schema added on 03/11/2017.")]
        [DisplayText("Timber")]
        Timber = 913,
        [Description("Mortar from the AGS schema added on 08/12/2020.")]
        [DisplayText("Mortar")]
        Mortar = 914,
        [Description("Void from the AGS schema added on 06/07/2016.")]
        [DisplayText("Void")]
        Void = 999,
        [Description("Topsoil from the AGS schema added on 25/05/2010.")]
        [DisplayText("TOPSOIL")]
        Topsoil = 101,
        [Description("Made Ground from the AGS schema added on 25/05/2010.")]
        [DisplayText("MADE GROUND")]
        MadeGround = 102,
        [Description("Bituminous Material from the AGS schema added on 25/05/2010.")]
        [DisplayText("Bituminous Material")]
        BituminousMaterial = 103,
        [Description("Concrete from the AGS schema added on 25/05/2010.")]
        [DisplayText("CONCRETE")]
        ConcreteMaterial = 104,
        [Description("Wood from the AGS schema added on 17/05/2016.")]
        [DisplayText("Wood")]
        Wood = 105,
        [Description("Brickwork from the AGS schema added on 20/01/2021.")]
        [DisplayText("Brickwork")]
        Brickwork = 108,
        [Description("Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("CLAY")]
        Clay = 201,
        [Description("Silty Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty CLAY")]
        SiltyClay = 202,
        [Description("Sandy Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy CLAY")]
        SandyClay = 203,
        [Description("Gravelly Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravelly CLAY")]
        GravellyClay = 204,
        [Description("Cobbly Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Cobbly CLAY")]
        CobblyClay = 205,
        [Description("Bouldery Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Bouldery CLAY")]
        BoulderyClay = 206,
        [Description("Silty Sandy Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy CLAY")]
        SiltySandyClay = 207,
        [Description("Silty Gravelly Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty gravelly CLAY")]
        SiltyGravellyClay = 208,
        [Description("Silty Cobbly Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty cobbly CLAY")]
        SiltyCobblyClay = 209,
        [Description("Silty Bouldery Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty bouldery CLAY")]
        SiltyBoulderyClay = 210,
        [Description("Silty Sandy Gravelly Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy gravelly CLAY")]
        SiltySandyGravellyClay = 211,
        [Description("Silty Sandy Cobbly Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy cobbly CLAY")]
        SiltySandyCobblyClay = 212,
        [Description("Silty Sandy Bouldery Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy bouldery CLAY")]
        SiltySandyBoulderyClay = 213,
        [Description("Silty Sandy Gravelly Cobbly Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy gravelly cobbly CLAY")]
        SiltySandyGravellyCobblyClay = 214,
        [Description("Silty Sandy Gravelly Bouldery Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy gravelly bouldery CLAY")]
        SiltySandyGravellyBoulderyClay = 215,
        [Description("Silty Sandy Gravelly Cobbly Bouldery Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy gravelly cobbly bouldery CLAY")]
        SiltySandyGravellyCobblyBoulderyClay = 216,
        [Description("Silty Sandy Organic Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy organic CLAY")]
        SiltySandyOrganicClay = 217,
        [Description("Silty Sandy Gravelly Organic Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy gravelly organic CLAY")]
        SiltySandyGravellyOrganicClay = 218,
        [Description("Silty Organic Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty organic CLAY")]
        SiltyOrganicClay = 219,
        [Description("Sandy Gravelly Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy gravelly CLAY")]
        SandyGravellyClay = 220,
        [Description("Sandy Cobbly Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy cobbly CLAY")]
        SandyCobblyClay = 222,
        [Description("Sandy Bouldery Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy bouldery CLAY")]
        SandyBoulderyClay = 223,
        [Description("Sandy Gravelly Cobbly Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy gravelly cobbly CLAY")]
        SandyGravellyCobblyClay = 224,
        [Description("Sandy Gravelly Bouldery Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy gravelly bouldery CLAY")]
        SandyGravellyBoulderyClay = 225,
        [Description("Sandy Gravelly Cobbly Bouldery Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy gravelly cobbly bouldery CLAY")]
        SandyGravellyCobblyBoulderyClay = 226,
        [Description("Sandy Organic Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy organic CLAY")]
        SandyOrganicClay = 227,
        [Description("Sandy Gravelly Organic Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy gravelly organic CLAY")]
        SandyGravellyOrganicClay = 228,
        [Description("Organic Clay from the AGS schema added on 25/05/2010.")]
        [DisplayText("Organic CLAY")]
        OrganicClay = 229,
        [Description("Gravelly Cobbly Clay from the AGS schema added on 04/04/2017.")]
        [DisplayText("Gravelly cobbly CLAY")]
        GravellyCobblyClay = 230,
        [Description("Silty Gravelly Cobbly Clay from the AGS schema added on 17/05/2017.")]
        [DisplayText("Silty gravelly cobbly CLAY")]
        SiltyGravellyCobblyClay = 231,
        [Description("Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("SILT")]
        Silt = 301,
        [Description("Clay/Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clay/Silt")]
        ClayOrSilt = 302,
        [Description("Sandy Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy SILT")]
        SandySilt = 303,
        [Description("Gravelly Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravelly SILT")]
        GravellySilt = 304,
        [Description("Organic Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Organic SILT")]
        OrganicSilt = 305,
        [Description("Clayey Sandy Silt from the AGS schema added on 19/04/2017.")]
        [DisplayText("Clayey sandy SILT")]
        ClayeySandySilt = 309,
        [Description("Sandy Gravelly Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy gravelly SILT")]
        SandyGravellySilt = 310,
        [Description("Clayey Sandy Gravelly Silt from the AGS schema added on 26/10/2017.")]
        [DisplayText("Clayey sandy gravelly SILT")]
        ClayeySandyGravellySilt = 312,
        [Description("Clayey Sandy Gravelly Organic Cobbly Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey sandy gravelly organic cobbly SILT")]
        ClayeySandyGravellyOrganicCobblySilt = 314,

        [Description("Sandy Cobbly Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy cobbly SILT")]
        SandyCobblySilt = 316,
        [Description("Sandy Bouldery Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy bouldery SILT")]
        SandyBoulderySilt = 317,
        [Description("Sandy Organic Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy organic SILT")]
        SandyOrganicSilt = 318,
        [Description("Sandy Gravelly Organic Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy gravelly organic SILT")]
        SandyGravellyOrganicSilt = 319,
        [Description("Sandy Gravelly Cobbly Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy gravelly cobbly SILT")]
        SandyGravellyCobblySilt = 320,
        [Description("Sandy Gravelly Organic Cobbly Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy gravelly organic cobbly SILT")]
        SandyGravellyOrganicCobblySilt = 321,
        [Description("Gravelly Cobbly Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravelly cobbly SILT")]
        GravellyCobblySilt = 322,
        [Description("Gravelly Bouldery Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravelly bouldery SILT")]
        GravellyBoulderySilt = 323,
        [Description("Gravelly Organic Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravelly organic SILT")]
        GravellyOrganicSilt = 324,
        [Description("Gravelly Organic Cobbly Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravelly organic cobbly SILT")]
        GravellyOrganicCobblySilt = 325,
        [Description("Cobbly Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Cobbly SILT")]
        CobblySilt = 326,
        [Description("Cobbly Bouldery Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Cobbly bouldery SILT")]
        CobblyBoulderySilt = 327,
        [Description("Organic Cobbly Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Organic cobbly SILT")]
        OrganicCobblySilt = 328,
        [Description("Bouldery Silt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Bouldery SILT")]
        BoulderySilt = 331,
        [Description("Sandy Gravelly Clayey Cobbly Silt from the AGS schema added on 25/07/2017.")]
        [DisplayText("Sandy gravelly clayey cobbly SILT")]
        SandyGravellyClayeyCobblySilt = 332,
        [Description("Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("SAND")]
        Sand = 401,
        [Description("Clayey Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey SAND")]
        ClayeySand = 402,
        [Description("Silty Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty SAND")]
        SiltySand = 403,
        [Description("Gravelly Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravelly SAND")]
        GravellySand = 404,
        [Description("Cobbly Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Cobbly SAND")]
        CobblySand = 405,
        [Description("Bouldery Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Bouldery SAND")]
        BoulderySand = 406,
        [Description("Clayey Gravelly Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey gravelly SAND")]
        ClayeyGravellySand = 410,
        [Description("Clayey Gravelly Cobbly Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey gravelly cobbly SAND")]
        ClayeyGravellyCobblySand = 411,
        [Description("Silty Gravelly Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty gravelly SAND")]
        SiltyGravellySand = 412,
        [Description("Silty Gravelly Cobbly Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty gravelly cobbly SAND")]
        SiltyGravellyCobblySand = 413,
        [Description("Silty Gravelly Cobbly Bouldery Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty gravelly cobbly bouldery SAND")]
        SiltyGravellyCobblyBoulderySand = 414,
        [Description("Gravelly Cobbly Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravelly cobbly SAND")]
        GravellyCobblySand = 415,
        [Description("Gravelly Cobbly Bouldery Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravelly cobbly bouldery SAND")]
        GravellyCobblyBoulderySand = 416,
        [Description("Gravelly Bouldery Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravelly bouldery SAND")]
        GravellyBoulderySand = 417,
        [Description("Cobbly Bouldery Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Cobbly bouldery SAND")]
        CobblyBoulderySand = 418,
        [Description("Silty Cobbly Sand from the AGS schema added on 22/05/2017.")]
        [DisplayText("Silty cobbly SAND")]
        SiltyCobblySand = 419,
        [Description("Sand And Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("SAND and GRAVEL")]
        SandAndGravel = 430,
        [Description("Organic Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Organic SAND")]
        OrganicSand = 431,
        [Description("Silty Organic Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty organic SAND")]
        SiltyOrganicSand = 433,
        [Description("Gravelly Organic Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravelly organic SAND")]
        GravellyOrganicSand = 434,
        [Description("Cobbly Organic Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Cobbly organic SAND")]
        CobblyOrganicSand = 435,
        [Description("Bouldery Organic Sand from the AGS schema added on 25/05/2010.")]
        [DisplayText("Bouldery organic SAND")]
        BoulderyOrganicSand = 436,
        [Description("Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("GRAVEL")]
        Gravel = 501,
        [Description("Clayey Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey GRAVEL")]
        ClayeyGravel = 502,
        [Description("Silty Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty GRAVEL")]
        SiltyGravel = 503,
        [Description("Sandy Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy GRAVEL")]
        SandyGravel = 504,
        [Description("Organic Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Organic GRAVEL")]
        OrganicGravel = 505,
        [Description("Cobbly Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Cobbly GRAVEL")]
        CobblyGravel = 506,
        [Description("Bouldery Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Bouldery GRAVEL")]
        BoulderyGravel = 507,
        [Description("Clayey Sandy Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey sandy GRAVEL")]
        ClayeySandyGravel = 509,
        [Description("Clayey Cobbly Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey cobbly GRAVEL")]
        ClayeyCobblyGravel = 510,
        [Description("Clayey Bouldery Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey bouldery GRAVEL")]
        ClayeyBoulderyGravel = 511,
        [Description("Clayey Organic Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey organic GRAVEL")]
        ClayeyOrganicGravel = 512,
        [Description("Clayey Sandy Cobbly Gravel from the AGS schema added on 04/04/2017.")]
        [DisplayText("Clayey sandy cobbly GRAVEL")]
        ClayeySandyCobblyGravel = 513,
        [Description("Clayey Sandy Organic Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey sandy organic GRAVEL")]
        ClayeySandyOrganicGravel = 517,
        [Description("Silty Sandy Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy GRAVEL")]
        SiltySandyGravel = 520,
        [Description("Silty Cobbly Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty cobbly GRAVEL")]
        SiltyCobblyGravel = 521,
        [Description("Silty Bouldery Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty bouldery GRAVEL")]
        SiltyBoulderyGravel = 522,
        [Description("Silty Organic Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty organic GRAVEL")]
        SiltyOrganicGravel = 523,
        [Description("Silty Organic Sandy Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty organic sandy GRAVEL")]
        SiltyOrganicSandyGravel = 524,
        [Description("Sandy Cobbly Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy cobbly GRAVEL")]
        SandyCobblyGravel = 525,
        [Description("Sandy Bouldery Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy bouldery GRAVEL")]
        SandyBoulderyGravel = 526,
        [Description("Sandy Organic Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy organic GRAVEL")]
        SandyOrganicGravel = 527,
        [Description("Silty Sandy Cobbly Gravel from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy cobbly GRAVEL")]
        SiltySandyCobblyGravel = 528,
        [Description("Peat from the AGS schema added on 25/05/2010.")]
        [DisplayText("PEAT")]
        Peat = 601,
        [Description("Clayey Peat from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey PEAT")]
        ClayeyPeat = 602,
        [Description("Silty Peat from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty PEAT")]
        SiltyPeat = 603,
        [Description("Sandy Peat from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy PEAT")]
        SandyPeat = 604,
        [Description("Gravelly Peat from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravelly PEAT")]
        GravellyPeat = 605,
        [Description("Cobbly Peat from the AGS schema added on 25/05/2010.")]
        [DisplayText("Cobbly PEAT")]
        CobblyPeat = 606,
        [Description("Clayey Sandy Peat from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey sandy PEAT")]
        ClayeySandyPeat = 608,
        [Description("Clayey Gravelly Peat from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey gravelly PEAT")]
        ClayeyGravellyPeat = 609,
        [Description("Silty Sandy Peat from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy PEAT")]
        SiltySandyPeat = 612,
        [Description("Silty Sandy Gravelly Peat from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy gravelly PEAT")]
        SiltySandyGravellyPeat = 613,
        [Description("Sandy Gravelly Peat from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy gravelly PEAT")]
        SandyGravellyPeat = 614,
        [Description("Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("COBBLES")]
        Cobbles = 701,
        [Description("Clayey Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey COBBLES")]
        ClayeyCobbles = 702,
        [Description("Silty Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty COBBLES")]
        SiltyCobbles = 703,
        [Description("Sandy Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy COBBLES")]
        SandyCobbles = 704,
        [Description("Gravelly Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravelly COBBLES")]
        GravellyCobbles = 705,
        [Description("Organic Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Organic COBBLES")]
        OrganicCobbles = 706,
        [Description("Clayey Sandy Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey sandy COBBLES")]
        ClayeySandyCobbles = 708,
        [Description("Clayey Gravelly Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Clayey gravelly COBBLES")]
        ClayeyGravellyCobbles = 709,
        [Description("Silty Sandy Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy COBBLES")]
        SiltySandyCobbles = 713,
        [Description("Silty Gravelly Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty gravelly COBBLES")]
        SiltyGravellyCobbles = 714,
        [Description("Silty Organic Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty organic COBBLES")]
        SiltyOrganicCobbles = 715,
        [Description("Silty Gravelly Sandy Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty gravelly sandy COBBLES")]
        SiltyGravellySandyCobbles = 716,
        [Description("Silty Sandy Organic Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy organic COBBLES")]
        SiltySandyOrganicCobbles = 717,
        [Description("Silty Sandy Gravelly Organic Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Silty sandy gravelly organic COBBLES")]
        SiltySandyGravellyOrganicCobbles = 718,
        [Description("Sandy Gravelly Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy gravelly COBBLES")]
        SandyGravellyCobbles = 719,
        [Description("Sandy Organic Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Sandy organic COBBLES")]
        SandyOrganicCobbles = 720,
        [Description("Gravelly Organic Cobbles from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravelly organic COBBLES")]
        GravellyOrganicCobbles = 721,
        [Description("Cobbles And Boulders from the AGS schema added on 25/05/2010.")]
        [DisplayText("COBBLES and BOULDERS")]
        CobblesAndBoulders = 725,
        [Description("Boulders from the AGS schema added on 25/05/2010.")]
        [DisplayText("BOULDERS")]
        Boulders = 730,
        [Description("Gravelly Cobbly Boulders from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gravelly cobbly BOULDERS")]
        GravellyCobblyBoulders = 731,
        [Description("Mudstone from the AGS schema added on 25/05/2010.")]
        [DisplayText("MUDSTONE")]
        Mudstone = 801,
        [Description("Siltstone from the AGS schema added on 25/05/2010.")]
        [DisplayText("SILTSTONE")]
        Siltstone = 802,
        [Description("Sandstone from the AGS schema added on 25/05/2010.")]
        [DisplayText("SANDSTONE")]
        Sandstone = 803,
        [Description("Limestone from the AGS schema added on 25/05/2010.")]
        [DisplayText("LIMESTONE")]
        Limestone = 804,
        [Description("Chalk from the AGS schema added on 25/05/2010.")]
        [DisplayText("CHALK")]
        Chalk = 805,
        [Description("Coal from the AGS schema added on 25/05/2010.")]
        [DisplayText("COAL")]
        Coal = 806,
        [Description("Breccia from the AGS schema added on 25/05/2010.")]
        [DisplayText("BRECCIA")]
        Breccia = 807,
        [Description("Conglomerate from the AGS schema added on 25/05/2010.")]
        [DisplayText("CONGLOMERATE")]
        Conglomerate = 808,
        [Description("Fine Grained Igneous from the AGS schema added on 25/05/2010.")]
        [DisplayText("Fine grained IGNEOUS")]
        FineGrainedIgneous = 809,
        [Description("Medium Grained Igneous from the AGS schema added on 25/05/2010.")]
        [DisplayText("Medium grained IGNEOUS")]
        MediumGrainedIgneous = 810,
        [Description("Coarse Grained Igneous from the AGS schema added on 25/05/2010.")]
        [DisplayText("Coarse grained IGNEOUS")]
        CoarseGrainedIgneous = 811,
        [Description("Fine Grained Metamorphic from the AGS schema added on 25/05/2010.")]
        [DisplayText("Fine grained METAMORPHIC")]
        FineGrainedMetamorphic = 812,
        [Description("Medium Grained Metamorphic from the AGS schema added on 25/05/2010.")]
        [DisplayText("Medium grained METAMORPHIC")]
        MediumGrainedMetamorphic = 813,
        [Description("Coarse Grained Metamorphic from the AGS schema added on 25/05/2010.")]
        [DisplayText("Coarse grained METAMORPHIC")]
        CoarseGrainedMetamorphic = 814,
        [Description("Pyroclastic(Volcanic Ash) from the AGS schema added on 25/05/2010.")]
        [DisplayText("Pyroclastic(volcanic ash)")]
        PyroclasticVolcanicAsh=815,
        [Description("Gypsum, Rocksalt from the AGS schema added on 25/05/2010.")]
        [DisplayText("Gypsum, Rocksalt")]
        Gypsum, Rocksalt = 816,
        [Description("Shale from the AGS schema added on 25/05/2010.")]
        [DisplayText("Shale")]
        Shale = 817,
        [Description("Ironstone from the AGS schema added on 10/04/2017.")]
        [DisplayText("IRONSTONE")]
        Ironstone = 818,
        [Description("Slate from the AGS schema added on 04/12/2017.")]
        [DisplayText("SLATE")]
        Slate = 819,
        [Description("Broken Ground from the AGS schema added on 27/06/2017.")]
        [DisplayText("Broken Ground")]
        BrokenGround = 996,
        [Description("Undetermined from the AGS schema added on 01/10/2015.")]
        [DisplayText("Undetermined")]
        Undetermined = 997,
        [Description("No Recovery from the AGS schema added on 01/10/2015.")]
        [DisplayText("No Recovery")]
        NoRecovery = 998,
        [Description("Void from the AGS schema added on 25/05/2010.")]
        [DisplayText("Void")]
        Voided = 999,
    }

    /***************************************************/
}




