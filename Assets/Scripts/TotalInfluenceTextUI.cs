using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TotalInfluenceTextUI : MonoBehaviour
{
    private Text influenceText;
    [SerializeField] private Influence influence;
    private void Awake()
    {
        this.influenceText = GetComponent<Text>();
        if (influence == null)
            Debug.LogWarning("influence obj not found", this);
    }

    void Update()
    {
        this.influenceText.text = Mathf.RoundToInt(influence.CurrentInfluence).ToString();
    }
}
