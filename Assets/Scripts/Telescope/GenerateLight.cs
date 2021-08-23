/*
 * 
 *  Class that creates Line and change its properties to render the light.
 * 
 */

using UnityEngine;

public class GenerateLight : MonoBehaviour
{
    [HideInInspector] public int lineIndexCount;

    LineRenderer lrLight;    

    private void Start()
    {
        GetComponents();
    }
    public void DrawLine(int index, Vector3 startingPoint, Vector3 endingPoint)
    {
        lrLight.SetPosition(index, startingPoint);
        lrLight.SetPosition(index + 1, endingPoint);
    }

    public void SetStartCounts()
    {
        lineIndexCount = 0;
        lrLight.positionCount = 2;
    }
    
    public void IncreaseCounts()
    {
        lrLight.positionCount++;
        lineIndexCount++;
    }

    private void GetComponents()
    {
        lrLight = GetComponent<LineRenderer>();
    }
}
