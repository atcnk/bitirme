using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour
{
    private string sceneName;

    public void GotoScene(string name)
    {
        sceneName = name;
        StartCoroutine(Timer());
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
    }

}
