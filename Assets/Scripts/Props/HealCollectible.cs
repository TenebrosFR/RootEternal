using UnityEngine;

public class HealCollectible : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            int healValue = 30;
            Debug.Log("Test");
            other.gameObject.GetComponent<Health>().TakeHeal(healValue);
            Destroy(gameObject);
        }
    }
}