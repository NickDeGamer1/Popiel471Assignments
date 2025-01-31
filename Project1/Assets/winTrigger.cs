using UnityEngine;

public class winTrigger : MonoBehaviour
{
    [SerializeField] private GameObject Text;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.SetActive(true);
        }
    }
}
