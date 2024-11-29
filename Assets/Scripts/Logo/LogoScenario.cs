using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogoScenario : MonoBehaviour
{
	[SerializeField]
	private	Progress	progress;
	[SerializeField]
	private	SceneNames	nextScene;
	[SerializeField]
	private Text titleText;

	Color colorAlhpa;
	float f = 1;

	private void Awake()
	{
		SystemSetup();
	}

	private void SystemSetup()
	{
		// Ȱ��ȭ���� ���� ���¿����� ������ ��� ����
		Application.runInBackground = true;

		// �ػ� ���� (9:18.5, 1440x2960, ������ ��Ʈ 8)
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

	/*
	IEnumerator FadeOut()
    {
		while (true)
		{
			colorAlhpa.a = titleText.color.a;
			colorAlhpa.a -= Time.deltaTime;
			titleText.color = colorAlhpa;
		}
	}
	*/
}

