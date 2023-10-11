using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RVibration
{
    public void VibrateLong() {
        Handheld.Vibrate();
    }

    public void VibrateShort() {
        VibrationMng.ShortVibration();
    }
}
