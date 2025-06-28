// Respawning character class


using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Character : MonoBehaviour
{
    public delegate void CharacterEvent();
    public static CharacterEvent characterDeactivated;
    public static CharacterEvent characterReachedGoal;

    Rigidbody2D rb;
    SpriteRenderer sr;

    public static WaitForSeconds respawnTime = new WaitForSeconds(4f);
    public static WaitForSeconds freezeTime = new WaitForSeconds(0.25f);
    Coroutine moveRoutine = null;

    
    float speed = 5f, jumpForce = 12f;
    public Vector3 startingPostion = new Vector3(-8.75f, 0.5f, 0f);
    float fallMultiplier = 2.5f, lowJumpMultiplier = 2f;

    #region Unity Methods
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        transform.position = startingPostion;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        moveRoutine = StartCoroutine(Move());
    }

    private void OnDisable() {
        StopCoroutine(moveRoutine);
        if (characterDeactivated != null) characterDeactivated();
    }

    public void Update() {
        if (rb.velocity.y < 0) 
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (rb.velocity.y > 0) 
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.gameObject.layer) {
            case (6): Goal(); break;
            case (7): Jump(); break;
            case (8): Boost(); break;
        }
    }
    #endregion


    #region Actions
    private IEnumerator Move() {
        yield return freezeTime;

        // Start motion
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.velocity = Vector2.right * speed;

        yield return respawnTime;

        // Stop motion
        rb.velocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return freezeTime;

        gameObject.SetActive(false);
    }

    private void Goal() {
        Debug.Log("Reached the goal!!");
        StopCoroutine(moveRoutine);
        rb.drag = 2f;

        
        if (characterReachedGoal != null) characterReachedGoal();
    }

    private void Jump() {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Boost() {
        rb.AddForce(Vector3.right * jumpForce, ForceMode2D.Impulse);
    }
    #endregion
}
