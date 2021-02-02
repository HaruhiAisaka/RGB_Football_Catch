using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public GameState gameState;
    public Save save;

    void Start()
    {
        save = LoadSave();
        if (save != null)
        {
            gameState.highScore = save.highScore;
        }
    }

    public void SaveGame()
    {
        Save save = CreateSave();

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "currentSave.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, save);
        stream.Close();
    }

    public Save LoadSave()
    {
        string path = Application.persistentDataPath + "currentSave.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Save result = formatter.Deserialize(stream) as Save;
            stream.Close();
            return result;
        }
        else
        {
            return null;
        }
    }

    private Save CreateSave()
    {
        return new Save(gameState.highScore);
    }
}