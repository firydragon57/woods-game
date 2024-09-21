using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

public GameObject explosion;

    public void PlayEffect() {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
