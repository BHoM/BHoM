using BH.oM.Base.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.oM.Base
{
    public class TestObjectToBeDeleted : BHoMObject
    {
        [FilePath]
        public virtual string FilePath { get; set; }

        [FilePath(new string[] { "exe", "bat", "png" })]
        public virtual string FilePathWithExtensions { get; set; }

        [FolderPath]
        public virtual string FolderPath { get; set; }
    }
}
