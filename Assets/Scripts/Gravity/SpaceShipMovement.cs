/*
 * 
 *  Class with all the movement operations related to spaceship.
 * 
 */

using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    SpaceShipInput csSpaceShipInput;
    GravityGameManager csGravityGameManager;

    private Rigidbody2D rbSpaceShip;

    private float speed = 5f;

    private void Start()
    {
        GetComponents();
    }
    public void MoveShip()
    {
        rbSpaceShip.AddForce(transform.up * speed * Time.deltaTime, ForceMode2D.Force);
    }

    public void RotateShip()
    {
        transform.Rotate(0, 0, -(csSpaceShipInput.accelarationValue * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Earth") || collision.gameObject.CompareTag("Moon"))
        {
            csGravityGameManager.Finish();
        }

        if (collision.gameObject.CompareTag("SpaceObstacle"))
        {
            csGravityGameManager.Boom();
        }
    }

    private void GetComponents()
    {
        rbSpaceShip = GetComponent<Rigidbody2D>();
        csSpaceShipInput = GetComponent<SpaceShipInput>();
        csGravityGameManager = GameObject.Find("Scene Manager").GetComponent<GravityGameManager>();
    }
}