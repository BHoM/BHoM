using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BHoM.Base
{
    public static class TypeDictionary
    {
        public static Type GetType(string name)
        {
            if (m_TypeDictionary == null)
                CreateDictionary();

            Type type = null;
            m_TypeDictionary.TryGetValue(name, out type);
            return type;
        }


        private static void CreateDictionary()
        {
            m_TypeDictionary = new Dictionary<string, Type>();

            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                // Save shorter names for BHoM objects only
                string name = asm.GetName().Name;
                if (name == "BHoM" || name.EndsWith("_oM"))
                {
                    foreach (Type type in asm.GetTypes())
                        m_TypeDictionary[type.Name] = type;
                }

                // Save full names for all dlls
                foreach (Type type in asm.GetTypes())
                    m_TypeDictionary[type.FullName] = type;
            }
        }

        private static Dictionary<string, Type> m_TypeDictionary;
    }
}
