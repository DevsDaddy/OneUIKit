# Unity OneUI Kit
![image](https://github.com/DevsDaddy/OneUIKit/assets/147835900/0cf9beef-d2d6-4093-a412-d311d09cd938)
Welcome to the **One UI Kit** for Unity! This set includes dozens of different elements, components, and graphical styles for creating your user interface in games or applications on Unity.

**Features:**
- Modern Ready-to-Use UI;
- Animations, Shader Effects, UI Particles;
- Dozens of ready-to-use components;
- Huge set of ready-to-use icons;
- Many different examples of screens and navigation;
- Optimized for Mobile;
- Ready for MVC/MVP/MVVM;

**Depedencies:**
- [Unity UI Framework](https://github.com/DevsDaddy/UIFramework) (included in project);
- TextMesh Pro for UGUI (included in project);
- [Unity Event Framework](https://github.com/DevsDaddy/UnityEventFramework) (included in project);
- Recommended 2D Sprite Package (but not required);

Installation process:
- Download and import [latest release from this page](https://github.com/DevsDaddy/OneUIKit/releases);
- Open **Demo Scene** and see how it works;

## Usage
Just [download latest release](https://github.com/DevsDaddy/OneUIKit/releases) and see our example scene with different screens, navigation and binding system, shaders and effects examples;

**Views Binding:**
```csharp
UIFramework.BindView(Instantiate(homeView), true); // Home Page
UIFramework.BindView(Instantiate(pageView));       // Sub-Page
```

**Navigate to another view:**
```csharp
EventMessenger.Main.Publish(new OnViewNavigated {
    View = typeof(DemoPageView),
    Display = new DisplayOptions { IsAnimated = true, Delay = 0f, Duration = 0.5f, Type = AnimationType.Fade },
    Data = new DemoPageView.Data {
        Title = "Demo Page",
        Content = pageContent
    }
});
```

## Ready to Use Screens and Components
**The sample interface and windows shown below are already included in the project**. For some of them it is easiest to use the **Event Framework** - an example of which is also in the Demo-scene.
![image](https://github.com/DevsDaddy/OneUIKit/assets/147835900/2d0d13db-8260-4d82-a10e-106e61b9ec29)
![image](https://github.com/DevsDaddy/OneUIKit/assets/147835900/730c665b-41a4-4e1a-bc44-2e787fedd2fd)
![image](https://github.com/DevsDaddy/OneUIKit/assets/147835900/e3517445-6bb9-4fa6-a33c-65a9eeacd16f)
![image](https://github.com/DevsDaddy/OneUIKit/assets/147835900/cb671207-4dbd-47fb-a68c-4d37fa569a5b)
![image](https://github.com/DevsDaddy/OneUIKit/assets/147835900/255ddaf2-03d8-497f-aeda-9ecaf65e494d)
![image](https://github.com/DevsDaddy/OneUIKit/assets/147835900/68253a91-d1a3-46cc-88b7-fb0837ab240b)
![image](https://github.com/DevsDaddy/OneUIKit/assets/147835900/bbe59a83-6ff3-4752-88c8-4ea7a0b1f478)
![image](https://github.com/DevsDaddy/OneUIKit/assets/147835900/8675f7f0-37c9-461a-873f-64e0032694cd)
![image](https://github.com/DevsDaddy/OneUIKit/assets/147835900/3c966941-2ece-415e-b2e7-3b9b80d31c0e)

## Join Community
- <a href="https://discord.gg/xuNTKRDebx">Discord Community</a>
- <a href="https://boosty.to/devsdaddy">Buy me a Beer (Boosty)</a>
