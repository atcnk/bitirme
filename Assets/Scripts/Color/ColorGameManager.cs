/*
 * 
 *  Class with all the main operations related to Color Game.
 * 
 */

using UnityEngine;

public class ColorGameManager : MonoBehaviour
{
    #region Singleton

    static ColorGameManager instance = null;

    public static ColorGameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
    }

    #endregion

    [SerializeField] private GameObject prefabGreenSphere, prefabOrangeSphere, prefabPurpleSphere;
    [SerializeField] private GameObject goYellowSphere, goBlueSphere, goRedSphere;
    [SerializeField] private AudioClip[] acSounds;

    [HideInInspector] public int coloredCount = 0;
    [HideInInspector] public string currentColor = "";
    [HideInInspector] public bool isOrangeSpawned, isGreenSpawned, isPurpleSpawned, isAllSpawned;

    Sound csSound;
    Snapper csSnapperA;
    Snapper csSnapperB;
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

    public void CheckSnappers()
    {
        if (currentColor == "BlueYellow" || currentColor == "YellowBlue")
        {
            isGreenSpawned = SetSpawn(prefabGreenSphere, isGreenSpawned);

            SetOrigin(goBlueSphere, goYellowSphere);
        }

        else if (currentColor == "YellowRed" || currentColor == "RedYellow")
        {
            isOrangeSpawned = SetSpawn(prefabOrangeSphere, isOrangeSpawned);

            SetOrigin(goYellowSphere, goRedSphere);
        }

        else if (currentColor == "RedBlue" || currentColor == "BlueRed")
        {
            isPurpleSpawned = SetSpawn(prefabPurpleSphere, isPurpleSpawned);

            SetOrigin(goRedSphere, goBlueSphere);
        }

        CheckSecondaryColorsSpawn();
    }

    private bool SetSpawn(GameObject sphere, bool isSpawned)
    {
        if (!isSpawned)
        {
            GenerateColor(sphere);
        }

        return true;
    }

    private void CheckSecondaryColorsSpawn()
    {
        if (isGreenSpawned && isPurpleSpawned && isOrangeSpawned)
        {
            isAllSpawned = true;
        }
    }
    public void CheckFinish()
    {
        if (coloredCount == 3 && !isAllSpawned || coloredCount == 6)
        {
            if (!csHoldTheDoor.muteNarrator)
            {
                PlaySound(1);

                csChangeScene.GoToScene(csChangeScene.nextSceneIndex, acSounds[1].length + csChangeScene.shortDelay);
            }
            else
            {
                csChangeScene.GoToScene(csChangeScene.nextSceneIndex, csChangeScene.shortDelay);
            }
        }
    }

    private void GenerateColor(GameObject sphere)
    {
        Instantiate(sphere, sphere.transform.position, Quaternion.identity);
    }

    private void SetOrigin(GameObject go1, GameObject go2)
    {
        go1.transform.position = go1.GetComponent<ColorController>().originPosition;
        go2.transform.position = go2.GetComponent<ColorController>().originPosition;

        SetNull();
    }

    private void SetNull()
    {
        currentColor = "";

        csSnapperA.isFilled = false;
        csSnapperB.isFilled = false;
    }

    private void PlaySound(int index)
    {
        SetClick(false);

        csSound.PlaySoundWithDelay(acSounds[index], "Color");
    }

    public void SetClick(bool status)
    {
        goRedSphere.GetComponent<ColorController>().canClick = status;
        goBlueSphere.GetComponent<ColorController>().canClick = status;
        goYellowSphere.GetComponent<ColorController>().canClick = status;
    }

    private void GetScripts()
    {
        csChangeScene = GameObject.Find("Scene Manager").GetComponent<ChangeScene>();
        csHoldTheDoor = GameObject.Find("Door").GetComponent<HoldTheDoor>();
        csSound = GameObject.Find("Scene Manager").GetComponent<Sound>();

        if (csChangeScene.activeSceneIndex == 5)
        {
            csSnapperA = GameObject.Find("SnapperA").GetComponent<Snapper>();
            csSnapperB = GameObject.Find("SnapperB").GetComponent<Snapper>();
        }
    }
}