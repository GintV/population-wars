using PopulationWars.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PopulationWars.Mechanics
{
    public static class DataParser
    {
        private static string m_fullPath = AppDomain.CurrentDomain.BaseDirectory + "data\\";

        public static void Serialize(List<TrainSet> trainSets) =>
            Serialize(trainSets, m_fullPath + "trainSets.ser");

        public static void Serialize(List<Nation> nations) =>
            Serialize(nations, m_fullPath + "nations.ser");

        public static List<TrainSet> Deserialize(bool dummy = true) =>
            (List<TrainSet>)Deserialize(m_fullPath + "trainSets.ser");

        public static List<Nation> Deserialize() =>
            (List<Nation>)Deserialize(m_fullPath + "nations.ser");

        private static void Serialize(object data, string path)
        {
            var formatter = new BinaryFormatter();
            Directory.CreateDirectory(path.Substring(0, path.LastIndexOf(Path.DirectorySeparatorChar)));
            var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, data);
            stream.Close();
        }

        private static object Deserialize(string path)
        {
            if (File.Exists(path))
            {
                var formatter = new BinaryFormatter();
                object data = null;
                try
                {
                    var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                    data = formatter.Deserialize(stream);
                    stream.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                return data;
            }

            return null;
        }


    }
}
