using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    [SerializeField] string groundName;
    [SerializeField] Transform projectileTransform;
    [SerializeField] GameObject range;
    Vector3 StartPos;

    private void Start() {
        StartPos = gameObject.transform.position;
    }

    private void Update() {
        if (Vector3.Distance(StartPos, gameObject.transform.position) >= 0.75*range.transform.localScale.x ) {
            Destroy(gameObject);
        }
    }
}
