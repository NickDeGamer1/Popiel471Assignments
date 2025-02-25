using UnityEngine;

public class CamFallow : MonoBehaviour
{
    [SerializeField]
    GameObject body;
    [SerializeField]
    Vector3 offset = new Vector3(1, 1, -3.5f);
    // Update is called once per frame
    void Update()
    {
        transform.position = body.transform.position + offset;
    }
}
