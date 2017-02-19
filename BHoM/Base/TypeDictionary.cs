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
            if (m_TypeDictionary == null || m_TypeDictionary.Count == 0)
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
                try
                {
                    Type[] types = asm.GetTypes();

                    // Save shorter names for BHoM objects only
                    string name = asm.GetName().Name;
                    if (name == "BHoM" || name.EndsWith("_oM"))
                    {
                        foreach (Type type in types)
                            m_TypeDictionary[type.Name] = type;
                    }

                    // Save full names for all dlls
                    foreach (Type type in types)
                        m_TypeDictionary[type.FullName] = type;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot load types of assembly " + asm.GetName().Name);
                }
            }
        }

        private static Dictionary<string, Type> m_TypeDictionary;
    }
}
