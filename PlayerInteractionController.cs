using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractionController : MonoBehaviour
{
    //is the player in range?
    protected bool isPlayerInRange = false;

    //store the reference of the interactable item
    
    protected float maxDistance = 5f;

    [SerializeField] protected LayerMask _interactableLayer;

    protected string _tagOfInteractableInPuzzle; //tag of the item the player is interacting with

    protected GameObject _objectInHand;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        
        
    }

    protected virtual void Update()
    {
        CheckIfPlayerInRange();
        
    }

    //detect whether the player is close to an interactable
    protected void CheckIfPlayerInRange()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray _myRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit _hit;

            if (Physics.Raycast(_myRay, out _hit, maxDistance, _interactableLayer))
            {
                //detect if the ray has hit something - tag based check
                //check if object hit has the specified tag

                if (_hit.transform.gameObject.tag == _tagOfInteractableInPuzzle)
                {
                    //player is in range
                    isPlayerInRange = true;

                    //store object in variable
                    _objectInHand = _hit.transform.gameObject;

                   
                }
            }
        }
    }
}
