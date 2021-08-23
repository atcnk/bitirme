/*
 * 
 *  Class with all operations related to changing the scene
 * 
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [HideInInspector] public int activeSceneIndex;
    [HideInInspector] public int nextSceneIndex;

    [HideInInspector] public float withoutDelay = 0f;
    [HideInInspector] public float shortDelay = 1.0f;
    [HideInInspector] public float longDelay = 3.0f;

    private int tempIndex;
    
    private void Awake()
    {
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        GetScenes();
    }

    public void GoToScene(int index, float delay)
    {
        // Change scene by index number with delay

        tempIndex = index;

        Invoke("SceneWithDelay", delay);
    }

    private void SceneWithDelay()
    {
        SceneManager.LoadScene(tempIndex);
    }

    private void GetScenes()
    {
        nextSceneIndex = activeSceneIndex + 1;
    }
}
