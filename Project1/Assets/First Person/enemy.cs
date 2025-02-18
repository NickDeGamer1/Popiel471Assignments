using UnityEngine;

public class enemy : MonoBehaviour
{
    public int Health = 5;
    public EnemyController EC;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EC = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            if (EC == null)
            {
                Destroy(gameObject);
            }
            else
            {
                EC.CurrentState = EnemyController.State.Dieing;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Health -= 1;
            Debug.Log("hit");
        }
    }
}
