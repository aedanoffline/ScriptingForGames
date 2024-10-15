using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class StaminaBarImageBehavior : MonoBehaviour
{
    private Image imageObj;
    private RectTransform rectTransform;
    public SimpleFloatData dataObj;
    private float healthScaler = 250f;
    
    private void Start()
    {
        imageObj = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        dataObj.SetValue(1f);
    }
    
    public void Update()
    {
        imageObj.rectTransform.sizeDelta = new Vector2(dataObj.value * healthScaler, rectTransform.sizeDelta.y);
    }
}