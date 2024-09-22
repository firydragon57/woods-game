using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManagerL : MonoBehaviour
{
    public float speed = 5f;
    public float rightEdge;
    
    // Start is called before the first frame update
    void Start()
    {
        rightEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x + 10f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        if(transform.position.x > rightEdge) {
            Destroy(gameObject);
        }
        
    }
}
