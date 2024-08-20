public interface IVistior
{
    public void Visit(FistControllerWeapon fistControllerWeapon,float Damage); // пока буду отслеживать только оружие руки

    // в будующем можно добавить например Visit(FootControllerWeapon) и тогда мы сможем отслеживать удары ногами и воспроизводить анимацию падения
}
