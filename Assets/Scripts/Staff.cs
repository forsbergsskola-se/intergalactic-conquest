using UnityEngine;

[CreateAssetMenu(fileName = "Staff", menuName = "ScriptableObjects/Staff", order = 3)]
public class Staff : ScriptableObject
{
    [Header("Staff Information")]
    public string Name;

    [Space]
    public string Title;

    [Space]
    public Planet HomeWorld;

    [Header("Strategy Specialization")]
    public Strategy Strategy;

    [Space]
    public SubStrategy SubStrategy;

    [Header("Influence Settings")]
    public int InfluencePerincrement;
}
