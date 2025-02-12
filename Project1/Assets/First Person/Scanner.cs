using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] GameObject toSend;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.tag);
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        Debug.Log(true);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            toSend.GetComponent<firstPersonController>().ObjectToLockOn = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            toSend.GetComponent<firstPersonController>().ObjectToLockOn = null;
        }
    }
}

