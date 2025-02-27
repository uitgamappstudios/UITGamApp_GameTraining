public class MultiShotSkill : BaseSkill
{
    // Gọi hàm khởi tạo của lớp cha với tên "MultiShot"
    public MultiShotSkill() : base("MultiShot") { }

    // Định nghĩa hành vi của MultiShot skill
    public override void Activate()
    {
        PlayerController player = SkillManager.Instance.Player;
        
        if (player != null )
        {
            player.Shoot();
        }    
    }
}
