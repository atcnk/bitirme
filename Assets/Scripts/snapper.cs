using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class snapper : MonoBehaviour
{
    
    public Vector3 spawnPos = new Vector3(0,0,0);
    public GameObject renk1, renk2, renk3;
    public bool orangeSpawned = false, greenSpawned=false, purpleSpawned=false;
    public string currentColor="";

    


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

            if (other.gameObject.CompareTag("RedBall"))
            {
                
                other.transform.DOMove(gameObject.transform.position, 2f).SetEase(Ease.OutElastic).OnComplete(() =>
                {
                    currentColor = "Red";
                    ColorGameManager.Instance.CheckColors();
                });

            }
            else if (other.gameObject.CompareTag("GreenBall"))
            {
                
                other.transform.DOMove(gameObject.transform.position, 2f).SetEase(Ease.OutElastic).OnComplete(() =>
                {
                    currentColor = "Yellow";
                    ColorGameManager.Instance.CheckColors();
                });

            }
            else if (other.gameObject.CompareTag("BlueBall"))
            {
                
                other.transform.DOMove(gameObject.transform.position, 2f).SetEase(Ease.OutElastic).OnComplete(() =>
                {
                    currentColor = "Blue";
                    ColorGameManager.Instance.CheckColors();
                });
            }
        

    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("renk"+currentColor);
    }




}
