using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;
using Unity.VisualScripting;
using System;


public class PlayerLorePagePickup : PlayerInteractionController
{
    protected List<GameObject> lorePagesCollected;
    public List<TextMeshProUGUI> displayablePages;
    public TextMeshProUGUI lorePageCounterDisplay;
    public int lorePageCount = 0;
    public int lorePageModifier = 0;
    private int index1 = 0;
    //text objects
    [SerializeField] protected TextMeshProUGUI lorePage1_1text;
    [SerializeField] protected TextMeshProUGUI lorePage1_2text;
    [SerializeField] protected TextMeshProUGUI lorePage2_1text;
    [SerializeField] protected TextMeshProUGUI lorePage2_2text;
    [SerializeField] protected TextMeshProUGUI lorePage3_1text;
    [SerializeField] protected TextMeshProUGUI lorePage3_2text;
    [SerializeField] protected TextMeshProUGUI lorePage4_1text;
    [SerializeField] protected TextMeshProUGUI lorePage4_2text;
    [SerializeField] protected TextMeshProUGUI lorePage5_1text;
    [SerializeField] protected TextMeshProUGUI lorePage5_2text;
    [SerializeField] protected TextMeshProUGUI lorePage6_1text;
    [SerializeField] protected TextMeshProUGUI lorePage6_2text;
    [SerializeField] protected TextMeshProUGUI lorePage7_1text;
    [SerializeField] protected TextMeshProUGUI lorePage7_2text;
    [SerializeField] protected TextMeshProUGUI lorePage8_1text;
    [SerializeField] protected TextMeshProUGUI lorePage8_2text;
    [SerializeField] protected TextMeshProUGUI lorePage9_1text;
    [SerializeField] protected TextMeshProUGUI lorePage9_2text;
    [SerializeField] protected TextMeshProUGUI lorePage10_1text;
    [SerializeField] protected TextMeshProUGUI lorePage10_2text;
    [SerializeField] protected TextMeshProUGUI lorePage11_1text;
    [SerializeField] protected TextMeshProUGUI lorePage11_2text;
    [SerializeField] protected TextMeshProUGUI lorePage12_1text;
    [SerializeField] protected TextMeshProUGUI lorePage12_2text;
    [SerializeField] protected TextMeshProUGUI lorePage13_1text;
    [SerializeField] protected TextMeshProUGUI lorePage13_2text;
    [SerializeField] protected TextMeshProUGUI lorePage14_1text;
    [SerializeField] protected TextMeshProUGUI lorePage15_1text;
    [SerializeField] protected TextMeshProUGUI lorePage15_2text;
    [SerializeField] protected TextMeshProUGUI lorePage16_1text;
    [SerializeField] protected TextMeshProUGUI lorePage16_2text;
    [SerializeField] protected TextMeshProUGUI lorePage17_1text;
    [SerializeField] protected TextMeshProUGUI lorePage17_2text;
    [SerializeField] protected TextMeshProUGUI lorePage18_1text;
    [SerializeField] protected TextMeshProUGUI lorePage18_2text;
    [SerializeField] protected TextMeshProUGUI lorePage19_1text;
    [SerializeField] protected TextMeshProUGUI lorePage19_2text;
    [SerializeField] protected TextMeshProUGUI lorePage20_1text;
    [SerializeField] protected TextMeshProUGUI lorePage20_2text;
    [SerializeField] protected TextMeshProUGUI lorePage21_1text;
    [SerializeField] protected TextMeshProUGUI lorePage21_2text;
    [SerializeField] protected TextMeshProUGUI navInstructions;
    [SerializeField] protected TextMeshProUGUI noPages;

    //game objects
    [SerializeField] protected GameObject LorePage1;
    [SerializeField] protected GameObject LorePage2;
    [SerializeField] protected GameObject LorePage3;
    [SerializeField] protected GameObject LorePage4;
    [SerializeField] protected GameObject LorePage5;
    [SerializeField] protected GameObject LorePage6;
    [SerializeField] protected GameObject LorePage7;
    [SerializeField] protected GameObject LorePage8;
    [SerializeField] protected GameObject LorePage9;
    [SerializeField] protected GameObject LorePage10;
    [SerializeField] protected GameObject LorePage11;
    [SerializeField] protected GameObject LorePage12;
    [SerializeField] protected GameObject LorePage13;
    [SerializeField] protected GameObject LorePage14;
    [SerializeField] protected GameObject LorePage15;
    [SerializeField] protected GameObject LorePage16;
    [SerializeField] protected GameObject LorePage17;
    [SerializeField] protected GameObject LorePage18;
    [SerializeField] protected GameObject LorePage19;
    [SerializeField] protected GameObject LorePage20;
    [SerializeField] protected GameObject LorePage21;
    [SerializeField] protected GameObject lpBG;
    [SerializeField] protected GameObject instructionsBG;


