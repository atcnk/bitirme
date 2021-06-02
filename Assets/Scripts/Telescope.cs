using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Telescope : MonoBehaviour
{
    public Button btnTelescope;
    private ChangeScene changeSceneScript;

    void Start()
    {
        btnTelescope.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Game 2 Level 1");
    }
  
}
