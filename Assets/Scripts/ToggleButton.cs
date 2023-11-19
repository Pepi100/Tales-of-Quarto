using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] Color backgorundActiveColor;
    [SerializeField] Color handleActiveColor;

    Image backgorundImage, handleImage;

    Color backgorundDefaultColor, handleDefaultColor;

    Toggle toggle;

    Vector2 handlePosition;

    void Awake()
    {
        toggle = GetComponent<Toggle>();
        handlePosition = uiHandleRectTransform.anchoredPosition;

        backgorundImage = uiHandleRectTransform.parent.GetComponent<Image>();

        handleImage =  uiHandleRectTransform.GetComponent<Image>();

        backgorundDefaultColor = backgorundImage.color;
        handleDefaultColor = handleImage.color;

        toggle.onValueChanged.AddListener(OnSwitch);

        if(toggle.isOn)
            OnSwitch(true);
    }

    void OnSwitch(bool on)
    {
        if(on)
            uiHandleRectTransform.anchoredPosition = handlePosition * -1;
        else 
            uiHandleRectTransform.anchoredPosition = handlePosition;

        backgorundImage.color = on ? backgorundActiveColor : backgorundDefaultColor;
        handleImage.color = on ? handleActiveColor : handleDefaultColor;
    }

    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}