/*
 * 
 *  Class to keep the some values to be transferred to the next scene.
 * 
 */

using UnityEngine;

public class HoldTheDoor : MonoBehaviour
{
    [HideInInspector] public bool isFirstGravity = true;
    [HideInInspector] public bool isGameFinished;
    [HideInInspector] public bool muteMusic;
    [HideInInspector] public bool muteNarrator;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
