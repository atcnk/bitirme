/*
 * 
 *  Class with all the main operations related to Gravity Game.
 * 
 */

using UnityEngine;

public class GravityGameManager : MonoBehaviour
{
    [SerializeField] private GameObject boomAnimation;
    [SerializeField] private GameObject winAnimation;
    [SerializeField] private GameObject firingAnimation;
    [SerializeField] private GameObject spaceShipBody;
    [SerializeField] private GameObject goSpaceShip;
    [SerializeField] private bool isLastLevel;
    [SerializeField] private AudioSource asSounds;
    [SerializeField] private AudioClip[] acSounds;

    [HideInInspector] public bool gameOver;
    [HideInInspector] public bool isRigidbodyFrozen;
    [HideInInspector] public bool canCallPause = true;

    ChangeScene csChangeScene;
    HoldTheDoor csHoldTheDoor;
    Sound csSound;

    private Rigidbody2D rbSpaceShip;
    private bool isFiringSoundActive;

    private void Start()
    {
        GetComponents();

        if (csHoldTheDoor.isFirstGravity)
        {
            PlaySound(0);
        }
    }
    public void Boom()
    {
        SetFiring(false);

        boomAnimation.gameObject.SetActive(true);
        spaceShipBody.gameObject.SetActive(false);
        goSpaceShip.gameObject.SetActive(false);
        csHoldTheDoor.isFirstGravity = false;

        if (!csHoldTheDoor.muteMusic)
        {
            asSounds.PlayOneShot(acSounds[3]);
        }

        csChangeScene.GoToScene(csChangeScene.activeSceneIndex, acSounds[3].length + csChangeScene.shortDelay);
    }

    public void Finish()
    {
        SetFiring(false);
        SetRigidbodyFreezeStatus(false);

        gameOver = true;
        winAnimation.gameObject.SetActive(true);
        csHoldTheDoor.isFirstGravity = true;

        PlaySound(1);

        csChangeScene.GoToScene(csChangeScene.nextSceneIndex, acSounds[1].length + csChangeScene.shortDelay);

        if (isLastLevel)
        {
            csHoldTheDoor.isGameFinished = true;
        }
    }

    public void SetFiring(bool active)
    {
        if (active)
        {
            firingAnimation.gameObject.SetActive(true);

            if (!isFiringSoundActive)
            {
                asSounds.loop = true;
                asSounds.clip = acSounds[2];

                if (!csHoldTheDoor.muteMusic)
                {
                    asSounds.Play();
                }
                
                isFiringSoundActive = true;
            }
        }
        else
        {
            firingAnimation.gameObject.SetActive(false);

            asSounds.loop = false;
            asSounds.Stop();
            isFiringSoundActive = false;
        }
    }

    public void PlaySound(int index)
    {
        SetRigidbodyFreezeStatus(false);
        csSound.PlaySoundWithDelay(acSounds[index], "Gravity");
    }

    public void SetRigidbodyFreezeStatus(bool isFromMenu)
    {
        if (isFromMenu)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        else
        {
            if (isRigidbodyFrozen)
            {
                rbSpaceShip.constraints = RigidbodyConstraints2D.None;
                rbSpaceShip.WakeUp();
                isRigidbodyFrozen = false;
                canCallPause = true;
            }

            else if (!isRigidbodyFrozen)
            {
                rbSpaceShip.constraints = RigidbodyConstraints2D.FreezeAll;
                isRigidbodyFrozen = true;
                canCallPause = false;
            }
        }    
    }

    public void GetComponents()
    {
        csChangeScene = GameObject.Find("Scene Manager").GetComponent<ChangeScene>();
        rbSpaceShip = GameObject.Find("SpaceShip").GetComponent<Rigidbody2D>();
        csHoldTheDoor = GameObject.Find("Door").GetComponent<HoldTheDoor>();
        csSound = GameObject.Find("Scene Manager").GetComponent<Sound>();
    }
}