using UnityEngine;

[CreateAssetMenu(fileName = "DrawPatternScriptableObject", menuName = "Scriptable Objects/DrawPatternScriptableObject")]
public class DrawPatternSODefinition : ScriptableObject
{
    public Vector2Int[] gridPositions;
}
