using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InventoryItemData)), CanEditMultipleObjects]
public class PropertyHolderEditor : Editor
{
    public SerializedProperty
        state_Prop,
        name_Prop,
        description_Prop,
        icon_Prop,
        prefab_Prop,
        count_Prop,
        ammoType_Prop,
        valueDamage_Prop,
        shootRollback_Prop,
        valueHeal_Prop;

    private void OnEnable()
    {
        state_Prop = serializedObject.FindProperty("itemType");
        name_Prop = serializedObject.FindProperty("title");
        description_Prop = serializedObject.FindProperty("description");
        icon_Prop = serializedObject.FindProperty("icon");
        prefab_Prop = serializedObject.FindProperty("prefab");
        count_Prop = serializedObject.FindProperty("stackCount");
        valueDamage_Prop = serializedObject.FindProperty("damage");
        shootRollback_Prop = serializedObject.FindProperty("shootRollback");
        valueHeal_Prop = serializedObject.FindProperty("heal");
        ammoType_Prop = serializedObject.FindProperty("ammoType");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        EditorGUILayout.PropertyField(name_Prop, new GUIContent("Name"));
        EditorGUILayout.PropertyField(description_Prop, new GUIContent("Description"));
        EditorGUILayout.PropertyField(icon_Prop, new GUIContent("Icon"));
        EditorGUILayout.PropertyField(prefab_Prop, new GUIContent("Prefab"));
        EditorGUILayout.PropertyField(count_Prop, new GUIContent("Count"));
        
        
        EditorGUILayout.PropertyField(state_Prop);
        ItemType type = (ItemType)state_Prop.enumValueIndex;
        
        switch (type)
        {
            case ItemType.Weapon:
                EditorGUILayout.PropertyField(ammoType_Prop, new GUIContent("Ammo type"));
                EditorGUILayout.PropertyField(valueDamage_Prop, new GUIContent("Damage"));
                EditorGUILayout.PropertyField(shootRollback_Prop, new GUIContent("Rollback"));
                break;
            
            case ItemType.Item:
                EditorGUILayout.PropertyField(valueHeal_Prop, new GUIContent("Heal"));
                break;
            
            case ItemType.Ammo:
                EditorGUILayout.PropertyField(ammoType_Prop, new GUIContent("Ammo type"));
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
