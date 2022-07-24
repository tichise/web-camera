using UnityEngine;
using UnityEngine.UI;

public class WebCamera : MonoBehaviour
{
    int width = 1920;
    int height = 1080;

    private static int FPS = 60;

    public int selectCameraIndex;

    // UI
    RawImage rawImage;
    WebCamTexture webCamTexture;

	WebCamDevice[] webCamDevices;

	// スタート時に呼ばれる
	void Start () 
    {
        // カメラの取得
        webCamDevices = WebCamTexture.devices;

        // Webカメラの開始
        this.rawImage = GetComponent<RawImage>();
        this.webCamTexture = new WebCamTexture(webCamDevices[selectCamera].name,
            width, height, FPS);
        this.rawImage.texture = this.webCamTexture;
        this.webCamTexture.Play();
    }

    // カメラの選択
    int selectCamera = 0;

    // カメラの変更
    public void ChangeCamera()
    {
        // カメラの取得
        webCamDevices = WebCamTexture.devices;

        // カメラが1個の時は無処理
        if (webCamDevices.Length <= 1) return;

        // カメラの切り替え
        selectCamera++;
        if (selectCamera >= webCamDevices.Length) selectCamera = selectCameraIndex;
        this.webCamTexture.Stop();
        this.webCamTexture = new WebCamTexture(webCamDevices[selectCamera].name,
            width, height, FPS);
        this.rawImage.texture = this.webCamTexture;
        this.webCamTexture.Play();
    }
}