// Respawns objects when they're moved


using System.Collections;
using UnityEngine;
using TMPro;

public class Sandbox : MonoBehaviour
{
    [SerializeField] GameObject[] objectPrefabs;
    [SerializeField] TMP_Text respawnTracker;

    private void OnEnable() {
        StartCoroutine(SpawnObjects());
    }

    private void OnDisable() {
        Character.respawnTime = new WaitForSeconds(4f);
    }


    IEnumerator SpawnObjects() {
        Vector3 screenCorner = Camera.main.ScreenToWorldPoint(Vector3.zero) + Vector3.one;
        Vector3 objPos = new Vector3(screenCorner.x, screenCorner.y, 0);

        foreach (GameObject obj in objectPrefabs) {
            Instantiate(obj, objPos, Quaternion.identity, transform);
            objPos += new Vector3(1.5f, 0, 0);
            yield return null;
        }
    }

    public void Respawn(GameObject obj, Vector3 pos) {
        Instantiate(obj, pos, Quaternion.identity);
    }

    public void UpdateRespawnTime(float time) {
        respawnTracker.text = "Respawn time: " + time.ToString("0.0") + "s";
        Character.respawnTime = new WaitForSeconds(time);
    }
}
