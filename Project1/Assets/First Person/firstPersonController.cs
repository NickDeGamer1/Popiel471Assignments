using UnityEngine;
using UnityEngine.InputSystem;

public class firstPersonController : MonoBehaviour
{
    Vector2 movement;
    Vector2 mouseMovement;
    float CamUpRotation = 0;
    CharacterController controller;
    [SerializeField]
    float speed = 2.0f;
    [SerializeField]
    float mouseSensitivity = 100.0f;
    [SerializeField]
    GameObject Cam;
    [SerializeField]
    GameObject BulletSpawner;
    [SerializeField]
    GameObject Bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = movement.x * Time.deltaTime * mouseSensitivity;
        float moveZ = movement.y * Time.deltaTime * mouseSensitivity;

        float lookX = mouseMovement.x;
        float lookY = mouseMovement.y;

        CamUpRotation -= lookY;

        CamUpRotation = Mathf.Clamp(CamUpRotation,- 90,90);

        transform.Rotate(Vector3.up * lookX);

        Cam.transform.localRotation = Quaternion.Euler(CamUpRotation, 0, 0);

        //Vector3 ActualMovement = new Vector3(moveX, 0, moveZ);
        Vector3 ActualMovement = transform.forward * moveZ + transform.right * moveX;
        controller.Move(ActualMovement * Time.deltaTime * speed);
    }

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnLook(InputValue lookVal)
    {
        mouseMovement = lookVal.Get<Vector2>();
    }

    void OnAttack(InputValue attackVal)
    {
        Instantiate(Bullet, BulletSpawner.transform.position, BulletSpawner.transform.rotation);
    }
}
