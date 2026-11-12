/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
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

using BH.oM.Base.Attributes;
using System.ComponentModel;

namespace BH.oM.Classification.Project
{
    [Description("A country or territory, named in the ISO 3166 style long form (e.g. United_Kingdom_of_Great_Britain_and_Northern_Ireland).")]
    public enum CountryRegion
    {
        Undefined,
        Afghanistan,
        [DisplayText("Aland Islands")]
        Aland_Islands,
        Albania,
        Algeria,
        [DisplayText("American Samoa")]
        American_Samoa,
        Andorra,
        Angola,
        Anguilla,
        Antarctica,
        [DisplayText("Antigua and Barbuda")]
        Antigua_and_Barbuda,
        Argentina,
        Armenia,
        Aruba,
        Australia,
        Austria,
        Azerbaijan,
        Bahamas,
        Bahrain,
        Bangladesh,
        Barbados,
        Belarus,
        Belgium,
        Belize,
        Benin,
        Bermuda,
        Bhutan,
        Bolivia,
        [DisplayText("Bonaire Sint Eustatius and Saba")]
        Bonaire_Sint_Eustatius_and_Saba,
        [DisplayText("Bosnia and Herzegovina")]
        Bosnia_and_Herzegovina,
        Botswana,
        [DisplayText("Bouvet Island")]
        Bouvet_Island,
        Brazil,
        [DisplayText("British Indian Ocean Territory")]
        British_Indian_Ocean_Territory,
        [DisplayText("Brunei Darussalam")]
        Brunei_Darussalam,
        Bulgaria,
        [DisplayText("Burkina Faso")]
        Burkina_Faso,
        Burundi,
        [DisplayText("Cabo Verde")]
        Cabo_Verde,
        Cambodia,
        Cameroon,
        Canada,
        [DisplayText("Cayman Islands")]
        Cayman_Islands,
        [DisplayText("Central African Republic")]
        Central_African_Republic,
        Chad,
        Chile,
        China,
        [DisplayText("Christmas Island")]
        Christmas_Island,
        [DisplayText("Cocos Keeling Islands")]
        Cocos_Keeling_Islands,
        Colombia,
        Comoros,
        [DisplayText("Congo, the Democratic Republic of the")]
        Congo_the_Democratic_Republic_of_the,
        [DisplayText("Cook Islands")]
        Cook_Islands,
        [DisplayText("Costa Rica")]
        Costa_Rica,
        [DisplayText("Cote dIvoire")]
        Cote_dIvoire,
        Croatia,
        Cuba,
        Curacao,
        Cyprus,
        Czechia,
        Denmark,
        Djibouti,
        Dominica,
        [DisplayText("Dominican Republic")]
        Dominican_Republic,
        Ecuador,
        Egypt,
        [DisplayText("El Salvador")]
        El_Salvador,
        [DisplayText("Equatorial Guinea")]
        Equatorial_Guinea,
        Eritrea,
        Estonia,
        Eswatini,
        Ethiopia,
        [DisplayText("Falkland Islands")]
        Falkland_Islands,
        [DisplayText("Faroe Islands")]
        Faroe_Islands,
        Fiji,
        Finland,
        France,
        [DisplayText("French Guiana")]
        French_Guiana,
        [DisplayText("French Polynesia")]
        French_Polynesia,
        [DisplayText("French Southern Territories")]
        French_Southern_Territories,
        Gabon,
        Gambia,
        Georgia,
        Germany,
        Ghana,
        Gibraltar,
        Greece,
        Greenland,
        Grenada,
        Guadeloupe,
        Guam,
        Guatemala,
        Guernsey,
        Guinea,
        [DisplayText("Guinea Bissau")]
        Guinea_Bissau,
        Guyana,
        Haiti,
        [DisplayText("Heard Island and McDonald Islands")]
        Heard_Island_and_McDonald_Islands,
        [DisplayText("Holy See")]
        Holy_See,
        Honduras,
        [DisplayText("Hong Kong")]
        Hong_Kong,
        Hungary,
        Iceland,
        India,
        Indonesia,
        [DisplayText("Iran, Islamic Republic of")]
        Iran_Islamic_Republic_of,
        Iraq,
        Ireland,
        [DisplayText("Isle of Man")]
        Isle_of_Man,
        Israel,
        Italy,
        Jamaica,
        Japan,
        Jersey,
        Jordan,
        Kazakhstan,
        Kenya,
        Kiribati,
        [DisplayText("Korea, Democratic Peoples Republic of")]
        Korea_Democratic_Peoples_Republic_of,
        [DisplayText("Korea, the Republic of")]
        Korea_the_Republic_of,
        Kuwait,
        Kyrgyzstan,
        [DisplayText("Lao Peoples Democratic Republic")]
        Lao_Peoples_Democratic_Republic,
        Latvia,
        Lebanon,
        Lesotho,
        Liberia,
        Libya,
        Liechtenstein,
        Lithuania,
        Luxembourg,
        Macao,
        Madagascar,
        Malawi,
        Malaysia,
        Maldives,
        Mali,
        Malta,
        [DisplayText("Marshall Islands")]
        Marshall_Islands,
        Martinique,
        Mauritania,
        Mauritius,
        Mayotte,
        Mexico,
        [DisplayText("Micronesia, Federated States of")]
        Micronesia_Federated_States_of,
        [DisplayText("Moldova, the Republic of")]
        Moldova_the_Republic_of,
        Monaco,
        Mongolia,
        Montenegro,
        Montserrat,
        Morocco,
        Mozambique,
        Myanmar,
        Namibia,
        Nauru,
        Nepal,
        Netherlands,
        [DisplayText("New Caledonia")]
        New_Caledonia,
        [DisplayText("New Zealand")]
        New_Zealand,
        Nicaragua,
        Niger,
        Nigeria,
        Niue,
        [DisplayText("Norfolk Island")]
        Norfolk_Island,
        [DisplayText("Northern Mariana Islands")]
        Northern_Mariana_Islands,
        Norway,
        Oman,
        Pakistan,
        Palau,
        [DisplayText("Palestine, State of")]
        Palestine_State_of,
        Panama,
        [DisplayText("Papua New Guinea")]
        Papua_New_Guinea,
        Paraguay,
        Peru,
        Philippines,
        Pitcairn,
        Poland,
        Portugal,
        [DisplayText("Puerto Rico")]
        Puerto_Rico,
        Qatar,
        [DisplayText("Republic of North Macedonia")]
        Republic_of_North_Macedonia,
        [DisplayText("Réunion")]
        Reunion,
        Romania,
        [DisplayText("Russian Federation")]
        Russian_Federation,
        Rwanda,
        [DisplayText("Saint Barthélemy")]
        Saint_Barthelemy,
        [DisplayText("Saint Helena, Ascension and Tristan da Cunha")]
        Saint_Helena_Ascension_and_Tristan_da_Cunha,
        [DisplayText("Saint Kitts and Nevis")]
        Saint_Kitts_and_Nevis,
        [DisplayText("Saint Lucia")]
        Saint_Lucia,
        [DisplayText("Saint Martin, French part")]
        Saint_Martin_French_part,
        [DisplayText("Saint Pierre and Miquelon")]
        Saint_Pierre_and_Miquelon,
        [DisplayText("Saint Vincent and the Grenadines")]
        Saint_Vincent_and_the_Grenadines,
        Samoa,
        [DisplayText("San Marino")]
        San_Marino,
        [DisplayText("Sao Tome and Principe")]
        Sao_Tome_and_Principe,
        [DisplayText("Saudi Arabia")]
        Saudi_Arabia,
        Senegal,
        Serbia,
        Seychelles,
        [DisplayText("Sierra Leone")]
        Sierra_Leone,
        Singapore,
        [DisplayText("Sint Maarten, Dutch part")]
        Sint_Maarten_Dutch_part,
        Slovakia,
        Slovenia,
        [DisplayText("Solomon Islands")]
        Solomon_Islands,
        Somalia,
        [DisplayText("South Africa")]
        South_Africa,
        [DisplayText("South Georgia and the South Sandwich Islands")]
        South_Georgia_and_the_South_Sandwich_Islands,
        [DisplayText("South Sudan")]
        South_Sudan,
        Spain,
        [DisplayText("Sri Lanka")]
        Sri_Lanka,
        Sudan,
        Suriname,
        [DisplayText("Svalbard and Jan Mayen")]
        Svalbard_and_Jan_Mayen,
        Sweden,
        Switzerland,
        [DisplayText("Syrian, Arab Republic")]
        Syrian_Arab_Republic,
        Taiwan,
        Tajikistan,
        [DisplayText("Tanzania, United Republic of")]
        Tanzania_United_Republic_of,
        Thailand,
        [DisplayText("The Congo")]
        The_Congo,
        [DisplayText("Timor Leste")]
        Timor_Leste,
        Togo,
        Tokelau,
        Tonga,
        [DisplayText("Trinidad and Tobago")]
        Trinidad_and_Tobago,
        Tunisia,
        Turkey,
        Turkmenistan,
        [DisplayText("Turks and Caicos Islands")]
        Turks_and_Caicos_Islands,
        Tuvalu,
        Uganda,
        Ukraine,
        [DisplayText("United Arab Emirates")]
        United_Arab_Emirates,
        [DisplayText("United Kingdom")]
        United_Kingdom_of_Great_Britain_and_Northern_Ireland,
        [DisplayText("United States, Minor Outlying Islands")]
        United_States_Minor_Outlying_Islands,
        [DisplayText("United States of America")]
        United_States_of_America,
        Uruguay,
        Uzbekistan,
        Vanuatu,
        Venezuela,
        [DisplayText("Viet Nam")]
        Viet_Nam,
        [DisplayText("Virgin Islands British")]
        Virgin_Islands_British,
        [DisplayText("Virgin Islands US")]
        Virgin_Islands_US,
        [DisplayText("Wallis and Futuna")]
        Wallis_and_Futuna,
        [DisplayText("Western Sahara")]
        Western_Sahara,
        Yemen,
        Zambia,
        Zimbabwe,
    }
}
