using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject player;

    #region Singleton
    private static SkillManager instance;

    public static SkillManager Instance => instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }        
    }
    #endregion


}
