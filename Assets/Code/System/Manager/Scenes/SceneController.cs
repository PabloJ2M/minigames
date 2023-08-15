using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace UnityEngine.SceneManagement
{
    [AddComponentMenu("System/SceneManagement/SceneController")]
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private GameObject _fade;
        [SerializeField] private UnityEvent<bool> _loading;

        public static SceneController Instance;
        private List<string> _scenes = new();
        private bool _lock;

        private void Awake() => Instance = this;

        public void CutScene(string value) => SceneManager.LoadScene(value);
        public void SwipeScene(string value) => OnFading(value);
        public void Quit() => OnFading(string.Empty);

        public IEnumerator AddScene(string value)
        {
            if (_scenes.Contains(value)) yield break;
            _loading.Invoke(true);

            yield return SceneManager.LoadSceneAsync(value, LoadSceneMode.Additive);
            _loading.Invoke(false);
            _scenes.Add(value);
        }
        public void RemoveScene(string value)
        {
            if (!_scenes.Contains(value)) return;
            SceneManager.UnloadSceneAsync(value, UnloadSceneOptions.None);
            _scenes.Remove(value);
        }
        private void OnFading(string value)
        {
            if (_lock) return; else _lock = true;
            Instantiate(_fade, transform).GetComponent<FadeScene>().onFadeScene += onComplete;

            void onComplete()
            {
                if (string.IsNullOrEmpty(value)) Application.Quit();
                else SceneManager.LoadSceneAsync(value, LoadSceneMode.Single);
            }
        }
    }
}