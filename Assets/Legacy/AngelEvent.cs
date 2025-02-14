using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelEvent : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log(1);
            LevelUpManager.Instance.GenSkill();
        }
    }
}
