/*
 * 
 *  Class with movement operations of mirrors
 * 
 */

using UnityEngine;

public class MirrorMovement : MonoBehaviour
{
    [HideInInspector] public bool rotateLeft; 
    [HideInInspector] public bool rotateRight;

    Transform tfMirror;
    Mirror csActiveMirror;
    HoldTheDoor csHoldTheDoor;
    TelescopeGameManager csTelescopeGameManager;

    private float rotationSpeed = 0.1f; 
    private float mirrorRotationZ;

    private void Start()
    {
        GetScripts();
        
        mirrorRotationZ = csActiveMirror.startAngle; 
    }

    private void Update()
    {
        if (!csActiveMirror.isSoundPlaying) 
        {
            SetRotation();
        }
    }

    private void SetRotation()
    {
        if (rotateLeft)
        {
            mirrorRotationZ += rotationSpeed;
            GetMathf();
        }

        if (rotateRight)
        {
            mirrorRotationZ -= rotationSpeed;
            GetMathf();
        }
    }

    private void GetMathf()
    {
        mirrorRotationZ = Mathf.Round(mirrorRotationZ * 10f) / 10f;
        mirrorRotationZ = Mathf.Clamp(mirrorRotationZ, csActiveMirror.clampMin, csActiveMirror.clampMax);

        RotateMirror();
    }

    private void RotateMirror()
    {
        tfMirror.localEulerAngles = new Vector3(0, 0, mirrorRotationZ);

        CheckAngle();
    }

    private void CheckAngle()
    {
        if (mirrorRotationZ == csActiveMirror.correctAngle)
        {
            if (!csHoldTheDoor.muteMusic)
            {
                csTelescopeGameManager.PlaySound(2);
            }
            
            rotateLeft = false;
            rotateRight = false;
            csActiveMirror.canNextRotate = true;

            csTelescopeGameManager.SetColors(); 
            csTelescopeGameManager.ChangeActiveMirror(csActiveMirror.nextMirror);

            GetScripts(); 
        }
    }

    private void GetScripts()
    {
        csTelescopeGameManager = GameObject.Find("Scene Manager").GetComponent<TelescopeGameManager>();
        csHoldTheDoor = GameObject.Find("Door").GetComponent<HoldTheDoor>();
        csActiveMirror = GameObject.Find(csTelescopeGameManager.activeMirror).GetComponent<Mirror>();
        tfMirror = GameObject.Find(csTelescopeGameManager.activeMirror).GetComponent<Transform>();
        mirrorRotationZ = csActiveMirror.startAngle;
    }
}
