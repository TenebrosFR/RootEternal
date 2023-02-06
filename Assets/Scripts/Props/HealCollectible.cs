using UnityEngine;

public class HealCollectible : MonoBehaviour
{
    [SerializeField] LayerMask PlayerMask;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Mathf.Log(PlayerMask.value, 2))
        {
            int healValue = 30;
            Debug.Log("Test");
            other.gameObject.GetComponent<Health>().TakeHeal(healValue);
            Destroy(gameObject);
        }
    }
}