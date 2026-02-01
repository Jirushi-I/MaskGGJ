using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MaskTransition : MonoBehaviour {

    [SerializeField] private Image transitionImage;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private AnimationCurve fadeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private Coroutine currentTransition;

    void Start() {
        //Set transparant on the start
        if (transitionImage != null) {
            Color c = transitionImage.color;
            c.a = 0f;
            transitionImage.color = c;
        }
    }

    // Transition pour mettre le masque (fade to black puis callback)
    public void TransitionToMask(System.Action onTransitionMiddle) {
        if (currentTransition != null)
            StopCoroutine(currentTransition);

        currentTransition = StartCoroutine(FadeTransition(true, onTransitionMiddle));
    }


    /// Transition pour enlever le masque (fade to black puis callback)
    public void TransitionFromMask(System.Action onTransitionMiddle) {
        if (currentTransition != null)
            StopCoroutine(currentTransition);

        currentTransition = StartCoroutine(FadeTransition(true, onTransitionMiddle));
    }

    // Fade In/Out avec callback au milieu (quand l'écran est noir)
    private IEnumerator FadeTransition(bool fadeToBlack, System.Action onMiddle) {
        float elapsed = 0f;
        Color color = transitionImage.color;

        // Fade TO black
        while (elapsed < fadeDuration) {
            elapsed += Time.deltaTime;
            float t = fadeCurve.Evaluate(elapsed / fadeDuration);
            color.a = fadeToBlack ? t : 1f - t;
            transitionImage.color = color;
            yield return null;
        }

        // Assurer qu'on est bien à fond noir
        color.a = 1f;
        transitionImage.color = color;

        // CALLBACK : Appliquer/retirer le masque pendant que l'écran est noir
        onMiddle?.Invoke();

        // Petite pause (optionnel)
        yield return new WaitForSeconds(0.1f);

        // Fade FROM black
        elapsed = 0f;
        while (elapsed < fadeDuration) {
            elapsed += Time.deltaTime;
            float t = fadeCurve.Evaluate(elapsed / fadeDuration);
            color.a = 1f - t;
            transitionImage.color = color;
            yield return null;
        }

        // Assurer qu'on est bien transparent
        color.a = 0f;
        transitionImage.color = color;

        currentTransition = null;
    }
}