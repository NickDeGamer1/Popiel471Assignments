using TMPro;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
    [SerializeField]
    GameObject Label;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
            Label.SetActive(true);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Label.SetActive(false);
        }
            
    }
}
