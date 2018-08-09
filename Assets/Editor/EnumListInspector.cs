using UnityEditor;

/*[CustomEditor(typeof(GravityManager))]
public class EnumListInspector : Editor
{
    bool foldout = false;
    public override void OnInspectorGUI()
    {
        GravityManager myTarget = (GravityManager)target;
        EditorGUILayout.LabelField("Gravity states");
        EditorGUILayout.Space();
        myTarget.currentGravity = (Enums.GravityEnum)EditorGUILayout.EnumPopup("Current Gravity: ", myTarget.currentGravity);
        EditorGUILayout.Space();

        for (int i = 0; i < myTarget.gravityStates.Length; i++)
        {
            myTarget.gravityStates[i].gravityEnum = (Enums.GravityEnum)EditorGUILayout.EnumPopup(myTarget.gravityStates[i].gravityEnum.ToString(), myTarget.gravityStates[i].gravityEnum);
            myTarget.gravityStates[i].value = EditorGUILayout.FloatField("Value: ", myTarget.gravityStates[i].value);
            EditorGUILayout.Space();
        }
        foldout = EditorGUILayout.Foldout(foldout, "Gravity Objects");
        if (foldout)
        {
            for (int i = 0; i < myTarget.gravityObjects.Count; i++)
            {
                if (i == 0)
                    EditorGUILayout.LabelField("Gravity", "Object");

                for (int u = 0; u < myTarget.gravityStates.Length; u++)
                {
                    if (myTarget.gravityStates[u].gravityEnum == myTarget.gravityObjects[i].gravityState)
                    {
                        EditorGUILayout.ObjectField(myTarget.gravityStates[u].value.ToString(), myTarget.gravityObjects[i].gameObject, typeof(GravityObject), true);
                    }
                }
            }
        }
    }
}*/