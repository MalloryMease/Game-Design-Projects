using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.Playables;
using TMPro;

public class LorePageScript : MonoBehaviour
{
    public GameObject testObject;
    public GameObject TabWasPressed;
    public static GameObject currentObjectInHand;
    public static List<GameObject> Displayable;
    public static String pageName;
    public static bool isKeyPressed = false;
    public static int index = 0;
    public TextMeshProUGUI lorePageCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Displayable = new List<GameObject>();
        TabWasPressed.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        UpdateDisplayList();
        DisplayPages();
        if (Displayable.Count > 0)
        {
            if (lorePageCounter.text != Displayable.Count.ToString() + "/21")
            {
                lorePageCounter.text = Displayable.Count.ToString() + "/21";
            }
        }
    }

    public void DisplayPages()
    {
        if (Input.GetKeyDown(KeyCode.Tab))//check if the player presses it
        {
            TabWasPressed.gameObject.SetActive(true); //used for debugging
            isKeyPressed = true; //set the key being pressed to true
        }

        if (isKeyPressed) //while it is pressed
        {
            if (Displayable.Count > 0)//if the list is not empty
            {
                index = 0; //set the index to 0
                Displayable[0].gameObject.SetActive(true); //automatically open to the first page
                if (Input.GetKeyDown(KeyCode.RightArrow) && index < Displayable.Count)//press the right arrow to display the next page counting up
                {
                    Displayable[index].gameObject.SetActive(false);
                    index++;
                    Displayable[index].gameObject.SetActive(true);

                }
                if (Input.GetKeyDown(KeyCode.LeftArrow) && index > 0)//press the left arrow to display the next page counting down
                {
                    Displayable[index].gameObject.SetActive(false);
                    index--;
                    Displayable[index].gameObject.SetActive(true);
                }
            }
            else
            {
                Debug.Log("there are no pages found");//if the list is empty, show on debug
            }
            if (Input.GetKeyDown(KeyCode.Tab)) //if they press tab again
            {
                TabWasPressed.gameObject.SetActive(false);//debugging purposes
                if (Displayable.Count > 0) //if the list is not empty
                {
                    Displayable[index].SetActive(false);//deactivate the currently displayed page
                }
                isKeyPressed = false;//set the key being pressed to false
            }
        }

    }

    public void UpdateDisplayList()//adds the pages to the displayable list
    {
        if (currentObjectInHand != null)
        {
            pageName = currentObjectInHand.ToString();
            if (!Displayable.Contains(GameObject.Find(pageName + "RI")))
            {
                Displayable.Add(GameObject.Find(pageName + "RI"));
            }
        }
    }
}
