using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerController))]
public class PlayerControllerInspectorEditor : Editor
{
    // Start is called before the first frame update
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        PlayerController playerController = (PlayerController)target;

        // EditorGUILayout.LabelField("Press to toggle different player controller system");
    }
}
