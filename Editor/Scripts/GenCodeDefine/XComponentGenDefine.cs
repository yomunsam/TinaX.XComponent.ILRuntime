using System;
using System.Collections.Generic;
using TinaX.XComponent.XILRuntime;
using TinaXEditor.XILRuntime.Generator;

namespace TinaXEditor.XComponent.XILRuntime.Generator
{
    public class GenCodeDefine : ICLRBindingGenerateDefine
    {
        public List<Type> ValueTypeBinders => new List<Type>
        {

        };

        public List<Type> DelegateTypes => new List<Type>
        {

        };


        public void Initialize(ref ILRuntime.Runtime.Enviorment.AppDomain appDomain)
        {
            //注册跨域适配器
            XComponentRegister.RegisterCrossBindingAdaptor(appDomain);
        }
    }
}