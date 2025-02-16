using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool isAlive;
    private SpriteRenderer SR;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void UpdateColor()
    {
        SR.color = isAlive ? Color.white : Color.red;
    }
}
