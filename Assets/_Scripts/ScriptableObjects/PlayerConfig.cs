using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public float maxSpeed;     // Tốc độ tối đa
    public float acceleration;// Độ lớn gia tốc khi nhấn phím
    public float friction; // Độ lớn ma sát khi không nhấn phím
    public float maxHealth; // Máu tối đa
}
