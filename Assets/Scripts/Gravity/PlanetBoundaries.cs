/*
 * 
 *  Class where limits and boundaries are checked for Gravity Game.
 * 
 */
using UnityEngine;

public class PlanetBoundaries : MonoBehaviour
{
    [SerializeField] private float speedLimit;
    [SerializeField] private float bottomVertBoundary;

    Rigidbody2D rbSpaceShip;
    Transform tfSpaceShip;    

    private const float leftAngleBoudary = 45f;
    private const float midAngleBoundary = 0f;
    private const float rightAngleBoundary = 315f;
    private const float angleOutOfBoundary = 270f;

    private float topVertBoundary = 9f;
    private float horiBoundary = 4.75f;

    private void Start()
    {
        GetComponents();
    }

    private void Update()
    {
        SpeedTrap();
        LimitRotate();
        CheckBoundaries();
    }

    private void LimitRotate()
    {
        if (tfSpaceShip.localEulerAngles.z > leftAngleBoudary)
        {
            if (tfSpaceShip.localEulerAngles.z < angleOutOfBoundary)
            {
                tfSpaceShip.localEulerAngles = new Vector3(midAngleBoundary, midAngleBoundary, leftAngleBoudary);
            }

            if (tfSpaceShip.localEulerAngles.z > angleOutOfBoundary)
            {
                if (tfSpaceShip.localEulerAngles.z <= rightAngleBoundary)
                {
                    tfSpaceShip.localEulerAngles = new Vector3(midAngleBoundary, midAngleBoundary, rightAngleBoundary);
                }
            }
        }
    }

    private void SpeedTrap()
    {
        if (rbSpaceShip.velocity.y > speedLimit)
        {
            rbSpaceShip.velocity = new Vector2(rbSpaceShip.velocity.x, speedLimit);
        }
    }

    private void CheckBoundaries()
    {
        float posX = tfSpaceShip.position.x;
        float posY = tfSpaceShip.position.y;

        posX = Mathf.Clamp(posX, -horiBoundary, horiBoundary);
        posY = Mathf.Clamp(posY, bottomVertBoundary, topVertBoundary);

        tfSpaceShip.position = new Vector3(posX, posY, tfSpaceShip.position.z);
    }

    private void GetComponents()
    {
        rbSpaceShip = GameObject.Find("SpaceShip").GetComponent<Rigidbody2D>();
        tfSpaceShip = GameObject.Find("SpaceShip").GetComponent<Transform>();
    }
}