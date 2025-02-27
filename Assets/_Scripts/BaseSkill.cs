using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill
{
    public string skillName;

    public BaseSkill(string name)
    {
        skillName = name;
    }

    // Phương thức trừu tượng để kích hoạt skill, cần được triển khai ở lớp con
    public abstract void Activate();
}
