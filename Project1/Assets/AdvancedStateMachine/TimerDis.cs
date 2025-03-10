using TMPro;
using UnityEngine;

public class TimerDis : MonoBehaviour
{
    float time = 0;
    Singleton singleton;
    TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        singleton = Singleton.Instance;
    }

    void Update()
    {
        time += Time.deltaTime;
        singleton.timeTook = time;
        int min = (int)(time / 60);
        int sec = (int)(time % 60);
        if (sec < 10)
            tmp.text = min.ToString() + ":0" + sec.ToString();
        else
            tmp.text = min.ToString() + ":" + sec.ToString();

    }
}
