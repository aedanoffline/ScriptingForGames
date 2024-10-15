using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SimpleImageBehavior : MonoBehaviour
{
    private Image imageObj;
    private RectTransform rectTransform;
    public SimpleFloatData dataObj;
    private void Start()
    {
        imageObj = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }
    
    public void UpdateWithFloatData()
    {
        imageObj.rectTransform.sizeDelta = new Vector2(dataObj.value * 500, rectTransform.sizeDelta.y);
    }
}
