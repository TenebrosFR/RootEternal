using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using utils;

public class DestroyProjectile : MonoBehaviour
{
    [SerializeField] string groundName;
    [SerializeField] Transform projectileTransform;
    [SerializeField] GameObject range;
    Vector3 StartPos;

    private void Start() {
        StartPos = gameObject.transform.position;
    }

    private void FixedUpdate() {

        // transform.position = transform.position + (transform.localScale - newScale) / 2;
        transform.localScale = transform.localScale.UpdateAxis(transform.localScale.z + Time.deltaTime, VectorAxis.Z);
        transform.position += transform.forward * (Time.deltaTime) / (1.25f + Time.deltaTime);

        if (transform.localScale.z >= 0.5*range.GetComponent<BoxCollider>().size.x ) {
            Destroy(gameObject);
        }
    }
}
