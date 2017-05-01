using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace BizApp.model
{
   public class SettingsModel
    {
        [Serializable]
       public class  ProgramSettings
        {
          public  string WindowName;
          public  bool OpenToNewApplicant;
          public  bool OpenToDashboard;
        }
//=====================================================================================
        public static bool SaveSettings( ProgramSettings Setting)
        {
            try
            {
                 XmlSerializer srl = new XmlSerializer(Setting.GetType());
                var objWriter = new StreamWriter("SettingsFile.txt",false);
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

        public static void ReadSettings(ref ProgramSettings Setting)
        {
        
            try
            {
                XmlSerializer de_serializer = new XmlSerializer(Setting.GetType());

            //create a streamreader that reads from the file on disk
            StreamReader oRead = new StreamReader("SettingsFile.txt");

                //instruct serializer to deserialize an object reference form the file and cast it to the
                //appropriate reference type
                Setting = (ProgramSettings)de_serializer.Deserialize(oRead);

            oRead.Close();
               
            }
            catch (Exception)
            {

                if (!CreateNewSettingsFile())
                {
                    //failure to create a new settings file give warning
                    //TODO: Warning Message
                }
            }

        }
        
  //==============================================================================
    private static bool CreateNewSettingsFile()
        {
            try
            {
                ProgramSettings prgSetting = new ProgramSettings();
                //Add some default values
                prgSetting.OpenToDashboard = true;
                prgSetting.OpenToNewApplicant = false;
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
