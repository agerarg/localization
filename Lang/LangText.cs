using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(TextMeshProUGUI))]
public class LangText : MonoBehaviour
{
    public string LangKey;
    void Start()
    {
        TextMeshProUGUI textPro = GetComponent<TextMeshProUGUI>();
        textPro.SetText(LangLocalization.instance.Get(LangKey));
    }

}
