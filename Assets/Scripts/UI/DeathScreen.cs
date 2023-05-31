using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject _deathScreen;
    public void OpenWindow(bool active)
    {
        _deathScreen.SetActive(active);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
