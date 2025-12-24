using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    public GameObject pause_menu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pause_menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            pause_menu.SetActive(!pause_menu.activeSelf);
            Time.timeScale = pause_menu.activeSelf ? 0f : 1f;
        }
    }
}
