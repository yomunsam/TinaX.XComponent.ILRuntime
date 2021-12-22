using ILRuntime.Runtime.Enviorment;
using TinaX.XComponent.Internal.Adaptor;
using TinaX.XILRuntime;

namespace TinaX.XComponent.XILRuntime
{
    public static class XComponentRegister
    {
        /// <summary>
        /// 注册 总入口
        /// </summary>
        /// <param name="xil"></param>
        public static void Register(IXILRuntime xil)
        {
            //注册跨域适配器
            RegisterCrossBindingAdaptor(xil.ILRuntimeAppDomain);
        }


        /// <summary>
        /// 注册 跨域适配器们
        /// </summary>
        /// <param name="xil"></param>
        public static void RegisterCrossBindingAdaptor(AppDomain appDomain)
        {
            appDomain.RegisterCrossBindingAdaptor(new XBehaviourAdaptor());
        }
    }
}
