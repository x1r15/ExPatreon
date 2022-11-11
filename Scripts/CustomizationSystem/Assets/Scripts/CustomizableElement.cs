using System.Collections.Generic;
using UnityEngine;

public class CustomizableElement : MonoBehaviour
{
    [SerializeField]
    private CustomizationType _type;
    
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField]
    private List<PositionedSprite> _spriteOptions;
    
    [field: SerializeField]
    public int SpriteIndex { get; private set; }

    [SerializeField]
    private List<Color> _colorOptions;

    [field: SerializeField]
    public int ColorIndex;

    [SerializeField]
    private List<SpriteRenderer> _copyColorTo;

    public Color CurrentColor => _colorOptions.Count == 0 ? Color.white : _colorOptions[ColorIndex];

    [ContextMenu("Next Sprite")]
    public PositionedSprite NextSprite()
    {
        SpriteIndex = Mathf.Min(SpriteIndex + 1, _spriteOptions.Count - 1);
        UpdateSprite();
        return _spriteOptions[SpriteIndex];
    }

    [ContextMenu("Previous Sprite")]
    public PositionedSprite PreviousSprite()
    {
        SpriteIndex = Mathf.Max(SpriteIndex - 1, 0);
        UpdateSprite();
        return _spriteOptions[SpriteIndex];
    }
    
    [ContextMenu("Next Color")]
    public Color NextColor()
    {
        ColorIndex = Mathf.Min(ColorIndex + 1, _colorOptions.Count - 1);
        UpdateColor();
        return _colorOptions[ColorIndex];
    }
    
    [ContextMenu("Previous Color")]
    public Color PreviousColor()
    {
        ColorIndex = Mathf.Max(ColorIndex - 1, 0);
        UpdateColor();
        return _colorOptions[ColorIndex];
    }

    [ContextMenu("Randomize")]
    public void Randomize()
    {
        SpriteIndex = Random.Range(0, _spriteOptions.Count - 1);
        ColorIndex = Random.Range(0, _colorOptions.Count - 1);
        UpdateSprite();
        UpdateColor();
    }
    
    [ContextMenu("Update Position Modifier")]
    public void UpdateSpritePositionModifier()
    {
        _spriteOptions[SpriteIndex].PositionModifier = transform.localPosition;
    }

    public CustomizationData GetCustomizationData()
    {
        return new CustomizationData(_type, _spriteOptions[SpriteIndex], _spriteRenderer.color);
    }

    private void UpdateSprite()
    {
        if (_spriteOptions.Count == 0) return;
        SpriteIndex = Mathf.Clamp(SpriteIndex, 0, _spriteOptions.Count - 1);
        var positionedSprite = _spriteOptions[SpriteIndex];
        _spriteRenderer.sprite = positionedSprite.Sprite;
        transform.localPosition = positionedSprite.PositionModifier;
    }

    private void UpdateColor()
    {
        if (_colorOptions.Count == 0) return;
        ColorIndex = Mathf.Clamp(ColorIndex, 0, _colorOptions.Count - 1);
        var newColor = _colorOptions[ColorIndex];
        _spriteRenderer.color = newColor;
        _copyColorTo.ForEach(sr => sr.color = newColor);
    }
}
