using TinaX.XComponent.Internal.Adaptor;

namespace TinaX.XILRuntime.Registers
{
    public static class XComponentILRTRegisterExtend
    {
        public static IXILRuntime RegisterXComponent(this IXILRuntime xil)
        {
            xil.RegisterCrossBindingAdaptor(new XBehaviourAdaptor());
            return xil;
        }
    }
}
