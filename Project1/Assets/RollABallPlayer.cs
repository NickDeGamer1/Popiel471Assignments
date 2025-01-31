using UnityEngine;
using UnityEngine.InputSystem;

public class RollABallPlayer : MonoBehaviour
{
    Vector2 m;
    Rigidbody RB;
    [SerializeField] float JumpHight = 50;
    [SerializeField] GameObject RaycastLocation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m = new Vector2(0, 0);
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastLocation.transform.position = transform.position;

        float x_dir = m.x;
        float z_dir = m.y;
        Vector3 actualMovement;

        
        actualMovement = new Vector3(x_dir, 0, z_dir);
        
        //print(actualMovement);

        RB.AddForce(actualMovement);

        if (Input.GetButtonDown("Jump") & RaycastLocation.GetComponent<RaycastCheck>().CheckFloor())
        {
            RB.linearVelocity = new Vector3(RB.linearVelocity.x, JumpHight, RB.linearVelocity.z);
        }

        if (transform.position.y < -100)
        {
            transform.position = new Vector3(0, 1, 0);
            RB.linearVelocity = new Vector3(0,0,0);
        }
    }

    void OnMove(InputValue movement)
    {
        m = movement.Get<Vector2>();
    }
}
