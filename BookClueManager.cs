using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookClueManager : PlayerInteractionController
{
    [SerializeField] private TextMeshProUGUI _bookClueText;
    [SerializeField] private TextMeshProUGUI _bookClueReaction;
    // Start is called before the first frame update
    protected override void Start()
    {
        _bookClueText.enabled = false;
        _tagOfInteractableInPuzzle = "BookClue";
        _bookClueReaction.enabled = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        ActivateBookClue();
    }

    private void ActivateBookClue()
    {
        if(_objectInHand.gameObject.name == "BookPuzzleClue")
        {

            _bookClueText.enabled = true;
            StartCoroutine(BookClueCooldown());
            _bookClueReaction.enabled = true;
            StartCoroutine(BookReactionCooldown());
            
        }
    }

    IEnumerator BookClueCooldown()
    {
        yield return new WaitForSeconds(8);
        _bookClueText.text = "";
        
    }

    IEnumerator BookReactionCooldown()
    {
        yield return new WaitForSeconds(12);
        _bookClueReaction.text = "";
    }
    
}
