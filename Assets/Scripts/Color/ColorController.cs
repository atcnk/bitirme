/*
 * 
 *	Controller class for Color Game.
 * 
 */

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
            Destroy(this.gameObject);
        }

        instance = this;
    }

    #endregion Singleton

    [HideInInspector] public Vector3 originPosition;

    public bool canClick = true;
    public bool isDragging;

    public void OnMouseDown()
    {
        isDragging = true;
    }
    public void OnMouseUp()
    {
        isDragging = false;
    }

    private void Start()
    {
        originPosition = transform.position;
    }

    private void Update()
    {
        if(isDragging&&canClick)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);
        }
    }
}
