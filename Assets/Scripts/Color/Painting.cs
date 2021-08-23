/*
 * 
 *  Class with painting operations.
 * 
 */

using UnityEngine;

public class Painting : MonoBehaviour
{
    [SerializeField] private Sprite spriteColored;
    [SerializeField] private SpriteRenderer srUncolored;

    [HideInInspector] public bool canPaint;

    ChangeScene csChangeScene;

    private void Start()
    {
        CheckScene();
    }
    private void Update()
    {
        if (ColorGameManager.Instance.isAllSpawned)
        {
            // If all colors are spawned set canPaint to true

            SetPaint(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(gameObject.tag) && canPaint)
        {
            srUncolored.sprite = spriteColored;
            Destroy(other.gameObject);

            ColorGameManager.Instance.coloredCount++;
            ColorGameManager.Instance.CheckFinish();
        }
    }

    private void SetPaint(bool status)
    {
        canPaint = status;
    }

    private void CheckScene()
    {
        // If this is not level 2 set canPaint to true

        csChangeScene = GameObject.Find("Scene Manager").GetComponent<ChangeScene>();

        if (csChangeScene.activeSceneIndex == 4)
        {
            SetPaint(true);
        }
    }
}
