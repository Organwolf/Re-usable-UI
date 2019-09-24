using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace UI
{
    public class UI_Menus : MonoBehaviour
    {
        [MenuItem("UI Tools/Create UI Group")]
        public static void CreateUIGroup()
        {
            //Debug.Log("Creating UI group");
            GameObject uiGroup = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Todo_App/Prefabs/UI/UI_GRP.prefab");
            if (uiGroup)
            {
                GameObject createdGroup = (GameObject)Instantiate(uiGroup);
                createdGroup.name = "UI_GRP";
            }
            else
            {
                EditorUtility.DisplayDialog("UI Tools Warning", "Cannot find UI Group Prefab!", "OK");
            }
        }
    }
}
