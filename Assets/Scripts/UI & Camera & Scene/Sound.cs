/*
 *  
 * Class in which audio-related operations are performed
 * 
 */

using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource asSounds;
    [SerializeField] private bool isAnimationScene;
    
    HoldTheDoor csHoldTheDoor;
    ColorDetection csColorDetection;
    ColorGameManager csColorGameManager;
    GravityGameManager csGravityGameManager;
    TelescopeGameManager csTelescopeGameManager;

    private void Awake()
    {
        GetScripts();

        if (isAnimationScene && !csHoldTheDoor.muteNarrator)
        {
            asSounds.Play();
        }
    }

    public void PlaySoundWithDelay(AudioClip clip, string methodName)
    {
        /*  Play sound with name of the game.
         *  This goes to another method which matches game name
         *  and it does game specific actions
         */ 

        if (!csHoldTheDoor.muteNarrator)
        {
            asSounds.PlayOneShot(clip);
        }

        Invoke(methodName, clip.length);
    }

    private void Telescope()
    {
        csTelescopeGameManager.csActiveMirror.isSoundPlaying = false;
    }

    private void Gravity()
    {
        csGravityGameManager.SetRigidbodyFreezeStatus(false);
    }

    private void AR()
    {
        csColorDetection.goCaptureButton.SetActive(true);
    }

    private void Color()
    {
        csColorGameManager.SetClick(true);
    }

    private void GetScripts()
    {  
        csTelescopeGameManager = GameObject.Find("Scene Manager").GetComponent<TelescopeGameManager>();
        csGravityGameManager = GameObject.Find("Scene Manager").GetComponent<GravityGameManager>();
        csColorGameManager = GameObject.Find("Scene Manager").GetComponent<ColorGameManager>();
        csColorDetection = GameObject.Find("Scene Manager").GetComponent<ColorDetection>();
        csHoldTheDoor = GameObject.Find("Door").GetComponent<HoldTheDoor>();
    }
}
