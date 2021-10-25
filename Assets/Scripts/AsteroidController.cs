using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    Rigidbody2D rb;
    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision with " + other.gameObject);
        if (other.tag == "Ground")
        {
            Debug.Log("Explode");
            animator.SetTrigger("Impact");
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
        Destroy(gameObject, 0.30f);
    }
}
