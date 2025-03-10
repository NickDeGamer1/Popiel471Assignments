using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalMenu : MonoBehaviour
{
    
    public TextMeshProUGUI[] displays;
    public Button Menu;
    public Button Play;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;

        Menu.onClick.AddListener(BackToMenu);
        Play.onClick.AddListener(PlayAgain);

        Singleton singleton = Singleton.Instance;

        if (singleton != null)
        {
            singleton.SetSpeedList();

            for (int i = 0; i < displays.Length; i++)
            {
                if (i > singleton.TopSpeeds.Count - 1)
                {
                    //Debug.Log("End of list " + i.ToString());
                    break;
                }
                int min = (int)(singleton.TopSpeeds[i] / 60);
                int sec = (int)(singleton.TopSpeeds[i] % 60);
                if (sec < 10)
                    displays[i].text = min.ToString() + ":0" + sec.ToString();
                else
                    displays[i].text = min.ToString() + ":" + sec.ToString();
            }
        }
    }
    void OnStart()
    {
        PlayAgain();
    }

    void OnExit()
    {
        BackToMenu();
    }

    void BackToMenu()
    {
        SceneManager.LoadScene("StartingScene");
    }

    void PlayAgain()
    {
        SceneManager.LoadScene("AdvancedStateMachine");
    }
}
