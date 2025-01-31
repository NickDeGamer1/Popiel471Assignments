using UnityEngine;

public class Obst : MonoBehaviour
{
    public float Speed = 5.0f;
    bool Right = true;
    Rigidbody RB;
    float Lmost;
    float Rmost;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = GetComponent<Rigidbody>(); 
        Lmost = transform.position.x - 10;
        Rmost = transform.position.x + 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Right)
        {
            transform.position = new Vector3(transform.position.x + (Speed * Time.deltaTime), transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - (Speed * Time.deltaTime), transform.position.y, transform.position.z);
        }

        if (transform.position.x < Lmost)
        {
            Right = true;
        }
        else if (transform.position.x > Rmost)
        {
            Right = false;
        }
    }
}
