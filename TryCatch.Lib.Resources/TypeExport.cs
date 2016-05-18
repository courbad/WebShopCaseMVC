using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TryCatch.Resources.Util
{
    public static class TypeExport
    {
        public static IEnumerable<Type> GetAllResxTypes()
        {
            return Assembly.GetExecutingAssembly()
                .GetExportedTypes()
                .Where(t => t.IsClass && t.Namespace != "TryCatch.Resources.Util") // 
                .ToList();
        }
    }
}
