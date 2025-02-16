using UnityEngine;

public class ShapeCastCam : MonoBehaviour
{
    public bool LockedOn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public GameObject ShapeCast()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Vector3 p1 = transform.position;
            int layerMask = ~LayerMask.GetMask("Bullets");
            if (Physics.SphereCast(p1, 0.5f, transform.forward.normalized, out hit, 30, layerMask))
            {
                if (hit.rigidbody != null)
                {
                    GameObject h = hit.rigidbody.gameObject;
                    if (h.CompareTag("Enemy"))
                    {
                        return h;
                    }
                }
            }
        }
        return null;
    }

}
