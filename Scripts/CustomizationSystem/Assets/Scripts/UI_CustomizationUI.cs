using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UI_CustomizationUI : MonoBehaviour
{
    private List<UI_CustomizationPicker> _pickers;
    void Start()
    {
        _pickers = GetComponentsInChildren<UI_CustomizationPicker>().ToList();
    }

    public void UpdatePickersState()
    {
        _pickers.ForEach(picker =>
        {
            picker.UpdateSpriteId();
            picker.UpdateColorIcon();
        });
    }

}
