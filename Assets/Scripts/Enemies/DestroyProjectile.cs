using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    [SerializeField] GameObject self;
    [SerializeField] string groundName;
    [SerializeField] Transform projectileTransform;

    private void Update() {
        if (projectileTransform.position.y <= -0.75) {
            Destroy(self);
        }
    }
}
