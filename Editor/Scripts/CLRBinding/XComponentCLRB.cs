using System;
using System.Collections.Generic;
using TinaX.XComponent;
using TinaXEditor.XILRuntime;

namespace TinaXEditor.XComponent.Internal.CLR
{
    public class XComponentCLRB : ICLRBindingData
    {
        public List<Type> GetCLRBindingTypes()
        {
            return new List<Type>()
            {
                typeof(XBehaviour),
            };
        }
    }

}
