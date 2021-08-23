/*
 * 
 *  Class in which input operations are performed.
 * 
 */

using UnityEngine;

public class SpaceShipInput : MonoBehaviour
{
    [SerializeField] private GameObject goAnimations;

    [HideInInspector] public float accelarationValue;

    SpaceShipMovement csSpaceShipMovement;
    GravityGameManager csGravityGameManager;

    private void Start()
    {
        GetComponents();
    }

    private void Update()
    {
        SetAnimationPosition();
        SetAccelaration();
        CheckRotateMove();
    }

    private void SetAccelaration()
    {
        accelarationValue = Input.acceleration.normalized.x;
    }

    private void SetAnimationPosition()
    {
        goAnimations.transform.position = transform.position;
    }

    private void CheckRotateMove()
    {
        if (!csGravityGameManager.isRigidbodyFrozen && !csGravityGameManager.gameOver && Time.timeScale == 1)
        {
            csSpaceShipMovement.RotateShip();

            if (Input.GetMouseButton(0))
            {
                csSpaceShipMovement.MoveShip();
                csGravityGameManager.SetFiring(true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                csGravityGameManager.SetFiring(false);
            }
        }
    }

    private void GetComponents()
    {
        csSpaceShipMovement = GetComponent<SpaceShipMovement>();
        csGravityGameManager = GameObject.Find("Scene Manager").GetComponent<GravityGameManager>();
    }
}
