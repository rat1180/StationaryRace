//アイテムの定数
//constを前につけることで定数値にできる

namespace ITEMConst
{
    public static class ITEM {
        public const int ItemNull            =  -1; //何もない何もない
        public const int ERASER_RESIDDUE     = 101; //ケシカス.
        public const int BIRIBIRI_PEN        = 102; //ビリビリペン.☆
        public const int MECHANICAL_PEN_LEAD = 103; //シャーペン芯.☆
        public const int STICKY_NOTE         = 104; //付箋.☆
        public const int TAPE_BALL           = 105; //丸めたボール.
        public const int SCOTCH_TAPE         = 106; //セロハンテープ.
        public const int MAGIC_PEN           = 107; //マジックペン.
        public const int CARDBOARD           = 108; //段ボール☆
        public const int KESHIKASU_BOM       = 109; //ケシカス爆弾.
        public const int BLACKBOARD_ERASER   = 110; //黒板けし.
        public const int INDIA_INK           = 111; //墨汁.
        public const int ORIGAMI_CRANE       = 112; //鶴の折り紙.☆

        //newアイテム
        public const int CARDBOARD_WALL      = 113; //段ボールの壁

        //順位によってのアイテム数値の最大値・最小値
        public const int ItemMin = 109; //最小の値
        public const int ItemMax = 110; //最大の値（最大の値に+1して範囲に入れる）
        //public const int ItemMin = 110; //最小の値
        //public const int ItemMax = 111; //最大の値（最大の値に+1して範囲に入れる）
        public const int UpperMin  = 101; //上位のアイテム最小値
        public const int UpperMax  = 107; //上位のアイテム最大値
        public const int MediumMin = 103; //中位のアイテム最小値
        public const int MediumMax = 111; //中位のアイテム最大値
        public const int LowerMin  = 111; //下位のアイテム最小値
        public const int LowerMax  = 113; //下位のアイテム最大値
    }
}