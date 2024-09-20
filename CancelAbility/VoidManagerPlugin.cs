using VoidManager;
using VoidManager.MPModChecks;

namespace CancelAbility
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public override MultiplayerType MPType => MultiplayerType.Client;

        public override string Author => MyPluginInfo.PLUGIN_AUTHORS;

        public override string Description => MyPluginInfo.PLUGIN_DESCRIPTION;

        public override string ThunderstoreID => MyPluginInfo.PLUGIN_THUNDERSTORE_ID;

        internal static bool SessionFeaturesEnabled = false;

        public override SessionChangedReturn OnSessionChange(SessionChangedInput input)
        {
            if(input.IsMod_Session)
                SessionFeaturesEnabled = true;
            else
                SessionFeaturesEnabled = false;

            return new SessionChangedReturn() { SetMod_Session = true };
        }
    }
}
