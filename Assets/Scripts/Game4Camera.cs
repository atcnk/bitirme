using UnityEngine;

public class Game4Camera : MonoBehaviour
{
    private SpaceshipController shipScript;

    private float posCamZ = -10f;
    private float posCamX = 0f;

    public float limitCamY;
    // Start is called before the first frame update
    void Start()
    {
        shipScript = GameObject.Find("Ship").GetComponent<SpaceshipController>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowShip();
    }

    void FollowShip()
    {
        Vector3 shipPos = shipScript.transform.position;

        shipPos.x = posCamX;
        shipPos.y = Mathf.Clamp(shipPos.y, limitCamY, 0);
        shipPos.z = posCamZ;   
        
        transform.position = shipPos;
    }
}
