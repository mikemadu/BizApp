using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace BizApp.model
{
    class SettingsModel
    {
        [Serializable]
       public class ProgramSettings
        {
          public string WindowName;
          public  bool OpenWithPooling;
          public  bool OpenWithOngoingProject;
        }
//=====================================================================================
        public static bool SaveSettings( ProgramSettings Setting)

        {
            try
            {
               
                XmlSerializer srl = new XmlSerializer(Setting.GetType());
                var objWriter = new StreamWriter("SettingsFile.txt");
                srl.Serialize(objWriter, Setting);
                objWriter.Close();
                return true;

            }
            catch (Exception)
            {
                
                return false;

            }

        }

//=======================================================================================
/*
        public static ProgramSettings ReadSettings(ProgramSettings Setting)
        {
            try
            {
                XmlSerializer de_serializer = new XmlSerializer(Setting.GetType());

            //create a streamreader that reads from the file on disk
            StreamReader oRead = new StreamReader("SettingsFile.txt");

                //instruct serializer to deserialize an objectreference form the file and cast it to the
                //appropriate reference type
                ProgramSettings Setting = (ProgramSettings)de_serializer.Deserialize(oRead);

            oRead.Close();
            }
            catch (Exception)
            {

                CreateNewSettingsFile();
            }

        }
        */
  //==============================================================================
    private bool CreateNewSettingsFile()
    {
           
            try
            { ProgramSettings prgSetting = new ProgramSettings();
            //Add some default values
            prgSetting.OpenWithOngoingProject = true;
            prgSetting.OpenWithPooling = false;
            //save it
            SaveSettings(prgSetting);
            return true;

            }
            catch (Exception)
            {
                return false;
            }
    }
       
    }
  
}
