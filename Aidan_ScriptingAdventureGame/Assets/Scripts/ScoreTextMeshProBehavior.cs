using UnityEngine;
using TMPro;
using System.Globalization;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreTextMeshProBehavior : MonoBehaviour
{
    private TextMeshProUGUI textObj;
    private string currentScore;
    public SimpleIntData dataObj;
    private void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        dataObj.SetIntValue(0);
        //UpdateWithIntData();
    }
    
    /*void UpdateWithIntData()
    {
        textObj.text = dataObj.value.ToString(CultureInfo.InvariantCulture);
    }*/
    
    void Update()
    {
        currentScore = dataObj.value.ToString(CultureInfo.InvariantCulture);
        textObj.text = "Score: " + currentScore;
    }
}
