using UnityEngine;
using TMPro;
public class PlayerInteractionController : MonoBehaviour
{
    protected bool isPlayerInRange = false;
    protected float rayCastDist;
    [SerializeField]protected LayerMask interactableLayer;
    protected string tagOfObject;
    protected GameObject objectInHand;
    protected bool hasKeyCard1 = false;
    protected bool hasKeyCard2;
    //store the reference of the interactable item


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CheckIfInRange();
    }

    //detect if the player is close to an interactable item
    protected void CheckIfInRange()
    {
        
        //create a ray
        Ray myRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        RaycastHit hit;
        if (Physics.Raycast(myRay, out hit, rayCastDist, interactableLayer))
        {
            
            //detect if the ray had hit smth
            //check if the ray hit the specified tag
            if (hit.transform.gameObject.tag == tagOfObject)
            {
                

                if (Input.GetKeyDown(KeyCode.E))
                {
                    isPlayerInRange = true;
                    objectInHand = hit.transform.gameObject;
                    Debug.Log("Player interacted with this");

                }
            }



        }
       
    }

    
}
