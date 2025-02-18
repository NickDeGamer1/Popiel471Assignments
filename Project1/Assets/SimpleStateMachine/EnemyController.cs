using System.Linq;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum State
    {
        Pace,
        Fallow,
        Spin,
        Dieing
    }
    public State CurrentState = State.Pace;

    [SerializeField]
    GameObject[] route;
    GameObject target;
    int index = 0;
    float speed = 5f;
    float SpinTime = 4f;
    float Flop = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case State.Pace:
                {
                    OnPace();
                    break;
                }
            case State.Fallow:
                {
                    OnFallow();
                    break;
                }
            case State.Spin:
                {
                    OnSpin();
                    break;
                }
            case State.Dieing:
                {
                    Die();
                    break;
                }
        }
    }

    void OnPace()
    {
        //Debug.Log("Im pacing");
        target = route[index];

        if (Vector3.Distance(transform.position, target.transform.position) < 0.1)
        {
            index += 1;
            
            if (index >= route.Length)
                index = 0;
            CurrentState = State.Spin;
        }
        MoveTo(target);
        CastTheRay();
    }
    void OnFallow()
    {
        //Fallow
        MoveTo(target);


        GameObject obs = CheckForward();
        if (obs == null)
        {
            CurrentState = State.Pace;
        }
    }

    void OnSpin()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
        SpinTime -= Time.deltaTime;
        CastTheRay();
        if (SpinTime < 0)
        {
            SpinTime = 4f;
            CurrentState = State.Pace;
        }
    }

    void Die()
    {
        transform.rotation = new Quaternion(Flop, Flop, 0,0);
        Flop += Time.deltaTime * 100;
        if (transform.position.x > 0)
        {
            transform.Translate(-10 * Time.deltaTime,0, 0);
        }
        if (Flop > 90)
        {
            Destroy(gameObject);
        }
    }

    void MoveTo(GameObject T)
    {
        transform.position = Vector3.MoveTowards(transform.position, T.transform.position, speed * Time.deltaTime);
        transform.LookAt(T.transform.position);
    }

    void CastTheRay()
    {
        GameObject obs = CheckForward();
        if (obs != null)
        {
            target = obs;
            CurrentState = State.Fallow;
        }
    }

    GameObject CheckForward()
    {
        int layerMask = ~LayerMask.GetMask("Bullets");
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10, Color.green);

        if ((Physics.Raycast(transform.position, transform.forward, out hit, 10, layerMask)))
        {
            firstPersonController FPC = hit.transform.gameObject.GetComponent<firstPersonController>();

            if (FPC != null)
            {
                print(hit.transform.gameObject.name);
                return hit.transform.gameObject;
            }
        }
        return null;
    }
}
