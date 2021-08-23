/*
 * 
 *  Class with all the main operations related to Telescope Game.
 * 
 */

using UnityEngine;

public class TelescopeGameManager : MonoBehaviour
{
    [SerializeField] private GameObject finalBackground;
    [SerializeField] private AudioClip[] acSounds;

    [HideInInspector] public string activeMirror = "mir";
    [HideInInspector] public Mirror csActiveMirror;
    [HideInInspector] public bool isLevelFinished;

    Sound csSound;
    Mirror csNextMirror;
    Mirror csFinalMirror;
    ChangeScene csChangeScene;
    HoldTheDoor csHoldTheDoor;
    
    
    private void Start()
    {
        GetScripts();

        if (!csHoldTheDoor.muteNarrator)
        {            
            PlaySound(0);
        }     
    }

    private void Update()
    {
        if (csFinalMirror.canNextRotate && !isLevelFinished)
        {           
            FinishLevel();
        }
    }

    public void ChangeActiveMirror(string mirrorName)
    {
        activeMirror = mirrorName;

        GetScripts();
    }

    public void SetColors()
    {
        csActiveMirror.srMirror.color = Color.green;
        csNextMirror.srMirror.color = Color.red;
    }

    private void FinishLevel()
    {
        isLevelFinished = true;
        finalBackground.SetActive(true);

        if (!csHoldTheDoor.muteNarrator)
        {
            PlaySound(1);
        }
        
        csChangeScene.GoToScene(csChangeScene.nextSceneIndex, acSounds[1].length + csChangeScene.longDelay);
    }

    public void PlaySound(int index)
    {
        csActiveMirror.isSoundPlaying = true;
        csSound.PlaySoundWithDelay(acSounds[index], "Telescope");
    }

    private void GetScripts()
    {
        csFinalMirror = GameObject.Find("mirf").GetComponent<Mirror>();
        csActiveMirror = GameObject.Find(activeMirror).GetComponent<Mirror>();
        csNextMirror = GameObject.Find(csActiveMirror.nextMirror).GetComponent<Mirror>();
        csChangeScene = GameObject.Find("Scene Manager").GetComponent<ChangeScene>();
        csHoldTheDoor = GameObject.Find("Door").GetComponent<HoldTheDoor>();
        csSound = GameObject.Find("Scene Manager").GetComponent<Sound>();
    }
}
