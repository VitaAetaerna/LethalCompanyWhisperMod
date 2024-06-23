using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Whispering
{
    [BepInPlugin(_modGUID, _modName, _modVersion)]
    public class WhisperingBase : BaseUnityPlugin 
    {
        // Variables for Mod Display
        private const string _modGUID = "VitaAeterna.whisper";
        private const string _modName = "Whispering";
        private const string _modVersion = "1.0.0";

        // Create new Instance of Classes
        private readonly Harmony harmony = new Harmony(_modGUID);

        // Instance of this class as a variable
        private static WhisperingBase Instance;

        // Creating a Logger for Error Find and fixing
        internal ManualLogSource mls; 


        // When game starts / When dll is loaded
        void Awake()
        {
            // If Instance of class not existing create one else use old one // Singleton Class  
            if (Instance == null)
            {
                Instance = this;
            }

            // Setting Logger up
            mls = BepInEx.Logging.Logger.CreateLogSource(_modGUID);
            mls.LogInfo(" [Whispering] has awaken");


            // Patch all things into the game  / Also theres a Patch() for only patching one Class at a time
            harmony.PatchAll(typeof(WhisperingBase));
        }

    }
}
