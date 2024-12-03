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
		// Ȱ��ȭ���� ���� ���¿����� ������ ��� ����
		Application.runInBackground = true;

		int width	= Screen.width;
		int height	= (int)(Screen.width * 16f / 9);
		Screen.SetResolution(width, height, true);

		// ȭ���� ������ �ʵ��� ����
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		// �ε� �ִϸ��̼� ����, ��� �Ϸ�� OnAfterProgress() �޼ҵ� ����
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

