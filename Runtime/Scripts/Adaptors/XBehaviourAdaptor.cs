using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinaX.XComponent;

namespace TinaX.XComponent.Internal.Adaptor
{
    public class XBehaviourAdaptor : CrossBindingAdaptor
    {
        public override Type BaseCLRType => typeof(XBehaviour);

        public override Type AdaptorType => typeof(MyXBehaviourAdaptor);

        public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            return new MyXBehaviourAdaptor(appdomain, instance);
        }

        class MyXBehaviourAdaptor : XBehaviour
        {
            ILTypeInstance instance;
            ILRuntime.Runtime.Enviorment.AppDomain appdomain;

            IMethod mOnEnable;
            bool mOnEnableGot;
            bool mOnEnableInvoking;

            IMethod mOnDisable;
            bool mOnDisableGot;
            bool mOnDisableInvoking;

            IMethod mAwake;
            bool mAwakeGot;
            bool mAwakeInvoking;

            IMethod mStart;
            bool mStartGot;
            bool mStartInvoking;

            IMethod mOnDestroy;
            bool mOnDestroyGot;
            bool mOnDestroyInvoking;

            IMethod mUpdate;
            bool mUpdateGot;
            bool mUpdateInvoking;

            IMethod mFixedUpdate;
            bool mFixedUpdateGot;
            bool mFixedUpdateInvoking;

            IMethod mLateUpdate;
            bool mLateUpdateGot;
            bool mLateUpdateInvoking;

            IMethod mOnApplicationFocus;
            bool mOnApplicationFocusGot;
            bool mOnApplicationFocusInvoking;

            IMethod mOnApplicationPause;
            bool mOnApplicationPauseGot;
            bool mOnApplicationPauseInvoking;

            IMethod mOnApplicationQuit;
            bool mOnApplicationQuitGot;
            bool mOnApplicationQuitInvoking;

            IMethod mOnMessage;
            bool mOnMessageGot;
            bool mOnMessageInvoking;


            object[] param_1 = new object[1];

            public MyXBehaviourAdaptor()
            {

            }

