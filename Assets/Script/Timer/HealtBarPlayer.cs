using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBarPlayer : MonoBehaviour
{
    public Slider HealtBar;
    private Timer timer;
    private float maxHealth = 100;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }


    void Update()
    {
        float mappedHealth = Mathf.Clamp01(timer.PlayerHealth / maxHealth);
        HealtBar.value = mappedHealth;

    }
}
