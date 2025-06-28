// Respawns objects when they're moved


using System.Collections;
using UnityEngine;

public class Sandbox : MonoBehaviour
{
    [SerializeField] GameObject[] objectPrefabs;

    private void OnEnable() {
        StartCoroutine(SpawnObjects());
    }


    IEnumerator SpawnObjects() {
        Vector3 screenCorner = Camera.main.ScreenToWorldPoint(Vector3.zero) + Vector3.one;
        Vector3 objPos = new Vector3(screenCorner.x, screenCorner.y, 0);

        foreach (GameObject obj in objectPrefabs) {
            Instantiate(obj, objPos, Quaternion.identity, transform);
            objPos += new Vector3(2, 0, 0);
            yield return null;
        }
    }

    public void Respawn(GameObject obj, Vector3 pos) {
        Instantiate(obj, pos, Quaternion.identity);
    }
}
