using UnityEngine;
using System.Collections;

public partial class CEnemy : MonoBehaviour
{
    public enum StartPosition
    {
        TL, T1, T2, T3, T4, T5, T6, T7, TR, L1, L2, L3, L4, L5, R1, R2, R3, R4, R5, W1, W2, W3, W4, W5, W6, W7, W8, Wa1, Wa2, Wa3, Wa4, Wa5, Wa6, Br1, Br2, Br3, Br4, Br5, Br6, Br7
    }

    public static Vector3 GetStartPosition(StartPosition start_position)
    {
        switch (start_position)
        {
            case StartPosition.TL:
                return new Vector3(-600f, 640f, 0f);
            case StartPosition.T1:
                return new Vector3(-450f, 640f, 0f);
            case StartPosition.T2:
                return new Vector3(-300f, 640f, 0f);
            case StartPosition.T3:
                return new Vector3(-150f, 640f, 0f);
            case StartPosition.T4:
                return new Vector3(-0f, 640f, 0f);
            case StartPosition.T5:
                return new Vector3(150f, 640f, 0f);
            case StartPosition.T6:
                return new Vector3(300f, 640f, 0f);
            case StartPosition.T7:
                return new Vector3(450f, 640f, 0f);
            case StartPosition.TR:
                return new Vector3(600f, 640f, 0f);
            case StartPosition.L1:
                return new Vector3(-600f, 480f, 0f);
            case StartPosition.L2:
                return new Vector3(-600f, 320f, 0f);
            case StartPosition.L3:
                return new Vector3(-600f, 160f, 0f);
            case StartPosition.L4:
                return new Vector3(-600f, 0f, 0f);
            case StartPosition.L5:
                return new Vector3(-600f, -160f, 0f);
            case StartPosition.R1:
                return new Vector3(600f, 480f, 0f);
            case StartPosition.R2:
                return new Vector3(600f, 320f, 0f);
            case StartPosition.R3:
                return new Vector3(600f, 160f, 0f);
            case StartPosition.R4:
                return new Vector3(600f, 0f, 0f);
            case StartPosition.R5:
                return new Vector3(600f, -160f, 0f);
            case StartPosition.W1:
                return new Vector3(-529f, 640f, 0f);
            case StartPosition.W2:
                return new Vector3(-378f, 640f, 0f);
            case StartPosition.W3:
                return new Vector3(-227f, 640f, 0f);
            case StartPosition.W4:
                return new Vector3(-76f, 640f, 0f);
            case StartPosition.W5:
                return new Vector3(76f, 640f, 0f);
            case StartPosition.W6:
                return new Vector3(227f, 640f, 0f);
            case StartPosition.W7:
                return new Vector3(378f, 640f, 0f);
            case StartPosition.W8:
                return new Vector3(529f, 640f, 0f);
            case StartPosition.Wa1:
                return new Vector3(-508f, 640f, 0f);
            case StartPosition.Wa2:
                return new Vector3(-305f, 640f, 0f);
            case StartPosition.Wa3:
                return new Vector3(-102f, 640f, 0f);
            case StartPosition.Wa4:
                return new Vector3(102f, 640f, 0f);
            case StartPosition.Wa5:
                return new Vector3(305f, 640f, 0f);
            case StartPosition.Wa6:
                return new Vector3(508f, 640f, 0f);
            case StartPosition.Br1:
                return new Vector3(-425f, 640f, 0f);
            case StartPosition.Br2:
                return new Vector3(-255f, 640f, 0f);
            case StartPosition.Br3:
                return new Vector3(-85f, 640f, 0f);
            case StartPosition.Br4:
                return new Vector3(0f, 640f, 0f);
            case StartPosition.Br5:
                return new Vector3(85f, 640f, 0f);
            case StartPosition.Br6:
                return new Vector3(255f, 640f, 0f);
            case StartPosition.Br7:
                return new Vector3(425f, 640f, 0f);

            default:
                return Vector3.zero;
        }
    }

    Vector3[] path_NO_1_L = {
		new Vector3(0f, 0f, 0f),
		new Vector3(0f, -530f, 0f),
		new Vector3(326f, -921.443f, 0f)
	};

    Vector3[] path_NO_1_R = {
		new Vector3(0f, 0f, 0f),
		new Vector3(0f, -530f, 0f),
		new Vector3(-326f, -921.443f, 0f)
	};

    Vector3[] path_NO_2_L = {
		new Vector3(0f, 0f, 0f),
		new Vector3(300f, 0f, 0f),
		new Vector3(406.066f, 43.934f, 0f),
		new Vector3(450f, 150f, 0f),
		new Vector3(406.066f, 256.066f, 0f),
		new Vector3(300f, 300f, 0f),
		new Vector3(193.934f, 256.066f, 0f),
		new Vector3(150f, 150f, 0f),
		new Vector3(193.934f, 43.934f, 0f),
		new Vector3(300f, 1.14441e-005f, 0f),
		new Vector3(800f, 1.14441e-005f, 0f)
	};

    Vector3[] path_NO_2_R = {
		new Vector3(0f, 0f, 0f),
		new Vector3(-300f, -2.62268e-005f, 0f),
		new Vector3(-406.066f, 43.934f, 0f),
		new Vector3(-450f, 150f, 0f),
		new Vector3(-406.066f, 256.066f, 0f),
		new Vector3(-300f, 300f, 0f),
		new Vector3(-193.934f, 256.066f, 0f),
		new Vector3(-150f, 150f, 0f),
		new Vector3(-193.934f, 43.934f, 0f),
		new Vector3(-300f, -7.62939e-006f, 0f),
		new Vector3(-800f, -5.13408e-005f, 0f)
	};

    Vector3[] path_RE = {
		new Vector3(0f, 0f, 0f),
		new Vector3(0f, -130f, 0f),
	};
}