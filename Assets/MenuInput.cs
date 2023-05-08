using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuInput : MonoBehaviour
{
    [SerializeField] Button[] allButtons;
    [SerializeField] int index = 0;

    private void OnSelection(InputValue value)
    {
        if(value.Get<float>() < 0)
        {
            if (index > 0)
            {
                
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
                index--;
                allButtons[index].Select();
            }
        }
        else if(index + value.Get<float>() < allButtons.Length)
        {
            Debug.LogWarning("Positive");
            index++;
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
            allButtons[index].Select();
        }
    }
}
