using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBarImageBehavior : MonoBehaviour
{
    private Image imageObj;
    private RectTransform rectTransform;
    public SimpleFloatData dataObj;
    private float healthScaler = 500f;
    
    private void Start()
    {
        imageObj = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        dataObj.SetValue(1f);
    }
    
    public void Update() //Had to replace UpdateWithFloatData with Update because there is no instruction to actually trigger this method
    {
        imageObj.rectTransform.sizeDelta = new Vector2(dataObj.value * healthScaler, rectTransform.sizeDelta.y);
    }
    
    /*public void UpdateWithFloatData()
    {
        imageObj.rectTransform.sizeDelta = new Vector2(dataObj.value * healthScaler, rectTransform.sizeDelta.y);
    }*/
}
