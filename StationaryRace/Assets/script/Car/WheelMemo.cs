using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
プロパティ	                     機能

Mass	                    :ホイールの質量。

Radius	                    :ホイールの半径。

Wheel Damping Rate	        :ホイールに適用される減衰値です。

Suspension Distance	        :ホイールサスペンションの最大延長距離で、ローカル空間で測定されます。
                             サスペンションは常にローカルの Y 軸を通じて下に伸びます。

Force App Point Distance	:このパラメーターは、ホイールの力が適用される位置を定義します。
                             これは、ホイールの基準となる静止位置からメートル単位でサスペンションの進行方向に沿った期待値を設定します。
                            「forceAppPointDistance = 0」のとき、力はホイールの基準となる静止位置で適用されます。
                             一般的に車両の重心より少し下で適用します。

Center	                    :オブジェクトのローカル空間でのホイールの中心。

Suspension Spring	        :サスペンションが、スプリングと減衰力を追加して、Target Position に達しようとします。

Spring	                    :スプリング力が Target Position に到達しようとします。
                             値が大きいほど、サスペンションが Target Position に到達する速度が上がります。

Damper	                    :サスペンションの速度を減衰します。値が小さいほど Suspension Spring の速度が下がります。

Target Position	            :Suspension Distance に沿ったサスペンションの残りの距離。
                             1 は、完全に伸びきったサスペンションをマッピングし、0 は完全に縮まったサスペンションをマッピングします。
                             デフォルトは 0.5 で、通常の車両のサスペンションの動作に一致します。

Forward/Sideways Friction	:Forward/Sideways Friction ホイールが前転や横転する際のタイヤの摩擦のプロパティ。

Extremum Slip/Value	        :曲線の極値点。

Asymptote Slip/Value	    :摩擦曲線の漸近線のスリップ、およびフォース値

Stiffness	                :Extremum Value と Asymptote Value に対する乗数 (デフォルトは 1)。摩擦の剛性を変化させます。
                             これを 0 に設定すると、ホイールからのすべての摩擦が完全に無効になります。
                             通常、ランタイム時に剛性を修正して、スクリプトから各種地盤材料をシミュレートします。
 
 */