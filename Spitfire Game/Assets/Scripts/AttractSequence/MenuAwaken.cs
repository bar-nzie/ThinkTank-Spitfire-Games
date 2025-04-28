using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuAwaken : MonoBehaviour
{
    [SerializeField] MenuSubcription MenuControls;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MenuControls.ActionButton)
        {
            LoadGameScene();
        }

    }
    private void LoadGameScene()
    {
        SceneManager.LoadScene("LevelGeneration");

    }
}
