using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class ButtonClick : MonoBehaviour
    {
        public void StartButtonClick()
        {
            StartCoroutine(LoadAsync());
        }
        
        private IEnumerator LoadAsync()
        {
            yield return null;

            AsyncOperation Operation = SceneManager.LoadSceneAsync(1);

            Operation.allowSceneActivation = false;

            while (!Operation.isDone)
            {
                if (Operation.progress >= 0.9f)
                {
                    Operation.allowSceneActivation = true;
                }
                yield return null;
            }
        }
    }
}