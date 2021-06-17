using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Game2Camera : MonoBehaviour
{
    private Rotate rotateScriptGameTwo;
    private Rotate rotateScriptGameThree;
    private ReflectionLine reflectionLineScript;
    private Camera m_OrthographicCamera;

    private Vector3 camChangeX = new Vector3(0, 0, -10);
    private float sizeChange = 5.0f;
    private float speedChange = 0.002f;

    private float farSize = 5.0f;
    private float midSize = 3.0f;
    private float closeSize = 2.5f;

    private float fastSpeed = 0.003f;
    private float normalSpeed = 0.002f;
    private float slowSpeed = 0.001f;

    private float normalCamX = 0f;
    private float rightCamX = 3f;

    private bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        m_OrthographicCamera = GetComponent<Camera>();
        reflectionLineScript = GameObject.Find("Source").GetComponent<ReflectionLine>();
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        m_OrthographicCamera.transform.position = Vector3.Lerp(transform.position, camChangeX, speedChange);
        m_OrthographicCamera.orthographicSize = sizeChange;

        if (gameStarted)
        {
            Camera();
        }
        
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
        gameStarted = true;
    }

    private void Camera()
    {

        Scene scene = SceneManager.GetActiveScene();

        if(scene.name == "Game 2 Level 1")
        {
            sizeChange = farSize;
            camChangeX.x = normalCamX;
        }

        if (scene.name == "Game 2 Level 2")
        {
            rotateScriptGameTwo = GameObject.Find("Mirror (3)").GetComponent<Rotate>();

            if (!rotateScriptGameTwo.rightAngle)
            {
                speedChange = normalSpeed;
                sizeChange = closeSize;
                camChangeX.x = rightCamX;
            }

            if(rotateScriptGameTwo.rightAngle && !reflectionLineScript.gameOver)
            {
                speedChange = normalSpeed;
                sizeChange = midSize;
                camChangeX.x = -rightCamX;
            }

            if (reflectionLineScript.gameOver)
            {
                speedChange = fastSpeed;
                sizeChange = farSize;
                camChangeX.x = normalCamX;
            }
        }

        if (scene.name == "Game 2 Level 3")
        {
            rotateScriptGameThree = GameObject.Find("Mirror (8)").GetComponent<Rotate>();

            if (!rotateScriptGameThree.rightAngle)
            {
                speedChange = normalSpeed;
                sizeChange = closeSize;
                camChangeX.x = rightCamX;
            }

            if (rotateScriptGameThree.rightAngle && !reflectionLineScript.gameOver)
            {
                speedChange = slowSpeed;
                sizeChange = midSize;
                camChangeX.x = -rightCamX;
            }

            if (reflectionLineScript.gameOver)
            {
                speedChange = fastSpeed;
                sizeChange = farSize;
                camChangeX.x = normalCamX;
            }
        }

    }
}
