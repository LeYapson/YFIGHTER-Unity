using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorManager : MonoBehaviour
{
    public Button[] buttons;
    private Color clickedColor = Color.yellow;
    public void OnButtonClicked(){

        // ColorBlock cb = button.colors;
        // cb.normalColor = clickedColor;
        // button.colors = cb;
    }
}
