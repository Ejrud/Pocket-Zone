using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _exitBtn;

    private void Start()
    {
        _playBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
        
        _exitBtn.onClick.AddListener(() =>
        {
            Application.Quit();            
        });
    }
}
