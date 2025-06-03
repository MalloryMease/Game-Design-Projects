using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectablesPuzzleController : PlayerInteractionController
{
    [SerializeField] private GameObject _bar2;
    [SerializeField] private GameObject _silverPosition;
    [SerializeField] private GameObject _bronzePosition;
    [SerializeField] private GameObject _goldPosition;
    [SerializeField] private TextMeshProUGUI _bar2Text;
    [SerializeField] private TextMeshProUGUI _trophyHint;
    [SerializeField] private TextMeshProUGUI _trophyMemory;

    private bool _sCollcected = false;
    private bool _bCollected = false;
    private bool _gCollected = false;

    

    
    // Start is called before the first frame update
    protected override void Start()
    {
        _tagOfInteractableInPuzzle = "Trophy";
        _bar2Text.enabled = false;
        _trophyHint.enabled = false;
        _trophyMemory.enabled = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (_objectInHand.gameObject.name == "SilverTrophy")
        {
            _objectInHand.transform.position = _silverPosition.transform.position;
            _objectInHand.transform.rotation = _silverPosition.transform.rotation;
            _sCollcected = true;
            CollectTrophies();
        }

        if (_objectInHand.gameObject.name == "BronzeTrophy")
        {
            _objectInHand.transform.position = _bronzePosition.transform.position;
            _objectInHand.transform.rotation = _bronzePosition.transform.rotation;
            _bCollected = true;
            CollectTrophies();
        }

        if (_objectInHand.gameObject.name == "GoldTrophy")
        {
            _objectInHand.transform.position = _goldPosition.transform.position;
            _objectInHand.transform.rotation = _goldPosition.transform.rotation;
            _gCollected = true;
            CollectTrophies();
        }
        if(_bCollected ^ _sCollcected ^ _gCollected)
        {
            _trophyHint.enabled = true;
            StartCoroutine(TrophyHintCooldown());
        }
        

    }

    protected void CollectTrophies()
    {
        
        if(_sCollcected && _bCollected && _gCollected)
        {
            _bar2.SetActive(false);
            _bar2Text.enabled = true;
            _trophyMemory.enabled = true;
            
            StartCoroutine(Bar2Cooldown());
            
        }
    }

    IEnumerator Bar2Cooldown()
    {
        
        yield return new WaitForSeconds(5);
        _bar2Text.text = "";
        _trophyMemory.text = "";
       
    }
    IEnumerator TrophyHintCooldown()
    {
        yield return new WaitForSeconds(8);
        _trophyHint.text = "";
    }
}
