using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColliderColor : MonoBehaviour
{
    
    #region Singleton

    static ColliderColor instance = null;

    public static ColliderColor Instance
    {
        get { return instance; }
    }


    void Awake()
    {
        if (instance != null && instance != this)
        {
            //Destroy(this.gameObject);
        }

        instance = this;
    }

    #endregion
    public string currentBallA="bos";
    public string currentBallB="bos";
    public bool isTouchable = true;
    public GameObject redBall;
    public GameObject blueBall;
    public GameObject greenBall;
    public Vector3 redPos;
    public Vector3 bluePos;
    public Vector3 greenPos;
    public bool dogruCevap = false;
    // Start is called before the first frame update

    void Start()
    {
        redPos = redBall.transform.position;
        bluePos = blueBall.transform.position;
        greenPos = greenBall.transform.position;


    }
    // Update is called once per frame
    private void FreezePositions()
    {
        redBall.transform.position = redPos;
        blueBall.transform.position = bluePos;
        greenBall.transform.position = greenPos;
        

    }
    private void Update()
    {

    
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(3f);
        FreezePositions();
    }

}

