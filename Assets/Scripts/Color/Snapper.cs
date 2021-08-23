/*
 * 
 *  Class which controls snappers and do the animations
 * 
 */

using UnityEngine;
using System.Linq;
using DG.Tweening;

public class Snapper : MonoBehaviour
{
    private readonly string[] ballTags = { "Apple", "River", "Sun" };

    public bool isFilled;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<ColorController>().isDragging = false;

        if (ballTags.Contains(other.gameObject.tag))
        {
            if (!isFilled)
            {
                isFilled = true;

                // Color sphere goes to the snapper with animation
                other.transform.DOMove(gameObject.transform.position, 2f).SetEase(Ease.OutElastic).OnComplete(() =>
                {
                    ColorGameManager.Instance.currentColor += other.gameObject.name;
                    ColorGameManager.Instance.CheckSnappers();
                });
            }
            else
            {
                other.gameObject.transform.position = other.gameObject.GetComponent<ColorController>().originPosition;
            }
        }
    }
}
