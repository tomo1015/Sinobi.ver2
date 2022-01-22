/*---------------------------

   汎用的な定数を定義する

-----------------------------*/

namespace Constants
{
    /// <summary>
    /// オブジェクトごとのタグ名定義
    /// </summary>
    public readonly struct ObjectTagName
    {
        public const string None            = "Untagged";
        public const string Untagged        = "Untagged";
        public const string MainCamera      = "MainCamera";
        public const string Character       = "Character";
        public const string Player          = "Player";
        public const string Tower           = "Tower";
        public const string TowerParent     = "TowerParent";
        public const string TowerManager    = "TowerManager";
        public const string Field           = "Field";
        public const string Respawn         = "Respawn";
        public const string Mushroom        = "Mushroom";
        public const string Cystal          = "Cystal";
        public const string Enemy           = "Enemy";
        public const string Ally            = "Ally";
    }

    /// <summary>
    /// Inputのハンドル名定義
    /// </summary>
    public readonly struct InputName
    {
        public const string LeftHorizontal  = "Horizontal";
        public const string LeftVertical    = "Vertical";
        public const string RightHorizontal = "RightHorizontal";
        public const string RightVertical   = "RightVertical";
        public const string Next            = "Submit";
        public const string Back            = "Cancel";
        public const string Submit          = "Submit";
        public const string Cancel          = "Cancel";
        public const string Pause           = "Pause";
        public const string Jump            = "Jump";
        public const string MouseX          = "Mouse X";
        public const string MouseY          = "Mouse Y";
    }

    public readonly struct ItweenName
    {
        public const string Rotation        = "rotation";
        public const string Time            = "time";
    }

    /// <summary>
    /// ソートレイヤー名定義
    /// </summary>
    public readonly struct SortingLayerName
    {
        public const string Back    = "Back";
        public const string Default = "Default";
        public const string Flont   = "Flont";
        public const string Fade    = "Fade";
    }

    /// <summary>
    /// シーン名
    /// </summary>
    public readonly struct SceneName
    {
        public const string Title       = "Title";
        public const string Stage       = "Stage";
        public const string Result      = "Result";
    }

    /// <summary>
    /// キャラクターステータス
    /// </summary>
    public readonly struct CharacterStatus
    {
        public const float KETTSEY_SPEED  = 60.0f;
        public const float KETTSEY_ATTACK = 25.0f;
        public const float KETTSEY_MAXHP  = 100.0f;
        public const float ELF_SPEED      = 50.0f;
        public const float ELF_ATTACK     = 15.0f;
        public const float ELF_MAXHP      = 150.0f;
    }
    /// <summary>
    /// 各種オブジェクトステータス
    /// </summary>
    public readonly struct ObjectStatus
    {
        public const float ARROW_HEIGHT = 7.0f;//矢が生成される高さ(Y座標)
    }
    /// <summary>
    /// ゲーム機能
    /// </summary>
    public readonly struct GameExecutive
    {
        public const float RESPAWN_WAIT_TIME = 5.0f;    //リスポーン待機時間
        public const float CAMERA_MOVE = 5.0f;          //カメラ移動量
        public const float LIMIT_ANGLE_UP = 60.0f;      //カメラ上方向制限値
        public const float LIMIT_ANGLE_DOWN = -60.0f;   //カメラ下方向制限値
    }
    /// <summary>
    /// タワーステータス
    /// </summary>
    public readonly struct TowerStatus
    {
        public const int LIMIT_RED        = 5000;      //赤色タワーへの境界線
        public const int LIMIT_NATURAL    = 0;         //中立タワーへの境界線
        public const int LIMIT_BLUE       = -5000;     //青色タワーの境界線
        public const int TOWER_CAPTURE    = 10;        //占領速度
        public const float CAPTURE_RANGE  = 100.0f;     //占領可能範囲
    }
}