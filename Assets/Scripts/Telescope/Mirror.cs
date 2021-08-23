/*
 * 
 *  Mirror class
 * 
 */

using UnityEngine;

public class Mirror : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer srMirror; 
    [HideInInspector] public bool isSoundPlaying;

    public float startAngle; 
    public float clampMin; 
    public float clampMax; 
    public float correctAngle; 
    public string previousMirror; 
    public string nextMirror; 
    public bool canNextRotate; 

    private void Start()
    {
        GetComponents();
    }

    private void GetComponents()
    {
        srMirror = GetComponent<SpriteRenderer>();
    }
}
