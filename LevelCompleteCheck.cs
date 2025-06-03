using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelCompleteCheck : MonoBehaviour
{
    [SerializeField] private GameObject _bar1;
    [SerializeField] private GameObject _bar2;
    [SerializeField] private GameObject _bar3;
    [SerializeField] private GameObject _safeStuff;
    [SerializeField] private TextMeshProUGUI _levelCompleteText;
    
    // Start is called before the first frame update
    void Start()
    {
        _safeStuff.SetActive(false);
        _levelCompleteText.enabled = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!_bar1.activeSelf)
        {
            if (!_bar2.activeSelf)
            {
                _safeStuff.SetActive(true);
                if (!_bar3.activeSelf)
                {
                    _levelCompleteText.enabled = true;
                   

                }
            }

        }
    }

    
}
