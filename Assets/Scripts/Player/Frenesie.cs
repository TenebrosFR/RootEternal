using UnityEngine;
using UnityEngine.AI;

public class Frenesie : MonoBehaviour
{
    int charge = 130;
    public static Frenesie instance;

    public void JaugeFrenesie(int _damage)
    {
        charge = charge + _damage;
        Debug.Log("Chargement de la frenesie: " + charge);
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