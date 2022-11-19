using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(VideoPlayer))]
public class VideoManager : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Prepare();
        videoPlayer.loopPointReached += VideoEnd;
    }

    private void VideoEnd(VideoPlayer source)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
