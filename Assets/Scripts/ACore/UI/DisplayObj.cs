using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class DisplayObj : MonoBehaviour
{
    static Dictionary<string, System.Type> prefixType = new Dictionary<string, System.Type>();

    void Start()
    {
        prefixType.Add("btn", typeof(Button));
        prefixType.Add("sp", typeof(Image));
        prefixType.Add("lbl", typeof(Text));
        prefixType.Add("input", typeof(InputField));
        prefixType.Add("tab", typeof(ToggleGroup));
        prefixType.Add("toggle", typeof(Toggle));
        FindCompoents();
    }

    private void FindCompoents()
    {
        FieldInfo[] fieldInfos = this.GetType().GetFields();
        foreach (FieldInfo fieldInfo in fieldInfos)
        {
            Debug.Log("pinfo.Name:" + fieldInfo.Name);
            foreach (KeyValuePair<string, System.Type> kvp in prefixType)
            {
                if (fieldInfo.Name.Length > kvp.Key.Length && fieldInfo.Name.Substring(0, kvp.Key.Length).Equals(kvp.Key))
                {
                    fieldInfo.SetValue(this, FindCompoent(this.gameObject, fieldInfo.Name));
                }
            }
        }
    }

    protected Component FindCompoent(GameObject go, string goName)
    {
        foreach (KeyValuePair<string, System.Type> kvp in prefixType)
        {
            if (goName.Substring(0, kvp.Key.Length).Equals(kvp.Key))
            {
                System.Type type = kvp.Value;
                foreach (Transform t in go.GetComponentsInChildren<Transform>())
                {
                    if (t.name.Equals(goName))
                    {
                        return t.GetComponent(type);
                    }
                }
            }
        }
        return null;
    }
}