            public MyXBehaviourAdaptor(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
            {
                this.appdomain = appdomain;
                this.instance = instance;
            }

            public override void OnEnable()
            {
                if(!mOnEnableGot)
                {
                    mOnEnable = instance.Type.GetMethod("OnEnable", 0);
                    mOnEnableGot = true;
                }

                if (mOnEnable != null && !mOnEnableInvoking)
                {
                    mOnEnableInvoking = true;
                    appdomain.Invoke(mOnEnable, instance);
                    mOnEnableInvoking = false;
                }
                else
                    base.OnEnable();
            }

            public override void OnDisable()
            {
                if (!mOnDisableGot)
                {
                    mOnDisable = instance.Type.GetMethod("OnDisable", 0);
                    mOnDisableGot = true;
                }

                if (mOnDisable != null && !mOnDisableInvoking)
                {
                    mOnDisableInvoking = true;
                    appdomain.Invoke(mOnDisable, instance);
                    mOnDisableInvoking = false;
                }
                else
                    base.OnDestroy();
            }

            public override void Awake()
            {
                if (!mAwakeGot)
                {
                    mAwake = instance.Type.GetMethod("Awake", 0);
                    mAwakeGot = true;
                }

                if (mAwake != null && !mAwakeInvoking)
                {
                    mAwakeInvoking = true;
                    appdomain.Invoke(mAwake, instance);
                    mAwakeInvoking = false;
                }
                else
                    base.Awake();
            }

            public override void Start()
            {
                if (!mStartGot)
                {
                    mStart = instance.Type.GetMethod("Start", 0);
                    mStartGot = true;
                }

                if (mStart != null && !mStartInvoking)
                {
                    mStartInvoking = true;
                    appdomain.Invoke(mStart, instance);
                    mStartInvoking = false;
                }
                else
                    base.Start();
            }
            
            public override void OnDestroy()
            {
                if (!mOnDestroyGot)
                {
                    mOnDestroy = instance.Type.GetMethod("OnDestroy", 0);
                    mOnDestroyGot = true;
                }

                if (mOnDestroy != null && !mOnDestroyInvoking)
                {
                    mOnDestroyInvoking = true;
                    appdomain.Invoke(mOnDestroy, instance);
                    mOnDestroyInvoking = false;
                }
                else
                    base.OnDestroy();
            }

            public override void Update()
            {
                if (!mUpdateGot)
                {
                    mUpdate = instance.Type.GetMethod("Update", 0);
                    mUpdateGot = true;
                }

                if (mUpdate != null && !mUpdateInvoking)
                {
                    mUpdateInvoking = true;
                    appdomain.Invoke(mUpdate, instance);
                    mUpdateInvoking = false;
                }
                else
                    base.Update();
            }

            public override void FixedUpdate()
            {
                if (!mFixedUpdateGot)
                {
                    mFixedUpdate = instance.Type.GetMethod("FixedUpdate", 0);
                    mFixedUpdateGot = true;
                }

                if (mFixedUpdate != null && !mFixedUpdateInvoking)
                {
                    mFixedUpdateInvoking = true;
                    appdomain.Invoke(mFixedUpdate, instance);
                    mFixedUpdateInvoking = false;
                }
                else
                    base.FixedUpdate();
            }

            public override void LateUpdate()
            {
                if (!mLateUpdateGot)
                {
                    mLateUpdate = instance.Type.GetMethod("LateUpdate", 0);
                    mLateUpdateGot = true;
                }

                if (mLateUpdate != null && !mLateUpdateInvoking)
                {
                    mLateUpdateInvoking = true;
                    appdomain.Invoke(mLateUpdate, instance);
                    mLateUpdateInvoking = false;
                }
                else
                    base.LateUpdate();
            }

            public override void OnApplicationFocus(bool focus)
            {
                if (!mOnApplicationFocusGot)
                {
                    mOnApplicationFocus = instance.Type.GetMethod("OnApplicationFocus", 0);
                    mOnApplicationFocusGot = true;
                }

                if (mOnApplicationFocus != null && !mOnApplicationFocusInvoking)
                {
                    mOnApplicationFocusInvoking = true;
                    param_1[0] = focus;
                    appdomain.Invoke(mOnApplicationFocus, instance, param_1);
                    mOnApplicationFocusInvoking = false;
                }
                else
                    base.OnApplicationFocus(focus);
            }

            public override void OnApplicationPause(bool pause)
            {
                if (!mOnApplicationPauseGot)
                {
                    mOnApplicationPause = instance.Type.GetMethod("OnApplicationPause", 0);
                    mOnApplicationPauseGot = true;
                }

                if (mOnApplicationPause != null && !mOnApplicationPauseInvoking)
                {
                    mOnApplicationPauseInvoking = true;
                    param_1[0] = pause;
                    appdomain.Invoke(mOnApplicationPause, instance, param_1);
                    mOnApplicationPauseInvoking = false;
                }
                else
                    base.OnApplicationPause(pause);
            }

            public override void OnApplicationQuit()
            {
                if (!mOnApplicationQuitGot)
                {
                    mOnApplicationQuit = instance.Type.GetMethod("OnApplicationQuit", 0);
                    mOnApplicationQuitGot = true;
                }

                if (mOnApplicationQuit != null && !mOnApplicationQuitInvoking)
                {
                    mOnApplicationQuitInvoking = true;
                    appdomain.Invoke(mOnApplicationQuit, instance);
                    mOnApplicationQuitInvoking = false;
                }
                else
                    base.OnApplicationQuit();
            }

            public override void OnMessage(string msgName, params object[] msgParams)
            {
                if (!mOnMessageGot)
                {
                    mOnMessage = instance.Type.GetMethod("OnMessage", 0);
                    mOnMessageGot = true;
                }

                if (mOnMessage != null && !mOnMessageInvoking)
                {
                    mOnMessageInvoking = true;
                    object[] param = new object[msgParams.Length + 1];
                    param[0] = msgName;
                    msgParams.CopyTo(param, 1);
                    appdomain.Invoke(mOnMessage, instance, param);
                    mOnMessageInvoking = false;
                }
                else
                    base.OnMessage(msgName,msgParams);
            }

        }

    }
}
