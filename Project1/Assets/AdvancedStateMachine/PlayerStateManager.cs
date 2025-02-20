using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    public AbstractClass currentState;

    public AbstractClass idolState = new IdolState();
    public AbstractClass walkState = new PlayerWalkState();
    public AbstractClass sneakState = new PlayerSneakState();
    [SerializeField]
    public float defaultSpeed = 2f;
    [HideInInspector]
    public Vector2 movement = new Vector2 (0, 0);
    CharacterController controller;
    public bool IsSneaking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();

        SwitchState(idolState);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnSprint()
    {
        IsSneaking = !IsSneaking;
    }

    public void MovePlayer(float multiplier)
    {
        float movex = movement.x;
        float movez = movement.y;

        Vector3 actualMovement = new Vector3(movex * Time.deltaTime * multiplier, 0 , movez * Time.deltaTime * multiplier);
        controller.Move(actualMovement);
    }

    public void SwitchState(AbstractClass newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
}
