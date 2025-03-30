using UnityEngine;
using UnityEngine.TerrainTools;

public class DepletesHealth : MonoBehaviour {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    RectTransform rt;
    void Start() {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    public void ReduceHealth(int intensity) {
        Vector3 new_result = rt.localScale = new Vector3(rt.localScale.x - 0.1f*intensity, rt.localScale.y, rt.localScale.z);
        if (new_result.x < 0) {
            rt.localScale = rt.localScale = new Vector3(0, rt.localScale.y, rt.localScale.z);

        }
    }
}
