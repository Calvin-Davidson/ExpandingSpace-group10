using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class ButtonClick : MonoBehaviour
    {

        public void StartButtonClick()
        {
            SceneManager.LoadScene(1);
        }
    }
}