using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotation;
    public float angle; 
    public float clampMin;
    public float clampMax;
    public string previousMirrorName;
    public string nextMirrorName;
    public bool canNextRotate;
    public bool rightAngle = true;
    private AudioSource audioData;

    private bool boolCompleted = true;
    private float speed;

    private SpriteRenderer m_sp;
    private ReflectionLine reflectionLineScript;

    private Rotate previousMirrorScript;
    private Rotate nextMirrorScript;

    // Start is called before the first frame update
    void Start()
    {
        reflectionLineScript = GameObject.Find("Source").GetComponent<ReflectionLine>();
        previousMirrorScript = GameObject.Find(previousMirrorName).GetComponent<Rotate>();
        nextMirrorScript = GameObject.Find(nextMirrorName).GetComponent<Rotate>();
        audioData = GetComponent<AudioSource>();
        m_sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (previousMirrorScript.canNextRotate && rotation == angle && boolCompleted)
        {
            Completed();
        }
    }
    private void OnMouseDrag()
    {
        speed = Input.GetAxis("Mouse X");

        if (speed > 0)
        {
            speed = 0.2f;
        }
        else if (speed < 0)
        {
            speed = -0.2f;
        }

        if (!reflectionLineScript.gameOver && !rightAngle && previousMirrorScript.canNextRotate)
        {
            rotation += speed;
            
            rotation = Mathf.Round(rotation * 10f) / 10f;
            rotation = Mathf.Clamp(rotation, clampMin, clampMax);

            transform.localEulerAngles = new Vector3(0, 0, rotation);
        }
        
    }

    private void Completed()
    {
        rightAngle = true;
        canNextRotate = true;
        boolCompleted = false;

        audioData.Play(0);

        SetColors();
    }

    private void SetColors()
    {
        m_sp.color = Color.green;
        nextMirrorScript.m_sp.color = Color.red;
    }
}