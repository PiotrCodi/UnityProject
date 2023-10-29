using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject healthBar;
    float z = Knight2.z;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
    private void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.z = z;
        transform.position = newPosition;
        Debug.Log(z);
    }
}
