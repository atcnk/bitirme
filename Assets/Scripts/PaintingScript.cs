using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PaintingScript : MonoBehaviour
{
    public GameObject dogruRenk;
    private SpriteRenderer renksizCicek;
    public Sprite renkliCicek;
    private SpriteRenderer renksizCimen;
    public Sprite renkliCimen;
    private SpriteRenderer renksizPortakal;
    public Sprite renkliPortakal;
    Color _orange = new Color(1.0f, 0.64f, 0.0f);

    private Renderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        renksizCicek = GameObject.Find("cicek-renksiz").GetComponent<SpriteRenderer>();
        renksizCimen = GameObject.Find("cimen-renksiz").GetComponent<SpriteRenderer>();
        renksizPortakal = GameObject.Find("portakal-renksiz").GetComponent<SpriteRenderer>();
        sprite = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("OrangeBall")&&gameObject.CompareTag("Portakal")) 
        {
            renksizPortakal.sprite = renkliPortakal;
            sprite.material.SetColor("_Color", _orange);
            //sprite.color = Color.yellow;
            Debug.Log("turuncu");
            Destroy(other.gameObject);
        }
        if (gameObject.CompareTag("Cimen")&&other.gameObject.CompareTag("YesilBall"))
        {
            renksizCimen.sprite = renkliCimen;
            sprite.material.SetColor("_Color", Color.green);
            //sprite.color = Color.yellow;
            Debug.Log("yesil");
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("PurpleBall") && gameObject.CompareTag("Mor")) 
        {
            renksizCicek.sprite = renkliCicek;
            sprite.material.SetColor("_Color", Color.magenta);
            //sprite.color = Color.yellow;
            Debug.Log("mor");
            Destroy(other.gameObject);
        }
        /*else
        {
            if (other.gameObject.CompareTag("YesilBall"))
            {
                Debug.Log("yanlis secim");
                //ColorController.Instance.canClick = false;
                other.transform.DOMove(ColorGameManager.Instance.purpleSpawn, 5f).SetEase(Ease.OutElastic);
                //ColorController.Instance.canClick = true;
            }
            else 
            {
                other.gameObject.transform.position = ColorGameManager.Instance.orangeSpawn;
            }
        }*/
    }
}
