using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CommandBar : UIBehaviour
{
    public List<GameObject> commandsForPicerPrefabs, commandsForDiactivaterPrefabs;
    public bool[] notActivateCommands;
     new void Start()
     {
        switch (Level.robot)
        {
            case AlphaBot_Bitcoin.RobotCore.Robots.Picer:
                for (int i = 0; i < commandsForPicerPrefabs.Count; i++)
                {
                    if (notActivateCommands[i])
                    {
                        commandsForPicerPrefabs[i].GetComponent<ButtonState>().isActivated = false;
                    }
                    Instantiate<GameObject>(commandsForPicerPrefabs[i], transform);
                    commandsForPicerPrefabs[i].GetComponent<ButtonState>().isActivated = true;
                }
                break;
            case AlphaBot_Bitcoin.RobotCore.Robots.Diactivater:
                for (int i = 0; i < commandsForDiactivaterPrefabs.Count; i++)
                {
                    if (notActivateCommands[i])
                    {
                        commandsForDiactivaterPrefabs[i].GetComponent<ButtonState>().isActivated = false;
                    }
                    Instantiate<GameObject>(commandsForDiactivaterPrefabs[i], transform);
                    commandsForDiactivaterPrefabs[i].GetComponent<ButtonState>().isActivated = true;
                }
                break;
            default:
                print("Not include");
                break;
        }
    }
}
