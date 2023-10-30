using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInfo", menuName = "Scriptables/ Enemy Info")]
public class EnemyInfo : ScriptableObject
{
    public Color color;
    public int damage;
    public int velocity;
    public float deteccion;
    public MonoScript script;
}
