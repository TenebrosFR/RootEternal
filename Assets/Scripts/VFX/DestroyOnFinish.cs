using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class DestroyOnFinish : MonoBehaviour
{
    [SerializeField] VisualEffect effect;
    private void Start() {
        StartCoroutine(Destroy());
    }
    private IEnumerator Destroy() {
        yield return new  WaitForSeconds(3);
        Destroy(gameObject);
    }
}
    