using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Telescope : MonoBehaviour
{
    public Button btnTelescope;
    private ChangeScene scriptChangeScene;

    void Start()
    {
        scriptChangeScene = GameObject.Find("Scene Manager").GetComponent<ChangeScene>();
        btnTelescope.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        scriptChangeScene.GotoScene("Game 2 Level 1", 3);
    }
  
}
