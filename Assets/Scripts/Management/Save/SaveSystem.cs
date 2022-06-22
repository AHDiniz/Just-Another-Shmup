using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace JustAnotherShmup.Management.Save
{
    public class SaveSystem
    {
        private static BinaryFormatter _formatter = null;

        public static bool Save(string saveDataName, object saveData)
        {
            BinaryFormatter formatter = GetBinaryFormatter();

            if (!Directory.Exists(Application.persistentDataPath + "/saves"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/saves");
            }

            string path = Application.persistentDataPath + "/saves/" + saveDataName + ".save";

            FileStream file = File.Create(path);

            formatter.Serialize(file, saveData);

            file.Close();

            return true;
        }

        public static object Load(string path)
        {
            if (!File.Exists(path))
                return null;
            
            BinaryFormatter formatter = GetBinaryFormatter();

            FileStream file = File.Open(path, FileMode.Open);

            try
            {
                object save = formatter.Deserialize(file);
                file.Close();
                return save;
            }
            catch
            {
                file.Close();
                return null;
            }
        }

        private static BinaryFormatter GetBinaryFormatter()
        {
            if (_formatter == null)
                _formatter = new BinaryFormatter();
            return _formatter;
        }
    }
}