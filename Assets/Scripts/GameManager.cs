// Game Manager


using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Character characterPrefab;
    [SerializeField] ParticleSystem confetti;
    [SerializeField] TMP_Text level;
    [SerializeField] TMP_Text pauseButtonText;

    Character character;
    bool paused = false;

    private void OnEnable() {
        character = Instantiate(characterPrefab, characterPrefab.startingPostion, Quaternion.identity);
        level.text = "Level " + SceneManager.GetActiveScene().buildIndex;

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
        yield return new WaitUntil(() => !paused);
        
        character.gameObject.SetActive(true);
    }

    private void CharacterReachedGoal() {
        confetti.transform.position = character.transform.position;
        confetti.Play();
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene() {
        yield return Describable.tooltipDelay;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void TogglePlayPause() {
        if (paused) {
            paused = false;
            pauseButtonText.text = "Pause";
        } else {
            paused = true;
            pauseButtonText.text = "Play";
        }
    }
}
