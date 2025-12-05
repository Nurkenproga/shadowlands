using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Sets the switch hint text at runtime. Use this to initialize UI without manual inspector work.
/// </summary>
public class UIHint : MonoBehaviour
{
    public string hintText = "Press Tab to switch worlds";

    void Start()
    {
        var txt = GetComponentInChildren<Text>();
        if (txt != null)
        {
            txt.text = hintText;
        }
    }
}
