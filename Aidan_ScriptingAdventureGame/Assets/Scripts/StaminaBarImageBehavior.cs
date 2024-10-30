using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class StaminaBarImageBehavior : MonoBehaviour
{
    private Image imageObj;
    private RectTransform rectTransform;
    public SimpleFloatData dataObj;
    private float staminaScaler;
    
    private void Start()
    {
        imageObj = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        staminaScaler = rectTransform.sizeDelta.x;
        dataObj.SetValue(100f);
    }
    
    public void Update()
    {
        imageObj.rectTransform.sizeDelta = new Vector2((dataObj.value / 100f) * staminaScaler, rectTransform.sizeDelta.y);
    }
}