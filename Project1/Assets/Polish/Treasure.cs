using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField]
    GameManager manager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<firstPersonController>() != null)
        {
            Debug.Log(true);    
            manager.EndGame();
        }
    }
}
