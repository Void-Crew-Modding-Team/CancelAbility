using VoidManager.MPModChecks;

namespace CancelAbility
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public override MultiplayerType MPType => MultiplayerType.Client;

        public override string Author => "18107";

        public override string Description => "Allows abilities to be cancelled early for faster recharge";
    }
}
