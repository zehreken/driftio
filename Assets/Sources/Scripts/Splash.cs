using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace cln
{
    public class Splash : MonoBehaviour
    {
        public GameObject Logo;
        
        private void Start()
        {
            StartCoroutine(LoadMain());
            Logo.transform.localScale = Vector3.one * 0.5f;
            LeanTween.scale(Logo, Vector3.one, 0.5f);
        }

        private IEnumerator LoadMain()
        {
            yield return new WaitForSeconds(1f);
        
            SceneManager.LoadScene("Main");
        }
    }
}