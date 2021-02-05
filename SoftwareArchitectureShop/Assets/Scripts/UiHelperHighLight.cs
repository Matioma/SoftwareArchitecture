using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHelperHighLight : MonoBehaviour
{
    [SerializeField]
    GameObject[] highLightObjects;

    public void HighLightElement(GameObject button) {
        foreach (var highlight in highLightObjects) {
            if (button == highlight)
            {
                highlight.SetActive(true);
                continue;
            }
            highlight.SetActive(false);

        }
    }
}
