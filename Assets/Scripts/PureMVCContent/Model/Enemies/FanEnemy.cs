namespace PureMVCContent.Model.Enemies
{
    public class FanEnemy : Enemy
    {
        public override bool IsMovable => false;
        public override bool IsOnlyOne => true;
        public override EnemyTypes EnemyType => EnemyTypes.Fan;
    }
}