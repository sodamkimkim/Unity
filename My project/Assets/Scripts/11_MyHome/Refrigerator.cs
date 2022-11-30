using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : HomeAppliances
{
    private ColorPanel[] colorPanels = null;

    private void Awake()
    {
        colorPanels = GetComponentsInChildren<ColorPanel>();
        PowerOff();
    }

    public override void PowerOn()
    {
        if (IsPowerOn) return;

        base.PowerOn();

        foreach (ColorPanel colorPanel in colorPanels)
            colorPanel.On();
    }

    public override void PowerOff()
    {
        if (!IsPowerOn) return;

        base.PowerOff();

        foreach (ColorPanel colorPanel in colorPanels)
            colorPanel.Off();
    }

    public override void Use()
    {
        if (!IsPowerOn) return;

        foreach (ColorPanel colorPanel in colorPanels)
            colorPanel.ChangeRandomColor();
    }
}
