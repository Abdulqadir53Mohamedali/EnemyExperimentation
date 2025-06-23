using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/Enemy/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float maxHealth;
    public float damage;
    public float minHealth;
}
