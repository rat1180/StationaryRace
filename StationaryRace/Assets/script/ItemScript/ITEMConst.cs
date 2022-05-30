//アイテムの定数
//constを前につけることで定数値にできる

namespace ITEMConst
{
    public static class ITEM {
        public const int ItemNull = -1;             //何もない何もない
        public const int ERASER_RESIDDUE = 101;     //ケシカス.
        public const int KESHIKASU_BOM = 102;       //ケシカス爆弾.
        public const int BLACKBOARD_ERASER = 103;   //黒板けし.
        public const int MECHANICAL_PEN_LEAD = 104; //シャーペン芯.☆
        public const int STICKY_NOTE = 105;         //付箋.☆
        public const int TAPE_BALL = 106;           //丸めたボール.
        public const int SCOTCH_TAPE = 107;         //セロハンテープ.
        public const int MAGIC_PEN = 108;           //マジックペン.
        public const int ORIGAMI_CRANE = 109;       //鶴の折り紙.☆
        public const int BIRIBIRI_PEN = 110;        //ビリビリペン.☆
        public const int INDIA_INK = 111;           //墨汁.
        public const int CARDBOARD = 112;           //段ボール☆

        //アイテム数値の最大値・最小値
        public const int ItemMin = 101; //最小の値
        public const int ItemMax = 113; //最大の値（最大の値に+1して範囲に入れる）
    }
}