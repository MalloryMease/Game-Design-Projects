using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookPuzzleController : PlayerInteractionController
{
    
    private int _counter = 0;
    [SerializeField] private GameObject _greenPosition;
    [SerializeField] private GameObject _bluePosition;
    [SerializeField] private GameObject _redPosition;
    [SerializeField] private TextMeshProUGUI _bar1Completed;
    [SerializeField] private GameObject _bar1;
    [SerializeField] private TextMeshProUGUI _bookMemoryText;
    private bool _puzzleFinished = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        _tagOfInteractableInPuzzle = "Books";
        _bar1Completed.enabled = false;
        _bookMemoryText.enabled = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (_counter == 0 && _objectInHand.gameObject.name == "PuzzleBookGreen")
        {
            
            _objectInHand.transform.position = _greenPosition.transform.position;
            _objectInHand.transform.rotation = _greenPosition.transform.rotation;
            _counter += 1;
        }
        
        if (_counter == 1 && _objectInHand.gameObject.name == "PuzzleBookBlue")
        {
            _counter += 1;
            _objectInHand.transform.position = _bluePosition.transform.position;
            _objectInHand.transform.rotation = _bluePosition.transform.rotation;
        }
        
        if (_counter == 2 && _objectInHand.gameObject.name == "PuzzleBookRed")
        {
            _counter += 1;
            BookPuzzleOrderCheck();
            _objectInHand.transform.position = _redPosition.transform.position;
            _objectInHand.transform.rotation = _redPosition.transform.rotation;
        }

        


        Debug.Log("Player interacted with " + _objectInHand + " Count: " + _counter);
    }

    protected void BookPuzzleOrderCheck()
    {

        if (_counter == 3)
        {
            _bar1.SetActive(false);
            _bar1Completed.enabled = true;
            
            _bookMemoryText.enabled = true;
            StartCoroutine(Bar1TextOnUICooldown());

        }
         

    }

    IEnumerator Bar1TextOnUICooldown()
    {
        yield return new WaitForSeconds(8);
        _bar1Completed.enabled = false;
        _bookMemoryText.enabled = false;
        
    }
}
