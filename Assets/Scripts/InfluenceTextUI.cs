using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class InfluenceTextUI : MonoBehaviour
{
    private Text influenceText;
    [SerializeField] private Influence influence;
    private void Start()
    {
        this.influenceText = GetComponent<Text>();
        if (this.influence == null)
        {
            Debug.LogWarning("Influence obj missing. Please provide influence reference", this);
        }
    }

    void Update()
    {
        this.influenceText.text = Mathf.RoundToInt(this.influence.CurrentInfluence).ToString();
    }
}
