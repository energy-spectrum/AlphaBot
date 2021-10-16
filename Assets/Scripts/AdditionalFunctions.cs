using UnityEngine;
class AdditionalFunctions
{
    static public bool EqualsVector3(Vector3 a, Vector3 b)
    {
        return a.x == b.x && a.y == b.y && a.z == b.z;
    }
}