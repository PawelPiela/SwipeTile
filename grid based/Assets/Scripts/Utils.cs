using UnityEngine;
using System.Collections;
public class Utils : MonoBehaviour
{
    public static Vector3 ScreenToWorld(Camera camera, Vector3 position){
        position.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(position);
    }

    // public static void WaitForSeconds() {
    //    StartCoroutine(WaitTime());
    // }
    IEnumerator WaitTime1Second() 
    {
        yield return new WaitForSeconds(1F);
    }
}
