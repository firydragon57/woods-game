using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManagerR : MonoBehaviour
{
    public float speed = 5f;
    public float leftEdge;
    
    // Start is called before the first frame update
    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
        
    }
}
