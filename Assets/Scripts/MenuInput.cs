using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuInput : MonoBehaviour
{
    [SerializeField] Button[] allButtons;
    [SerializeField] Button backButtonCredits;
    [SerializeField] int index = 0;

    private bool isInCredits = false;

    private void OnSelection(InputValue value)
    {
        if (isInCredits)
        {
            backButtonCredits.Select();
            isInCredits = false;
        }
        else
        {
            if (value.Get<float>() < 0)
            {
                if (index > 0)
                {

                    UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
                    index--;
                    allButtons[index].Select();
                }
            }
            else if (index + value.Get<float>() < allButtons.Length)
            {
                index++;
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
                allButtons[index].Select();
            }
        }
    }

    public void ChangeToCredits()
    {
        isInCredits = true;
    }
}
