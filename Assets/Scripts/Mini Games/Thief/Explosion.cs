using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    Animator explosionAnim;

    private void Start()
    {
        explosionAnim = GetComponent<Animator>();
    }

    public void SetExplosionPos(Transform newPos)
    {
        transform.position = newPos.position;
    }

    public void ExplosionEffect()
    {
        explosionAnim.SetTrigger("Swiped");
    }
}
