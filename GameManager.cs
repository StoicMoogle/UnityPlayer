using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ammoCounter;
    public Image healthBar;
    public ShooterScript shooter;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoCounter.text = "Ammo: " + shooter.currentAmmo + " / " + shooter.reserveAmmo;
        healthBar.fillAmount = ((float)player.currentHealth / player.maxHealth);



    }
}
