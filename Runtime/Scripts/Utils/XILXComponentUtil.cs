using ILRuntime.CLR.Utils;
using ILRuntime.Reflection;
using ILRuntime.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TinaX.XComponent.Utils
{
    /// <summary>
    /// XComponent Util (for ILRuntime)
    /// </summary>
    public static class XILXComponentUtil
    {
        private static BindingFlags _bindFlag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;

        public static void InjectBindings(XComponentScriptBase component, object target)
        {
            if (component == null || target == null)
                return;
            Type type_uobject = typeof(UnityEngine.Object);
            Type type_go = typeof(UnityEngine.GameObject);
            Type actualType = target.GetActualType();

            foreach(var property in actualType.GetProperties(_bindFlag))
            {
                string find_bind_name = property.Name;
                bool null_able = true; //默认可空
                var attr = property.GetCustomAttribute<BindingAttribute>(true);
                if(attr != null)
                {
                    null_able = attr.Nullable;
                    if (!attr.BindingName.IsNullOrEmpty())
                        find_bind_name = attr.BindingName;
                }

                //UObject Bind
                if (property.PropertyType.IsSubclassOf(type_uobject))
                {
                    if(component.TryGetBindingUObject(find_bind_name,out var uobj))
                    {
                        Type __uobj_type = uobj.GetType();
                        if (property.PropertyType.IsSubclassOf(__uobj_type) || property.PropertyType.IsAssignableFrom(__uobj_type))
                        {
                            property.SetValue(target, uobj);
                            continue;
                        }
                        else
                        {
                            if (__uobj_type == type_go) //如果绑定在XComponent列表上的类型是GameObject, 尝试寻找想要被注入的类型是不是这个GameObject上的Component
                            {
                                if (((UnityEngine.GameObject)uobj).TryGetComponent(property.PropertyType.FullName, out var _result))
                                {
                                    property.SetValue(target, _result);
                                    continue;
                                }
                            }
                        }
                    }
                }

                //Base Type Bind
                if (component.TryGetBindingType(find_bind_name, out var obj))
                {
                    if (property.PropertyType.Equals(obj.GetType()))
                    {
                        property.SetValue(target, obj);
                        continue;
                    }
                }

                if (!null_able)
                    throw new Exception($"Inject binding object failed: cannot found binding object \"{find_bind_name}\"");

            }

            foreach (var field in actualType.GetFields(_bindFlag))
            {
                string find_bind_name = field.Name;
                bool null_able = true; //默认可空
                var attr = field.GetCustomAttribute<BindingAttribute>(true);
                if (attr != null)
                {
                    null_able = attr.Nullable;
                    if (!attr.BindingName.IsNullOrEmpty())
                        find_bind_name = attr.BindingName;
                }
                //UObject Bind
                if (field.FieldType.IsSubclassOf(type_uobject))
                {
                    if (component.TryGetBindingUObject(find_bind_name, out var uobj))
                    {
                        Type __uobj_type = uobj.GetType();
                        if (field.FieldType.IsSubclassOf(__uobj_type) || field.FieldType.IsAssignableFrom(__uobj_type))
                        {
                            field.SetValue(target, uobj);
                            continue;
                        }
                        else
                        {
                            if (__uobj_type == type_go) //如果绑定在XComponent列表上的类型是GameObject, 尝试寻找想要被注入的类型是不是这个GameObject上的Component
                            {
                                Debug.Log("有通过GameObject找值");

                                if (((UnityEngine.GameObject)uobj).TryGetComponent(field.FieldType, out var _result))
                                {
                                    field.SetValue(target, _result);
                                    continue;
                                }
                            }
                        }
                            
                    }
                }

                //Base Type Bind
                if (component.TryGetBindingType(find_bind_name, out var obj))
                {
                    if (field.FieldType.Equals(obj.GetType()))
                    {
                        field.SetValue(target, obj);
                        continue;
                    }
                }

                if (!null_able)
                    throw new Exception($"Inject binding object failed: cannot found binding object \"{find_bind_name}\"");

            }
        }
    }
}
