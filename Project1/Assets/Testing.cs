using UnityEngine;

public class Testing : MonoBehaviour
{
    public GameObject cube;
    Transform t;
    float speed = 1.0f;

    //int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //print(score);
        t = cube.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (t.position.y > 10)
        {
            speed *= -1;
        }
        else if (t.position.y < -10)
        {
            speed *= -1;
        }
        t.Translate(0, speed, 0);
        //speed += 0.01f;
        //t.Rotate(speed,0,0);


        //if (score < 500)
        //{
        //    score += 1;
        //    print(score);
        //}
        //else
        //{
        //    cube.SetActive(false);
        //    print("Friend: AAAAAAAAAAA");
        //}

    }
}
