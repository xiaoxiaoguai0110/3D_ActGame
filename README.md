# 3D Action Game

基于 Unity 引擎开发的 3D 动作游戏项目。

## 项目简介

这是一个第三人称 3D 动作游戏，使用 Unity 的 **Input System** 包处理玩家输入，包含基本的角色移动和摄像机控制功能。

当前版本实现了：
- 第三人称角色控制（移动 + 旋转）
- 自由摄像机（鼠标控制视角）
- 基础动画系统（移动/跑步动画切换）

## 项目结构

```
Assets/
├── Scripts/              # 游戏脚本
│   ├── Player.cs         # 玩家角色控制
│   └── PlayerCamera.cs   # 第三人称摄像机
├── Anim/                 # 角色动画
│   └── PlayerAnim/
├── Prefabs/              # 预制体
├── Scenes/               # 游戏场景
├── Flooded_Grounds/      # 环境资源包
└── Knights_(Pack)/       # 角色模型资源
```

## 使用的技术

| 技术 | 用途 |
|------|------|
| Unity Input System | 处理键盘/鼠标输入 |
| Rigidbody | 基于物理的角色移动 |
| Animator | 动画状态机控制 |
| New Input System | 现代化的输入方案 |

## 控制方式

| 按键 | 功能 |
|------|------|
| WASD | 角色移动 |
| 鼠标移动 | 控制摄像机视角 |
| ESC | 释放鼠标指针 |
| 鼠标左键 | 重新锁定鼠标指针 |

## 如何运行

1. 使用 Unity 打开本项目（推荐 Unity 2021.3 LTS 或更高版本）
2. 确保已安装 **Input System** 包（Window → Package Manager）
3. 打开 `Assets/Scenes/` 下的场景文件
4. 点击 Play 运行
