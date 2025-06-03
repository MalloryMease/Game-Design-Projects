using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SafePuzzleContoller : PlayerInteractionController
{
    //all the button game objects
    [SerializeField] private GameObject _button1;
    [SerializeField] private GameObject _button2;
    [SerializeField] private GameObject _button3;
    [SerializeField] private GameObject _button4;
    [SerializeField] private GameObject _button5;
    [SerializeField] private GameObject _button6;
    [SerializeField] private GameObject _button7;
    [SerializeField] private GameObject _button8;
    [SerializeField] private GameObject _button9;
    [SerializeField] private GameObject _button0;
    [SerializeField] private GameObject _buttonEnter;
    [SerializeField] private GameObject _buttonClear;

    //the texts
    [SerializeField] private TextMeshProUGUI _bar3Text;
    [SerializeField] private TextMeshProUGUI _safeMemory;
    [SerializeField] private TMP_Text _codeDisplay;

    //the bar
    [SerializeField] private GameObject _bar3;

    //Safedoor
    [SerializeField] private GameObject _safeDoor;

    private bool one = true;
    private bool two = true;
    private bool three = true;
    private bool four = true;
    private bool five = true;
    private bool six = true;
    private bool seven = true;
    private bool eight = true;
    private bool nine = true;
    private bool zero = true;
    

    private string _code;//stores the player's code
    private string _answer = "2871"; //correct code is 2871

    // Start is called before the first frame update
    protected override void Start()
    {
        _tagOfInteractableInPuzzle = "KeypadButton";
        _bar3Text.enabled = false;
        _safeMemory.enabled = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (_objectInHand.gameObject.name == "Button1" && one)
        {
            one = false;
            _code = _code + "1";
            _codeDisplay.text = _code;

        }

        if (_objectInHand.gameObject.name == "Button2" && two)
        {
            two = false;
            _code = _code + "2";
            _codeDisplay.text = _code;
        }

        if (_objectInHand.gameObject.name == "Button3" && three)
        {
            three = false;
            _code = _code + "3";
            _codeDisplay.text = _code;
        }

        if (_objectInHand.gameObject.name == "Button4" && four)
        {
            four = false;
            _code = _code + "4";
            _codeDisplay.text = _code;
        }

        if (_objectInHand.gameObject.name == "Button5" && five)
        {
            five = false;
            _code = _code + "5";
            _codeDisplay.text = _code;
        }

        if (_objectInHand.gameObject.name == "Button6" && six)
        {
            six = false;
            _code = _code + "6";
            _codeDisplay.text = _code;
        }

        if (_objectInHand.gameObject.name == "Button7" && seven)
        {
            seven = false;
            _code = _code + "7";
            _codeDisplay.text = _code;
        }

        if (_objectInHand.gameObject.name == "Button8" && eight)
        {
            eight = false;
            _code = _code + "8";
            _codeDisplay.text = _code;
        }

        if (_objectInHand.gameObject.name == "Button9" && nine)
        {
            nine = false;
            _code += "9";
            _codeDisplay.text = _code;
        }

        if (_objectInHand.gameObject.name == "Button0" && zero)
        {
            zero = false;
            _code += "0";
            _codeDisplay.text = _code;
        }

        if (_objectInHand.gameObject.name == "ButtonEnter")
        {

            SafeCodeCheck();
        }

        if (_objectInHand.gameObject.name == "ButtonClear")
        {
            _code = "";
            _codeDisplay.text = _code;
        }
        if(_code.Length > 4)
        {
            _code = "";
            _codeDisplay.text = _code;
        }

        Debug.Log("Button pressed: " + _objectInHand+ " Code: " + _code);
    }

    private void SafeCodeCheck()
    {
        if(_code == _answer)
        {
            _bar3.SetActive(false);
            _safeDoor.SetActive(false);
            _bar3Text.enabled = true;
            _safeMemory.enabled = true;
            StartCoroutine(SafeTextCooldown());
        }
        else
        {
            _code = "";
            _codeDisplay.text = _code;
            one = true;
            two = true;
            three = true;
            four = true;
            five = true;
            six = true;
            seven = true;
            eight = true;
            nine = true;
            zero = true;
            
        }
    }

    IEnumerator SafeTextCooldown()
    {
        yield return new WaitForSeconds(5);
        _bar3Text.text = "";
        _safeMemory.text = "";
    }
}
