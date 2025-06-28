// Game Manager

using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Character character;
    [SerializeField] ParticleSystem confetti;

    private void OnEnable() {
        Character.characterDeactivated += CharacterDeactivated;
        Character.characterReachedGoal += CharacterReachedGoal;
    }

    private void OnDisable() {
        Character.characterDeactivated -= CharacterDeactivated;
        Character.characterReachedGoal -= CharacterReachedGoal;
    }

    private void CharacterDeactivated() {
        StartCoroutine(ReactivateCharacter());
    }

    IEnumerator ReactivateCharacter() {
        yield return Character.freezeTime;
        
        character.gameObject.SetActive(true);
    }

    private void CharacterReachedGoal() {
        confetti.transform.position = character.transform.position;
        confetti.Play();
        // StartCoroutine(NextScene());
    }

    IEnumerator NextScene() {
        yield return Describable.tooltipDelay;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
