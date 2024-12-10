using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    public string targetSceneName = "Boss"; // Tên Scene bạn muốn chuyển đến
    private bool isPlayerInside = false;   // Xác định xem nhân vật đã vào vùng hay chưa
    private float teleportDelay = 3f;      // Thời gian đợi để chuyển Scene
    private float timer = 0f;              // Bộ đếm thời gian

    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra nếu vật thể đi vào là nhân vật (Player)
        if (other.CompareTag("Player")) // Đảm bảo nhân vật được gắn Tag "Player"
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Khi nhân vật rời khỏi vùng, reset timer
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            timer = 0f;
        }
    }

    private void Update()
    {
        if (isPlayerInside)
        {
            timer += Time.deltaTime; // Đếm thời gian
            if (timer >= teleportDelay)
            {
                SceneManager.LoadScene(targetSceneName); // Chuyển Scene sau 3 giây
            }
        }
    }
}

