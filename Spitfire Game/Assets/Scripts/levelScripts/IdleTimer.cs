using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleTimer : MonoBehaviour
{
    public float idleTimeLimit = 20f;
    private float idleTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            idleTime = 0f;
        }
        else
        {
            idleTime += Time.deltaTime;
        }

        if (idleTime >= idleTimeLimit)
        {
            LoadStartMenu();
        }
    }

    private void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
