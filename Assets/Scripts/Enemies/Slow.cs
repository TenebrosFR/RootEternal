using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Slow : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    float slowDuration = 10;
    public static Slow instance;
    bool isSlowed;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Debug.Log("Connecté à l'objet: " + gameObject.name);
    }

    public void SlowMode()
    {
        Frenesie.instance.LockCharge();
        StartCoroutine(SlowCoroutine());
    }

    private IEnumerator SlowCoroutine()
    {
        isSlowed = true;
        agent.speed/= 5;
        Debug.Log("SlowMode active");
        yield return new WaitForSeconds(slowDuration);
        Frenesie.instance.DelockCharge();
        Frenesie.instance.ResetCharge();
        Debug.Log("Fin SlowMode");
        agent.speed *= 5;
        isSlowed = false;
    }

    void Update()
    {
        if (Frenesie.instance.CheckDamage() && !isSlowed)
        {
            SlowMode();
        }
    }

    public void Awake()
    {
        instance = this;
    }
}