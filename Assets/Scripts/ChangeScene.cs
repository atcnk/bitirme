using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour
{
    private string nextSceneName;

    public void GotoScene(string name, int seconds)
    {
        nextSceneName = name;
        StartCoroutine(Timer(seconds));    
    }

    IEnumerator Timer(int secValue)
    {
        yield return new WaitForSeconds(secValue);
        SceneManager.LoadScene(nextSceneName);
    }

}
