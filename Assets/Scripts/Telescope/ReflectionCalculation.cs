/*
 * 
 *  Class where reflections are calculated with RayCast
 * 
 */
using UnityEngine;

public class ReflectionCalculation : MonoBehaviour
{
    [SerializeField] private int maxDistance;
    [SerializeField] private int maxReflectionCount;

    GenerateLight csGenerateLight;

    private void Start()
    {
        GetScripts();
    }

    private void Update()
    {
        StartCast();
    }

    private void StartCast()
    {
        csGenerateLight.SetStartCounts();
        CastAgain(transform.position, transform.up, maxReflectionCount);
    }

    private void CastAgain(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {
        if (reflectionsRemaining == 0)
        {
            return;
        }

        Vector3 startingPosition = position;      

        RaycastHit hit;
        Ray ray = new Ray(position, direction);

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.transform.CompareTag("Mirror"))
            {
                // If it is a mirror then reflect the light and cast a ray again

                direction = Vector3.Reflect(direction, hit.normal);

                position = hit.point;       

                csGenerateLight.DrawLine(csGenerateLight.lineIndexCount, startingPosition, position);
                csGenerateLight.IncreaseCounts();
                csGenerateLight.DrawLine(csGenerateLight.lineIndexCount, position, position);

                CastAgain(position, direction, reflectionsRemaining - 1);
            }

            if (hit.transform.CompareTag("Obstacle"))
            {
                // If it is an obstacle then set last point of the Line

                position = hit.point;

                csGenerateLight.DrawLine(csGenerateLight.lineIndexCount, startingPosition, position);
            }
        }
        else
        {
            // If it doesn't hit anything then set last point of the Line by adding maxDistance

            csGenerateLight.DrawLine(csGenerateLight.lineIndexCount, startingPosition, position + direction * maxDistance);
        }
    }

    private void GetScripts()
    {
        csGenerateLight = GameObject.Find("Light").GetComponent<GenerateLight>();
    }
}
