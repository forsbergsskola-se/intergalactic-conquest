
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

[RequireComponent(typeof(Image))]
public class ClickablePlanet : MonoBehaviour, IPointerClickHandler
{
    [Header("Planet")]
    public Planet PlanetData;

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
        PlanetManager.instance.CurrentPlanet = PlanetData;
        Debug.Log(PlanetManager.instance.CurrentPlanet);
        this.image.transform.localScale = sizeMultiplier;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    void OnValidate()
    {
        this.sizeMultiplier = Vector3.one * enlargeMultiplier;
    }
}
