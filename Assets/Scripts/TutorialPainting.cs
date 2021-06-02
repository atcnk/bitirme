using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPainting : MonoBehaviour
{
    private Renderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GreenBall") && gameObject.CompareTag("Gunes"))
        {
            sprite.material.SetColor("_Color", Color.yellow);
            //sprite.color = Color.yellow;
            Debug.Log("turuncu");
            Destroy(other.gameObject);
        }
        if (gameObject.CompareTag("Deniz") && other.gameObject.CompareTag("BlueBall"))
        {
            sprite.material.SetColor("_Color", Color.blue);
            //sprite.color = Color.yellow;
            Debug.Log("yesil");
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("RedBall") && gameObject.CompareTag("Cilek"))
        {
            sprite.material.SetColor("_Color", Color.red);
            //sprite.color = Color.yellow;
            Debug.Log("mor");
            Destroy(other.gameObject);
        }
    }
}
