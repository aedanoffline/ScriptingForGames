using UnityEngine;

[CreateAssetMenu(menuName = "Single Variables/SimpleIntData")]
public class SimpleIntData : ScriptableObject
{
    public int value;

    public void UpdateIntValue(int amount)
    {
        value += amount;
    }

    public void SetIntValue(int amount)
    {
        value = amount;
    }
}
