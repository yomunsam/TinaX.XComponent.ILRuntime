using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TinaX.XILRuntime;
using System;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime;
using ILRuntime.CLR.TypeSystem;

namespace TinaX.XComponent
{
    [AddComponentMenu("TinaX/XComponent/XIL Component")]
    public class XILComponent : XComponent
    {
        public string ILBehaviourTypeName;
        public bool DontDestoryOnLoad;

        private IDisposable m_Disposable_WaitXCore;

        protected override void Awake()
        {
            if (this.DontDestoryOnLoad)
                this.gameObject.DontDestroy();
            HandlerILBehaviourWhenReady();
            base.Awake();
        }

        protected override void OnDestroy()
        {
            m_Disposable_WaitXCore?.Dispose();
        }

        private void HandlerILBehaviourWhenReady()
        {
            m_Disposable_WaitXCore = Observable.EveryUpdate()
                .Where(_ => XCore.MainInstance != null && XCore.MainInstance.IsRunning)
                .Subscribe(_ =>
                {
                    m_Disposable_WaitXCore?.Dispose();
                    if (this.ILBehaviourTypeName.IsNullOrEmpty())
                    {
                        Debug.LogError($"[XIL Component - {ILBehaviourTypeName}:{this.gameObject.name}]Type name is invalid.", this);
                        return;
                    }
                    DoILBehaviour();
                });
        }



        private void DoILBehaviour()
        {
            if (XCore.GetMainInstance().Services.TryGet<IXILRuntime>(out var xil))
            {
                var type = xil.ILRuntimeAppDomain.GetType(ILBehaviourTypeName);
                if(type == null)
                {
                    Debug.LogError($"[XIL Component - {ILBehaviourTypeName}:{this.gameObject.name}]Type name is invalid : {ILBehaviourTypeName}", this);
                    return;
                }
                if (!type.ReflectionType.IsSubclassOf(typeof(XBehaviour)))
                {
                    Debug.LogError($"[XIL Component - {ILBehaviourTypeName}:{this.gameObject.name}]Type \"{ILBehaviourTypeName}\" does not inherit from \"TinaX.XComponent.XBehaviour\"", this);
                    return;
                }
                var behaviour = xil.CreateInstanceAndInject(type.ReflectionType);

                this.SetBehaviour(((ILTypeInstance)behaviour).CLRInstance as XBehaviour);
            }
            else
            {
                Debug.LogError($"[XIL Component - {ILBehaviourTypeName}:{this.gameObject.name}]TinaX.ILRuntime Service not ready. XIL Component cannot startup.", this);
            }
        }

    }
}

