# AA1_Animations_Delivery3
# Nahuel Aparicio // nahuel.aparicio@enti.cat
# David Soriano // david.soriano@enti.cat

Start / Respawn -> L
Move target (where you aim) -> WASD
Shoot -> hold space on key up -> near ball = shoot
Predict trayectory -> press i

Exercice 1

1.1 -> script "IK_tentacles" function NotifyShoot()
1.2 -> script "MovingBall" function GetDirection() el _target de la funcion es el "BlueTarget" que puedes mover con WASD
1.3 -> script "SliderController"
1.4 -> script "IK_Scorpion" input -> space NotifyStartWalk() resets position, script "MovingBall" function Respawn()
1.5 -> Para un movimiento linear la predicción sería -> posicionPredecida = posicionActual + velocidadActual * tiempoDePredicción;

Exercice 2
2.1 -> EffectSlider script & IK_Scorpion
2.2 -> MovingBall line 70 -> func GetRotation()
2.3 -> Not working trajectory
2.4 -> Not working
2.5 -> Rotation Velocity =  Vector3.Cross(transform.position, targetPostion - yourPosition) * (targetPosition - yourPosition).magnitude * Mathf.Rad2Deg;
2.6 -> Magnus = (drag * density * crossSection * (velocidad en el plano XZ ^2)) / 2

Exercice 3

3.1 -> script "IK_Scorpion", Update en Raycast
3.2 -> Escalones en medio del terrain
3.3 -> Not done
3.4 -> script "IK_Scorpion", Update en if del Raycast
3.5 -> Not done
3.6 -> Not done

Exercice 4 (tail)
4.1 -> Not done
4.2 -> Not done
4.3 -> Not done

Exercice 4 (Octopus)
4.1 -> MyOctopusController.dll ->ClampRotation()
4.2 -> MyOctopusController.dll -> Lerp line 181 inside update_ccd
4.3 -> MyOctopusController.dll -> ClampRotation(Q q, Q q)