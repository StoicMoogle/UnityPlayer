using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public GameObject bullet;
    public int maxAmmo = 60;
    public int clipSize = 15;
    public int currentAmmo;
    public int reserveAmmo;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = clipSize;
        reserveAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo < clipSize && reserveAmmo > 0 && Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if (currentAmmo == 0 && reserveAmmo > 0 && Input.GetMouseButtonDown(0))
        {
            Reload();
        }

        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            Instantiate(bullet, this.transform.position, this.transform.rotation);
            currentAmmo--;
        } 
    }

    void Reload()
    {
            reserveAmmo -= (clipSize - currentAmmo);
            currentAmmo += (clipSize - currentAmmo);
    }
}
