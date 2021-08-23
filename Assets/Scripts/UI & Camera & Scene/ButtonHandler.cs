/*
 * 
 *  Class that gives functionality to all buttons in the UI.
 * 
 */

using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Image continueImage;
    [SerializeField] private Image pauseImage;
    [SerializeField] private AudioSource asSounds;

    [HideInInspector] public bool isCaptured;

    GravityGameManager csGravityGameManager;
    MirrorMovement csMirrorMovement;
    ChangeScene csChangeScene;
    HoldTheDoor csHoldTheDoor;

    private bool isGameMenuActive;

    public void Start()
    {
        GetScripts();
    }

    #region Scene Changes
    // All the scene change operations by buttons

    public void MainMenu()
    {
        csChangeScene.GoToScene(0, csChangeScene.withoutDelay);
    }

    public void Settings()
    {
        csChangeScene.GoToScene(1, csChangeScene.withoutDelay);
    }

    public void StartGame()
    {
        if (isGameMenuActive)
        {
            csChangeScene.GoToScene(2, csChangeScene.withoutDelay);
        }
        else
        {
            ColorAnimation();
        }
    }

    public void ColorAnimation()
    {
        csChangeScene.GoToScene(3, csChangeScene.shortDelay);
    }

    public void ColorGame()
    {
        csChangeScene.GoToScene(4, csChangeScene.withoutDelay);
    }

    public void TelescopeAnimation()
    {
        csChangeScene.GoToScene(7, csChangeScene.shortDelay);
    }

    public void Room()
    {
        csChangeScene.GoToScene(8, csChangeScene.withoutDelay);
    }

    public void TelescopeGame()
    {
        csChangeScene.GoToScene(9, csChangeScene.withoutDelay);
    }

    public void GravitiyAnimation()
    {
        csChangeScene.GoToScene(12, csChangeScene.shortDelay);
    }

    public void GravityGame()
    {
        csChangeScene.GoToScene(13, csChangeScene.withoutDelay);
    }

    public void ReloadAnimationScene()
    {
        csChangeScene.GoToScene(csChangeScene.activeSceneIndex, csChangeScene.withoutDelay);
    }

    public void ReloadScene()
    {
        csChangeScene.GoToScene(csChangeScene.activeSceneIndex, csChangeScene.shortDelay);
    }

    #endregion Scene Changes

    #region Telescope Game  
    // Rotate operations for mirrors

    public void RotateCounterClockwise()
    {
        SetMirrorRotates(true, false);
    }

    public void RotateClockwise()
    {
        SetMirrorRotates(false, true);
    }

    public void StopRotate()
    {
        SetMirrorRotates(false, false);
    }

    public void SetMirrorRotates(bool left, bool right)
    {
        csMirrorMovement.rotateLeft = left;
        csMirrorMovement.rotateRight = right;
    }

    #endregion Telescope Game

    #region Sound
    // Mute & unmute operations for music and narrator.

    public void MuteMusic()
    {
        csHoldTheDoor.muteMusic = !csHoldTheDoor.muteMusic;

        if (!csHoldTheDoor.muteMusic)
        {
            csHoldTheDoor.muteMusic = true;
        }
        else
        {
            csHoldTheDoor.muteMusic = false;
        }
    }

    public void MuteNarrator()
    {
        if (!csHoldTheDoor.muteNarrator)
        {
            csHoldTheDoor.muteNarrator = true;
        }
        else
        {
            csHoldTheDoor.muteNarrator = false;
        }
    }

    #endregion Sound

    public void PauseGravityGame()
    {
        if (csGravityGameManager.canCallPause)
        {
            if (Time.timeScale == 1)
            {
                pauseImage.gameObject.SetActive(false);
                continueImage.gameObject.SetActive(true);
            }
            else
            {
                continueImage.gameObject.SetActive(false);
                pauseImage.gameObject.SetActive(true);
            }

            csGravityGameManager.SetFiring(false);
            csGravityGameManager.SetRigidbodyFreezeStatus(true);
        }
    }

    public void Capture()
    {
        // Set isCaptured 'true' to get screenshot and read pixels. 
        isCaptured = true;
    }

    public void Exit()
    {
        // Quit from game.
        Application.Quit();
    }

    private void GetScripts()
    {
        csChangeScene = GameObject.Find("Scene Manager").GetComponent<ChangeScene>();
        csMirrorMovement = GameObject.Find("Scene Manager").GetComponent<MirrorMovement>();
        csHoldTheDoor = GameObject.Find("Door").GetComponent<HoldTheDoor>();
        csGravityGameManager = GameObject.Find("Scene Manager").GetComponent<GravityGameManager>();
    }
}
