using UnityEngine;

public class EquippedWeapon : MonoBehaviour
{
    public static int CurrentGun = 1;
    public GameObject SwordUI;
    public GameObject GunUI;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipSword();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipGun();
        } 
    }


    public void EquipSword()
    {
        GunUI.SetActive(false);
        SwordUI.SetActive(true);
        CurrentGun = 1;
    }

    public void EquipGun()
    {
        SwordUI.SetActive(false);
        GunUI.SetActive(true);
        CurrentGun = 2;
    }

}
