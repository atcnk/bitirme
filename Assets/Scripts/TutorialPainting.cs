using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPainting : MonoBehaviour
{
    private SpriteRenderer renksizElma;
    public Sprite renkliElma;
    private SpriteRenderer renksizGunes;
    public Sprite renkliGunes;
    private SpriteRenderer renksizDere;
    public Sprite renkliDere;

    private Renderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<Renderer>();
        renksizElma = GameObject.Find("Apple").GetComponent<SpriteRenderer>();
        renksizGunes = GameObject.Find("Sun").GetComponent<SpriteRenderer>();
        renksizDere = GameObject.Find("Water").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GreenBall") && gameObject.CompareTag("Gunes"))
        {
            renksizGunes.sprite = renkliGunes;
            sprite.material.SetColor("_Color", Color.yellow);
            //sprite.color = Color.yellow;
            Debug.Log("turuncu");
            Destroy(other.gameObject);
        }
        if (gameObject.CompareTag("Deniz") && other.gameObject.CompareTag("BlueBall"))
        {
            renksizDere.sprite = renkliDere;
            sprite.material.SetColor("_Color", Color.blue);
            //sprite.color = Color.yellow;
            Debug.Log("yesil");
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("RedBall") && gameObject.CompareTag("Cilek"))
        {
            renksizElma.sprite = renkliElma;
            sprite.material.SetColor("_Color", Color.red);
            //sprite.color = Color.yellow;
            Debug.Log("mor");
            Destroy(other.gameObject);
        }
    }
}
