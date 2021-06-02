using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    #region Singleton

    static ColorController instance = null;

    public static ColorController Instance
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
    public bool canClick = true;
    private bool isDragging;
    public void OnMouseDown()
    {
        isDragging = true;
    }
    public void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if(isDragging&&canClick)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);
        }

    }

}
