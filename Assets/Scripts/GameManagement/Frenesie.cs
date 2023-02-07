using UnityEngine;
using UnityEngine.AI;

public class Frenesie : MonoBehaviour
{
    int charge;
    bool isSlowed;
    public static Frenesie instance;

    public void JaugeFrenesie(int _damage)
    {
        if (!isSlowed)
        {
            charge = charge + _damage;
            Debug.Log("Chargement de la frenesie: " + charge);
        }
    }
    public bool LockCharge()
    {
        isSlowed = true;
        return isSlowed;
    }
    public bool DelockCharge()
    {
        isSlowed = false;
        return isSlowed;
    }

    public bool CheckDamage()
    {
        return charge == 150;
    }

    public void Awake()
    {
        instance = this;
    }

    public void ResetCharge()
    {
        charge = 0;
    }
}