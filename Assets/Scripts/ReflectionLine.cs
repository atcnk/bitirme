using UnityEngine;
using System.Linq;

public class ReflectionLine : MonoBehaviour
{
    public string nextSceneName;
    public bool gameOver = false;

    public GameObject winTextObject;

    private ChangeScene changeSceneScript;
    private LineRenderer inputLine;
    

    private int maxReflectionCount = 100;
    private int lineIndex = 0;
    private float maxStepDistance = 100f;
    private readonly string[] reflectorTags = { "Reflector", "Ref80", "Ref84", "Ref97", "Ref106"
                                               , "Ref131", "Ref33", "Ref38", "RefGame1", "RefGame2"
                                               , "Ref26", "Ref27", "Ref20", "Ref24", "Ref43", "Ref49"
                                               , "Ref110", "Ref86", "Ref62", "RefGame3", "Ref34", "Ref149"};

    // Start is called before the first frame update
    void Start()
    {
        inputLine = GameObject.Find("Reflection").GetComponent<LineRenderer>();
        //targetRenderer = GameObject.Find("Target").GetComponent<Renderer>();
        //targetMat = targetRenderer.material;
        winTextObject.SetActive(false);
        changeSceneScript = GameObject.Find("Scene Manager").GetComponent<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        Light();
    }

    private void Light()
    {
        lineIndex = 0;
        inputLine.positionCount = 2;

        CastRay(transform.position, transform.up, maxReflectionCount);
    }

    private void CastRay(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {

        if (reflectionsRemaining == 0)
        {
            return;
        }

        Vector3 startingPosition = position;        // store the value of position

        RaycastHit hit;
        Ray ray = new Ray(position, direction);     // cast ray

        if (Physics.Raycast(ray, out hit, maxStepDistance))     // if it isn't first ray and hits
        {

            if (reflectorTags.Contains(hit.transform.tag))
            {
                direction = Vector3.Reflect(direction, hit.normal);     // get reflect of ray
                position = hit.point;       // store hit point

                UpdateLine(lineIndex, startingPosition, position);      // update line

                inputLine.positionCount++;

                UpdateLine(lineIndex + 1, position, position);      // equalize the last two points with same position after posSize++
                lineIndex++;
                CastRay(position, direction, reflectionsRemaining - 1);         // cast reflect
            }

            if (hit.transform.CompareTag("Obstacle"))
            {
                position = hit.point;
                UpdateLine(lineIndex, startingPosition, position);
            }

            if (hit.transform.CompareTag("Finish"))
            {
                position = hit.point;
                UpdateLine(lineIndex, startingPosition, position);
                //targetMat.EnableKeyword("_EMISSION");
                //targetMat.SetColor("_EmissionColor", Color.yellow);
                gameOver = true;
                winTextObject.SetActive(true);
                changeSceneScript.GotoScene(nextSceneName, 5);
            }

        }

        else        // if it doesn't hit - last line
        {
            UpdateLine(lineIndex, startingPosition, position + direction * maxStepDistance);        // update last points of the line with maxStepDistance
        }
    }

    private void UpdateLine(int index, Vector3 startingPoint, Vector3 endingPoint)
    {
        inputLine.SetPosition(index, startingPoint);
        inputLine.SetPosition(index + 1, endingPoint);
    }
}
