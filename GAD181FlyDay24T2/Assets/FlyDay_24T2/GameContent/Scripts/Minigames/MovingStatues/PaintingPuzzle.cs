using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaintingPuzzle : MonoBehaviour
{
    [SerializeField] Transform rayOrigin;
    private RaycastHit hit;
    [SerializeField] Sprite[] puzzleImages;
    [SerializeField] SpriteRenderer paintingSprite;
    int currentPainting;
    Ray ray;

    private void Update()
    {
        Raycast();
    }
    void Raycast()
    {
        ray = new Ray(rayOrigin.position, rayOrigin.forward );
        if (Physics.Raycast(ray, out hit, 10))
        {
            if(hit.transform.tag == "Player" && Input.GetKeyDown(KeyCode.P))
            {
                paintingSprite.sprite = puzzleImages[currentPainting];
                currentPainting++;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray); 
    }


}
