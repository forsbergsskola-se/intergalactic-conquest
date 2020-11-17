using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetMenuUI : MonoBehaviour
{
    public GameObject StaffMenu;
    public GameObject UpgradeMenu;
    
    public void BackButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void StaffButtonClicked()
    {
        bool currentlyActive = StaffMenu.activeSelf;
        StaffMenu.SetActive(!currentlyActive);
    }
    
    public void UpgradesButtonClicked()
    {
        bool currentlyActive = UpgradeMenu.activeSelf;
        UpgradeMenu.SetActive(!currentlyActive);
    }
}
