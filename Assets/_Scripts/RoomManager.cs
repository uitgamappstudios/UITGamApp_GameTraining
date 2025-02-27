using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    #region Singleton
    private static RoomManager _instance;
    public static RoomManager Instance => _instance;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    [SerializeField] private string[] roomNames;

    private PlayerController _playerController;

    private bool canSwitchRoom = false;
    private string currentRoomName = "";

    public bool CanSwitchRoom => canSwitchRoom;

    private void Start()
    {
        SetUp();
    }

    private void SetUp()
    {
        // Tìm player trên scene hiện tại
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            _playerController = playerObj.GetComponent<PlayerController>();
        }

        CheckSwitchRoom();
    }

    public void CheckSwitchRoom()
    {
        if (!_playerController.EnemiesCleared)
        {
            // Nếu player chưa clear hết enemy => chưa thể qua room mới
            canSwitchRoom = false ;
        } 
        else
        {
            canSwitchRoom = true;
        }    
    }

    public void SwitchRoom()
    {
        if (canSwitchRoom)
        {
            string randomRoom = "";

            do
            {
                randomRoom = roomNames[Random.Range(0, roomNames.Length)];
            }
            while (currentRoomName == randomRoom);

            currentRoomName = randomRoom;

            Debug.Log($"Switch to {currentRoomName}");
            SceneManager.LoadScene(currentRoomName);
        }
    }    
}
