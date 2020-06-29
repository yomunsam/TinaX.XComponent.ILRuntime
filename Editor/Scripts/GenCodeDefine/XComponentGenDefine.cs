//using System;
//using System.Collections.Generic;
//using TinaX.XComponent;
//using TinaXEditor.XILRuntime;
using System;
using System.Collections.Generic;
using System.Reflection;
using TinaX.XComponent;
using TinaX.XComponent.Internal.Adaptor;
using TinaXEditor.XILRuntime;

namespace TinaXEditor.XComponent.XILRuntime.Generator
{
    public class GenCodeDefine : ICLRGenerateDefine
    {
        public void GenerateByAssemblies_InitILRuntime(ILRuntime.Runtime.Enviorment.AppDomain appdomain)
        {
            //注册跨域
            appdomain.RegisterCrossBindingAdaptor(new XBehaviourAdaptor());
        }

        /// <summary>
        /// 生成CLR绑定代码的列表
        /// </summary>
        /// <returns></returns>
        public List<Type> GetCLRBindingTypes() => new List<Type>
        {
            typeof(XILComponent),
        };

        public HashSet<FieldInfo> GetCLRBindingExcludeFields() => null;

        public HashSet<MethodBase> GetCLRBindingExcludeMethods() => null;



        public List<Type> GetDelegateTypes() => null;

        public List<Type> GetValueTypeBinders() => null;
    }
}