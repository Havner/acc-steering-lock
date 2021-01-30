# Simple SimHub plugin for setting wheel rotation based on ACC car

ACC doesn't have a soft lock option. This plugin allows to use hard
lock option with 1:1 steering ratio. The same way Content Manager does
that.

Currently it works for:
- MMOs
- all SimuCUBEs (1, 2S, 2P, 2U)
- Thrustmasters (300, 500, TGT, TMX, TSPC, TSXW, TX, F1)

## Instalation

Put the plugin in SimHub folder. Enable it in SimHub.

## Configuration of your wheel

Set whatever rotation you want, it doesn't matter, it will be changed
anyway by the plugin (you won't see the change in the Thrustmaster
panel though).

## Configuration in ACC

Set the wheel rotation to 0. This means that the car will use 100%
available steering lock. And the correct steering lock will be set by
the plugin.

## Confirmation that it works?

Check SimHub logs:

	INFO	AccSteeringLock: Init()
	INFO	AccSteeringLock: found supported wheel: Simucube 2 Pro
	INFO	AccSteeringLock: setting rotation of amr_v8_vantage_gt3 to: 640

In TrueDrive you should see "Angle set by game" below "Steering range".

# Acknowlegments

Ilja Jusupov for his code that sets the steering lock in SimuCUBE.  
https://github.com/gro-ove/actools/tree/master/AcTools.WheelAngles/Implementations

Mika Takala for pointing me this code and providing other related
samples.

<!-- Local Variables: -->
<!-- delete-trailing-whitespace-on-save: nil -->
<!-- End: -->
