using UnityEngine;

public class GrassPlacement : MonoBehaviour
{
    public GameObject grassPrefab;
    public int grassCount = 1000;

    void Start()
    {
        for (int i = 0; i < grassCount; i++)
        {
            Vector3 grassPosition = new Vector3(Random.Range(-42.5f, 42.5f), 0, Random.Range(-42.5f, 42.5f));
            Quaternion grassRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
            GameObject grassInstance = Instantiate(grassPrefab, grassPosition, grassRotation);
            grassInstance.transform.parent = transform;
        }
    }
}