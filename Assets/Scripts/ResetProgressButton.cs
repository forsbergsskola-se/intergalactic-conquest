using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Debugging class. Resets the content of PlayerPrefs 
/// </summary>
public class ResetProgressButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
