using System.Collections;
using System.Collections.Generic;
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
    public GameObject snapperA, snapperB;
    [SerializeField]
    private GameObject greenBallPrefab, orangeBallPrefab, purpleBallPrefab;
    public string resultColor;
    private Vector3 yellowPos, bluePos, redPos;
    public Vector3 purpleSpawn=new Vector3(-7,0,0), orangeSpawn=new Vector3(7,0,0);
    [SerializeField]
    private GameObject yellowBall, blueBall, redBall;
    private bool orangeSpawned = false, greenSpawned = false, purpleSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        redPos = redBall.transform.position;
        bluePos = blueBall.transform.position;
        yellowPos = yellowBall.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetColor()
    {
        switch (resultColor)
        {
            case "green":  
                if (!greenSpawned)
                {
                    Instantiate(greenBallPrefab, purpleSpawn, Quaternion.identity);
                    SetBallPos();
                    greenSpawned = true;
                }
                else 
                {
                    SetBallPos();
                }
                break;
            case "orange":
                if (!orangeSpawned)
                {
                    Instantiate(orangeBallPrefab, orangeSpawn, Quaternion.identity);
                    SetBallPos();
                    orangeSpawned = true;             
                }
                else
                {
                    SetBallPos();
                }
                break;
            case "purple":
                if (!purpleSpawned)
                {
                    Instantiate(purpleBallPrefab, Vector3.zero, Quaternion.identity);
                    SetBallPos();
                    purpleSpawned = true;
                }
                else
                {
                    SetBallPos();
                }
                break;

        }
    }
    public void CheckColors()
    {
        if ((snapperA.GetComponent<snapper>().currentColor=="Yellow"&& snapperB.GetComponent<snapper>().currentColor == "Blue") || (snapperA.GetComponent<snapper>().currentColor == "Blue" && snapperB.GetComponent<snapper>().currentColor == "Yellow"))
        {
            resultColor = "green";
            SetColor();
        }
        else if ((snapperA.GetComponent<snapper>().currentColor == "Yellow" && snapperB.GetComponent<snapper>().currentColor == "Red") || (snapperA.GetComponent<snapper>().currentColor == "Red" && snapperB.GetComponent<snapper>().currentColor == "Yellow"))
        {
            resultColor = "orange";
            SetColor();
        }
        else if ((snapperA.GetComponent<snapper>().currentColor == "Red" && snapperB.GetComponent<snapper>().currentColor == "Blue") || (snapperA.GetComponent<snapper>().currentColor == "Blue" && snapperB.GetComponent<snapper>().currentColor == "Red"))
        {
            resultColor = "purple";
            SetColor();
        }
    }
    public void SetBallPos()
    {
        redBall.transform.position = redPos;
        blueBall.transform.position = bluePos;
        yellowBall.transform.position = yellowPos;
        SetNull();
    }
    public void SetNull()
    {
        snapperB.GetComponent<snapper>().currentColor = "";
        snapperA.GetComponent<snapper>().currentColor = "";
    }
}
