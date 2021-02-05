using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChangeHelper : MonoBehaviour
{
    [SerializeField]
    Button[] CategoryButtons;

    public void HighLightElement(Button pButton)
    {
        foreach (var button in CategoryButtons)
        {
            if (pButton == button)
            {
                button.interactable = false;
                continue;
            }
            button.interactable = true;
        }
    }
}
