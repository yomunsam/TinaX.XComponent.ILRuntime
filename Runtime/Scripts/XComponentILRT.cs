using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinaX.XILRuntime;
using TinaX.XComponent.Internal.Adaptor;

namespace TinaX.XComponent
{
    public static class XComponentILRT
    {
        public static void Register(ref IXRuntime ixruntime)
        {
            ixruntime.RegisterCrossBindingAdaptor(new XBehaviourAdaptor());
        }
    }
}

