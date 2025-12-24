using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    private UIDocument document;
    private Button button;
    private List<Button> menu_buttons = new List<Button>();

    private void Awake()
    {
        document = GetComponent<UIDocument>();
        button = document.rootVisualElement.Q("ResumeButton") as Button;
        button.RegisterCallback<ClickEvent>(ResumeButtonClicked);

        menu_buttons = document.rootVisualElement.Query<Button>().ToList();
    }

    private void OnDisable()
    {
        button.UnregisterCallback<ClickEvent>(ResumeButtonClicked);
    }

    private void ResumeButtonClicked(ClickEvent clickevent)
    {
        Debug.Log("resume button clicked");
    }
}
