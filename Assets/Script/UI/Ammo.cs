using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public int AmmoLeft;
    int MagazineSize;
    public Text AmmoText;
    bool HeldGun = false;
    void Start()
    {

    }
    public void StartAmmo(int AmmoAmount){
        MagazineSize = AmmoAmount;
        AmmoLeft = AmmoAmount;
        HeldGun = true;
    }
    void Update()
    {
        if (HeldGun)
        {
            AmmoText.text = AmmoLeft + "/" + MagazineSize;
        }
    }

    public void ReduceAmmo()
    {
        AmmoLeft--;
    }
    public void RestartAmmo(int AmmoAmount)
    {
        AmmoLeft = AmmoAmount;
    }
}
