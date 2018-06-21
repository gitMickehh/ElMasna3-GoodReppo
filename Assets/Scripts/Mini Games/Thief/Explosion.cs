using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    Animator explosionAnim;

    private void Start()
    {
        explosionAnim = GetComponent<Animator>();
    }
    public void ExplosionEffect(Transform newPos)
    {
        transform.position = newPos.position;
        explosionAnim.SetTrigger("Swiped");
    }
}
