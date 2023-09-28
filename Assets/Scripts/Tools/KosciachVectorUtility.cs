using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KosciachVectorUtility
{
    //Move to position on choosen axis.
    public static void MoveToPosX(Transform transform, float posX)
    {
        Vector3 pos = transform.position;
        pos.x = posX;
        transform.position = pos;
    }
    public static void MoveToPosXLocal(Transform transform, float posX)
    {
        Vector3 pos = transform.localPosition;
        pos.x = posX;
        transform.localPosition = pos;
    }
    public static void MoveToPosY(Transform transform, float posY)
    {
        Vector3 pos = transform.position;
        pos.y = posY;
        transform.position = pos;
    }
    public static void MoveToPosYLocal(Transform transform, float posY)
    {
        Vector3 pos = transform.localPosition;
        pos.y = posY;
        transform.localPosition = pos;
    }
    public static void MoveToPosZ(Transform transform, float posZ)
    {
        Vector3 pos = transform.position;
        pos.z = posZ;
        transform.position = pos;
    }
    public static void MoveToPosZLocal(Transform transform, float posZ)
    {
        Vector3 pos = transform.localPosition;
        pos.z = posZ;
        transform.localPosition = pos;
    }
}
