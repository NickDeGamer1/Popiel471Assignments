using UnityEngine;


//https://youtu.be/7tzyK1VxS60
public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    float TTD = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * 150);
        TTD -= Time.deltaTime;
        if (TTD < 0)
        {
            Destroy(gameObject);
        }
    }
}
