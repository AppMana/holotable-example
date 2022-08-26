# AppMana Holotable Example Project

Use this project as a fully featured example of AppMana features in Unity.

### Getting Started

 1. Download the prerequisites.
    1. [Import](https://github.com/new/import) this repository (`https://github.com/AppMana/unity-starter`) to make a private copy. When prompted to enable Git LFS, say **Yes**. This lets you use large files in GitHub. You can also [fork](https://github.com/AppMana/unity-starter/fork) it for a public copy.
    2. Clone this repository to your computer. Not sure how to do that? Download [GitHub Desktop](https://desktop.github.com) and then [clone it there](x-github-client://openRepo/https://github.com/AppMana/unity-starter).
    3. [Download Unity](https://unity3d.com/get-unity/download). You will need to install the latest version of Unity 2021.3. Need help? [Watch this tutorial](https://www.youtube.com/watch?v=rE03nC4K_Eg).
 2. Work on your project.
    1. Open the **Game** scene in `Assets/Scenes/Game.unity`
    2. Make your changes. Look carefully at the hierarchy. Delete the sample content and re-enable the appropriate objects. The objects you need are labeled.
    3. Do you need something to happen when the player connects to your stream? Add methods to **On Player Connected** on the **Main Camera**'s **Remote Playable Configuration** component.
    4. Do you need to use inputs? You can't use anything in `Input.`, like `Input.mousePosition`. Instead, use `Pointer.current?.position.ReadValue() ?? Vector2.zero`. See [here for migration tips](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.3/manual/Migration.html).
    5. Commit and push your changes.
    6. Whenever you push your changes to your fork, your link will update automatically with a new build.
 3. Get your project live. Join our [Discord](https://discord.gg/pnr3aUrt4y) and message us to build your forked repository. You will receive a URL with your project.

### Project Requirements

 - Unity 2021.3 LTS.

### Bonus Features

 - Use the **ScreenView** and **MaterialScreen** components to easily add and edit screens to your user interface.
 - Use CineMachine to set up your cameras. The **Turntable Camera** game object in the **Space Holo Table** hierarchy is an example of an orbital control turn table.
 - Use UniRx to make your user interface reactive.
 - Use UniTask instead of coroutines for more control over your creative.

### Unsupported Features

 - You must use InputSystem (`"com.unity.inputsystem": "1.3.0"`). `Input.mousePosition` and other legacy input approaches are **not supported**. See [here for migration tips](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.3/manual/Migration.html).
 - Do not use **Screen** properties. There is no physical display when streaming.
 - You **cannot** use overlay canvases. Use **Camera Space** in your canvases.
