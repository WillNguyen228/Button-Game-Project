using UnityEngine;
using System.Collections;

public class tremble : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     IEnumerator Tremble() {
           for ( int i = 0; i < 10; i++)
           {
               transform.localPosition += new Vector3(1f, 0, 0);
               yield return new WaitForSeconds(0.01f);
               transform.localPosition -= new Vector3(1f, 0, 0);
               yield return new WaitForSeconds(0.01f);
           }
     }

}
