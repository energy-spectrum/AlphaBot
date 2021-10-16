using UnityEngine;

public class Erase : MonoBehaviour
{
    static public bool isActive = false;

    public void Activate()
    {
        TurnOffAllTools.Off();
        isActive = true;
    }

    static public void Off()
    {
        isActive = false;
    }
}
