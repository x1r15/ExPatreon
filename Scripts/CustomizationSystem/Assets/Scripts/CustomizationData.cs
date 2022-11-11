using System;
using UnityEngine;

[Serializable]
public class CustomizationData
{
    [field: SerializeField]
    public CustomizationType Type { get; private set; }

    [field: SerializeField]
    public PositionedSprite Sprite { get; private set; }
    
    [field: SerializeField]
    public Color Color { get; private set; }

    public CustomizationData(CustomizationType t, PositionedSprite s, Color c)
    {
        Type = t;
        Sprite = s;
        Color = c;
    }
}
