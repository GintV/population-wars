using System;
using System.IO;
using PopulationWars.Components;

namespace PopulationWars.Agents
{
    /*
     * Sample agent, demonstrating how AI's data can be stored
     * when application closes and how can it be loaded back.
     */
    public class SampleAgent : IAgent
    {
        private string m_importantStuff;
        private string m_dataPath;
        ~SampleAgent()
        {
            // Serialization goes here
            var sw = new StreamWriter(m_dataPath + "\\important.txt");
            sw.Write(m_importantStuff);
            sw.Close();
        }

        public void SetDataPath(string path)
        {
            m_dataPath = path;
        }

        public bool LoadData()
        {
            // Deserialization goes here
            if (string.IsNullOrEmpty(m_dataPath))
            {
                return false;
            }
            try
            {
                using (StreamReader sr = new StreamReader(m_dataPath + "\\important.txt"))
                {
                    m_importantStuff = sr.ReadToEnd();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Decision MakeDecision(Situation situation)
        {
            throw new NotImplementedException();
        }
    }
}
