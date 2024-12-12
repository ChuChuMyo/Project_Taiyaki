using UnityEngine.SceneManagement;

public enum SceneNames { Logo=0, Lobby, InGame, }

public enum GameState { End, Playing, Pause,  }

public enum Ingredient { Bun = 0, Lettuce, Tomato, Cheese, Patty, }
public static class Utils
{
	public static string GetActiveScene()
	{
		return SceneManager.GetActiveScene().name;
	}

	public static void LoadScene(string sceneName="")
	{
		if ( sceneName == "" )
		{
			SceneManager.LoadScene(GetActiveScene());
		}
		else
		{
			SceneManager.LoadScene(sceneName);
		}
	}

	public static void LoadScene(SceneNames sceneName)
	{
		// SceneNames ���������� �Ű������� �޾ƿ� ��� ToString() ó��
		SceneManager.LoadScene(sceneName.ToString());
	}
}

