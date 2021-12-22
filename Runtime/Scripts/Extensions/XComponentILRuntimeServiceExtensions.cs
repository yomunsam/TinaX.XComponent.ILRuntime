using TinaX.XComponent.XILRuntime;
using TinaX.XILRuntime.Builders;

namespace TinaX.Services
{
    public static class XComponentILRuntimeServiceExtensions
    {
        //XILRuntime Builder
        public static XILRuntimeBuilder RegisterXComponent(this XILRuntimeBuilder builder)
        {
            builder.Register(xil =>
            {
                XComponentRegister.Register(xil);
            });
            return builder;
        }
    }
}
