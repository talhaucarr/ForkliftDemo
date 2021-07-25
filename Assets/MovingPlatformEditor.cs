using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MovingPlatformEditor: MonoBehaviour
{

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.GetChild(i).transform.position, 1);
        }
        for (int i = 0; i < transform.childCount-1; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i+1).transform.position);
        }

    }
#endif

}

#if UNITY_EDITOR
[CustomEditor(typeof(MovingPlatformEditor))]
[System.Serializable]
class MovingPlatformEditorS : Editor
{
    public override void OnInspectorGUI()
    {
        MovingPlatformEditor script = (MovingPlatformEditor)target;
        if (GUILayout.Button("GOKAY", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            GameObject point = new GameObject();
            point.transform.parent = script.transform;
            point.transform.position = script.transform.position;
            point.name = script.transform.childCount.ToString();
        }
    }
}
#endif

