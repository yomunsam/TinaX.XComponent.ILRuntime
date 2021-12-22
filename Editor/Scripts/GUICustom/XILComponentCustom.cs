using TinaX.XComponent;
using UnityEditor;
using UnityEngine;

namespace TinaXEditor.XComponent.GUICustom
{
    //[CustomEditor(typeof(TinaX.XComponent.XILComponent), true)]
    //public class XILComponentCustom : XComponentCustom
    //{
    //    private SerializedObject m_serObj;

    //    public override void OnInspectorGUI()
    //    {
    //        if(m_serObj == null)
    //        {
    //            m_serObj = new SerializedObject((XILComponent)target);
    //        }

    //        GUILayout.Space(5);

    //        //TypeName
    //        EditorGUILayout.BeginVertical();
    //        EditorGUILayout.LabelField(new GUIContent("Type name in IL assemblies:"));
    //        EditorGUILayout.PropertyField(m_serObj.FindProperty("ILBehaviourTypeName"),GUIContent.none);
    //        EditorGUILayout.EndVertical();
    //        GUILayout.Space(5);

    //        EditorGUILayout.BeginHorizontal();
    //        EditorGUILayout.LabelField(new GUIContent("Don't Destroy On Load"),GUILayout.MaxWidth(145));
    //        EditorGUILayout.PropertyField(m_serObj.FindProperty("DontDestoryOnLoad"), GUIContent.none);
    //        EditorGUILayout.EndHorizontal();

    //        GUILayout.Space(5);
    //        base.OnInspectorGUI();

    //        if (m_serObj != null)
    //            m_serObj.ApplyModifiedProperties();
    //    }
    //}
}
