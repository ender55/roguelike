
using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private PlayerInput input; 
        
    private void Start()
    {
        input = GameLinks.GetLink<Player>().PlayerInput;
    }

    void Update()
    {
        if (Input.GetKeyDown(input.exitGame))
        {
            Debug.Log("exit");
            Application.Quit();
        }
    }
}
