using UnityEngine;
using UnityEditor; 

public class RulebaseEditor : EditorWindow
{
    private string test_string = "Hello world";
    private bool group_enabled;
    private bool test_bool = true;
    private float test_float = 1.25f;

    private static Object condition_script; 

    [MenuItem("Window/Rulebase")]
    static void Init()
    {
        RulebaseEditor window = (RulebaseEditor)EditorWindow.GetWindow(typeof(RulebaseEditor));
        window.Show(); 
    }

    public void OnGUI()
    {
        GUILayout.Label("Condition Variable", EditorStyles.boldLabel);
        condition_script = EditorGUILayout.ObjectField(condition_script, typeof(Object), true); 


    }
}

/* Notes 
 * 
 * Object field to gain script/object
 * EditorGUILayout.Popup for drop down menu of scripts 
 * 
 */