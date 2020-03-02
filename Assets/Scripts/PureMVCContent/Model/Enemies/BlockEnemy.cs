namespace PureMVCContent.Model.Enemies
{
    public class BlockEnemy : Enemy
    {
        public override bool IsMovable => true;
        public override bool IsOnlyOne => false;
        public override EnemyTypes EnemyType => EnemyTypes.Block;
    }
}