using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LogoScenario : MonoBehaviour
{
	[SerializeField]
	private	Progress	progress;
	[SerializeField]
	private	SceneNames	nextScene;
	[SerializeField]
	private TextMeshProUGUI titleText;
	[SerializeField]
	private float fadeDuration = 0.5f;

	private void Awake()
	{
		SystemSetup();

		//titleText.alpha = 0f;

		//FadeInOut();
	}

	private void SystemSetup()
	{
		// 활성화되지 않은 상태에서도 게임이 계속 진행
		Application.runInBackground = true;

		int width	= Screen.width;
		int height	= (int)(Screen.width * 16f / 9);
		Screen.SetResolution(width, height, true);

		// 화면이 꺼지지 않도록 설정
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		// 로딩 애니메이션 시작, 재생 완료시 OnAfterProgress() 메소드 실행
		progress.Play(OnAfterProgress);
	}

	private void OnAfterProgress()
	{
		Utils.LoadScene(nextScene);
	}

	public void FadeInOut()
	{
		titleText.DOFade(1f, fadeDuration).SetEase(Ease.Linear)
			.OnKill(() => {
				titleText.DOFade(0f, fadeDuration).SetEase(Ease.Linear);
			});
	}
}

