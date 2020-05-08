using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private PlayerData _playerData;

        private void Awake()
        {
            _playerData = new PlayerData();
        }

        private void Start()
        {
            StartCoroutine(Loop());
        }


        public PlayerData GetPlayerData()
        {
            return this._playerData;
        }

        private IEnumerator Loop()
        {
            yield return new WaitForSeconds(1);

            this._playerData.lucht -= 1;

            if (this._playerData.lucht < 0) PlayerDie();
            if (this._playerData.getHealth() < 0) PlayerDie();

            StartCoroutine(Loop());
        }

        public void PlayerDie()
        {
            // Load deathscreen.
            SceneManager.LoadScene(2);
        }
    }
}
