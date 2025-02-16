using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private enum State
    {
        Pace,
        Fallow,
    }
    private State CurrentState = State.Pace;

    [SerializeField]
    GameObject[] route;
    GameObject target;
    int index = 0;
    float speed = 5f;

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
        }
        MoveTo(target);
        GameObject obs = CheckForward();
        if (obs != null)
        {
            //Debug.Log(true);
            print("No longer pacing: " + obs.name);
            target = obs;
            CurrentState = State.Fallow;
        }
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

    void MoveTo(GameObject T)
    {
        transform.position = Vector3.MoveTowards(transform.position, T.transform.position, speed * Time.deltaTime);
        transform.LookAt(T.transform.position);
    }

    GameObject CheckForward()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10, Color.green);

        if ((Physics.Raycast(transform.position, transform.forward, out hit, 10)))
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
