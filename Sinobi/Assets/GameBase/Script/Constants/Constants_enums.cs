/*------------------------------------

 全公開宣言する列挙型はここに定義する。

--------------------------------------*/

namespace Constants
{
    /// <summary>
    /// キャラクター種類
    /// </summary>
    public enum CHARA_TYPE
    {
        Kettsey,
        Elf
    }
    /// <summary>
    /// チームカラー
    /// </summary>
    public enum TEAM_COLOR
    {
        BLUE,
        RED,
        NATURAL
    }
    /// <summary>
    /// AI状態遷移
    /// </summary>
    public enum AI_STATUS
    {
        NONE,            //何もしない
        TOWERMOVING,     //タワーへ移動中
        ENEMYMOVING,     //敵へ移動中
        ATTACK,          //攻撃中
        CAPTURE,         //占領中
        SEARCH           //探索中
    }

    public enum ANIMATION_ID
    {
        IDLE = 0,   //待機モーション
        WALK,       //歩きモーション
        ATTACK,     //攻撃モーション
        DUSH,       //ダッシュモーション
    }

}