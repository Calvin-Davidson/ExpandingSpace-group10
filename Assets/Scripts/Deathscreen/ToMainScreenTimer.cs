using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Deathscreen
{
    public class ToMainScreenTimer : MonoBehaviour
    {
        public float WaitingTime = 10f;

        void Start()
        {
            StartCoroutine(timer());
        }

        public IEnumerator timer()
        {
            yield return new WaitForSeconds(WaitingTime);

            SceneManager.LoadScene(0);
        }
    }
}