    int index = 0;
    protected bool inTab = false;
    protected bool firstTab = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        

        displayablePages = new List<TextMeshProUGUI>();
        lorePagesCollected = new List<GameObject>();
        lorePageCounterDisplay.text = string.Format("{0}/21", displayablePages.Count); ;
        lorePagesCollected = new List<GameObject>();
        rayCastDist = 5;
        tagOfObject = "lorePage";
        if (ES3.KeyExists("savedPageIDs"))
        {
            List<string> savedIDs = ES3.Load<List<string>>("savedPageIDs");

            foreach (string id in savedIDs)
            {
                TextMeshProUGUI foundText = FindTextByName(id);
                if (foundText != null && !displayablePages.Contains(foundText))
                {
                    displayablePages.Add(foundText);
                }
            }

            lorePageCount = displayablePages.Count / 2;
            lorePageCounterDisplay.text = (lorePageCount + lorePageModifier) + "/21";
        }


    }

    private TextMeshProUGUI FindTextByName(string id)
    {
        TextMeshProUGUI[] allTexts = {
        lorePage1_1text, lorePage1_2text,
        lorePage2_1text, lorePage2_2text,
        lorePage3_1text, lorePage3_2text,
        lorePage4_1text, lorePage4_2text,
        lorePage5_1text, lorePage5_2text,
        lorePage6_1text, lorePage6_2text,
        lorePage7_1text, lorePage7_2text,
        lorePage8_1text, lorePage8_2text,
        lorePage9_1text, lorePage9_2text,
        lorePage10_1text, lorePage10_2text,
        lorePage11_1text, lorePage11_2text,
        lorePage12_1text, lorePage12_2text,
        lorePage13_1text, lorePage13_2text,
        lorePage14_1text,
        lorePage15_1text, lorePage15_2text,
        lorePage16_1text, lorePage16_2text,
        lorePage17_1text, lorePage17_2text,
        lorePage18_1text, lorePage18_2text,
        lorePage19_1text, lorePage19_2text,
        lorePage20_1text, lorePage20_2text,
        lorePage21_1text, lorePage21_2text
    };

        foreach (TextMeshProUGUI text in allTexts)
        {
            if (text != null && text.gameObject.name == id)
                return text;
        }

        return null;
    }

    // Update is called once per frame
    protected override void Update()
    {
        index1++;
        CheckIfInRange();
        if (objectInHand != null)
        {
            addPageToList();
        }
        displayPages(displayablePages);
    }

    protected void addPageToList()
    {
        if (!lorePagesCollected.Contains(objectInHand))
        {
            lorePagesCollected.Add(objectInHand);
           if(objectInHand == LorePage1 && !displayablePages.Contains(lorePage1_1text))
            {
                displayablePages.Add(lorePage1_1text);
                displayablePages.Add(lorePage1_2text);
            }
            if (objectInHand == LorePage2 && !displayablePages.Contains(lorePage2_1text))
            {
                displayablePages.Add(lorePage2_1text);
                displayablePages.Add(lorePage2_2text);
            }
            if (objectInHand == LorePage3 && !displayablePages.Contains(lorePage3_1text))
            {
                displayablePages.Add(lorePage3_1text); 
                displayablePages.Add(lorePage3_2text);
            }
            if (objectInHand == LorePage4 && !displayablePages.Contains(lorePage4_1text))
            {
                displayablePages.Add(lorePage4_1text);
                displayablePages.Add(lorePage4_2text);
            }
            if (objectInHand == LorePage5 && !displayablePages.Contains(lorePage5_1text))
            {
                displayablePages.Add(lorePage5_1text); 
                displayablePages.Add(lorePage5_2text);
            }
            if (objectInHand == LorePage6 && !displayablePages.Contains(lorePage6_1text))
            {
                displayablePages.Add(lorePage6_1text);
                displayablePages.Add(lorePage6_2text);
            }
            if (objectInHand == LorePage7 && !displayablePages.Contains(lorePage7_1text))
            {
                displayablePages.Add(lorePage7_1text);
                displayablePages.Add(lorePage7_2text);
            }
            if (objectInHand == LorePage8 && !displayablePages.Contains(lorePage8_1text))
            {
                displayablePages.Add(lorePage8_1text);
                displayablePages.Add(lorePage8_2text);
            }
            if (objectInHand == LorePage9 && !displayablePages.Contains(lorePage9_1text))
            {
                displayablePages.Add(lorePage9_1text);
                displayablePages.Add(lorePage9_2text);
            }
            if (objectInHand == LorePage10 && !displayablePages.Contains(lorePage10_1text))
            {
                displayablePages.Add(lorePage10_1text);
                displayablePages.Add(lorePage10_2text);
            }
            if (objectInHand == LorePage11 && !displayablePages.Contains(lorePage11_1text))
            {
                displayablePages.Add(lorePage11_1text);
                displayablePages.Add(lorePage11_2text);
            }
            if (objectInHand == LorePage12 && !displayablePages.Contains(lorePage12_1text))
            {
                displayablePages.Add(lorePage12_1text);
                displayablePages.Add(lorePage12_2text);
            }
            if (objectInHand == LorePage13 && !displayablePages.Contains(lorePage13_1text))
            {
                displayablePages.Add(lorePage13_1text);
                displayablePages.Add(lorePage13_2text);
            }
            if (objectInHand == LorePage14 && !displayablePages.Contains(lorePage14_1text))
            {
                displayablePages.Add(lorePage14_1text);
            }
            if (objectInHand == LorePage15 && !displayablePages.Contains(lorePage15_1text))
            {
                displayablePages.Add(lorePage15_1text);
                displayablePages.Add(lorePage15_2text);
            }
            if (objectInHand == LorePage16 && !displayablePages.Contains(lorePage16_1text))
            {
                displayablePages.Add(lorePage16_1text);
                displayablePages.Add(lorePage16_2text);
            }
            if (objectInHand == LorePage17 && !displayablePages.Contains(lorePage17_1text))
            {
                displayablePages.Add(lorePage17_1text);
                displayablePages.Add(lorePage17_2text);
            }
            if (objectInHand == LorePage18 && !displayablePages.Contains(lorePage18_1text))
            {
                displayablePages.Add(lorePage18_1text);
                displayablePages.Add(lorePage18_2text);
            }
            if (objectInHand == LorePage19 && !displayablePages.Contains(lorePage19_1text))
            {
                displayablePages.Add(lorePage19_1text);
                displayablePages.Add(lorePage19_2text);
            }
            if (objectInHand == LorePage20 && !displayablePages.Contains(lorePage20_1text))
            {
                displayablePages.Add(lorePage20_1text);
                displayablePages.Add(lorePage20_2text);
            }
            if (objectInHand == LorePage21 && !displayablePages.Contains(lorePage21_1text))
            {
                displayablePages.Add(lorePage21_1text);
                displayablePages.Add(lorePage21_2text);
            }
            lorePageCount++;
            lorePageCounterDisplay.text = ((lorePageCount + lorePageModifier) + "/21");
            objectInHand.gameObject.SetActive(false);
        }
    }

    protected void displayPages(List<TextMeshProUGUI> displayableList)
    {
        if (displayableList.Count != 0) {
            
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                navInstructions.gameObject.SetActive(true);
                inTab = true;
                Debug.Log("in tab: " + inTab);
                instructionsBG.gameObject.SetActive(true);
                lpBG.gameObject.SetActive(true);
                
            }
            if (inTab)
            {
                Debug.Log("in desplayable list");
                Debug.Log(displayableList[0].gameObject.name + displayableList[1].gameObject.name);
                if (firstTab) 
                { 
                    displayableList[0].gameObject.SetActive(true); 
                    firstTab = false;
                }
                
                if (Input.GetKeyDown(KeyCode.RightBracket) && index < displayableList.Count - 1 && index1 >=30)
                {
                    index1 = 0;
                    Debug.Log("in L if statement");
                    displayableList[index].gameObject.SetActive(false);
                    index++;
                    displayableList[index].gameObject.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.LeftBracket) && index >= 1 && index1 >= 30)
                {
                    index1 = 0;
                    Debug.Log("in K if statement");
                    displayableList[index].gameObject.SetActive(false);
                    index--;
                    displayableList[index].gameObject.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.Backspace))
                {
                    inTab = false;
                }
                
            }
            else
            {
                displayableList[index].gameObject.SetActive(false);
                index = 0;
                firstTab = true;
                navInstructions.gameObject.SetActive(false);
                instructionsBG.gameObject.SetActive(false);
                lpBG.gameObject.SetActive(false);
            }
            
            
       
            
        }
        
    }

    public void SavePages()
    {
        List<string> savedPageIDs = new List<string>();

        foreach (TextMeshProUGUI page in displayablePages)
        {
            savedPageIDs.Add(page.gameObject.name);
        }

        ES3.Save("savedPageIDs", savedPageIDs);
        Debug.Log("saved pages id: " + ES3.Load<List<string>>("savedPageIDs")[0]);
    }
}
