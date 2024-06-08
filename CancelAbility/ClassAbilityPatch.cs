using HarmonyLib;

namespace CancelAbility
{
    [HarmonyPatch(typeof(ClassAbility))]
    internal class ClassAbilityPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("ActivationKeyPressed")]
        static void ActivationKeyPressed(ClassAbility __instance)
        {
            if (__instance is FiniteDurationClassAbility ability && ability is not ChannelGrapplingHook)
            {
                if (ability.IsOngoing())
                {
                    float refund = (1 - ability.CurrentActiveDuration / ability.FiniteTimeDuration.Value) * ability.CooldownSeconds.Value;
                    ability.StopAbility();
                    ability.RefundCooldown(refund);
                }
                else
                {
                    float cooldown = ability.CurrentCooldown;
                    ability.CurrentCooldown = 0;
                    ability.StartAbility();
                    ability.CurrentActiveDuration = (1 - cooldown / ability.CooldownSeconds.Value) * ability.FiniteTimeDuration.Value;
                }
            }
        }
    }
}
