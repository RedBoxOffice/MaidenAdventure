using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.TextCore.Text;

public class SavePointPlayer : MonoBehaviour
{
    [SerializeField] private DirectionHero _hero;

    private string _filePath;

    private void Awake()
    {
        _filePath = Application.persistentDataPath + "/save.gamesave";
    }
    
    public void SaveGame()
    {       
        BinaryFormatter binaryFormatter = new BinaryFormatter();       
        FileStream fileStream = new FileStream(_filePath, FileMode.Create);    
        Save save = new Save();    
        save.SaveCharacter(_hero);                
        binaryFormatter.Serialize(fileStream, save);      
        fileStream.Close();
    }

    public void LoadGame()
    {       
        if (!File.Exists(_filePath))
            return;        
        
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(_filePath, FileMode.Open);
        Save save = (Save)binaryFormatter.Deserialize(fileStream);       
        fileStream.Close(); 
        _hero.GetComponent<DirectionHero>().LoadData(save.Hero);       
    }
}

[System.Serializable]
public class Save
{
    [System.Serializable]
    public struct SaveVector
    {
        public float x, y, z;

        public SaveVector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    [System.Serializable]
    public struct CharacterSaveData
    {
        public SaveVector Position;

        public CharacterSaveData(SaveVector position)
        {
            Position = position;          
        }
    }    

    public CharacterSaveData Hero = new CharacterSaveData();    

    public void SaveCharacter(DirectionHero character)
    {
        var vectorDirection = character.GetComponent<DirectionHero>();
        SaveVector position = new SaveVector(character.transform.position.x, character.transform.position.y, character.transform.position.z);       
        Hero = new CharacterSaveData(position);      
    }   
}
