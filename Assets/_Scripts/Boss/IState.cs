using System.Collections;
using System;

public interface IState
{
    // gọi khi mới chuyển trạng thái
    void Enter();
    // mô phỏng update/ fixed update
    void Tick();
    void FixedTick();
    // gọi khi thoát khỏi trạng thái
    void Exit();
}