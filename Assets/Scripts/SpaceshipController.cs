using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipController : MonoBehaviour
{
    private Rigidbody2D rbComp;
    private float accX;
    public string nextSceneName;
    private ChangeScene scriptChangeScene;

    public AudioSource winAudio;
    public AudioSource boomAudio;
    public AudioSource firingAudio;


    private void Start()
    {
        rbComp = GetComponent<Rigidbody2D>();
        scriptChangeScene = GameObject.Find("Scene Manager").GetComponent<ChangeScene>();
    }
    void Update()
    {
        accX = Mathf.Round(Input.acceleration.x * 1000f) / 10f; ;

        if (Input.GetMouseButton(0)) 
        {
            rbComp.AddForce(transform.up * 15 * Time.deltaTime, ForceMode2D.Force);
            firingAudio.Play();
        }

        CheckLimits(); 
    }

    private void FixedUpdate()
    {
        RotateShip();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            scriptChangeScene.GotoScene(nextSceneName, 5);
            Debug.Log("iniş başarılı");
            winAudio.Play();
        }

        if (collision.gameObject.CompareTag("SpaceObstacle"))
        {
            Debug.Log("boom!");
            Scene scene = SceneManager.GetActiveScene(); // Reload scene 
            scriptChangeScene.GotoScene(scene.name, 2);
            boomAudio.Play();
            gameObject.SetActive(false);
        }
    }

    private void RotateShip()
    { 
        rbComp.SetRotation(-accX);
    }

    private void CheckLimits()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;
        float posZ = transform.position.z;

        posX = Mathf.Clamp(posX, -8, 8);
        posY = Mathf.Clamp(posY, -60, 14.5f);

        transform.position = new Vector3(posX, posY, posZ);
    }
}
