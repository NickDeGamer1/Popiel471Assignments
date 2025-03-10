using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerStateManager : MonoBehaviour
{
    public AbstractClass currentState;

    public AbstractClass idolState = new IdolState();
    public AbstractClass walkState = new PlayerWalkState();
    public AbstractClass sneakState = new PlayerSneakState();
    public float defaultSpeed = 7f;
    public Vector2 MouseMovement;
    [HideInInspector]
    public Vector2 movement = new Vector2 (0, 0);
    CharacterController controller;
    public bool IsSneaking = false;
    [SerializeField]
    GameObject ResetPoint;
    public Animator animator1;
    public Animator animator2;
    public Animator anim3;
    bool camRight = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        SwitchState(idolState);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        transform.Rotate(0, MouseMovement.x, 0);
    }

    void OnLook(InputValue lookVal)
    {
        MouseMovement = lookVal.Get<Vector2>();
    }

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnSprint()
    {
        IsSneaking = !IsSneaking;
    }

    void OnJump()
    {
        camRight = !camRight;
        anim3.SetBool("CamRight", camRight);
    }

    public void SetWalk()
    {
        transform.localScale = new Vector3(1, 1, 1);
        animator1.SetBool("Sneaking", false);
    }
    public void SetSneak()
    {
        transform.localScale = new Vector3(1, 0.5f, 1);
        animator1.SetBool("Sneaking", true);
    }

    public void MovePlayer(float multiplier)
    {
        float movex = movement.x;
        float movez = movement.y;
        Vector3 actualMovement = transform.forward * movez + transform.right * movex;//new Vector3(movex * Time.deltaTime * multiplier, 0 , movez * Time.deltaTime * multiplier);
        //Vector3 ActualMovement = transform.forward * moveZ + transform.right * moveX;
        controller.Move(actualMovement * Time.deltaTime * multiplier);
    }

    public void ResetPosition()
    {
        transform.position = ResetPoint.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            ResetPosition();
        }
    }

    public void SwitchState(AbstractClass newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
}
