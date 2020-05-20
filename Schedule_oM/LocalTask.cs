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

using BH.oM.Schedule.Enums;
using BH.oM.Schedule.Microsoft.Project.Online.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BH.oM.Schedule
{
    [Description("LocalTask that can house various scheduling software programme data formats")]
    public class LocalTask
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual Guid Id { get; set; }
        public virtual Guid ParentId { get; set; }
        public virtual LocalTask Parent { get; set; }
        public virtual Microsoft.Project.Desktop.Components.Task DesktopTask { get; set; }
        public virtual Task OnlineTask { get; set; }
        public virtual TaskCreationInfo Info { get; set; }
        public virtual List<LocalTask> Children { get; set; }
        public virtual WBSType LevelType { get; set; }
        public virtual Dictionary<Guid, ConnectionType> Connections { get; set; }

        /***************************************************/
        
        public LocalTask()
        {
            Children = new List<LocalTask>();
            Info = new TaskCreationInfo();
            Connections = new Dictionary<Guid, ConnectionType>();
        }

        public void Add()
        { ; }

        public void Add(string name, bool isManual, WBSType levelType)
        {
            Info.Name = name;
            Info.IsManual = isManual;
            Info.Id = Guid.NewGuid();
            Id = Info.Id;
            //Task = pjDoc.CurrentDraft.Tasks.Add(Info);
            //Task = Document.CurrentDraft.Tasks.Add(Info);
            LevelType = levelType;
        }
        public void Add(string name, bool isManual, string duration, WBSType levelType)
        {
            Info.Name = name;
            Info.IsManual = isManual;
            Info.Duration = duration;
            Info.Id = Guid.NewGuid();
            Id = Info.Id;
            //Task = pjDoc.CurrentDraft.Tasks.Add(Info);
            //Task = Document.CurrentDraft.Tasks.Add(Info);
            LevelType = levelType;
        }
        public void Add(string name, bool isManual, LocalTask parent, WBSType levelType)
        {
            Info.Name = name;
            Info.IsManual = isManual;
            Info.ParentId = parent.Id;
            Info.Id = Guid.NewGuid();
            ParentId = parent.Id;
            Parent = parent;
            Id = Info.Id;
            //Task = pjDoc.CurrentDraft.Tasks.Add(Info);
            //Task = Document.CurrentDraft.Tasks.Add(Info);
            if (Parent.Children.Count(e => e.Info.Name == name) == 0) Parent.Children.Add(this);
            LevelType = levelType;
        }
        public void Add(string name, bool isManual, string duration, LocalTask parent, WBSType levelType)
        {
            Info.Name = name;
            Info.IsManual = isManual;
            Info.Duration = duration;
            Info.ParentId = parent.Id;
            Info.Id = Guid.NewGuid();
            ParentId = parent.Id;
            Parent = parent;
            Id = Info.Id;
            //Task = pjDoc.CurrentDraft.Tasks.Add(Info);
            //Task = Document.CurrentDraft.Tasks.Add(Info);
            if (Parent.Children.Count(e => e.Info.Name == name) == 0) Parent.Children.Add(this);
            LevelType = levelType;
        }
    }
}
