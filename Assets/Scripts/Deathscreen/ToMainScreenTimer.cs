using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainScreenTimer : MonoBehaviour
{
    public float WaitingTime = 10f;
    void Start()
    {
        timer();
    }

    public IEnumerator timer()
    {
        yield return new WaitForSeconds(WaitingTime);

        SceneManager.LoadScene(0);
    }
}
