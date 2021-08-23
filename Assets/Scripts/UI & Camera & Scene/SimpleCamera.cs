/*
 * 
 *  Camera class to follow player for Gravity Game.
 * 
 */

using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    [SerializeField] private float cameraLimitY;

    SpaceShipInput csSpaceShipInput;    

    void Start()
    {
        GetComponents();
    }

    void Update()
    {
        FollowShip();
    }

    private void FollowShip()
    {
        Vector3 spaceShipPosition = csSpaceShipInput.transform.position;

        spaceShipPosition.x = transform.position.x;
        spaceShipPosition.y = Mathf.Clamp(spaceShipPosition.y, cameraLimitY, 0);
        spaceShipPosition.z = transform.position.z;

        transform.position = spaceShipPosition;
    }
    
    private void GetComponents()
    {
        csSpaceShipInput = GameObject.Find("SpaceShip").GetComponent<SpaceShipInput>();
    }
}
