using UnityEngine;

public class CamFallow : MonoBehaviour
{
    [SerializeField]
    GameObject body;
    // Update is called once per frame
    void Update()
    {
        transform.position = body.transform.position + new Vector3(1,1,-3.5f);
    }
}
