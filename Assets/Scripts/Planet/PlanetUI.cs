
using UnityEngine;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;

[RequireComponent(typeof(Image))]
public class PlanetUI : MonoBehaviour, IPointerClickHandler
{
    [Tooltip("multiplayer to enlarge planet image on click")] 
    public float enlargeMultiplier;

    private Vector3 sizeMultiplier = Vector3.one;
    private Image image;
    
    private void Start()
    {
        this.image = GetComponent<Image>();
        
        if (this.image == null)
        {
            Debug.Log("Warning, no image found", this);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ClickEvent();
        }
    }

    private void ClickEvent()
    {
        this.image.transform.localScale = sizeMultiplier;
        //TODO create popup or switch screen.
        
        // If changing scene
        // LoadScene(string sceneName, SceneManagement.LoadSceneMode mode = LoadSceneMode.Single);
        
        // If popup
        // Instantiate();
    }
    
    void OnValidate()
    {
        this.sizeMultiplier = Vector3.one * enlargeMultiplier;
    }
}
