using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RemainPowerSlider : MonoBehaviour
{
    public PlayerShooter Shooter;

    [SerializeField]
    private Slider m_Slider;

    private void Update()
    {
        m_Slider.value = Shooter.RemainShootPower / Shooter.MaxShootPower;
    }
}
